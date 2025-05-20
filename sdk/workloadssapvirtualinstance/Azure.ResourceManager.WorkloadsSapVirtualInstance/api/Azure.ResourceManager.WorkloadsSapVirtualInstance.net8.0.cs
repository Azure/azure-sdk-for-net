namespace Azure.ResourceManager.WorkloadsSapVirtualInstance
{
    public partial class AzureResourceManagerWorkloadsSapVirtualInstanceContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerWorkloadsSapVirtualInstanceContext() { }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.AzureResourceManagerWorkloadsSapVirtualInstanceContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class SapApplicationServerInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource>, System.Collections.IEnumerable
    {
        protected SapApplicationServerInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationInstanceName, Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationInstanceName, Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource> Get(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource>> GetAsync(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource> GetIfExists(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource>> GetIfExistsAsync(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapApplicationServerInstanceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceData>
    {
        public SapApplicationServerInstanceData(Azure.Core.AzureLocation location) { }
        public string DispatcherStatus { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceErrorDetail ErrorsProperties { get { throw null; } }
        public long? GatewayPort { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState? Health { get { throw null; } }
        public string Hostname { get { throw null; } }
        public long? IcmHttpPort { get { throw null; } }
        public long? IcmHttpsPort { get { throw null; } }
        public string InstanceNo { get { throw null; } }
        public System.Net.IPAddress IPAddress { get { throw null; } }
        public string KernelPatch { get { throw null; } }
        public string KernelVersion { get { throw null; } }
        public Azure.Core.ResourceIdentifier LoadBalancerDetailsId { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus? Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVmDetails> VmDetails { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapApplicationServerInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SapApplicationServerInstanceResource() { }
        public virtual Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sapVirtualInstanceName, string applicationInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult> Start(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StartSapInstanceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult>> StartAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StartSapInstanceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult> Stop(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StopSapInstanceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult>> StopAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StopSapInstanceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource> Update(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapApplicationServerInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource>> UpdateAsync(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapApplicationServerInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SapCentralServerInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource>, System.Collections.IEnumerable
    {
        protected SapCentralServerInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string centralInstanceName, Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string centralInstanceName, Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource> Get(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource>> GetAsync(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource> GetIfExists(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource>> GetIfExistsAsync(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapCentralServerInstanceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceData>
    {
        public SapCentralServerInstanceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueReplicationServerProperties EnqueueReplicationServerProperties { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueServerProperties EnqueueServerProperties { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceErrorDetail ErrorsProperties { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.GatewayServerProperties GatewayServerProperties { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState? Health { get { throw null; } }
        public string InstanceNo { get { throw null; } }
        public string KernelPatch { get { throw null; } }
        public string KernelVersion { get { throw null; } }
        public Azure.Core.ResourceIdentifier LoadBalancerDetailsId { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.MessageServerProperties MessageServerProperties { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus? Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVmDetails> VmDetails { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapCentralServerInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SapCentralServerInstanceResource() { }
        public virtual Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sapVirtualInstanceName, string centralInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult> Start(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StartSapInstanceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult>> StartAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StartSapInstanceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult> Stop(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StopSapInstanceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult>> StopAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StopSapInstanceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource> Update(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapCentralServerInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource>> UpdateAsync(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapCentralServerInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SapDatabaseInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource>, System.Collections.IEnumerable
    {
        protected SapDatabaseInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseInstanceName, Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseInstanceName, Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource> Get(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource>> GetAsync(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource> GetIfExists(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource>> GetIfExistsAsync(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapDatabaseInstanceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceData>
    {
        public SapDatabaseInstanceData(Azure.Core.AzureLocation location) { }
        public string DatabaseSid { get { throw null; } }
        public string DatabaseType { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceErrorDetail ErrorsProperties { get { throw null; } }
        public System.Net.IPAddress IPAddress { get { throw null; } }
        public Azure.Core.ResourceIdentifier LoadBalancerDetailsId { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus? Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseVmDetails> VmDetails { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapDatabaseInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SapDatabaseInstanceResource() { }
        public virtual Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sapVirtualInstanceName, string databaseInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult> Start(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StartSapInstanceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult>> StartAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StartSapInstanceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult> Stop(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StopSapInstanceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult>> StopAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StopSapInstanceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource> Update(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource>> UpdateAsync(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SapVirtualInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource>, System.Collections.IEnumerable
    {
        protected SapVirtualInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sapVirtualInstanceName, Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sapVirtualInstanceName, Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource> Get(string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource>> GetAsync(string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource> GetIfExists(string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource>> GetIfExistsAsync(string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapVirtualInstanceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceData>
    {
        public SapVirtualInstanceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapConfiguration Configuration { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapEnvironmentType? Environment { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceErrorDetail ErrorsProperties { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState? Health { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceIdentity Identity { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ManagedResourcesNetworkAccessType? ManagedResourcesNetworkAccessType { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType? SapProduct { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceState? State { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus? Status { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapVirtualInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SapVirtualInstanceResource() { }
        public virtual Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sapVirtualInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource> GetSapApplicationServerInstance(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource>> GetSapApplicationServerInstanceAsync(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceCollection GetSapApplicationServerInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource> GetSapCentralServerInstance(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource>> GetSapCentralServerInstanceAsync(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceCollection GetSapCentralServerInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource> GetSapDatabaseInstance(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource>> GetSapDatabaseInstanceAsync(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceCollection GetSapDatabaseInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult> Start(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StartSapInstanceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult>> StartAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StartSapInstanceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult> Stop(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StopSapInstanceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult>> StopAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StopSapInstanceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class WorkloadsSapVirtualInstanceExtensions
    {
        public static Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsResult> GetAvailabilityZoneDetailsSapVirtualInstance(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsResult>> GetAvailabilityZoneDetailsSapVirtualInstanceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsResult> GetDiskConfigurationsSapVirtualInstance(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsResult>> GetDiskConfigurationsSapVirtualInstanceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource GetSapApplicationServerInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource GetSapCentralServerInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource GetSapDatabaseInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedResourceSkusResult> GetSapSupportedSkuSapVirtualInstance(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSkusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedResourceSkusResult>> GetSapSupportedSkuSapVirtualInstanceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSkusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource> GetSapVirtualInstance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource>> GetSapVirtualInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource GetSapVirtualInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceCollection GetSapVirtualInstances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource> GetSapVirtualInstances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource> GetSapVirtualInstancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationResult> GetSizingRecommendationsSapVirtualInstance(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationResult>> GetSizingRecommendationsSapVirtualInstanceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.WorkloadsSapVirtualInstance.Mocking
{
    public partial class MockableWorkloadsSapVirtualInstanceArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableWorkloadsSapVirtualInstanceArmClient() { }
        public virtual Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceResource GetSapApplicationServerInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceResource GetSapCentralServerInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceResource GetSapDatabaseInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource GetSapVirtualInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableWorkloadsSapVirtualInstanceResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableWorkloadsSapVirtualInstanceResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource> GetSapVirtualInstance(string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource>> GetSapVirtualInstanceAsync(string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceCollection GetSapVirtualInstances() { throw null; }
    }
    public partial class MockableWorkloadsSapVirtualInstanceSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableWorkloadsSapVirtualInstanceSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsResult> GetAvailabilityZoneDetailsSapVirtualInstance(Azure.Core.AzureLocation location, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsResult>> GetAvailabilityZoneDetailsSapVirtualInstanceAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsResult> GetDiskConfigurationsSapVirtualInstance(Azure.Core.AzureLocation location, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsResult>> GetDiskConfigurationsSapVirtualInstanceAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedResourceSkusResult> GetSapSupportedSkuSapVirtualInstance(Azure.Core.AzureLocation location, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSkusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedResourceSkusResult>> GetSapSupportedSkuSapVirtualInstanceAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSkusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource> GetSapVirtualInstances(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceResource> GetSapVirtualInstancesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationResult> GetSizingRecommendationsSapVirtualInstance(Azure.Core.AzureLocation location, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationResult>> GetSizingRecommendationsSapVirtualInstanceAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.WorkloadsSapVirtualInstance.Models
{
    public partial class ApplicationServerConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerConfiguration>
    {
        public ApplicationServerConfiguration(Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualMachineConfiguration virtualMachineConfiguration, long instanceCount) { }
        public long InstanceCount { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationServerFullResourceNames : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerFullResourceNames>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerFullResourceNames>
    {
        public ApplicationServerFullResourceNames() { }
        public string AvailabilitySetName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.VirtualMachineResourceNames> VirtualMachines { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerFullResourceNames System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerFullResourceNames>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerFullResourceNames>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerFullResourceNames System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerFullResourceNames>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerFullResourceNames>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerFullResourceNames>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationServerVirtualMachineType : System.IEquatable<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVirtualMachineType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationServerVirtualMachineType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVirtualMachineType Active { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVirtualMachineType Standby { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVirtualMachineType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVirtualMachineType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVirtualMachineType left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVirtualMachineType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVirtualMachineType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVirtualMachineType left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVirtualMachineType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplicationServerVmDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVmDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVmDetails>
    {
        internal ApplicationServerVmDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> StorageDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualMachineId { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVirtualMachineType? VirtualMachineType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVmDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVmDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVmDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVmDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVmDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVmDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVmDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmWorkloadsSapVirtualInstanceModelFactory
    {
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVmDetails ApplicationServerVmDetails(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVirtualMachineType? virtualMachineType = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVirtualMachineType?), Azure.Core.ResourceIdentifier virtualMachineId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> storageDetails = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVmDetails CentralServerVmDetails(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVirtualMachineType? virtualMachineType = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVirtualMachineType?), Azure.Core.ResourceIdentifier virtualMachineId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> storageDetails = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseVmDetails DatabaseVmDetails(Azure.Core.ResourceIdentifier virtualMachineId = null, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus? status = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> storageDetails = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiscoveryConfiguration DiscoveryConfiguration(Azure.Core.ResourceIdentifier centralServerVmId = null, string managedRgStorageAccountName = null, Azure.Core.AzureLocation? appLocation = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueReplicationServerProperties EnqueueReplicationServerProperties(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueReplicationServerType? ersVersion = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueReplicationServerType?), string instanceNo = null, string hostname = null, string kernelVersion = null, string kernelPatch = null, System.Net.IPAddress ipAddress = null, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState? health = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueServerProperties EnqueueServerProperties(string hostname = null, System.Net.IPAddress ipAddress = null, long? port = default(long?), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState? health = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.GatewayServerProperties GatewayServerProperties(long? port = default(long?), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState? health = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.MessageServerProperties MessageServerProperties(long? msPort = default(long?), long? internalMsPort = default(long?), long? httpPort = default(long?), long? httpsPort = default(long?), string hostname = null, System.Net.IPAddress ipAddress = null, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState? health = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult OperationStatusResult(Azure.Core.ResourceIdentifier id = null, string name = null, string status = null, double? percentComplete = default(double?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult> operations = null, Azure.ResponseError error = null, Azure.Core.ResourceIdentifier resourceId = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.SapApplicationServerInstanceData SapApplicationServerInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string instanceNo = null, Azure.Core.ResourceIdentifier subnetId = null, string hostname = null, string kernelVersion = null, string kernelPatch = null, System.Net.IPAddress ipAddress = null, long? gatewayPort = default(long?), long? icmHttpPort = default(long?), long? icmHttpsPort = default(long?), string dispatcherStatus = null, Azure.Core.ResourceIdentifier loadBalancerDetailsId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerVmDetails> vmDetails = null, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus? status = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus?), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState? health = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState?), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState?), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceErrorDetail errorsProperties = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsResult SapAvailabilityZoneDetailsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZonePair> availabilityZonePairs = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZonePair SapAvailabilityZonePair(long? zoneA = default(long?), long? zoneB = default(long?)) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.SapCentralServerInstanceData SapCentralServerInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string instanceNo = null, Azure.Core.ResourceIdentifier subnetId = null, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.MessageServerProperties messageServerProperties = null, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueServerProperties enqueueServerProperties = null, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.GatewayServerProperties gatewayServerProperties = null, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueReplicationServerProperties enqueueReplicationServerProperties = null, string kernelVersion = null, string kernelPatch = null, Azure.Core.ResourceIdentifier loadBalancerDetailsId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVmDetails> vmDetails = null, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus? status = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus?), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState? health = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState?), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState?), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceErrorDetail errorsProperties = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.SapDatabaseInstanceData SapDatabaseInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.Core.ResourceIdentifier subnetId = null, string databaseSid = null, string databaseType = null, System.Net.IPAddress ipAddress = null, Azure.Core.ResourceIdentifier loadBalancerDetailsId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseVmDetails> vmDetails = null, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus? status = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus?), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState?), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceErrorDetail errorsProperties = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfiguration SapDiskConfiguration(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskVolumeConfiguration recommendedConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SupportedConfigurationsDiskDetails> supportedConfigurations = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsResult SapDiskConfigurationsResult(System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfiguration> volumeConfigurations = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationContent SapSizingRecommendationContent(Azure.Core.AzureLocation appLocation = default(Azure.Core.AzureLocation), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapEnvironmentType environment = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapEnvironmentType), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType sapProduct = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDeploymentType deploymentType = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDeploymentType), long saps = (long)0, long dbMemory = (long)0, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseType databaseType = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseType), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseScaleMethod? dbScaleMethod = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseScaleMethod?), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHighAvailabilityType? highAvailabilityType = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHighAvailabilityType?)) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedResourceSkusResult SapSupportedResourceSkusResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSku> supportedSkus = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSku SapSupportedSku(string vmSku = null, bool? isAppServerCertified = default(bool?), bool? isDatabaseCertified = default(bool?)) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSkusContent SapSupportedSkusContent(Azure.Core.AzureLocation appLocation = default(Azure.Core.AzureLocation), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapEnvironmentType environment = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapEnvironmentType), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType sapProduct = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDeploymentType deploymentType = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDeploymentType), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseType databaseType = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseType), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHighAvailabilityType? highAvailabilityType = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHighAvailabilityType?)) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.SapVirtualInstanceData SapVirtualInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapEnvironmentType? environment = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapEnvironmentType?), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType? sapProduct = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType?), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ManagedResourcesNetworkAccessType? managedResourcesNetworkAccessType = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ManagedResourcesNetworkAccessType?), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapConfiguration configuration = null, string managedResourceGroupName = null, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus? status = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus?), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState? health = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState?), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceState? state = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceState?), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState?), Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceErrorDetail errorsProperties = null, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceErrorDetail SapVirtualInstanceErrorDetail(string code = null, string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceErrorDetail> details = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerRecommendationResult SingleServerRecommendationResult(string vmSku = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SupportedConfigurationsDiskDetails SupportedConfigurationsDiskDetails(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskDetailsDiskSkuName? skuName = default(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskDetailsDiskSkuName?), long? sizeInGB = default(long?), long? minimumSupportedDiskCount = default(long?), long? maximumSupportedDiskCount = default(long?), long? iopsReadWrite = default(long?), long? mbpsReadWrite = default(long?), string diskTier = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierRecommendationResult ThreeTierRecommendationResult(string dbVmSku = null, long? databaseInstanceCount = default(long?), string centralServerVmSku = null, long? centralServerInstanceCount = default(long?), string applicationServerVmSku = null, long? applicationServerInstanceCount = default(long?)) { throw null; }
    }
    public partial class CentralServerConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerConfiguration>
    {
        public CentralServerConfiguration(Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualMachineConfiguration virtualMachineConfiguration, long instanceCount) { }
        public long InstanceCount { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CentralServerFullResourceNames : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerFullResourceNames>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerFullResourceNames>
    {
        public CentralServerFullResourceNames() { }
        public string AvailabilitySetName { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.LoadBalancerResourceNames LoadBalancer { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.VirtualMachineResourceNames> VirtualMachines { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerFullResourceNames System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerFullResourceNames>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerFullResourceNames>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerFullResourceNames System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerFullResourceNames>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerFullResourceNames>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerFullResourceNames>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CentralServerVirtualMachineType : System.IEquatable<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVirtualMachineType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CentralServerVirtualMachineType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVirtualMachineType Ascs { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVirtualMachineType Ers { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVirtualMachineType ErsInactive { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVirtualMachineType Primary { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVirtualMachineType Secondary { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVirtualMachineType Standby { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVirtualMachineType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVirtualMachineType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVirtualMachineType left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVirtualMachineType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVirtualMachineType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVirtualMachineType left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVirtualMachineType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CentralServerVmDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVmDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVmDetails>
    {
        internal CentralServerVmDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> StorageDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualMachineId { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVirtualMachineType? VirtualMachineType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVmDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVmDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVmDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVmDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVmDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVmDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerVmDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateAndMountFileShareConfiguration : Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.FileShareConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CreateAndMountFileShareConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CreateAndMountFileShareConfiguration>
    {
        public CreateAndMountFileShareConfiguration() { }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CreateAndMountFileShareConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CreateAndMountFileShareConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CreateAndMountFileShareConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CreateAndMountFileShareConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CreateAndMountFileShareConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CreateAndMountFileShareConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CreateAndMountFileShareConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseConfiguration>
    {
        public DatabaseConfiguration(Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualMachineConfiguration virtualMachineConfiguration, long instanceCount) { }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseType? DatabaseType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskVolumeConfiguration> DiskVolumeConfigurations { get { throw null; } }
        public long InstanceCount { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseServerFullResourceNames : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseServerFullResourceNames>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseServerFullResourceNames>
    {
        public DatabaseServerFullResourceNames() { }
        public string AvailabilitySetName { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.LoadBalancerResourceNames LoadBalancer { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.VirtualMachineResourceNames> VirtualMachines { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseServerFullResourceNames System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseServerFullResourceNames>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseServerFullResourceNames>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseServerFullResourceNames System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseServerFullResourceNames>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseServerFullResourceNames>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseServerFullResourceNames>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseVmDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseVmDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseVmDetails>
    {
        internal DatabaseVmDetails() { }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> StorageDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualMachineId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseVmDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseVmDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseVmDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseVmDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseVmDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseVmDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseVmDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeployerVmPackages : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeployerVmPackages>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeployerVmPackages>
    {
        public DeployerVmPackages() { }
        public System.Uri PackageUri { get { throw null; } set { } }
        public string StorageAccountId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeployerVmPackages System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeployerVmPackages>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeployerVmPackages>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeployerVmPackages System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeployerVmPackages>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeployerVmPackages>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeployerVmPackages>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentConfiguration : Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeploymentConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeploymentConfiguration>
    {
        public DeploymentConfiguration() { }
        public Azure.Core.AzureLocation? AppLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.InfrastructureConfiguration InfrastructureConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSoftwareConfiguration SoftwareConfiguration { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeploymentConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeploymentConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeploymentConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeploymentConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeploymentConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeploymentConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeploymentConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentWithOSConfiguration : Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeploymentWithOSConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeploymentWithOSConfiguration>
    {
        public DeploymentWithOSConfiguration() { }
        public Azure.Core.AzureLocation? AppLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.InfrastructureConfiguration InfrastructureConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OSSapConfiguration OSSapConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSoftwareConfiguration SoftwareConfiguration { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeploymentWithOSConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeploymentWithOSConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeploymentWithOSConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeploymentWithOSConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeploymentWithOSConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeploymentWithOSConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeploymentWithOSConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryConfiguration : Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiscoveryConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiscoveryConfiguration>
    {
        public DiscoveryConfiguration() { }
        public Azure.Core.AzureLocation? AppLocation { get { throw null; } }
        public Azure.Core.ResourceIdentifier CentralServerVmId { get { throw null; } set { } }
        public string ManagedRgStorageAccountName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiscoveryConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiscoveryConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiscoveryConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiscoveryConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiscoveryConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiscoveryConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiscoveryConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskDetailsDiskSkuName : System.IEquatable<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskDetailsDiskSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskDetailsDiskSkuName(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskDetailsDiskSkuName PremiumLrs { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskDetailsDiskSkuName PremiumV2Lrs { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskDetailsDiskSkuName PremiumZrs { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskDetailsDiskSkuName StandardLrs { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskDetailsDiskSkuName StandardSsdLrs { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskDetailsDiskSkuName StandardSsdZrs { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskDetailsDiskSkuName UltraSsdLrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskDetailsDiskSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskDetailsDiskSkuName left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskDetailsDiskSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskDetailsDiskSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskDetailsDiskSkuName left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskDetailsDiskSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskVolumeConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskVolumeConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskVolumeConfiguration>
    {
        public DiskVolumeConfiguration() { }
        public long? Count { get { throw null; } set { } }
        public long? SizeInGB { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskDetailsDiskSkuName? SkuName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskVolumeConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskVolumeConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskVolumeConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskVolumeConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskVolumeConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskVolumeConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskVolumeConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnqueueReplicationServerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueReplicationServerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueReplicationServerProperties>
    {
        public EnqueueReplicationServerProperties() { }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueReplicationServerType? ErsVersion { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState? Health { get { throw null; } }
        public string Hostname { get { throw null; } }
        public string InstanceNo { get { throw null; } }
        public System.Net.IPAddress IPAddress { get { throw null; } }
        public string KernelPatch { get { throw null; } }
        public string KernelVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueReplicationServerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueReplicationServerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueReplicationServerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueReplicationServerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueReplicationServerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueReplicationServerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueReplicationServerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnqueueReplicationServerType : System.IEquatable<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueReplicationServerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnqueueReplicationServerType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueReplicationServerType EnqueueReplicator1 { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueReplicationServerType EnqueueReplicator2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueReplicationServerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueReplicationServerType left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueReplicationServerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueReplicationServerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueReplicationServerType left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueReplicationServerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnqueueServerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueServerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueServerProperties>
    {
        public EnqueueServerProperties() { }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState? Health { get { throw null; } }
        public string Hostname { get { throw null; } }
        public System.Net.IPAddress IPAddress { get { throw null; } }
        public long? Port { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueServerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueServerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueServerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueServerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueServerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueServerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.EnqueueServerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExternalInstallationSoftwareConfiguration : Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSoftwareConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ExternalInstallationSoftwareConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ExternalInstallationSoftwareConfiguration>
    {
        public ExternalInstallationSoftwareConfiguration() { }
        public Azure.Core.ResourceIdentifier CentralServerVmId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ExternalInstallationSoftwareConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ExternalInstallationSoftwareConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ExternalInstallationSoftwareConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ExternalInstallationSoftwareConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ExternalInstallationSoftwareConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ExternalInstallationSoftwareConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ExternalInstallationSoftwareConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class FileShareConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.FileShareConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.FileShareConfiguration>
    {
        protected FileShareConfiguration() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.FileShareConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.FileShareConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.FileShareConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.FileShareConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.FileShareConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.FileShareConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.FileShareConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GatewayServerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.GatewayServerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.GatewayServerProperties>
    {
        public GatewayServerProperties() { }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState? Health { get { throw null; } }
        public long? Port { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.GatewayServerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.GatewayServerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.GatewayServerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.GatewayServerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.GatewayServerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.GatewayServerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.GatewayServerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HighAvailabilitySoftwareConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.HighAvailabilitySoftwareConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.HighAvailabilitySoftwareConfiguration>
    {
        public HighAvailabilitySoftwareConfiguration(string fencingClientId, string fencingClientPassword) { }
        public string FencingClientId { get { throw null; } set { } }
        public string FencingClientPassword { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.HighAvailabilitySoftwareConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.HighAvailabilitySoftwareConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.HighAvailabilitySoftwareConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.HighAvailabilitySoftwareConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.HighAvailabilitySoftwareConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.HighAvailabilitySoftwareConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.HighAvailabilitySoftwareConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class InfrastructureConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.InfrastructureConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.InfrastructureConfiguration>
    {
        protected InfrastructureConfiguration(string appResourceGroup) { }
        public string AppResourceGroup { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.InfrastructureConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.InfrastructureConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.InfrastructureConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.InfrastructureConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.InfrastructureConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.InfrastructureConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.InfrastructureConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadBalancerResourceNames : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.LoadBalancerResourceNames>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.LoadBalancerResourceNames>
    {
        public LoadBalancerResourceNames() { }
        public System.Collections.Generic.IList<string> BackendPoolNames { get { throw null; } }
        public System.Collections.Generic.IList<string> FrontendIPConfigurationNames { get { throw null; } }
        public System.Collections.Generic.IList<string> HealthProbeNames { get { throw null; } }
        public string LoadBalancerName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.LoadBalancerResourceNames System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.LoadBalancerResourceNames>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.LoadBalancerResourceNames>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.LoadBalancerResourceNames System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.LoadBalancerResourceNames>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.LoadBalancerResourceNames>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.LoadBalancerResourceNames>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedResourcesNetworkAccessType : System.IEquatable<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ManagedResourcesNetworkAccessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedResourcesNetworkAccessType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ManagedResourcesNetworkAccessType Private { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ManagedResourcesNetworkAccessType Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ManagedResourcesNetworkAccessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ManagedResourcesNetworkAccessType left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ManagedResourcesNetworkAccessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ManagedResourcesNetworkAccessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ManagedResourcesNetworkAccessType left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ManagedResourcesNetworkAccessType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MessageServerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.MessageServerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.MessageServerProperties>
    {
        public MessageServerProperties() { }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState? Health { get { throw null; } }
        public string Hostname { get { throw null; } }
        public long? HttpPort { get { throw null; } }
        public long? HttpsPort { get { throw null; } }
        public long? InternalMsPort { get { throw null; } }
        public System.Net.IPAddress IPAddress { get { throw null; } }
        public long? MsPort { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.MessageServerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.MessageServerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.MessageServerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.MessageServerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.MessageServerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.MessageServerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.MessageServerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MountFileShareConfiguration : Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.FileShareConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.MountFileShareConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.MountFileShareConfiguration>
    {
        public MountFileShareConfiguration(Azure.Core.ResourceIdentifier fileShareId, Azure.Core.ResourceIdentifier privateEndpointId) { }
        public Azure.Core.ResourceIdentifier FileShareId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.MountFileShareConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.MountFileShareConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.MountFileShareConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.MountFileShareConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.MountFileShareConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.MountFileShareConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.MountFileShareConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkInterfaceResourceNames : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.NetworkInterfaceResourceNames>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.NetworkInterfaceResourceNames>
    {
        public NetworkInterfaceResourceNames() { }
        public string NetworkInterfaceName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.NetworkInterfaceResourceNames System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.NetworkInterfaceResourceNames>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.NetworkInterfaceResourceNames>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.NetworkInterfaceResourceNames System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.NetworkInterfaceResourceNames>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.NetworkInterfaceResourceNames>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.NetworkInterfaceResourceNames>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult>
    {
        internal OperationStatusResult() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult> Operations { get { throw null; } }
        public double? PercentComplete { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OperationStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OSSapConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OSSapConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OSSapConfiguration>
    {
        public OSSapConfiguration() { }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DeployerVmPackages DeployerVmPackages { get { throw null; } set { } }
        public string SapFqdn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OSSapConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OSSapConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OSSapConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OSSapConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OSSapConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OSSapConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.OSSapConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapApplicationServerInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapApplicationServerInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapApplicationServerInstancePatch>
    {
        public SapApplicationServerInstancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapApplicationServerInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapApplicationServerInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapApplicationServerInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapApplicationServerInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapApplicationServerInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapApplicationServerInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapApplicationServerInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapAvailabilityZoneDetailsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsContent>
    {
        public SapAvailabilityZoneDetailsContent(Azure.Core.AzureLocation appLocation, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType sapProduct, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseType databaseType) { }
        public Azure.Core.AzureLocation AppLocation { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseType DatabaseType { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType SapProduct { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapAvailabilityZoneDetailsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsResult>
    {
        internal SapAvailabilityZoneDetailsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZonePair> AvailabilityZonePairs { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZoneDetailsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapAvailabilityZonePair : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZonePair>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZonePair>
    {
        internal SapAvailabilityZonePair() { }
        public long? ZoneA { get { throw null; } }
        public long? ZoneB { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZonePair System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZonePair>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZonePair>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZonePair System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZonePair>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZonePair>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapAvailabilityZonePair>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapCentralServerInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapCentralServerInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapCentralServerInstancePatch>
    {
        public SapCentralServerInstancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapCentralServerInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapCentralServerInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapCentralServerInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapCentralServerInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapCentralServerInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapCentralServerInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapCentralServerInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class SapConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapConfiguration>
    {
        protected SapConfiguration() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapDatabaseInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseInstancePatch>
    {
        public SapDatabaseInstancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapDatabaseScaleMethod : System.IEquatable<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseScaleMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapDatabaseScaleMethod(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseScaleMethod ScaleUp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseScaleMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseScaleMethod left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseScaleMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseScaleMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseScaleMethod left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseScaleMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapDatabaseType : System.IEquatable<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapDatabaseType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseType DB2 { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseType Hana { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseType left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseType left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapDeploymentType : System.IEquatable<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDeploymentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapDeploymentType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDeploymentType SingleServer { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDeploymentType ThreeTier { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDeploymentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDeploymentType left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDeploymentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDeploymentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDeploymentType left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDeploymentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapDiskConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfiguration>
    {
        internal SapDiskConfiguration() { }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskVolumeConfiguration RecommendedConfiguration { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SupportedConfigurationsDiskDetails> SupportedConfigurations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapDiskConfigurationsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsContent>
    {
        public SapDiskConfigurationsContent(Azure.Core.AzureLocation appLocation, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapEnvironmentType environment, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType sapProduct, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseType databaseType, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDeploymentType deploymentType, string dbVmSku) { }
        public Azure.Core.AzureLocation AppLocation { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseType DatabaseType { get { throw null; } }
        public string DBVmSku { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDeploymentType DeploymentType { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapEnvironmentType Environment { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType SapProduct { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapDiskConfigurationsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsResult>
    {
        internal SapDiskConfigurationsResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfiguration> VolumeConfigurations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDiskConfigurationsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapEnvironmentType : System.IEquatable<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapEnvironmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapEnvironmentType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapEnvironmentType NonProd { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapEnvironmentType Prod { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapEnvironmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapEnvironmentType left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapEnvironmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapEnvironmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapEnvironmentType left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapEnvironmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapHealthState : System.IEquatable<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapHealthState(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState Degraded { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState Healthy { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState Unhealthy { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHealthState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapHighAvailabilityType : System.IEquatable<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHighAvailabilityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapHighAvailabilityType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHighAvailabilityType AvailabilitySet { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHighAvailabilityType AvailabilityZone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHighAvailabilityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHighAvailabilityType left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHighAvailabilityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHighAvailabilityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHighAvailabilityType left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHighAvailabilityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapImageReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapImageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapImageReference>
    {
        public SapImageReference() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapImageReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapImageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapImageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapImageReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapImageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapImageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapImageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapInstallWithoutOSConfigSoftwareConfiguration : Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSoftwareConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapInstallWithoutOSConfigSoftwareConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapInstallWithoutOSConfigSoftwareConfiguration>
    {
        public SapInstallWithoutOSConfigSoftwareConfiguration(System.Uri bomUri, string sapBitsStorageAccountId, string softwareVersion) { }
        public System.Uri BomUri { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.HighAvailabilitySoftwareConfiguration HighAvailabilitySoftwareConfiguration { get { throw null; } set { } }
        public string SapBitsStorageAccountId { get { throw null; } set { } }
        public string SoftwareVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapInstallWithoutOSConfigSoftwareConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapInstallWithoutOSConfigSoftwareConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapInstallWithoutOSConfigSoftwareConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapInstallWithoutOSConfigSoftwareConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapInstallWithoutOSConfigSoftwareConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapInstallWithoutOSConfigSoftwareConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapInstallWithoutOSConfigSoftwareConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapLinuxConfiguration : Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapOSConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapLinuxConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapLinuxConfiguration>
    {
        public SapLinuxConfiguration() { }
        public bool? DisablePasswordAuthentication { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSshKeyPair SshKeyPair { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSshPublicKey> SshPublicKeys { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapLinuxConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapLinuxConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapLinuxConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapLinuxConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapLinuxConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapLinuxConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapLinuxConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class SapOSConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapOSConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapOSConfiguration>
    {
        protected SapOSConfiguration() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapOSConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapOSConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapOSConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapOSConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapOSConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapOSConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapOSConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapOSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapOSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapOSProfile>
    {
        public SapOSProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapOSConfiguration OSConfiguration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapOSProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapOSProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapOSProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapOSProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapOSProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapOSProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapOSProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapProductType : System.IEquatable<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapProductType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType Ecc { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType Other { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType S4Hana { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapSizingRecommendationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationContent>
    {
        public SapSizingRecommendationContent(Azure.Core.AzureLocation appLocation, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapEnvironmentType environment, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType sapProduct, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDeploymentType deploymentType, long saps, long dbMemory, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseType databaseType) { }
        public Azure.Core.AzureLocation AppLocation { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseType DatabaseType { get { throw null; } }
        public long DBMemory { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseScaleMethod? DBScaleMethod { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDeploymentType DeploymentType { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapEnvironmentType Environment { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHighAvailabilityType? HighAvailabilityType { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType SapProduct { get { throw null; } }
        public long Saps { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class SapSizingRecommendationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationResult>
    {
        protected SapSizingRecommendationResult() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class SapSoftwareConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSoftwareConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSoftwareConfiguration>
    {
        protected SapSoftwareConfiguration() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSoftwareConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSoftwareConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSoftwareConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSoftwareConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSoftwareConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSoftwareConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSoftwareConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapSshKeyPair : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSshKeyPair>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSshKeyPair>
    {
        public SapSshKeyPair() { }
        public string PrivateKey { get { throw null; } set { } }
        public string PublicKey { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSshKeyPair System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSshKeyPair>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSshKeyPair>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSshKeyPair System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSshKeyPair>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSshKeyPair>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSshKeyPair>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapSshPublicKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSshPublicKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSshPublicKey>
    {
        public SapSshPublicKey() { }
        public string KeyData { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSshPublicKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSshPublicKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSshPublicKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSshPublicKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSshPublicKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSshPublicKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSshPublicKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapSupportedResourceSkusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedResourceSkusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedResourceSkusResult>
    {
        internal SapSupportedResourceSkusResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSku> SupportedSkus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedResourceSkusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedResourceSkusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedResourceSkusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedResourceSkusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedResourceSkusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedResourceSkusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedResourceSkusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapSupportedSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSku>
    {
        internal SapSupportedSku() { }
        public bool? IsAppServerCertified { get { throw null; } }
        public bool? IsDatabaseCertified { get { throw null; } }
        public string VmSku { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapSupportedSkusContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSkusContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSkusContent>
    {
        public SapSupportedSkusContent(Azure.Core.AzureLocation appLocation, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapEnvironmentType environment, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType sapProduct, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDeploymentType deploymentType, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseType databaseType) { }
        public Azure.Core.AzureLocation AppLocation { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseType DatabaseType { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDeploymentType DeploymentType { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapEnvironmentType Environment { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHighAvailabilityType? HighAvailabilityType { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapProductType SapProduct { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSkusContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSkusContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSkusContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSkusContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSkusContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSkusContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSupportedSkusContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapVirtualInstanceErrorDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceErrorDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceErrorDetail>
    {
        internal SapVirtualInstanceErrorDetail() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceErrorDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceErrorDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceErrorDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceErrorDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceErrorDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceErrorDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceErrorDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceErrorDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapVirtualInstanceIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceIdentity>
    {
        public SapVirtualInstanceIdentity(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceIdentityType type) { }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceIdentityType Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapVirtualInstanceIdentityType : System.IEquatable<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapVirtualInstanceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceIdentityType left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceIdentityType left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapVirtualInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstancePatch>
    {
        public SapVirtualInstancePatch() { }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ManagedResourcesNetworkAccessType? UpdateSapVirtualInstanceManagedResourcesNetworkAccessType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapVirtualInstanceProvisioningState : System.IEquatable<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapVirtualInstanceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapVirtualInstanceState : System.IEquatable<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapVirtualInstanceState(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceState AcssInstallationBlocked { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceState DiscoveryFailed { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceState DiscoveryInProgress { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceState DiscoveryPending { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceState InfrastructureDeploymentFailed { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceState InfrastructureDeploymentInProgress { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceState InfrastructureDeploymentPending { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceState RegistrationComplete { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceState SoftwareDetectionFailed { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceState SoftwareDetectionInProgress { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceState SoftwareInstallationFailed { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceState SoftwareInstallationInProgress { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceState SoftwareInstallationPending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceState left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceState left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapVirtualInstanceStatus : System.IEquatable<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapVirtualInstanceStatus(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus PartiallyRunning { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus Running { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus SoftShutdown { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus Starting { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus Stopping { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus left, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualInstanceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapVirtualMachineConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualMachineConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualMachineConfiguration>
    {
        public SapVirtualMachineConfiguration(string vmSize, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapImageReference imageReference, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapOSProfile osProfile) { }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapOSProfile OSProfile { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualMachineConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualMachineConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualMachineConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualMachineConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualMachineConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualMachineConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualMachineConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapWindowsConfiguration : Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapOSConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapWindowsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapWindowsConfiguration>
    {
        public SapWindowsConfiguration() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapWindowsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapWindowsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapWindowsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapWindowsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapWindowsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapWindowsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapWindowsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceInitiatedSoftwareConfiguration : Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSoftwareConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ServiceInitiatedSoftwareConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ServiceInitiatedSoftwareConfiguration>
    {
        public ServiceInitiatedSoftwareConfiguration(System.Uri bomUri, string softwareVersion, string sapBitsStorageAccountId, string sapFqdn, string sshPrivateKey) { }
        public System.Uri BomUri { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.HighAvailabilitySoftwareConfiguration HighAvailabilitySoftwareConfiguration { get { throw null; } set { } }
        public string SapBitsStorageAccountId { get { throw null; } set { } }
        public string SapFqdn { get { throw null; } set { } }
        public string SoftwareVersion { get { throw null; } set { } }
        public string SshPrivateKey { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ServiceInitiatedSoftwareConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ServiceInitiatedSoftwareConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ServiceInitiatedSoftwareConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ServiceInitiatedSoftwareConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ServiceInitiatedSoftwareConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ServiceInitiatedSoftwareConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ServiceInitiatedSoftwareConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharedStorageResourceNames : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SharedStorageResourceNames>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SharedStorageResourceNames>
    {
        public SharedStorageResourceNames() { }
        public string SharedStorageAccountName { get { throw null; } set { } }
        public string SharedStorageAccountPrivateEndPointName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SharedStorageResourceNames System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SharedStorageResourceNames>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SharedStorageResourceNames>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SharedStorageResourceNames System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SharedStorageResourceNames>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SharedStorageResourceNames>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SharedStorageResourceNames>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SingleServerConfiguration : Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.InfrastructureConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerConfiguration>
    {
        public SingleServerConfiguration(string appResourceGroup, Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualMachineConfiguration virtualMachineConfiguration) : base (default(string)) { }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerCustomResourceNames CustomResourceNames { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapDatabaseType? DatabaseType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskVolumeConfiguration> DiskVolumeConfigurations { get { throw null; } }
        public bool? IsSecondaryIPEnabled { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapVirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class SingleServerCustomResourceNames : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerCustomResourceNames>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerCustomResourceNames>
    {
        protected SingleServerCustomResourceNames() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerCustomResourceNames System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerCustomResourceNames>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerCustomResourceNames>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerCustomResourceNames System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerCustomResourceNames>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerCustomResourceNames>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerCustomResourceNames>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SingleServerFullResourceNames : Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerCustomResourceNames, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerFullResourceNames>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerFullResourceNames>
    {
        public SingleServerFullResourceNames() { }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.VirtualMachineResourceNames VirtualMachine { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerFullResourceNames System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerFullResourceNames>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerFullResourceNames>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerFullResourceNames System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerFullResourceNames>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerFullResourceNames>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerFullResourceNames>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SingleServerRecommendationResult : Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerRecommendationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerRecommendationResult>
    {
        internal SingleServerRecommendationResult() { }
        public string VmSku { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerRecommendationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerRecommendationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerRecommendationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerRecommendationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerRecommendationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerRecommendationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SingleServerRecommendationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkipFileShareConfiguration : Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.FileShareConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SkipFileShareConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SkipFileShareConfiguration>
    {
        public SkipFileShareConfiguration() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SkipFileShareConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SkipFileShareConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SkipFileShareConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SkipFileShareConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SkipFileShareConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SkipFileShareConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SkipFileShareConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StartSapInstanceContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StartSapInstanceContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StartSapInstanceContent>
    {
        public StartSapInstanceContent() { }
        public bool? StartVm { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StartSapInstanceContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StartSapInstanceContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StartSapInstanceContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StartSapInstanceContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StartSapInstanceContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StartSapInstanceContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StartSapInstanceContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StopSapInstanceContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StopSapInstanceContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StopSapInstanceContent>
    {
        public StopSapInstanceContent() { }
        public bool? DeallocateVm { get { throw null; } set { } }
        public long? SoftStopTimeoutSeconds { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StopSapInstanceContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StopSapInstanceContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StopSapInstanceContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StopSapInstanceContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StopSapInstanceContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StopSapInstanceContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.StopSapInstanceContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportedConfigurationsDiskDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SupportedConfigurationsDiskDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SupportedConfigurationsDiskDetails>
    {
        internal SupportedConfigurationsDiskDetails() { }
        public string DiskTier { get { throw null; } }
        public long? IopsReadWrite { get { throw null; } }
        public long? MaximumSupportedDiskCount { get { throw null; } }
        public long? MbpsReadWrite { get { throw null; } }
        public long? MinimumSupportedDiskCount { get { throw null; } }
        public long? SizeInGB { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DiskDetailsDiskSkuName? SkuName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SupportedConfigurationsDiskDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SupportedConfigurationsDiskDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SupportedConfigurationsDiskDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SupportedConfigurationsDiskDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SupportedConfigurationsDiskDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SupportedConfigurationsDiskDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SupportedConfigurationsDiskDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreeTierConfiguration : Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.InfrastructureConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierConfiguration>
    {
        public ThreeTierConfiguration(string appResourceGroup, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerConfiguration centralServer, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerConfiguration applicationServer, Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseConfiguration databaseServer) : base (default(string)) { }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerConfiguration ApplicationServer { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerConfiguration CentralServer { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierCustomResourceNames CustomResourceNames { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseConfiguration DatabaseServer { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapHighAvailabilityType? HighAvailabilityType { get { throw null; } set { } }
        public bool? IsSecondaryIPEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.FileShareConfiguration StorageTransportFileShareConfiguration { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ThreeTierCustomResourceNames : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierCustomResourceNames>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierCustomResourceNames>
    {
        protected ThreeTierCustomResourceNames() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierCustomResourceNames System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierCustomResourceNames>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierCustomResourceNames>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierCustomResourceNames System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierCustomResourceNames>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierCustomResourceNames>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierCustomResourceNames>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreeTierFullResourceNames : Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierCustomResourceNames, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierFullResourceNames>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierFullResourceNames>
    {
        public ThreeTierFullResourceNames() { }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ApplicationServerFullResourceNames ApplicationServer { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.CentralServerFullResourceNames CentralServer { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.DatabaseServerFullResourceNames DatabaseServer { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SharedStorageResourceNames SharedStorage { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierFullResourceNames System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierFullResourceNames>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierFullResourceNames>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierFullResourceNames System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierFullResourceNames>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierFullResourceNames>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierFullResourceNames>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreeTierRecommendationResult : Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.SapSizingRecommendationResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierRecommendationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierRecommendationResult>
    {
        internal ThreeTierRecommendationResult() { }
        public long? ApplicationServerInstanceCount { get { throw null; } }
        public string ApplicationServerVmSku { get { throw null; } }
        public long? CentralServerInstanceCount { get { throw null; } }
        public string CentralServerVmSku { get { throw null; } }
        public long? DatabaseInstanceCount { get { throw null; } }
        public string DBVmSku { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierRecommendationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierRecommendationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierRecommendationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierRecommendationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierRecommendationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierRecommendationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.ThreeTierRecommendationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineResourceNames : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.VirtualMachineResourceNames>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.VirtualMachineResourceNames>
    {
        public VirtualMachineResourceNames() { }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> DataDiskNames { get { throw null; } }
        public string HostName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.NetworkInterfaceResourceNames> NetworkInterfaces { get { throw null; } }
        public string OSDiskName { get { throw null; } set { } }
        public string VmName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.VirtualMachineResourceNames System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.VirtualMachineResourceNames>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.VirtualMachineResourceNames>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.VirtualMachineResourceNames System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.VirtualMachineResourceNames>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.VirtualMachineResourceNames>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapVirtualInstance.Models.VirtualMachineResourceNames>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
