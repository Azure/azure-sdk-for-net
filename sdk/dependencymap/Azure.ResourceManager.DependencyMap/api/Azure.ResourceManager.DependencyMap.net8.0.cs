namespace Azure.ResourceManager.DependencyMap
{
    public partial class AzureResourceManagerDependencyMapContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDependencyMapContext() { }
        public static Azure.ResourceManager.DependencyMap.AzureResourceManagerDependencyMapContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DependencyMapCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DependencyMap.DependencyMapResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DependencyMap.DependencyMapResource>, System.Collections.IEnumerable
    {
        protected DependencyMapCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DependencyMap.DependencyMapResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string mapName, Azure.ResourceManager.DependencyMap.DependencyMapData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DependencyMap.DependencyMapResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string mapName, Azure.ResourceManager.DependencyMap.DependencyMapData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapResource> Get(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DependencyMap.DependencyMapResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DependencyMap.DependencyMapResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapResource>> GetAsync(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DependencyMap.DependencyMapResource> GetIfExists(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DependencyMap.DependencyMapResource>> GetIfExistsAsync(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DependencyMap.DependencyMapResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DependencyMap.DependencyMapResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DependencyMap.DependencyMapResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DependencyMap.DependencyMapResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DependencyMapData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.DependencyMapData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.DependencyMapData>
    {
        public DependencyMapData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DependencyMap.Models.DependencyMapProvisioningState? DependencyMapProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.DependencyMapData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.DependencyMapData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.DependencyMapData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.DependencyMapData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.DependencyMapData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.DependencyMapData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.DependencyMapData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DependencyMapDiscoverySourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource>, System.Collections.IEnumerable
    {
        protected DependencyMapDiscoverySourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sourceName, Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sourceName, Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource> Get(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource>> GetAsync(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource> GetIfExists(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource>> GetIfExistsAsync(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DependencyMapDiscoverySourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceData>
    {
        public DependencyMapDiscoverySourceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DependencyMap.Models.DependencyMapDiscoverySourceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DependencyMapDiscoverySourceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DependencyMapDiscoverySourceResource() { }
        public virtual Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mapName, string sourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DependencyMap.Models.DependencyMapDiscoverySourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DependencyMap.Models.DependencyMapDiscoverySourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DependencyMapExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapResource> GetDependencyMap(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapResource>> GetDependencyMapAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource GetDependencyMapDiscoverySourceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DependencyMap.DependencyMapResource GetDependencyMapResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DependencyMap.DependencyMapCollection GetDependencyMaps(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DependencyMap.DependencyMapResource> GetDependencyMaps(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DependencyMap.DependencyMapResource> GetDependencyMapsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DependencyMapResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.DependencyMapData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.DependencyMapData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DependencyMapResource() { }
        public virtual Azure.ResourceManager.DependencyMap.DependencyMapData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mapName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ExportDependencies(Azure.WaitUntil waitUntil, Azure.ResourceManager.DependencyMap.Models.ExportDependenciesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExportDependenciesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DependencyMap.Models.ExportDependenciesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation GetConnectionsForProcessOnFocusedMachine(Azure.WaitUntil waitUntil, Azure.ResourceManager.DependencyMap.Models.GetConnectionsForProcessOnFocusedMachineContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> GetConnectionsForProcessOnFocusedMachineAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DependencyMap.Models.GetConnectionsForProcessOnFocusedMachineContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation GetConnectionsWithConnectedMachineForFocusedMachine(Azure.WaitUntil waitUntil, Azure.ResourceManager.DependencyMap.Models.GetConnectionsWithConnectedMachineForFocusedMachineContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> GetConnectionsWithConnectedMachineForFocusedMachineAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DependencyMap.Models.GetConnectionsWithConnectedMachineForFocusedMachineContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource> GetDependencyMapDiscoverySource(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource>> GetDependencyMapDiscoverySourceAsync(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceCollection GetDependencyMapDiscoverySources() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation GetDependencyViewForFocusedMachine(Azure.WaitUntil waitUntil, Azure.ResourceManager.DependencyMap.Models.GetDependencyViewForFocusedMachineContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> GetDependencyViewForFocusedMachineAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DependencyMap.Models.GetDependencyViewForFocusedMachineContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DependencyMap.DependencyMapData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.DependencyMapData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.DependencyMapData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.DependencyMapData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.DependencyMapData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.DependencyMapData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.DependencyMapData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DependencyMap.DependencyMapResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DependencyMap.Models.DependencyMapPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DependencyMap.DependencyMapResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DependencyMap.Models.DependencyMapPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DependencyMap.Mocking
{
    public partial class MockableDependencyMapArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDependencyMapArmClient() { }
        public virtual Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceResource GetDependencyMapDiscoverySourceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DependencyMap.DependencyMapResource GetDependencyMapResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDependencyMapResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDependencyMapResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapResource> GetDependencyMap(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.DependencyMapResource>> GetDependencyMapAsync(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DependencyMap.DependencyMapCollection GetDependencyMaps() { throw null; }
    }
    public partial class MockableDependencyMapSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDependencyMapSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DependencyMap.DependencyMapResource> GetDependencyMaps(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DependencyMap.DependencyMapResource> GetDependencyMapsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DependencyMap.Models
{
    public static partial class ArmDependencyMapModelFactory
    {
        public static Azure.ResourceManager.DependencyMap.DependencyMapData DependencyMapData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DependencyMap.Models.DependencyMapProvisioningState? dependencyMapProvisioningState = default(Azure.ResourceManager.DependencyMap.Models.DependencyMapProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DependencyMap.DependencyMapDiscoverySourceData DependencyMapDiscoverySourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DependencyMap.Models.DependencyMapDiscoverySourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DependencyMap.Models.DependencyMapDiscoverySourceProperties DependencyMapDiscoverySourceProperties(Azure.ResourceManager.DependencyMap.Models.DependencyMapProvisioningState? provisioningState = default(Azure.ResourceManager.DependencyMap.Models.DependencyMapProvisioningState?), string sourceType = null, Azure.Core.ResourceIdentifier sourceId = null) { throw null; }
        public static Azure.ResourceManager.DependencyMap.Models.ExportDependenciesContent ExportDependenciesContent(Azure.Core.ResourceIdentifier focusedMachineId = null, Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter filters = null) { throw null; }
        public static Azure.ResourceManager.DependencyMap.Models.GetConnectionsForProcessOnFocusedMachineContent GetConnectionsForProcessOnFocusedMachineContent(Azure.Core.ResourceIdentifier focusedMachineId = null, string processIdOnFocusedMachine = null, Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter filters = null) { throw null; }
        public static Azure.ResourceManager.DependencyMap.Models.GetConnectionsWithConnectedMachineForFocusedMachineContent GetConnectionsWithConnectedMachineForFocusedMachineContent(Azure.Core.ResourceIdentifier focusedMachineId = null, Azure.Core.ResourceIdentifier connectedMachineId = null, Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter filters = null) { throw null; }
        public static Azure.ResourceManager.DependencyMap.Models.GetDependencyViewForFocusedMachineContent GetDependencyViewForFocusedMachineContent(Azure.Core.ResourceIdentifier focusedMachineId = null, Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter filters = null) { throw null; }
        public static Azure.ResourceManager.DependencyMap.Models.OffAzureDiscoverySourceProperties OffAzureDiscoverySourceProperties(Azure.ResourceManager.DependencyMap.Models.DependencyMapProvisioningState? provisioningState = default(Azure.ResourceManager.DependencyMap.Models.DependencyMapProvisioningState?), Azure.Core.ResourceIdentifier sourceId = null) { throw null; }
    }
    public partial class DependencyMapDateTimeFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapDateTimeFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapDateTimeFilter>
    {
        public DependencyMapDateTimeFilter() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.DependencyMapDateTimeFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapDateTimeFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapDateTimeFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.DependencyMapDateTimeFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapDateTimeFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapDateTimeFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapDateTimeFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DependencyMapDiscoverySourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapDiscoverySourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapDiscoverySourcePatch>
    {
        public DependencyMapDiscoverySourcePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.DependencyMapDiscoverySourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapDiscoverySourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapDiscoverySourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.DependencyMapDiscoverySourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapDiscoverySourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapDiscoverySourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapDiscoverySourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DependencyMapDiscoverySourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapDiscoverySourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapDiscoverySourceProperties>
    {
        protected DependencyMapDiscoverySourceProperties(Azure.Core.ResourceIdentifier sourceId) { }
        public Azure.ResourceManager.DependencyMap.Models.DependencyMapProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.DependencyMapDiscoverySourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapDiscoverySourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapDiscoverySourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.DependencyMapDiscoverySourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapDiscoverySourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapDiscoverySourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapDiscoverySourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DependencyMapPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapPatch>
    {
        public DependencyMapPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.DependencyMapPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.DependencyMapPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DependencyMapProcessNameFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapProcessNameFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapProcessNameFilter>
    {
        public DependencyMapProcessNameFilter(Azure.ResourceManager.DependencyMap.Models.DependencyMapProcessNameFilterOperator @operator, System.Collections.Generic.IEnumerable<string> processNames) { }
        public Azure.ResourceManager.DependencyMap.Models.DependencyMapProcessNameFilterOperator Operator { get { throw null; } }
        public System.Collections.Generic.IList<string> ProcessNames { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.DependencyMapProcessNameFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapProcessNameFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapProcessNameFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.DependencyMapProcessNameFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapProcessNameFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapProcessNameFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapProcessNameFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DependencyMapProcessNameFilterOperator : System.IEquatable<Azure.ResourceManager.DependencyMap.Models.DependencyMapProcessNameFilterOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DependencyMapProcessNameFilterOperator(string value) { throw null; }
        public static Azure.ResourceManager.DependencyMap.Models.DependencyMapProcessNameFilterOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.DependencyMap.Models.DependencyMapProcessNameFilterOperator NotContains { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DependencyMap.Models.DependencyMapProcessNameFilterOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DependencyMap.Models.DependencyMapProcessNameFilterOperator left, Azure.ResourceManager.DependencyMap.Models.DependencyMapProcessNameFilterOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.DependencyMap.Models.DependencyMapProcessNameFilterOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DependencyMap.Models.DependencyMapProcessNameFilterOperator left, Azure.ResourceManager.DependencyMap.Models.DependencyMapProcessNameFilterOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DependencyMapProvisioningState : System.IEquatable<Azure.ResourceManager.DependencyMap.Models.DependencyMapProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DependencyMapProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DependencyMap.Models.DependencyMapProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.DependencyMap.Models.DependencyMapProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DependencyMap.Models.DependencyMapProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DependencyMap.Models.DependencyMapProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DependencyMap.Models.DependencyMapProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DependencyMap.Models.DependencyMapProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DependencyMap.Models.DependencyMapProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DependencyMap.Models.DependencyMapProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DependencyMap.Models.DependencyMapProvisioningState left, Azure.ResourceManager.DependencyMap.Models.DependencyMapProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DependencyMap.Models.DependencyMapProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DependencyMap.Models.DependencyMapProvisioningState left, Azure.ResourceManager.DependencyMap.Models.DependencyMapProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DependencyMapVisualizationFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter>
    {
        public DependencyMapVisualizationFilter() { }
        public Azure.ResourceManager.DependencyMap.Models.DependencyMapDateTimeFilter DateTime { get { throw null; } set { } }
        public Azure.ResourceManager.DependencyMap.Models.DependencyMapProcessNameFilter ProcessNameFilter { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportDependenciesContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.ExportDependenciesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.ExportDependenciesContent>
    {
        public ExportDependenciesContent(Azure.Core.ResourceIdentifier focusedMachineId) { }
        public Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter Filters { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier FocusedMachineId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.ExportDependenciesContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.ExportDependenciesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.ExportDependenciesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.ExportDependenciesContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.ExportDependenciesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.ExportDependenciesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.ExportDependenciesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetConnectionsForProcessOnFocusedMachineContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.GetConnectionsForProcessOnFocusedMachineContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.GetConnectionsForProcessOnFocusedMachineContent>
    {
        public GetConnectionsForProcessOnFocusedMachineContent(Azure.Core.ResourceIdentifier focusedMachineId, string processIdOnFocusedMachine) { }
        public Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter Filters { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier FocusedMachineId { get { throw null; } }
        public string ProcessIdOnFocusedMachine { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.GetConnectionsForProcessOnFocusedMachineContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.GetConnectionsForProcessOnFocusedMachineContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.GetConnectionsForProcessOnFocusedMachineContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.GetConnectionsForProcessOnFocusedMachineContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.GetConnectionsForProcessOnFocusedMachineContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.GetConnectionsForProcessOnFocusedMachineContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.GetConnectionsForProcessOnFocusedMachineContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetConnectionsWithConnectedMachineForFocusedMachineContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.GetConnectionsWithConnectedMachineForFocusedMachineContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.GetConnectionsWithConnectedMachineForFocusedMachineContent>
    {
        public GetConnectionsWithConnectedMachineForFocusedMachineContent(Azure.Core.ResourceIdentifier focusedMachineId, Azure.Core.ResourceIdentifier connectedMachineId) { }
        public Azure.Core.ResourceIdentifier ConnectedMachineId { get { throw null; } }
        public Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter Filters { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier FocusedMachineId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.GetConnectionsWithConnectedMachineForFocusedMachineContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.GetConnectionsWithConnectedMachineForFocusedMachineContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.GetConnectionsWithConnectedMachineForFocusedMachineContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.GetConnectionsWithConnectedMachineForFocusedMachineContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.GetConnectionsWithConnectedMachineForFocusedMachineContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.GetConnectionsWithConnectedMachineForFocusedMachineContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.GetConnectionsWithConnectedMachineForFocusedMachineContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetDependencyViewForFocusedMachineContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.GetDependencyViewForFocusedMachineContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.GetDependencyViewForFocusedMachineContent>
    {
        public GetDependencyViewForFocusedMachineContent(Azure.Core.ResourceIdentifier focusedMachineId) { }
        public Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter Filters { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier FocusedMachineId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.GetDependencyViewForFocusedMachineContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.GetDependencyViewForFocusedMachineContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.GetDependencyViewForFocusedMachineContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.GetDependencyViewForFocusedMachineContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.GetDependencyViewForFocusedMachineContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.GetDependencyViewForFocusedMachineContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.GetDependencyViewForFocusedMachineContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OffAzureDiscoverySourceProperties : Azure.ResourceManager.DependencyMap.Models.DependencyMapDiscoverySourceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.OffAzureDiscoverySourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.OffAzureDiscoverySourceProperties>
    {
        public OffAzureDiscoverySourceProperties(Azure.Core.ResourceIdentifier sourceId) : base (default(Azure.Core.ResourceIdentifier)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.OffAzureDiscoverySourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.OffAzureDiscoverySourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.OffAzureDiscoverySourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.OffAzureDiscoverySourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.OffAzureDiscoverySourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.OffAzureDiscoverySourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.OffAzureDiscoverySourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
