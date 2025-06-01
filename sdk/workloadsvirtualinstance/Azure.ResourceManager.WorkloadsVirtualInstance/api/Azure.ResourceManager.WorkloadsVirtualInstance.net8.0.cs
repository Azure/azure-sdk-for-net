namespace Azure.ResourceManager.WorkloadsVirtualInstance
{
    public partial class AzureResourceManagerWorkloadsVirtualInstanceContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerWorkloadsVirtualInstanceContext() { }
        public static Azure.ResourceManager.WorkloadsVirtualInstance.AzureResourceManagerWorkloadsVirtualInstanceContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class VirtualInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource>, System.Collections.IEnumerable
    {
        protected VirtualInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualInstanceName, Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualInstanceName, Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource> Get(string virtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource>> GetAsync(string virtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource> GetIfExists(string virtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource>> GetIfExistsAsync(string virtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualInstanceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceData>
    {
        public VirtualInstanceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsVirtualInstance.Models.VirtualInstanceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualInstanceResource() { }
        public virtual Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource> GetWorkloadComponent(string componentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource>> GetWorkloadComponentAsync(string componentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentCollection GetWorkloadComponents() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsVirtualInstance.Models.VirtualInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsVirtualInstance.Models.VirtualInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadComponentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource>, System.Collections.IEnumerable
    {
        protected WorkloadComponentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string componentName, Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string componentName, Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string componentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string componentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource> Get(string componentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource>> GetAsync(string componentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource> GetIfExists(string componentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource>> GetIfExistsAsync(string componentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadComponentData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentData>
    {
        public WorkloadComponentData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComponentProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadComponentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadComponentResource() { }
        public virtual Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualInstanceName, string componentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComponentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComponentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class WorkloadsVirtualInstanceExtensions
    {
        public static Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource> GetVirtualInstance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource>> GetVirtualInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource GetVirtualInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceCollection GetVirtualInstances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource> GetVirtualInstances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource> GetVirtualInstancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource GetWorkloadComponentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.WorkloadsVirtualInstance.Mocking
{
    public partial class MockableWorkloadsVirtualInstanceArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableWorkloadsVirtualInstanceArmClient() { }
        public virtual Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource GetVirtualInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentResource GetWorkloadComponentResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableWorkloadsVirtualInstanceResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableWorkloadsVirtualInstanceResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource> GetVirtualInstance(string virtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource>> GetVirtualInstanceAsync(string virtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceCollection GetVirtualInstances() { throw null; }
    }
    public partial class MockableWorkloadsVirtualInstanceSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableWorkloadsVirtualInstanceSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource> GetVirtualInstances(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceResource> GetVirtualInstancesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.WorkloadsVirtualInstance.Models
{
    public static partial class ArmWorkloadsVirtualInstanceModelFactory
    {
        public static Azure.ResourceManager.WorkloadsVirtualInstance.VirtualInstanceData VirtualInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WorkloadsVirtualInstance.Models.VirtualInstanceProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsVirtualInstance.Models.VirtualInstanceProperties VirtualInstanceProperties(Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadInfo workloadInfo = null, Azure.ResourceManager.WorkloadsVirtualInstance.Models.EnvironmentType environmentType = default(Azure.ResourceManager.WorkloadsVirtualInstance.Models.EnvironmentType), string environmentLabel = null, int? systemPriority = default(int?), Azure.ResourceManager.WorkloadsVirtualInstance.Models.SystemLifecycleStage systemLifecycleStage = default(Azure.ResourceManager.WorkloadsVirtualInstance.Models.SystemLifecycleStage), System.Collections.Generic.IDictionary<string, string> metadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsVirtualInstance.Models.LinkedResource> linkedResources = null, Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComplianceState? complianceState = default(Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComplianceState?), Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceProvisioningState?), Azure.ResponseError errors = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsVirtualInstance.WorkloadComponentData WorkloadComponentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComponentProperties properties = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComponentProperties WorkloadComponentProperties(string componentType = null, string componentRole = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceConfiguration> resources = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComplianceState? complianceState = default(Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComplianceState?), Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceProvisioningState?), Azure.ResponseError errors = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnvironmentType : System.IEquatable<Azure.ResourceManager.WorkloadsVirtualInstance.Models.EnvironmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnvironmentType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsVirtualInstance.Models.EnvironmentType NonProduction { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsVirtualInstance.Models.EnvironmentType Production { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsVirtualInstance.Models.EnvironmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsVirtualInstance.Models.EnvironmentType left, Azure.ResourceManager.WorkloadsVirtualInstance.Models.EnvironmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsVirtualInstance.Models.EnvironmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsVirtualInstance.Models.EnvironmentType left, Azure.ResourceManager.WorkloadsVirtualInstance.Models.EnvironmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinkedResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.LinkedResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.LinkedResource>
    {
        public LinkedResource(Azure.Core.ResourceIdentifier resourceId, Azure.ResourceManager.WorkloadsVirtualInstance.Models.LinkType linkType) { }
        public Azure.ResourceManager.WorkloadsVirtualInstance.Models.LinkType LinkType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsVirtualInstance.Models.LinkedResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.LinkedResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.LinkedResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsVirtualInstance.Models.LinkedResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.LinkedResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.LinkedResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.LinkedResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkType : System.IEquatable<Azure.ResourceManager.WorkloadsVirtualInstance.Models.LinkType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsVirtualInstance.Models.LinkType Dependency { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsVirtualInstance.Models.LinkType DisasterRecovery { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsVirtualInstance.Models.LinkType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsVirtualInstance.Models.LinkType left, Azure.ResourceManager.WorkloadsVirtualInstance.Models.LinkType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsVirtualInstance.Models.LinkType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsVirtualInstance.Models.LinkType left, Azure.ResourceManager.WorkloadsVirtualInstance.Models.LinkType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceConfiguration>
    {
        public ResourceConfiguration(Azure.Core.ResourceIdentifier resourceId) { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceProvisioningState left, Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceProvisioningState left, Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SystemLifecycleStage : System.IEquatable<Azure.ResourceManager.WorkloadsVirtualInstance.Models.SystemLifecycleStage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SystemLifecycleStage(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsVirtualInstance.Models.SystemLifecycleStage Active { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsVirtualInstance.Models.SystemLifecycleStage InActive { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsVirtualInstance.Models.SystemLifecycleStage InBuild { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsVirtualInstance.Models.SystemLifecycleStage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsVirtualInstance.Models.SystemLifecycleStage left, Azure.ResourceManager.WorkloadsVirtualInstance.Models.SystemLifecycleStage right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsVirtualInstance.Models.SystemLifecycleStage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsVirtualInstance.Models.SystemLifecycleStage left, Azure.ResourceManager.WorkloadsVirtualInstance.Models.SystemLifecycleStage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateVirtualInstanceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.UpdateVirtualInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.UpdateVirtualInstanceProperties>
    {
        public UpdateVirtualInstanceProperties() { }
        public string EnvironmentLabel { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsVirtualInstance.Models.EnvironmentType? EnvironmentType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadsVirtualInstance.Models.LinkedResource> LinkedResources { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public Azure.ResourceManager.WorkloadsVirtualInstance.Models.SystemLifecycleStage? SystemLifecycleStage { get { throw null; } set { } }
        public int? SystemPriority { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadInfo WorkloadInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsVirtualInstance.Models.UpdateVirtualInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.UpdateVirtualInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.UpdateVirtualInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsVirtualInstance.Models.UpdateVirtualInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.UpdateVirtualInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.UpdateVirtualInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.UpdateVirtualInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateWorkloadComponentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.UpdateWorkloadComponentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.UpdateWorkloadComponentProperties>
    {
        public UpdateWorkloadComponentProperties() { }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceConfiguration> Resources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsVirtualInstance.Models.UpdateWorkloadComponentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.UpdateWorkloadComponentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.UpdateWorkloadComponentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsVirtualInstance.Models.UpdateWorkloadComponentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.UpdateWorkloadComponentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.UpdateWorkloadComponentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.UpdateWorkloadComponentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.VirtualInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.VirtualInstancePatch>
    {
        public VirtualInstancePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsVirtualInstance.Models.UpdateVirtualInstanceProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsVirtualInstance.Models.VirtualInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.VirtualInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.VirtualInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsVirtualInstance.Models.VirtualInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.VirtualInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.VirtualInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.VirtualInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualInstanceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.VirtualInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.VirtualInstanceProperties>
    {
        public VirtualInstanceProperties(Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadInfo workloadInfo, Azure.ResourceManager.WorkloadsVirtualInstance.Models.EnvironmentType environmentType, Azure.ResourceManager.WorkloadsVirtualInstance.Models.SystemLifecycleStage systemLifecycleStage) { }
        public Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComplianceState? ComplianceState { get { throw null; } }
        public string EnvironmentLabel { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsVirtualInstance.Models.EnvironmentType EnvironmentType { get { throw null; } set { } }
        public Azure.ResponseError Errors { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadsVirtualInstance.Models.LinkedResource> LinkedResources { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.WorkloadsVirtualInstance.Models.SystemLifecycleStage SystemLifecycleStage { get { throw null; } set { } }
        public int? SystemPriority { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadInfo WorkloadInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsVirtualInstance.Models.VirtualInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.VirtualInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.VirtualInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsVirtualInstance.Models.VirtualInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.VirtualInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.VirtualInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.VirtualInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadComplianceState : System.IEquatable<Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComplianceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadComplianceState(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComplianceState Compliant { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComplianceState NonCompliant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComplianceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComplianceState left, Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComplianceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComplianceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComplianceState left, Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComplianceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkloadComponentPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComponentPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComponentPatch>
    {
        public WorkloadComponentPatch() { }
        public Azure.ResourceManager.WorkloadsVirtualInstance.Models.UpdateWorkloadComponentProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComponentPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComponentPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComponentPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComponentPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComponentPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComponentPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComponentPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadComponentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComponentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComponentProperties>
    {
        public WorkloadComponentProperties(string componentType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceConfiguration> resources) { }
        public Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComplianceState? ComplianceState { get { throw null; } }
        public string ComponentRole { get { throw null; } set { } }
        public string ComponentType { get { throw null; } set { } }
        public Azure.ResponseError Errors { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadsVirtualInstance.Models.ResourceConfiguration> Resources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComponentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComponentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComponentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComponentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComponentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComponentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadComponentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadInfo>
    {
        public WorkloadInfo(string workloadType, string workloadDefinitionName) { }
        public string WorkloadDefinitionName { get { throw null; } set { } }
        public string WorkloadDefinitionVersion { get { throw null; } set { } }
        public string WorkloadType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsVirtualInstance.Models.WorkloadInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
