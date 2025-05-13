namespace Azure.ResourceManager.DependencyMap
{
    public partial class AzureResourceManagerDependencyMapContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDependencyMapContext() { }
        public static Azure.ResourceManager.DependencyMap.AzureResourceManagerDependencyMapContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class DependencyMapExtensions
    {
        public static Azure.ResourceManager.DependencyMap.DiscoverySourceResource GetDiscoverySourceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DependencyMap.MapsResource GetMapsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DependencyMap.MapsResource> GetMapsResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.MapsResource>> GetMapsResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DependencyMap.MapsResourceCollection GetMapsResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DependencyMap.MapsResource> GetMapsResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DependencyMap.MapsResource> GetMapsResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiscoverySourceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.DiscoverySourceResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.DiscoverySourceResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiscoverySourceResource() { }
        public virtual Azure.ResourceManager.DependencyMap.DiscoverySourceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DependencyMap.DiscoverySourceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.DiscoverySourceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mapName, string sourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DependencyMap.DiscoverySourceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.DiscoverySourceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DependencyMap.DiscoverySourceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.DiscoverySourceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DependencyMap.DiscoverySourceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.DiscoverySourceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DependencyMap.DiscoverySourceResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.DiscoverySourceResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.DiscoverySourceResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.DiscoverySourceResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.DiscoverySourceResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.DiscoverySourceResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.DiscoverySourceResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DependencyMap.DiscoverySourceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DependencyMap.Models.DiscoverySourceResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DependencyMap.DiscoverySourceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DependencyMap.Models.DiscoverySourceResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiscoverySourceResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DependencyMap.DiscoverySourceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DependencyMap.DiscoverySourceResource>, System.Collections.IEnumerable
    {
        protected DiscoverySourceResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DependencyMap.DiscoverySourceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sourceName, Azure.ResourceManager.DependencyMap.DiscoverySourceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DependencyMap.DiscoverySourceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sourceName, Azure.ResourceManager.DependencyMap.DiscoverySourceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DependencyMap.DiscoverySourceResource> Get(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DependencyMap.DiscoverySourceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DependencyMap.DiscoverySourceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.DiscoverySourceResource>> GetAsync(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DependencyMap.DiscoverySourceResource> GetIfExists(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DependencyMap.DiscoverySourceResource>> GetIfExistsAsync(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DependencyMap.DiscoverySourceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DependencyMap.DiscoverySourceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DependencyMap.DiscoverySourceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DependencyMap.DiscoverySourceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiscoverySourceResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.DiscoverySourceResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.DiscoverySourceResourceData>
    {
        public DiscoverySourceResourceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DependencyMap.Models.DiscoverySourceResourceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.DiscoverySourceResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.DiscoverySourceResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.DiscoverySourceResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.DiscoverySourceResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.DiscoverySourceResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.DiscoverySourceResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.DiscoverySourceResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MapsResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.MapsResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.MapsResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MapsResource() { }
        public virtual Azure.ResourceManager.DependencyMap.MapsResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DependencyMap.MapsResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.MapsResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mapName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ExportDependencies(Azure.WaitUntil waitUntil, Azure.ResourceManager.DependencyMap.Models.ExportDependenciesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExportDependenciesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DependencyMap.Models.ExportDependenciesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DependencyMap.MapsResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.MapsResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation GetConnectionsForProcessOnFocusedMachine(Azure.WaitUntil waitUntil, Azure.ResourceManager.DependencyMap.Models.GetConnectionsForProcessOnFocusedMachineContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> GetConnectionsForProcessOnFocusedMachineAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DependencyMap.Models.GetConnectionsForProcessOnFocusedMachineContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation GetConnectionsWithConnectedMachineForFocusedMachine(Azure.WaitUntil waitUntil, Azure.ResourceManager.DependencyMap.Models.GetConnectionsWithConnectedMachineForFocusedMachineContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> GetConnectionsWithConnectedMachineForFocusedMachineAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DependencyMap.Models.GetConnectionsWithConnectedMachineForFocusedMachineContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation GetDependencyViewForFocusedMachine(Azure.WaitUntil waitUntil, Azure.ResourceManager.DependencyMap.Models.GetDependencyViewForFocusedMachineContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> GetDependencyViewForFocusedMachineAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DependencyMap.Models.GetDependencyViewForFocusedMachineContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DependencyMap.DiscoverySourceResource> GetDiscoverySourceResource(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.DiscoverySourceResource>> GetDiscoverySourceResourceAsync(string sourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DependencyMap.DiscoverySourceResourceCollection GetDiscoverySourceResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DependencyMap.MapsResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.MapsResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DependencyMap.MapsResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.MapsResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DependencyMap.MapsResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.MapsResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.MapsResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.MapsResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.MapsResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.MapsResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.MapsResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DependencyMap.MapsResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DependencyMap.Models.MapsResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DependencyMap.MapsResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DependencyMap.Models.MapsResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MapsResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DependencyMap.MapsResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DependencyMap.MapsResource>, System.Collections.IEnumerable
    {
        protected MapsResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DependencyMap.MapsResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string mapName, Azure.ResourceManager.DependencyMap.MapsResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DependencyMap.MapsResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string mapName, Azure.ResourceManager.DependencyMap.MapsResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DependencyMap.MapsResource> Get(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DependencyMap.MapsResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DependencyMap.MapsResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.MapsResource>> GetAsync(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DependencyMap.MapsResource> GetIfExists(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DependencyMap.MapsResource>> GetIfExistsAsync(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DependencyMap.MapsResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DependencyMap.MapsResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DependencyMap.MapsResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DependencyMap.MapsResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MapsResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.MapsResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.MapsResourceData>
    {
        public MapsResourceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DependencyMap.Models.ProvisioningState? MapsResourceProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.MapsResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.MapsResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.MapsResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.MapsResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.MapsResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.MapsResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.MapsResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.DependencyMap.Mocking
{
    public partial class MockableDependencyMapArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDependencyMapArmClient() { }
        public virtual Azure.ResourceManager.DependencyMap.DiscoverySourceResource GetDiscoverySourceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DependencyMap.MapsResource GetMapsResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDependencyMapResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDependencyMapResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DependencyMap.MapsResource> GetMapsResource(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DependencyMap.MapsResource>> GetMapsResourceAsync(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DependencyMap.MapsResourceCollection GetMapsResources() { throw null; }
    }
    public partial class MockableDependencyMapSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDependencyMapSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DependencyMap.MapsResource> GetMapsResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DependencyMap.MapsResource> GetMapsResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DependencyMap.Models
{
    public static partial class ArmDependencyMapModelFactory
    {
        public static Azure.ResourceManager.DependencyMap.DiscoverySourceResourceData DiscoverySourceResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DependencyMap.Models.DiscoverySourceResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DependencyMap.Models.DiscoverySourceResourceProperties DiscoverySourceResourceProperties(Azure.ResourceManager.DependencyMap.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.DependencyMap.Models.ProvisioningState?), string sourceType = null, string sourceId = null) { throw null; }
        public static Azure.ResourceManager.DependencyMap.Models.ExportDependenciesContent ExportDependenciesContent(string focusedMachineId = null, Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter filters = null) { throw null; }
        public static Azure.ResourceManager.DependencyMap.Models.GetConnectionsForProcessOnFocusedMachineContent GetConnectionsForProcessOnFocusedMachineContent(string focusedMachineId = null, string processIdOnFocusedMachine = null, Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter filters = null) { throw null; }
        public static Azure.ResourceManager.DependencyMap.Models.GetConnectionsWithConnectedMachineForFocusedMachineContent GetConnectionsWithConnectedMachineForFocusedMachineContent(string focusedMachineId = null, string connectedMachineId = null, Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter filters = null) { throw null; }
        public static Azure.ResourceManager.DependencyMap.Models.GetDependencyViewForFocusedMachineContent GetDependencyViewForFocusedMachineContent(string focusedMachineId = null, Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter filters = null) { throw null; }
        public static Azure.ResourceManager.DependencyMap.MapsResourceData MapsResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DependencyMap.Models.ProvisioningState? mapsResourceProvisioningState = default(Azure.ResourceManager.DependencyMap.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DependencyMap.Models.OffAzureDiscoverySourceResourceProperties OffAzureDiscoverySourceResourceProperties(Azure.ResourceManager.DependencyMap.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.DependencyMap.Models.ProvisioningState?), string sourceId = null) { throw null; }
    }
    public partial class DateTimeFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DateTimeFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DateTimeFilter>
    {
        public DateTimeFilter() { }
        public System.DateTimeOffset? EndDateTimeUtc { get { throw null; } set { } }
        public System.DateTimeOffset? StartDateTimeUtc { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.DateTimeFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DateTimeFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DateTimeFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.DateTimeFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DateTimeFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DateTimeFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DateTimeFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DependencyMapVisualizationFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter>
    {
        public DependencyMapVisualizationFilter() { }
        public Azure.ResourceManager.DependencyMap.Models.DateTimeFilter DateTime { get { throw null; } set { } }
        public Azure.ResourceManager.DependencyMap.Models.ProcessNameFilter ProcessNameFilter { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoverySourceResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DiscoverySourceResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DiscoverySourceResourcePatch>
    {
        public DiscoverySourceResourcePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.DiscoverySourceResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DiscoverySourceResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DiscoverySourceResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.DiscoverySourceResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DiscoverySourceResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DiscoverySourceResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DiscoverySourceResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DiscoverySourceResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DiscoverySourceResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DiscoverySourceResourceProperties>
    {
        protected DiscoverySourceResourceProperties(string sourceId) { }
        public Azure.ResourceManager.DependencyMap.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.DiscoverySourceResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DiscoverySourceResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.DiscoverySourceResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.DiscoverySourceResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DiscoverySourceResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DiscoverySourceResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.DiscoverySourceResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportDependenciesContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.ExportDependenciesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.ExportDependenciesContent>
    {
        public ExportDependenciesContent(string focusedMachineId) { }
        public Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter Filters { get { throw null; } set { } }
        public string FocusedMachineId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.ExportDependenciesContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.ExportDependenciesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.ExportDependenciesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.ExportDependenciesContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.ExportDependenciesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.ExportDependenciesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.ExportDependenciesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetConnectionsForProcessOnFocusedMachineContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.GetConnectionsForProcessOnFocusedMachineContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.GetConnectionsForProcessOnFocusedMachineContent>
    {
        public GetConnectionsForProcessOnFocusedMachineContent(string focusedMachineId, string processIdOnFocusedMachine) { }
        public Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter Filters { get { throw null; } set { } }
        public string FocusedMachineId { get { throw null; } }
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
        public GetConnectionsWithConnectedMachineForFocusedMachineContent(string focusedMachineId, string connectedMachineId) { }
        public string ConnectedMachineId { get { throw null; } }
        public Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter Filters { get { throw null; } set { } }
        public string FocusedMachineId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.GetConnectionsWithConnectedMachineForFocusedMachineContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.GetConnectionsWithConnectedMachineForFocusedMachineContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.GetConnectionsWithConnectedMachineForFocusedMachineContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.GetConnectionsWithConnectedMachineForFocusedMachineContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.GetConnectionsWithConnectedMachineForFocusedMachineContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.GetConnectionsWithConnectedMachineForFocusedMachineContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.GetConnectionsWithConnectedMachineForFocusedMachineContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetDependencyViewForFocusedMachineContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.GetDependencyViewForFocusedMachineContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.GetDependencyViewForFocusedMachineContent>
    {
        public GetDependencyViewForFocusedMachineContent(string focusedMachineId) { }
        public Azure.ResourceManager.DependencyMap.Models.DependencyMapVisualizationFilter Filters { get { throw null; } set { } }
        public string FocusedMachineId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.GetDependencyViewForFocusedMachineContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.GetDependencyViewForFocusedMachineContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.GetDependencyViewForFocusedMachineContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.GetDependencyViewForFocusedMachineContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.GetDependencyViewForFocusedMachineContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.GetDependencyViewForFocusedMachineContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.GetDependencyViewForFocusedMachineContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MapsResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.MapsResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.MapsResourcePatch>
    {
        public MapsResourcePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.MapsResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.MapsResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.MapsResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.MapsResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.MapsResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.MapsResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.MapsResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OffAzureDiscoverySourceResourceProperties : Azure.ResourceManager.DependencyMap.Models.DiscoverySourceResourceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.OffAzureDiscoverySourceResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.OffAzureDiscoverySourceResourceProperties>
    {
        public OffAzureDiscoverySourceResourceProperties(string sourceId) : base (default(string)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.OffAzureDiscoverySourceResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.OffAzureDiscoverySourceResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.OffAzureDiscoverySourceResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.OffAzureDiscoverySourceResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.OffAzureDiscoverySourceResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.OffAzureDiscoverySourceResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.OffAzureDiscoverySourceResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProcessNameFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.ProcessNameFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.ProcessNameFilter>
    {
        public ProcessNameFilter(Azure.ResourceManager.DependencyMap.Models.ProcessNameFilterOperator @operator, System.Collections.Generic.IEnumerable<string> processNames) { }
        public Azure.ResourceManager.DependencyMap.Models.ProcessNameFilterOperator Operator { get { throw null; } }
        public System.Collections.Generic.IList<string> ProcessNames { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.ProcessNameFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.ProcessNameFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DependencyMap.Models.ProcessNameFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DependencyMap.Models.ProcessNameFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.ProcessNameFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.ProcessNameFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DependencyMap.Models.ProcessNameFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProcessNameFilterOperator : System.IEquatable<Azure.ResourceManager.DependencyMap.Models.ProcessNameFilterOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProcessNameFilterOperator(string value) { throw null; }
        public static Azure.ResourceManager.DependencyMap.Models.ProcessNameFilterOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.DependencyMap.Models.ProcessNameFilterOperator NotContains { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DependencyMap.Models.ProcessNameFilterOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DependencyMap.Models.ProcessNameFilterOperator left, Azure.ResourceManager.DependencyMap.Models.ProcessNameFilterOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.DependencyMap.Models.ProcessNameFilterOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DependencyMap.Models.ProcessNameFilterOperator left, Azure.ResourceManager.DependencyMap.Models.ProcessNameFilterOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.DependencyMap.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DependencyMap.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.DependencyMap.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DependencyMap.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DependencyMap.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DependencyMap.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DependencyMap.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DependencyMap.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DependencyMap.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DependencyMap.Models.ProvisioningState left, Azure.ResourceManager.DependencyMap.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DependencyMap.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DependencyMap.Models.ProvisioningState left, Azure.ResourceManager.DependencyMap.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
