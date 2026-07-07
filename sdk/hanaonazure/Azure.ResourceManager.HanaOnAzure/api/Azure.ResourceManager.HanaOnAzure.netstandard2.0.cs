namespace Azure.ResourceManager.HanaOnAzure
{
    public partial class AzureResourceManagerHanaOnAzureContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerHanaOnAzureContext() { }
        public static Azure.ResourceManager.HanaOnAzure.AzureResourceManagerHanaOnAzureContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class HanaOnAzureExtensions
    {
        public static Azure.ResourceManager.HanaOnAzure.ProviderInstanceResource GetProviderInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HanaOnAzure.SapMonitorResource> GetSapMonitor(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sapMonitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HanaOnAzure.SapMonitorResource>> GetSapMonitorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sapMonitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HanaOnAzure.SapMonitorResource GetSapMonitorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HanaOnAzure.SapMonitorCollection GetSapMonitors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HanaOnAzure.SapMonitorResource> GetSapMonitors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HanaOnAzure.SapMonitorResource> GetSapMonitorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProviderInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HanaOnAzure.ProviderInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HanaOnAzure.ProviderInstanceResource>, System.Collections.IEnumerable
    {
        protected ProviderInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HanaOnAzure.ProviderInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string providerInstanceName, Azure.ResourceManager.HanaOnAzure.ProviderInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HanaOnAzure.ProviderInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string providerInstanceName, Azure.ResourceManager.HanaOnAzure.ProviderInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HanaOnAzure.ProviderInstanceResource> Get(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HanaOnAzure.ProviderInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HanaOnAzure.ProviderInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HanaOnAzure.ProviderInstanceResource>> GetAsync(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HanaOnAzure.ProviderInstanceResource> GetIfExists(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HanaOnAzure.ProviderInstanceResource>> GetIfExistsAsync(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HanaOnAzure.ProviderInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HanaOnAzure.ProviderInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HanaOnAzure.ProviderInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HanaOnAzure.ProviderInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProviderInstanceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HanaOnAzure.ProviderInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HanaOnAzure.ProviderInstanceData>
    {
        public ProviderInstanceData() { }
        public string Metadata { get { throw null; } set { } }
        public string ProviderProperties { get { throw null; } set { } }
        public string ProviderType { get { throw null; } set { } }
        public Azure.ResourceManager.HanaOnAzure.Models.HanaProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HanaOnAzure.ProviderInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HanaOnAzure.ProviderInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HanaOnAzure.ProviderInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HanaOnAzure.ProviderInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HanaOnAzure.ProviderInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HanaOnAzure.ProviderInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HanaOnAzure.ProviderInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HanaOnAzure.ProviderInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HanaOnAzure.ProviderInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProviderInstanceResource() { }
        public virtual Azure.ResourceManager.HanaOnAzure.ProviderInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sapMonitorName, string providerInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HanaOnAzure.ProviderInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HanaOnAzure.ProviderInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HanaOnAzure.ProviderInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HanaOnAzure.ProviderInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HanaOnAzure.ProviderInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HanaOnAzure.ProviderInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HanaOnAzure.ProviderInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HanaOnAzure.ProviderInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HanaOnAzure.ProviderInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HanaOnAzure.ProviderInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HanaOnAzure.ProviderInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HanaOnAzure.ProviderInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HanaOnAzure.ProviderInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SapMonitorCollection : Azure.ResourceManager.ArmCollection
    {
        protected SapMonitorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HanaOnAzure.SapMonitorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sapMonitorName, Azure.ResourceManager.HanaOnAzure.SapMonitorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HanaOnAzure.SapMonitorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sapMonitorName, Azure.ResourceManager.HanaOnAzure.SapMonitorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sapMonitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sapMonitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HanaOnAzure.SapMonitorResource> Get(string sapMonitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HanaOnAzure.SapMonitorResource>> GetAsync(string sapMonitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HanaOnAzure.SapMonitorResource> GetIfExists(string sapMonitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HanaOnAzure.SapMonitorResource>> GetIfExistsAsync(string sapMonitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SapMonitorData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HanaOnAzure.SapMonitorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HanaOnAzure.SapMonitorData>
    {
        public SapMonitorData(Azure.Core.AzureLocation location) { }
        public bool? EnableCustomerAnalytics { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogAnalyticsWorkspaceArmId { get { throw null; } set { } }
        public System.Guid? LogAnalyticsWorkspaceId { get { throw null; } set { } }
        public string LogAnalyticsWorkspaceSharedKey { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } }
        public Azure.Core.ResourceIdentifier MonitorSubnet { get { throw null; } set { } }
        public Azure.ResourceManager.HanaOnAzure.Models.HanaProvisioningState? ProvisioningState { get { throw null; } }
        public string SapMonitorCollectorVersion { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HanaOnAzure.SapMonitorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HanaOnAzure.SapMonitorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HanaOnAzure.SapMonitorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HanaOnAzure.SapMonitorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HanaOnAzure.SapMonitorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HanaOnAzure.SapMonitorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HanaOnAzure.SapMonitorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapMonitorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HanaOnAzure.SapMonitorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HanaOnAzure.SapMonitorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SapMonitorResource() { }
        public virtual Azure.ResourceManager.HanaOnAzure.SapMonitorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HanaOnAzure.SapMonitorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HanaOnAzure.SapMonitorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sapMonitorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HanaOnAzure.SapMonitorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HanaOnAzure.SapMonitorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HanaOnAzure.ProviderInstanceResource> GetProviderInstance(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HanaOnAzure.ProviderInstanceResource>> GetProviderInstanceAsync(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HanaOnAzure.ProviderInstanceCollection GetProviderInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HanaOnAzure.SapMonitorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HanaOnAzure.SapMonitorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HanaOnAzure.SapMonitorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HanaOnAzure.SapMonitorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HanaOnAzure.SapMonitorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HanaOnAzure.SapMonitorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HanaOnAzure.SapMonitorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HanaOnAzure.SapMonitorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HanaOnAzure.SapMonitorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HanaOnAzure.SapMonitorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HanaOnAzure.SapMonitorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HanaOnAzure.SapMonitorResource> Update(Azure.ResourceManager.HanaOnAzure.Models.SapMonitorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HanaOnAzure.SapMonitorResource>> UpdateAsync(Azure.ResourceManager.HanaOnAzure.Models.SapMonitorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HanaOnAzure.Mocking
{
    public partial class MockableHanaOnAzureArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHanaOnAzureArmClient() { }
        public virtual Azure.ResourceManager.HanaOnAzure.ProviderInstanceResource GetProviderInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HanaOnAzure.SapMonitorResource GetSapMonitorResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHanaOnAzureResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHanaOnAzureResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.HanaOnAzure.SapMonitorResource> GetSapMonitor(string sapMonitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HanaOnAzure.SapMonitorResource>> GetSapMonitorAsync(string sapMonitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HanaOnAzure.SapMonitorCollection GetSapMonitors() { throw null; }
    }
    public partial class MockableHanaOnAzureSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHanaOnAzureSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.HanaOnAzure.SapMonitorResource> GetSapMonitors(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HanaOnAzure.SapMonitorResource> GetSapMonitorsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableHanaOnAzureTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHanaOnAzureTenantResource() { }
    }
}
namespace Azure.ResourceManager.HanaOnAzure.Models
{
    public static partial class ArmHanaOnAzureModelFactory
    {
        public static Azure.ResourceManager.HanaOnAzure.ProviderInstanceData ProviderInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string providerType = null, string providerProperties = null, string metadata = null, Azure.ResourceManager.HanaOnAzure.Models.HanaProvisioningState? provisioningState = default(Azure.ResourceManager.HanaOnAzure.Models.HanaProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HanaOnAzure.SapMonitorData SapMonitorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HanaOnAzure.Models.HanaProvisioningState? provisioningState = default(Azure.ResourceManager.HanaOnAzure.Models.HanaProvisioningState?), string managedResourceGroupName = null, Azure.Core.ResourceIdentifier logAnalyticsWorkspaceArmId = null, bool? enableCustomerAnalytics = default(bool?), System.Guid? logAnalyticsWorkspaceId = default(System.Guid?), string logAnalyticsWorkspaceSharedKey = null, string sapMonitorCollectorVersion = null, Azure.Core.ResourceIdentifier monitorSubnet = null) { throw null; }
        public static Azure.ResourceManager.HanaOnAzure.Models.SapMonitorPatch SapMonitorPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HanaProvisioningState : System.IEquatable<Azure.ResourceManager.HanaOnAzure.Models.HanaProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HanaProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HanaOnAzure.Models.HanaProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.HanaOnAzure.Models.HanaProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.HanaOnAzure.Models.HanaProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HanaOnAzure.Models.HanaProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HanaOnAzure.Models.HanaProvisioningState Migrating { get { throw null; } }
        public static Azure.ResourceManager.HanaOnAzure.Models.HanaProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.HanaOnAzure.Models.HanaProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HanaOnAzure.Models.HanaProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HanaOnAzure.Models.HanaProvisioningState left, Azure.ResourceManager.HanaOnAzure.Models.HanaProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HanaOnAzure.Models.HanaProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HanaOnAzure.Models.HanaProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HanaOnAzure.Models.HanaProvisioningState left, Azure.ResourceManager.HanaOnAzure.Models.HanaProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapMonitorPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HanaOnAzure.Models.SapMonitorPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HanaOnAzure.Models.SapMonitorPatch>
    {
        public SapMonitorPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.HanaOnAzure.Models.SapMonitorPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HanaOnAzure.Models.SapMonitorPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HanaOnAzure.Models.SapMonitorPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HanaOnAzure.Models.SapMonitorPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HanaOnAzure.Models.SapMonitorPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HanaOnAzure.Models.SapMonitorPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HanaOnAzure.Models.SapMonitorPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HanaOnAzure.Models.SapMonitorPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HanaOnAzure.Models.SapMonitorPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
