namespace Azure.ResourceManager.Workloads
{
    public partial class SapApplicationServerInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource>, System.Collections.IEnumerable
    {
        protected SapApplicationServerInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationInstanceName, Azure.ResourceManager.Workloads.SapApplicationServerInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationInstanceName, Azure.ResourceManager.Workloads.SapApplicationServerInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource> Get(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource>> GetAsync(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource> GetIfExists(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource>> GetIfExistsAsync(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapApplicationServerInstanceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.SapApplicationServerInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapApplicationServerInstanceData>
    {
        public SapApplicationServerInstanceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Workloads.Models.SapVirtualInstanceErrorDetail ErrorsProperties { get { throw null; } }
        public long? GatewayPort { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapHealthState? Health { get { throw null; } }
        public string Hostname { get { throw null; } }
        public long? IcmHttpPort { get { throw null; } }
        public long? IcmHttpsPort { get { throw null; } }
        public string InstanceNo { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public string KernelPatch { get { throw null; } }
        public string KernelVersion { get { throw null; } }
        public Azure.Core.ResourceIdentifier LoadBalancerDetailsId { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus? Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Workloads.Models.ApplicationServerVmDetails> VmDetails { get { throw null; } }
        Azure.ResourceManager.Workloads.SapApplicationServerInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.SapApplicationServerInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.SapApplicationServerInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.SapApplicationServerInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapApplicationServerInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapApplicationServerInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapApplicationServerInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapApplicationServerInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SapApplicationServerInstanceResource() { }
        public virtual Azure.ResourceManager.Workloads.SapApplicationServerInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sapVirtualInstanceName, string applicationInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult> StartInstance(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult>> StartInstanceAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult> StopInstance(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.SapStopContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult>> StopInstanceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.SapStopContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.SapApplicationServerInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.SapApplicationServerInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SapCentralServerInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource>, System.Collections.IEnumerable
    {
        protected SapCentralServerInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string centralInstanceName, Azure.ResourceManager.Workloads.SapCentralServerInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string centralInstanceName, Azure.ResourceManager.Workloads.SapCentralServerInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource> Get(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource>> GetAsync(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource> GetIfExists(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource>> GetIfExistsAsync(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapCentralServerInstanceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.SapCentralServerInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapCentralServerInstanceData>
    {
        public SapCentralServerInstanceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerProperties EnqueueReplicationServerProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.EnqueueServerProperties EnqueueServerProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapVirtualInstanceErrorDetail ErrorsProperties { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.GatewayServerProperties GatewayServerProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapHealthState? Health { get { throw null; } }
        public string InstanceNo { get { throw null; } }
        public string KernelPatch { get { throw null; } }
        public string KernelVersion { get { throw null; } }
        public Azure.Core.ResourceIdentifier LoadBalancerDetailsId { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.MessageServerProperties MessageServerProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus? Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Workloads.Models.CentralServerVmDetails> VmDetails { get { throw null; } }
        Azure.ResourceManager.Workloads.SapCentralServerInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.SapCentralServerInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.SapCentralServerInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.SapCentralServerInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapCentralServerInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapCentralServerInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapCentralServerInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapCentralServerInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SapCentralServerInstanceResource() { }
        public virtual Azure.ResourceManager.Workloads.SapCentralServerInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sapVirtualInstanceName, string centralInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult> StartInstance(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult>> StartInstanceAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult> StopInstance(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.SapStopContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult>> StopInstanceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.SapStopContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.SapCentralServerInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.SapCentralServerInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SapDatabaseInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource>, System.Collections.IEnumerable
    {
        protected SapDatabaseInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseInstanceName, Azure.ResourceManager.Workloads.SapDatabaseInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseInstanceName, Azure.ResourceManager.Workloads.SapDatabaseInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource> Get(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource>> GetAsync(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource> GetIfExists(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource>> GetIfExistsAsync(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapDatabaseInstanceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.SapDatabaseInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapDatabaseInstanceData>
    {
        public SapDatabaseInstanceData(Azure.Core.AzureLocation location) { }
        public string DatabaseSid { get { throw null; } }
        public string DatabaseType { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapVirtualInstanceErrorDetail ErrorsProperties { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public Azure.Core.ResourceIdentifier LoadBalancerDetailsId { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus? Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Workloads.Models.DatabaseVmDetails> VmDetails { get { throw null; } }
        Azure.ResourceManager.Workloads.SapDatabaseInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.SapDatabaseInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.SapDatabaseInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.SapDatabaseInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapDatabaseInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapDatabaseInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapDatabaseInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapDatabaseInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SapDatabaseInstanceResource() { }
        public virtual Azure.ResourceManager.Workloads.SapDatabaseInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sapVirtualInstanceName, string databaseInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult> StartInstance(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult>> StartInstanceAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult> StopInstance(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.SapStopContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult>> StopInstanceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.SapStopContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.SapDatabaseInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.SapDatabaseInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SapLandscapeMonitorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.SapLandscapeMonitorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapLandscapeMonitorData>
    {
        public SapLandscapeMonitorData() { }
        public Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorPropertiesGrouping Grouping { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorMetricThresholds> TopMetricsThresholds { get { throw null; } }
        Azure.ResourceManager.Workloads.SapLandscapeMonitorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.SapLandscapeMonitorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.SapLandscapeMonitorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.SapLandscapeMonitorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapLandscapeMonitorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapLandscapeMonitorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapLandscapeMonitorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapLandscapeMonitorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SapLandscapeMonitorResource() { }
        public virtual Azure.ResourceManager.Workloads.SapLandscapeMonitorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapLandscapeMonitorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.SapLandscapeMonitorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapLandscapeMonitorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.SapLandscapeMonitorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapLandscapeMonitorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapLandscapeMonitorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapLandscapeMonitorResource> Update(Azure.ResourceManager.Workloads.SapLandscapeMonitorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapLandscapeMonitorResource>> UpdateAsync(Azure.ResourceManager.Workloads.SapLandscapeMonitorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SapMonitorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Workloads.SapMonitorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.SapMonitorResource>, System.Collections.IEnumerable
    {
        protected SapMonitorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapMonitorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.Workloads.SapMonitorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapMonitorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.Workloads.SapMonitorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapMonitorResource> Get(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Workloads.SapMonitorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Workloads.SapMonitorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapMonitorResource>> GetAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Workloads.SapMonitorResource> GetIfExists(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Workloads.SapMonitorResource>> GetIfExistsAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Workloads.SapMonitorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Workloads.SapMonitorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Workloads.SapMonitorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.SapMonitorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapMonitorData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.SapMonitorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapMonitorData>
    {
        public SapMonitorData(Azure.Core.AzureLocation location) { }
        public Azure.Core.AzureLocation? AppLocation { get { throw null; } set { } }
        public Azure.ResponseError Errors { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.UserAssignedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogAnalyticsWorkspaceArmId { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MonitorSubnetId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MsiArmId { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.WorkloadMonitorProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapRoutingPreference? RoutingPreference { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountArmId { get { throw null; } }
        public string ZoneRedundancyPreference { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.SapMonitorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.SapMonitorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.SapMonitorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.SapMonitorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapMonitorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapMonitorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapMonitorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapMonitorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SapMonitorResource() { }
        public virtual Azure.ResourceManager.Workloads.SapMonitorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapMonitorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapMonitorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapMonitorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapMonitorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Workloads.SapLandscapeMonitorResource GetSapLandscapeMonitor() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapProviderInstanceResource> GetSapProviderInstance(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapProviderInstanceResource>> GetSapProviderInstanceAsync(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Workloads.SapProviderInstanceCollection GetSapProviderInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapMonitorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapMonitorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapMonitorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapMonitorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapMonitorResource> Update(Azure.ResourceManager.Workloads.Models.SapMonitorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapMonitorResource>> UpdateAsync(Azure.ResourceManager.Workloads.Models.SapMonitorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SapProviderInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Workloads.SapProviderInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.SapProviderInstanceResource>, System.Collections.IEnumerable
    {
        protected SapProviderInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapProviderInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string providerInstanceName, Azure.ResourceManager.Workloads.SapProviderInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapProviderInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string providerInstanceName, Azure.ResourceManager.Workloads.SapProviderInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapProviderInstanceResource> Get(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Workloads.SapProviderInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Workloads.SapProviderInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapProviderInstanceResource>> GetAsync(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Workloads.SapProviderInstanceResource> GetIfExists(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Workloads.SapProviderInstanceResource>> GetIfExistsAsync(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Workloads.SapProviderInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Workloads.SapProviderInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Workloads.SapProviderInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.SapProviderInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapProviderInstanceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.SapProviderInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapProviderInstanceData>
    {
        public SapProviderInstanceData() { }
        public Azure.ResponseError Errors { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.UserAssignedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties ProviderSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.WorkloadMonitorProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.Workloads.SapProviderInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.SapProviderInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.SapProviderInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.SapProviderInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapProviderInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapProviderInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapProviderInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapProviderInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SapProviderInstanceResource() { }
        public virtual Azure.ResourceManager.Workloads.SapProviderInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string providerInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapProviderInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapProviderInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapProviderInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.SapProviderInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapProviderInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.SapProviderInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SapVirtualInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Workloads.SapVirtualInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.SapVirtualInstanceResource>, System.Collections.IEnumerable
    {
        protected SapVirtualInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapVirtualInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sapVirtualInstanceName, Azure.ResourceManager.Workloads.SapVirtualInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapVirtualInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sapVirtualInstanceName, Azure.ResourceManager.Workloads.SapVirtualInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapVirtualInstanceResource> Get(string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Workloads.SapVirtualInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Workloads.SapVirtualInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapVirtualInstanceResource>> GetAsync(string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Workloads.SapVirtualInstanceResource> GetIfExists(string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Workloads.SapVirtualInstanceResource>> GetIfExistsAsync(string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Workloads.SapVirtualInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Workloads.SapVirtualInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Workloads.SapVirtualInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.SapVirtualInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapVirtualInstanceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.SapVirtualInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapVirtualInstanceData>
    {
        public SapVirtualInstanceData(Azure.Core.AzureLocation location, Azure.ResourceManager.Workloads.Models.SapEnvironmentType environment, Azure.ResourceManager.Workloads.Models.SapProductType sapProduct, Azure.ResourceManager.Workloads.Models.SapConfiguration configuration) { }
        public Azure.ResourceManager.Workloads.Models.SapConfiguration Configuration { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapEnvironmentType Environment { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapVirtualInstanceErrorDetail ErrorsProperties { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapHealthState? Health { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.UserAssignedServiceIdentity Identity { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapProductType SapProduct { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapVirtualInstanceState? State { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus? Status { get { throw null; } }
        Azure.ResourceManager.Workloads.SapVirtualInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.SapVirtualInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.SapVirtualInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.SapVirtualInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapVirtualInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapVirtualInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.SapVirtualInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapVirtualInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SapVirtualInstanceResource() { }
        public virtual Azure.ResourceManager.Workloads.SapVirtualInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapVirtualInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapVirtualInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sapVirtualInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapVirtualInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapVirtualInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource> GetSapApplicationServerInstance(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource>> GetSapApplicationServerInstanceAsync(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Workloads.SapApplicationServerInstanceCollection GetSapApplicationServerInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource> GetSapCentralServerInstance(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource>> GetSapCentralServerInstanceAsync(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Workloads.SapCentralServerInstanceCollection GetSapCentralServerInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource> GetSapDatabaseInstance(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource>> GetSapDatabaseInstanceAsync(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Workloads.SapDatabaseInstanceCollection GetSapDatabaseInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapVirtualInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapVirtualInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapVirtualInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapVirtualInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult> Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult>> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult> Stop(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.SapStopContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult>> StopAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.SapStopContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapVirtualInstanceResource> Update(Azure.ResourceManager.Workloads.Models.SapVirtualInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapVirtualInstanceResource>> UpdateAsync(Azure.ResourceManager.Workloads.Models.SapVirtualInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class WorkloadsExtensions
    {
        public static Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource GetSapApplicationServerInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Workloads.SapCentralServerInstanceResource GetSapCentralServerInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Workloads.SapDatabaseInstanceResource GetSapDatabaseInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Workloads.SapLandscapeMonitorResource GetSapLandscapeMonitorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Workloads.SapMonitorResource> GetSapMonitor(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapMonitorResource>> GetSapMonitorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Workloads.SapMonitorResource GetSapMonitorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Workloads.SapMonitorCollection GetSapMonitors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Workloads.SapMonitorResource> GetSapMonitors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Workloads.SapMonitorResource> GetSapMonitorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Workloads.SapProviderInstanceResource GetSapProviderInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Workloads.SapVirtualInstanceResource> GetSapVirtualInstance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapVirtualInstanceResource>> GetSapVirtualInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Workloads.SapVirtualInstanceResource GetSapVirtualInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Workloads.SapVirtualInstanceCollection GetSapVirtualInstances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Workloads.SapVirtualInstanceResource> GetSapVirtualInstances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Workloads.SapVirtualInstanceResource> GetSapVirtualInstancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsResult> SapAvailabilityZoneDetails(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsResult>> SapAvailabilityZoneDetailsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsResult> SapDiskConfigurations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsResult>> SapDiskConfigurationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Workloads.Models.SapSizingRecommendationResult> SapSizingRecommendations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Workloads.Models.SapSizingRecommendationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.Models.SapSizingRecommendationResult>> SapSizingRecommendationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Workloads.Models.SapSizingRecommendationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Workloads.Models.SapSupportedResourceSkusResult> SapSupportedSku(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Workloads.Models.SapSupportedSkusContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.Models.SapSupportedResourceSkusResult>> SapSupportedSkuAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Workloads.Models.SapSupportedSkusContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Workloads.Mocking
{
    public partial class MockableWorkloadsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableWorkloadsArmClient() { }
        public virtual Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource GetSapApplicationServerInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Workloads.SapCentralServerInstanceResource GetSapCentralServerInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Workloads.SapDatabaseInstanceResource GetSapDatabaseInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Workloads.SapLandscapeMonitorResource GetSapLandscapeMonitorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Workloads.SapMonitorResource GetSapMonitorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Workloads.SapProviderInstanceResource GetSapProviderInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Workloads.SapVirtualInstanceResource GetSapVirtualInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableWorkloadsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableWorkloadsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapMonitorResource> GetSapMonitor(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapMonitorResource>> GetSapMonitorAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Workloads.SapMonitorCollection GetSapMonitors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapVirtualInstanceResource> GetSapVirtualInstance(string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapVirtualInstanceResource>> GetSapVirtualInstanceAsync(string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Workloads.SapVirtualInstanceCollection GetSapVirtualInstances() { throw null; }
    }
    public partial class MockableWorkloadsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableWorkloadsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Workloads.SapMonitorResource> GetSapMonitors(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Workloads.SapMonitorResource> GetSapMonitorsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Workloads.SapVirtualInstanceResource> GetSapVirtualInstances(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Workloads.SapVirtualInstanceResource> GetSapVirtualInstancesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsResult> SapAvailabilityZoneDetails(Azure.Core.AzureLocation location, Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsResult>> SapAvailabilityZoneDetailsAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsResult> SapDiskConfigurations(Azure.Core.AzureLocation location, Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsResult>> SapDiskConfigurationsAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.Models.SapSizingRecommendationResult> SapSizingRecommendations(Azure.Core.AzureLocation location, Azure.ResourceManager.Workloads.Models.SapSizingRecommendationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.Models.SapSizingRecommendationResult>> SapSizingRecommendationsAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Workloads.Models.SapSizingRecommendationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.Models.SapSupportedResourceSkusResult> SapSupportedSku(Azure.Core.AzureLocation location, Azure.ResourceManager.Workloads.Models.SapSupportedSkusContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.Models.SapSupportedResourceSkusResult>> SapSupportedSkuAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Workloads.Models.SapSupportedSkusContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Workloads.Models
{
    public partial class ApplicationServerConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ApplicationServerConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ApplicationServerConfiguration>
    {
        public ApplicationServerConfiguration(Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.Workloads.Models.SapVirtualMachineConfiguration virtualMachineConfiguration, long instanceCount) { }
        public long InstanceCount { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapVirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.ApplicationServerConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ApplicationServerConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ApplicationServerConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.ApplicationServerConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ApplicationServerConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ApplicationServerConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ApplicationServerConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationServerFullResourceNames : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ApplicationServerFullResourceNames>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ApplicationServerFullResourceNames>
    {
        public ApplicationServerFullResourceNames() { }
        public string AvailabilitySetName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Workloads.Models.VirtualMachineResourceNames> VirtualMachines { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.ApplicationServerFullResourceNames System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ApplicationServerFullResourceNames>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ApplicationServerFullResourceNames>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.ApplicationServerFullResourceNames System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ApplicationServerFullResourceNames>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ApplicationServerFullResourceNames>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ApplicationServerFullResourceNames>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationServerVirtualMachineType : System.IEquatable<Azure.ResourceManager.Workloads.Models.ApplicationServerVirtualMachineType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationServerVirtualMachineType(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.ApplicationServerVirtualMachineType Active { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.ApplicationServerVirtualMachineType Standby { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.ApplicationServerVirtualMachineType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.ApplicationServerVirtualMachineType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.ApplicationServerVirtualMachineType left, Azure.ResourceManager.Workloads.Models.ApplicationServerVirtualMachineType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.ApplicationServerVirtualMachineType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.ApplicationServerVirtualMachineType left, Azure.ResourceManager.Workloads.Models.ApplicationServerVirtualMachineType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplicationServerVmDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ApplicationServerVmDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ApplicationServerVmDetails>
    {
        internal ApplicationServerVmDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> StorageDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualMachineId { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.ApplicationServerVirtualMachineType? VirtualMachineType { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.ApplicationServerVmDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ApplicationServerVmDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ApplicationServerVmDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.ApplicationServerVmDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ApplicationServerVmDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ApplicationServerVmDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ApplicationServerVmDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmWorkloadsModelFactory
    {
        public static Azure.ResourceManager.Workloads.Models.ApplicationServerVmDetails ApplicationServerVmDetails(Azure.ResourceManager.Workloads.Models.ApplicationServerVirtualMachineType? virtualMachineType = default(Azure.ResourceManager.Workloads.Models.ApplicationServerVirtualMachineType?), Azure.Core.ResourceIdentifier virtualMachineId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> storageDetails = null) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.CentralServerVmDetails CentralServerVmDetails(Azure.ResourceManager.Workloads.Models.CentralServerVirtualMachineType? virtualMachineType = default(Azure.ResourceManager.Workloads.Models.CentralServerVirtualMachineType?), Azure.Core.ResourceIdentifier virtualMachineId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> storageDetails = null) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.DatabaseVmDetails DatabaseVmDetails(Azure.Core.ResourceIdentifier virtualMachineId = null, Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus? status = default(Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> storageDetails = null) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.DiscoveryConfiguration DiscoveryConfiguration(Azure.Core.ResourceIdentifier centralServerVmId = null, string managedRgStorageAccountName = null, Azure.Core.AzureLocation? appLocation = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerProperties EnqueueReplicationServerProperties(Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerType? ersVersion = default(Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerType?), string instanceNo = null, string hostname = null, string kernelVersion = null, string kernelPatch = null, string ipAddress = null, Azure.ResourceManager.Workloads.Models.SapHealthState? health = default(Azure.ResourceManager.Workloads.Models.SapHealthState?)) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.EnqueueServerProperties EnqueueServerProperties(string hostname = null, string ipAddress = null, long? port = default(long?), Azure.ResourceManager.Workloads.Models.SapHealthState? health = default(Azure.ResourceManager.Workloads.Models.SapHealthState?)) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.GatewayServerProperties GatewayServerProperties(long? port = default(long?), Azure.ResourceManager.Workloads.Models.SapHealthState? health = default(Azure.ResourceManager.Workloads.Models.SapHealthState?)) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.MessageServerProperties MessageServerProperties(long? msPort = default(long?), long? internalMsPort = default(long?), long? httpPort = default(long?), long? httpsPort = default(long?), string hostname = null, string ipAddress = null, Azure.ResourceManager.Workloads.Models.SapHealthState? health = default(Azure.ResourceManager.Workloads.Models.SapHealthState?)) { throw null; }
        public static Azure.ResourceManager.Workloads.SapApplicationServerInstanceData SapApplicationServerInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string instanceNo = null, Azure.Core.ResourceIdentifier subnetId = null, string hostname = null, string kernelVersion = null, string kernelPatch = null, string ipAddress = null, long? gatewayPort = default(long?), long? icmHttpPort = default(long?), long? icmHttpsPort = default(long?), Azure.Core.ResourceIdentifier loadBalancerDetailsId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.Models.ApplicationServerVmDetails> vmDetails = null, Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus? status = default(Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus?), Azure.ResourceManager.Workloads.Models.SapHealthState? health = default(Azure.ResourceManager.Workloads.Models.SapHealthState?), Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState? provisioningState = default(Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState?), Azure.ResourceManager.Workloads.Models.SapVirtualInstanceErrorDetail errorsProperties = null) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsResult SapAvailabilityZoneDetailsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.Models.SapAvailabilityZonePair> availabilityZonePairs = null) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SapAvailabilityZonePair SapAvailabilityZonePair(long? zoneA = default(long?), long? zoneB = default(long?)) { throw null; }
        public static Azure.ResourceManager.Workloads.SapCentralServerInstanceData SapCentralServerInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string instanceNo = null, Azure.Core.ResourceIdentifier subnetId = null, Azure.ResourceManager.Workloads.Models.MessageServerProperties messageServerProperties = null, Azure.ResourceManager.Workloads.Models.EnqueueServerProperties enqueueServerProperties = null, Azure.ResourceManager.Workloads.Models.GatewayServerProperties gatewayServerProperties = null, Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerProperties enqueueReplicationServerProperties = null, string kernelVersion = null, string kernelPatch = null, Azure.Core.ResourceIdentifier loadBalancerDetailsId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.Models.CentralServerVmDetails> vmDetails = null, Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus? status = default(Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus?), Azure.ResourceManager.Workloads.Models.SapHealthState? health = default(Azure.ResourceManager.Workloads.Models.SapHealthState?), Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState? provisioningState = default(Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState?), Azure.ResourceManager.Workloads.Models.SapVirtualInstanceErrorDetail errorsProperties = null) { throw null; }
        public static Azure.ResourceManager.Workloads.SapDatabaseInstanceData SapDatabaseInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.Core.ResourceIdentifier subnetId = null, string databaseSid = null, string databaseType = null, string ipAddress = null, Azure.Core.ResourceIdentifier loadBalancerDetailsId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.Models.DatabaseVmDetails> vmDetails = null, Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus? status = default(Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus?), Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState? provisioningState = default(Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState?), Azure.ResourceManager.Workloads.Models.SapVirtualInstanceErrorDetail errorsProperties = null) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SapDiskConfiguration SapDiskConfiguration(Azure.ResourceManager.Workloads.Models.DiskVolumeConfiguration recommendedConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.Models.SupportedConfigurationsDiskDetails> supportedConfigurations = null) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsResult SapDiskConfigurationsResult(System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Workloads.Models.SapDiskConfiguration> volumeConfigurations = null) { throw null; }
        public static Azure.ResourceManager.Workloads.SapLandscapeMonitorData SapLandscapeMonitorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorProvisioningState? provisioningState = default(Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorProvisioningState?), Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorPropertiesGrouping grouping = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorMetricThresholds> topMetricsThresholds = null) { throw null; }
        public static Azure.ResourceManager.Workloads.SapMonitorData SapMonitorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Workloads.Models.UserAssignedServiceIdentity identity = null, Azure.ResourceManager.Workloads.Models.WorkloadMonitorProvisioningState? provisioningState = default(Azure.ResourceManager.Workloads.Models.WorkloadMonitorProvisioningState?), Azure.ResponseError errors = null, Azure.Core.AzureLocation? appLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Workloads.Models.SapRoutingPreference? routingPreference = default(Azure.ResourceManager.Workloads.Models.SapRoutingPreference?), string zoneRedundancyPreference = null, string managedResourceGroupName = null, Azure.Core.ResourceIdentifier logAnalyticsWorkspaceArmId = null, Azure.Core.ResourceIdentifier monitorSubnetId = null, Azure.Core.ResourceIdentifier msiArmId = null, Azure.Core.ResourceIdentifier storageAccountArmId = null) { throw null; }
        public static Azure.ResourceManager.Workloads.SapProviderInstanceData SapProviderInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Workloads.Models.UserAssignedServiceIdentity identity = null, Azure.ResourceManager.Workloads.Models.WorkloadMonitorProvisioningState? provisioningState = default(Azure.ResourceManager.Workloads.Models.WorkloadMonitorProvisioningState?), Azure.ResponseError errors = null, Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties providerSettings = null) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SapSizingRecommendationContent SapSizingRecommendationContent(Azure.Core.AzureLocation appLocation = default(Azure.Core.AzureLocation), Azure.ResourceManager.Workloads.Models.SapEnvironmentType environment = default(Azure.ResourceManager.Workloads.Models.SapEnvironmentType), Azure.ResourceManager.Workloads.Models.SapProductType sapProduct = default(Azure.ResourceManager.Workloads.Models.SapProductType), Azure.ResourceManager.Workloads.Models.SapDeploymentType deploymentType = default(Azure.ResourceManager.Workloads.Models.SapDeploymentType), long saps = (long)0, long dbMemory = (long)0, Azure.ResourceManager.Workloads.Models.SapDatabaseType databaseType = default(Azure.ResourceManager.Workloads.Models.SapDatabaseType), Azure.ResourceManager.Workloads.Models.SapDatabaseScaleMethod? dbScaleMethod = default(Azure.ResourceManager.Workloads.Models.SapDatabaseScaleMethod?), Azure.ResourceManager.Workloads.Models.SapHighAvailabilityType? highAvailabilityType = default(Azure.ResourceManager.Workloads.Models.SapHighAvailabilityType?)) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SapSupportedResourceSkusResult SapSupportedResourceSkusResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.Models.SapSupportedSku> supportedSkus = null) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SapSupportedSku SapSupportedSku(string vmSku = null, bool? isAppServerCertified = default(bool?), bool? isDatabaseCertified = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SapSupportedSkusContent SapSupportedSkusContent(Azure.Core.AzureLocation appLocation = default(Azure.Core.AzureLocation), Azure.ResourceManager.Workloads.Models.SapEnvironmentType environment = default(Azure.ResourceManager.Workloads.Models.SapEnvironmentType), Azure.ResourceManager.Workloads.Models.SapProductType sapProduct = default(Azure.ResourceManager.Workloads.Models.SapProductType), Azure.ResourceManager.Workloads.Models.SapDeploymentType deploymentType = default(Azure.ResourceManager.Workloads.Models.SapDeploymentType), Azure.ResourceManager.Workloads.Models.SapDatabaseType databaseType = default(Azure.ResourceManager.Workloads.Models.SapDatabaseType), Azure.ResourceManager.Workloads.Models.SapHighAvailabilityType? highAvailabilityType = default(Azure.ResourceManager.Workloads.Models.SapHighAvailabilityType?)) { throw null; }
        public static Azure.ResourceManager.Workloads.SapVirtualInstanceData SapVirtualInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Workloads.Models.UserAssignedServiceIdentity identity = null, Azure.ResourceManager.Workloads.Models.SapEnvironmentType environment = default(Azure.ResourceManager.Workloads.Models.SapEnvironmentType), Azure.ResourceManager.Workloads.Models.SapProductType sapProduct = default(Azure.ResourceManager.Workloads.Models.SapProductType), Azure.ResourceManager.Workloads.Models.SapConfiguration configuration = null, string managedResourceGroupName = null, Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus? status = default(Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus?), Azure.ResourceManager.Workloads.Models.SapHealthState? health = default(Azure.ResourceManager.Workloads.Models.SapHealthState?), Azure.ResourceManager.Workloads.Models.SapVirtualInstanceState? state = default(Azure.ResourceManager.Workloads.Models.SapVirtualInstanceState?), Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState? provisioningState = default(Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState?), Azure.ResourceManager.Workloads.Models.SapVirtualInstanceErrorDetail errorsProperties = null) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceErrorDetail SapVirtualInstanceErrorDetail(string code = null, string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.Models.SapVirtualInstanceErrorDetail> details = null) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SingleServerRecommendationResult SingleServerRecommendationResult(string vmSku = null) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SupportedConfigurationsDiskDetails SupportedConfigurationsDiskDetails(Azure.ResourceManager.Workloads.Models.DiskDetailsDiskSkuName? skuName = default(Azure.ResourceManager.Workloads.Models.DiskDetailsDiskSkuName?), long? sizeInGB = default(long?), long? minimumSupportedDiskCount = default(long?), long? maximumSupportedDiskCount = default(long?), long? iopsReadWrite = default(long?), long? mbpsReadWrite = default(long?), string diskTier = null) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.ThreeTierRecommendationResult ThreeTierRecommendationResult(string dbVmSku = null, long? databaseInstanceCount = default(long?), string centralServerVmSku = null, long? centralServerInstanceCount = default(long?), string applicationServerVmSku = null, long? applicationServerInstanceCount = default(long?)) { throw null; }
    }
    public partial class CentralServerConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.CentralServerConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.CentralServerConfiguration>
    {
        public CentralServerConfiguration(Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.Workloads.Models.SapVirtualMachineConfiguration virtualMachineConfiguration, long instanceCount) { }
        public long InstanceCount { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapVirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.CentralServerConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.CentralServerConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.CentralServerConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.CentralServerConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.CentralServerConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.CentralServerConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.CentralServerConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CentralServerFullResourceNames : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.CentralServerFullResourceNames>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.CentralServerFullResourceNames>
    {
        public CentralServerFullResourceNames() { }
        public string AvailabilitySetName { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.LoadBalancerResourceNames LoadBalancer { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Workloads.Models.VirtualMachineResourceNames> VirtualMachines { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.CentralServerFullResourceNames System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.CentralServerFullResourceNames>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.CentralServerFullResourceNames>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.CentralServerFullResourceNames System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.CentralServerFullResourceNames>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.CentralServerFullResourceNames>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.CentralServerFullResourceNames>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CentralServerVirtualMachineType : System.IEquatable<Azure.ResourceManager.Workloads.Models.CentralServerVirtualMachineType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CentralServerVirtualMachineType(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.CentralServerVirtualMachineType Ascs { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.CentralServerVirtualMachineType Ers { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.CentralServerVirtualMachineType ErsInactive { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.CentralServerVirtualMachineType Primary { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.CentralServerVirtualMachineType Secondary { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.CentralServerVirtualMachineType Standby { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.CentralServerVirtualMachineType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.CentralServerVirtualMachineType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.CentralServerVirtualMachineType left, Azure.ResourceManager.Workloads.Models.CentralServerVirtualMachineType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.CentralServerVirtualMachineType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.CentralServerVirtualMachineType left, Azure.ResourceManager.Workloads.Models.CentralServerVirtualMachineType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CentralServerVmDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.CentralServerVmDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.CentralServerVmDetails>
    {
        internal CentralServerVmDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> StorageDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualMachineId { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.CentralServerVirtualMachineType? VirtualMachineType { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.CentralServerVmDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.CentralServerVmDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.CentralServerVmDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.CentralServerVmDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.CentralServerVmDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.CentralServerVmDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.CentralServerVmDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateAndMountFileShareConfiguration : Azure.ResourceManager.Workloads.Models.FileShareConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.CreateAndMountFileShareConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.CreateAndMountFileShareConfiguration>
    {
        public CreateAndMountFileShareConfiguration() { }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.CreateAndMountFileShareConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.CreateAndMountFileShareConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.CreateAndMountFileShareConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.CreateAndMountFileShareConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.CreateAndMountFileShareConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.CreateAndMountFileShareConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.CreateAndMountFileShareConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DatabaseConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DatabaseConfiguration>
    {
        public DatabaseConfiguration(Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.Workloads.Models.SapVirtualMachineConfiguration virtualMachineConfiguration, long instanceCount) { }
        public Azure.ResourceManager.Workloads.Models.SapDatabaseType? DatabaseType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Workloads.Models.DiskVolumeConfiguration> DiskVolumeConfigurations { get { throw null; } }
        public long InstanceCount { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapVirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.DatabaseConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DatabaseConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DatabaseConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.DatabaseConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DatabaseConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DatabaseConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DatabaseConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseServerFullResourceNames : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DatabaseServerFullResourceNames>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DatabaseServerFullResourceNames>
    {
        public DatabaseServerFullResourceNames() { }
        public string AvailabilitySetName { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.LoadBalancerResourceNames LoadBalancer { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Workloads.Models.VirtualMachineResourceNames> VirtualMachines { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.DatabaseServerFullResourceNames System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DatabaseServerFullResourceNames>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DatabaseServerFullResourceNames>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.DatabaseServerFullResourceNames System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DatabaseServerFullResourceNames>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DatabaseServerFullResourceNames>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DatabaseServerFullResourceNames>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseVmDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DatabaseVmDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DatabaseVmDetails>
    {
        internal DatabaseVmDetails() { }
        public Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> StorageDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualMachineId { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.DatabaseVmDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DatabaseVmDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DatabaseVmDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.DatabaseVmDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DatabaseVmDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DatabaseVmDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DatabaseVmDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DB2ProviderInstanceProperties : Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DB2ProviderInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DB2ProviderInstanceProperties>
    {
        public DB2ProviderInstanceProperties() { }
        public string DBName { get { throw null; } set { } }
        public string DBPassword { get { throw null; } set { } }
        public System.Uri DBPasswordUri { get { throw null; } set { } }
        public string DBPort { get { throw null; } set { } }
        public string DBUsername { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public string SapSid { get { throw null; } set { } }
        public System.Uri SslCertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapSslPreference? SslPreference { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.DB2ProviderInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DB2ProviderInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DB2ProviderInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.DB2ProviderInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DB2ProviderInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DB2ProviderInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DB2ProviderInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeployerVmPackages : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DeployerVmPackages>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DeployerVmPackages>
    {
        public DeployerVmPackages() { }
        public System.Uri PackageUri { get { throw null; } set { } }
        public string StorageAccountId { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.DeployerVmPackages System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DeployerVmPackages>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DeployerVmPackages>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.DeployerVmPackages System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DeployerVmPackages>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DeployerVmPackages>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DeployerVmPackages>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentConfiguration : Azure.ResourceManager.Workloads.Models.SapConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DeploymentConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DeploymentConfiguration>
    {
        public DeploymentConfiguration() { }
        public Azure.Core.AzureLocation? AppLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.InfrastructureConfiguration InfrastructureConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapSoftwareConfiguration SoftwareConfiguration { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.DeploymentConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DeploymentConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DeploymentConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.DeploymentConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DeploymentConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DeploymentConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DeploymentConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentWithOSConfiguration : Azure.ResourceManager.Workloads.Models.SapConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DeploymentWithOSConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DeploymentWithOSConfiguration>
    {
        public DeploymentWithOSConfiguration() { }
        public Azure.Core.AzureLocation? AppLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.InfrastructureConfiguration InfrastructureConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.OSSapConfiguration OSSapConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapSoftwareConfiguration SoftwareConfiguration { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.DeploymentWithOSConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DeploymentWithOSConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DeploymentWithOSConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.DeploymentWithOSConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DeploymentWithOSConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DeploymentWithOSConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DeploymentWithOSConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryConfiguration : Azure.ResourceManager.Workloads.Models.SapConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DiscoveryConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DiscoveryConfiguration>
    {
        public DiscoveryConfiguration() { }
        public Azure.Core.AzureLocation? AppLocation { get { throw null; } }
        public Azure.Core.ResourceIdentifier CentralServerVmId { get { throw null; } set { } }
        public string ManagedRgStorageAccountName { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.DiscoveryConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DiscoveryConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DiscoveryConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.DiscoveryConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DiscoveryConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DiscoveryConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DiscoveryConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskDetailsDiskSkuName : System.IEquatable<Azure.ResourceManager.Workloads.Models.DiskDetailsDiskSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskDetailsDiskSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.DiskDetailsDiskSkuName PremiumLrs { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.DiskDetailsDiskSkuName PremiumV2Lrs { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.DiskDetailsDiskSkuName PremiumZrs { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.DiskDetailsDiskSkuName StandardLrs { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.DiskDetailsDiskSkuName StandardSsdLrs { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.DiskDetailsDiskSkuName StandardSsdZrs { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.DiskDetailsDiskSkuName UltraSsdLrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.DiskDetailsDiskSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.DiskDetailsDiskSkuName left, Azure.ResourceManager.Workloads.Models.DiskDetailsDiskSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.DiskDetailsDiskSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.DiskDetailsDiskSkuName left, Azure.ResourceManager.Workloads.Models.DiskDetailsDiskSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskVolumeConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DiskVolumeConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DiskVolumeConfiguration>
    {
        public DiskVolumeConfiguration() { }
        public long? Count { get { throw null; } set { } }
        public long? SizeInGB { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.DiskDetailsDiskSkuName? SkuName { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.DiskVolumeConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DiskVolumeConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.DiskVolumeConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.DiskVolumeConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DiskVolumeConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DiskVolumeConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.DiskVolumeConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnqueueReplicationServerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerProperties>
    {
        public EnqueueReplicationServerProperties() { }
        public Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerType? ErsVersion { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapHealthState? Health { get { throw null; } }
        public string Hostname { get { throw null; } }
        public string InstanceNo { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public string KernelPatch { get { throw null; } }
        public string KernelVersion { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnqueueReplicationServerType : System.IEquatable<Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnqueueReplicationServerType(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerType EnqueueReplicator1 { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerType EnqueueReplicator2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerType left, Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerType left, Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnqueueServerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.EnqueueServerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.EnqueueServerProperties>
    {
        public EnqueueServerProperties() { }
        public Azure.ResourceManager.Workloads.Models.SapHealthState? Health { get { throw null; } }
        public string Hostname { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public long? Port { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.EnqueueServerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.EnqueueServerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.EnqueueServerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.EnqueueServerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.EnqueueServerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.EnqueueServerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.EnqueueServerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExternalInstallationSoftwareConfiguration : Azure.ResourceManager.Workloads.Models.SapSoftwareConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ExternalInstallationSoftwareConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ExternalInstallationSoftwareConfiguration>
    {
        public ExternalInstallationSoftwareConfiguration() { }
        public Azure.Core.ResourceIdentifier CentralServerVmId { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.ExternalInstallationSoftwareConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ExternalInstallationSoftwareConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ExternalInstallationSoftwareConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.ExternalInstallationSoftwareConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ExternalInstallationSoftwareConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ExternalInstallationSoftwareConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ExternalInstallationSoftwareConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class FileShareConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.FileShareConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.FileShareConfiguration>
    {
        protected FileShareConfiguration() { }
        Azure.ResourceManager.Workloads.Models.FileShareConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.FileShareConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.FileShareConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.FileShareConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.FileShareConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.FileShareConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.FileShareConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GatewayServerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.GatewayServerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.GatewayServerProperties>
    {
        public GatewayServerProperties() { }
        public Azure.ResourceManager.Workloads.Models.SapHealthState? Health { get { throw null; } }
        public long? Port { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.GatewayServerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.GatewayServerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.GatewayServerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.GatewayServerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.GatewayServerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.GatewayServerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.GatewayServerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HanaDBProviderInstanceProperties : Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.HanaDBProviderInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.HanaDBProviderInstanceProperties>
    {
        public HanaDBProviderInstanceProperties() { }
        public string DBName { get { throw null; } set { } }
        public string DBPassword { get { throw null; } set { } }
        public System.Uri DBPasswordUri { get { throw null; } set { } }
        public string DBUsername { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public string InstanceNumber { get { throw null; } set { } }
        public string SapSid { get { throw null; } set { } }
        public string SqlPort { get { throw null; } set { } }
        public System.Uri SslCertificateUri { get { throw null; } set { } }
        public string SslHostNameInCertificate { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapSslPreference? SslPreference { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.HanaDBProviderInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.HanaDBProviderInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.HanaDBProviderInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.HanaDBProviderInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.HanaDBProviderInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.HanaDBProviderInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.HanaDBProviderInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HighAvailabilitySoftwareConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.HighAvailabilitySoftwareConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.HighAvailabilitySoftwareConfiguration>
    {
        public HighAvailabilitySoftwareConfiguration(string fencingClientId, string fencingClientPassword) { }
        public string FencingClientId { get { throw null; } set { } }
        public string FencingClientPassword { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.HighAvailabilitySoftwareConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.HighAvailabilitySoftwareConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.HighAvailabilitySoftwareConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.HighAvailabilitySoftwareConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.HighAvailabilitySoftwareConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.HighAvailabilitySoftwareConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.HighAvailabilitySoftwareConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class InfrastructureConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.InfrastructureConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.InfrastructureConfiguration>
    {
        protected InfrastructureConfiguration(string appResourceGroup) { }
        public string AppResourceGroup { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.InfrastructureConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.InfrastructureConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.InfrastructureConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.InfrastructureConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.InfrastructureConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.InfrastructureConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.InfrastructureConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadBalancerResourceNames : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.LoadBalancerResourceNames>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.LoadBalancerResourceNames>
    {
        public LoadBalancerResourceNames() { }
        public System.Collections.Generic.IList<string> BackendPoolNames { get { throw null; } }
        public System.Collections.Generic.IList<string> FrontendIPConfigurationNames { get { throw null; } }
        public System.Collections.Generic.IList<string> HealthProbeNames { get { throw null; } }
        public string LoadBalancerName { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.LoadBalancerResourceNames System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.LoadBalancerResourceNames>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.LoadBalancerResourceNames>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.LoadBalancerResourceNames System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.LoadBalancerResourceNames>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.LoadBalancerResourceNames>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.LoadBalancerResourceNames>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedServiceIdentityType : System.IEquatable<Azure.ResourceManager.Workloads.Models.ManagedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.ManagedServiceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.ManagedServiceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.ManagedServiceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.ManagedServiceIdentityType left, Azure.ResourceManager.Workloads.Models.ManagedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.ManagedServiceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.ManagedServiceIdentityType left, Azure.ResourceManager.Workloads.Models.ManagedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MessageServerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.MessageServerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.MessageServerProperties>
    {
        public MessageServerProperties() { }
        public Azure.ResourceManager.Workloads.Models.SapHealthState? Health { get { throw null; } }
        public string Hostname { get { throw null; } }
        public long? HttpPort { get { throw null; } }
        public long? HttpsPort { get { throw null; } }
        public long? InternalMsPort { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public long? MsPort { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.MessageServerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.MessageServerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.MessageServerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.MessageServerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.MessageServerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.MessageServerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.MessageServerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MountFileShareConfiguration : Azure.ResourceManager.Workloads.Models.FileShareConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.MountFileShareConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.MountFileShareConfiguration>
    {
        public MountFileShareConfiguration(Azure.Core.ResourceIdentifier fileShareId, Azure.Core.ResourceIdentifier privateEndpointId) { }
        public Azure.Core.ResourceIdentifier FileShareId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.MountFileShareConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.MountFileShareConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.MountFileShareConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.MountFileShareConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.MountFileShareConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.MountFileShareConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.MountFileShareConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MsSqlServerProviderInstanceProperties : Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.MsSqlServerProviderInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.MsSqlServerProviderInstanceProperties>
    {
        public MsSqlServerProviderInstanceProperties() { }
        public string DBPassword { get { throw null; } set { } }
        public System.Uri DBPasswordUri { get { throw null; } set { } }
        public string DBPort { get { throw null; } set { } }
        public string DBUsername { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public string SapSid { get { throw null; } set { } }
        public System.Uri SslCertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapSslPreference? SslPreference { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.MsSqlServerProviderInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.MsSqlServerProviderInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.MsSqlServerProviderInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.MsSqlServerProviderInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.MsSqlServerProviderInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.MsSqlServerProviderInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.MsSqlServerProviderInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkInterfaceResourceNames : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.NetworkInterfaceResourceNames>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.NetworkInterfaceResourceNames>
    {
        public NetworkInterfaceResourceNames() { }
        public string NetworkInterfaceName { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.NetworkInterfaceResourceNames System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.NetworkInterfaceResourceNames>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.NetworkInterfaceResourceNames>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.NetworkInterfaceResourceNames System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.NetworkInterfaceResourceNames>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.NetworkInterfaceResourceNames>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.NetworkInterfaceResourceNames>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OSSapConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.OSSapConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.OSSapConfiguration>
    {
        public OSSapConfiguration() { }
        public Azure.ResourceManager.Workloads.Models.DeployerVmPackages DeployerVmPackages { get { throw null; } set { } }
        public string SapFqdn { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.OSSapConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.OSSapConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.OSSapConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.OSSapConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.OSSapConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.OSSapConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.OSSapConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrometheusHAClusterProviderInstanceProperties : Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.PrometheusHAClusterProviderInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.PrometheusHAClusterProviderInstanceProperties>
    {
        public PrometheusHAClusterProviderInstanceProperties() { }
        public string ClusterName { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public System.Uri PrometheusUri { get { throw null; } set { } }
        public string Sid { get { throw null; } set { } }
        public System.Uri SslCertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapSslPreference? SslPreference { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.PrometheusHAClusterProviderInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.PrometheusHAClusterProviderInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.PrometheusHAClusterProviderInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.PrometheusHAClusterProviderInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.PrometheusHAClusterProviderInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.PrometheusHAClusterProviderInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.PrometheusHAClusterProviderInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrometheusOSProviderInstanceProperties : Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.PrometheusOSProviderInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.PrometheusOSProviderInstanceProperties>
    {
        public PrometheusOSProviderInstanceProperties() { }
        public System.Uri PrometheusUri { get { throw null; } set { } }
        public string SapSid { get { throw null; } set { } }
        public System.Uri SslCertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapSslPreference? SslPreference { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.PrometheusOSProviderInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.PrometheusOSProviderInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.PrometheusOSProviderInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.PrometheusOSProviderInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.PrometheusOSProviderInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.PrometheusOSProviderInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.PrometheusOSProviderInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ProviderSpecificProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties>
    {
        protected ProviderSpecificProperties() { }
        Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapApplicationServerInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapApplicationServerInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapApplicationServerInstancePatch>
    {
        public SapApplicationServerInstancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.SapApplicationServerInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapApplicationServerInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapApplicationServerInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapApplicationServerInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapApplicationServerInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapApplicationServerInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapApplicationServerInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapAvailabilityZoneDetailsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsContent>
    {
        public SapAvailabilityZoneDetailsContent(Azure.Core.AzureLocation appLocation, Azure.ResourceManager.Workloads.Models.SapProductType sapProduct, Azure.ResourceManager.Workloads.Models.SapDatabaseType databaseType) { }
        public Azure.Core.AzureLocation AppLocation { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapDatabaseType DatabaseType { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapProductType SapProduct { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapAvailabilityZoneDetailsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsResult>
    {
        internal SapAvailabilityZoneDetailsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Workloads.Models.SapAvailabilityZonePair> AvailabilityZonePairs { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapAvailabilityZoneDetailsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapAvailabilityZonePair : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapAvailabilityZonePair>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapAvailabilityZonePair>
    {
        internal SapAvailabilityZonePair() { }
        public long? ZoneA { get { throw null; } }
        public long? ZoneB { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.SapAvailabilityZonePair System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapAvailabilityZonePair>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapAvailabilityZonePair>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapAvailabilityZonePair System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapAvailabilityZonePair>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapAvailabilityZonePair>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapAvailabilityZonePair>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapCentralServerInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapCentralServerInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapCentralServerInstancePatch>
    {
        public SapCentralServerInstancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.SapCentralServerInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapCentralServerInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapCentralServerInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapCentralServerInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapCentralServerInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapCentralServerInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapCentralServerInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class SapConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapConfiguration>
    {
        protected SapConfiguration() { }
        Azure.ResourceManager.Workloads.Models.SapConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapDatabaseInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapDatabaseInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapDatabaseInstancePatch>
    {
        public SapDatabaseInstancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.SapDatabaseInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapDatabaseInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapDatabaseInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapDatabaseInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapDatabaseInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapDatabaseInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapDatabaseInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapDatabaseScaleMethod : System.IEquatable<Azure.ResourceManager.Workloads.Models.SapDatabaseScaleMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapDatabaseScaleMethod(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SapDatabaseScaleMethod ScaleUp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.SapDatabaseScaleMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.SapDatabaseScaleMethod left, Azure.ResourceManager.Workloads.Models.SapDatabaseScaleMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.SapDatabaseScaleMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.SapDatabaseScaleMethod left, Azure.ResourceManager.Workloads.Models.SapDatabaseScaleMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapDatabaseType : System.IEquatable<Azure.ResourceManager.Workloads.Models.SapDatabaseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapDatabaseType(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SapDatabaseType DB2 { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapDatabaseType Hana { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.SapDatabaseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.SapDatabaseType left, Azure.ResourceManager.Workloads.Models.SapDatabaseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.SapDatabaseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.SapDatabaseType left, Azure.ResourceManager.Workloads.Models.SapDatabaseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapDeploymentType : System.IEquatable<Azure.ResourceManager.Workloads.Models.SapDeploymentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapDeploymentType(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SapDeploymentType SingleServer { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapDeploymentType ThreeTier { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.SapDeploymentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.SapDeploymentType left, Azure.ResourceManager.Workloads.Models.SapDeploymentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.SapDeploymentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.SapDeploymentType left, Azure.ResourceManager.Workloads.Models.SapDeploymentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapDiskConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapDiskConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapDiskConfiguration>
    {
        internal SapDiskConfiguration() { }
        public Azure.ResourceManager.Workloads.Models.DiskVolumeConfiguration RecommendedConfiguration { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Workloads.Models.SupportedConfigurationsDiskDetails> SupportedConfigurations { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.SapDiskConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapDiskConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapDiskConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapDiskConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapDiskConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapDiskConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapDiskConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapDiskConfigurationsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsContent>
    {
        public SapDiskConfigurationsContent(Azure.Core.AzureLocation appLocation, Azure.ResourceManager.Workloads.Models.SapEnvironmentType environment, Azure.ResourceManager.Workloads.Models.SapProductType sapProduct, Azure.ResourceManager.Workloads.Models.SapDatabaseType databaseType, Azure.ResourceManager.Workloads.Models.SapDeploymentType deploymentType, string dbVmSku) { }
        public Azure.Core.AzureLocation AppLocation { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapDatabaseType DatabaseType { get { throw null; } }
        public string DBVmSku { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapDeploymentType DeploymentType { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapEnvironmentType Environment { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapProductType SapProduct { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapDiskConfigurationsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsResult>
    {
        internal SapDiskConfigurationsResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Workloads.Models.SapDiskConfiguration> VolumeConfigurations { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapDiskConfigurationsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapEnvironmentType : System.IEquatable<Azure.ResourceManager.Workloads.Models.SapEnvironmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapEnvironmentType(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SapEnvironmentType NonProd { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapEnvironmentType Prod { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.SapEnvironmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.SapEnvironmentType left, Azure.ResourceManager.Workloads.Models.SapEnvironmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.SapEnvironmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.SapEnvironmentType left, Azure.ResourceManager.Workloads.Models.SapEnvironmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapHealthState : System.IEquatable<Azure.ResourceManager.Workloads.Models.SapHealthState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapHealthState(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SapHealthState Degraded { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapHealthState Healthy { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapHealthState Unhealthy { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapHealthState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.SapHealthState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.SapHealthState left, Azure.ResourceManager.Workloads.Models.SapHealthState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.SapHealthState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.SapHealthState left, Azure.ResourceManager.Workloads.Models.SapHealthState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapHighAvailabilityType : System.IEquatable<Azure.ResourceManager.Workloads.Models.SapHighAvailabilityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapHighAvailabilityType(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SapHighAvailabilityType AvailabilitySet { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapHighAvailabilityType AvailabilityZone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.SapHighAvailabilityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.SapHighAvailabilityType left, Azure.ResourceManager.Workloads.Models.SapHighAvailabilityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.SapHighAvailabilityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.SapHighAvailabilityType left, Azure.ResourceManager.Workloads.Models.SapHighAvailabilityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapImageReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapImageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapImageReference>
    {
        public SapImageReference() { }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.SapImageReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapImageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapImageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapImageReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapImageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapImageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapImageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapInstallWithoutOSConfigSoftwareConfiguration : Azure.ResourceManager.Workloads.Models.SapSoftwareConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapInstallWithoutOSConfigSoftwareConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapInstallWithoutOSConfigSoftwareConfiguration>
    {
        public SapInstallWithoutOSConfigSoftwareConfiguration(System.Uri bomUri, string sapBitsStorageAccountId, string softwareVersion) { }
        public System.Uri BomUri { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.HighAvailabilitySoftwareConfiguration HighAvailabilitySoftwareConfiguration { get { throw null; } set { } }
        public string SapBitsStorageAccountId { get { throw null; } set { } }
        public string SoftwareVersion { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.SapInstallWithoutOSConfigSoftwareConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapInstallWithoutOSConfigSoftwareConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapInstallWithoutOSConfigSoftwareConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapInstallWithoutOSConfigSoftwareConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapInstallWithoutOSConfigSoftwareConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapInstallWithoutOSConfigSoftwareConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapInstallWithoutOSConfigSoftwareConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapLandscapeMonitorMetricThresholds : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorMetricThresholds>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorMetricThresholds>
    {
        public SapLandscapeMonitorMetricThresholds() { }
        public float? Green { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public float? Red { get { throw null; } set { } }
        public float? Yellow { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorMetricThresholds System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorMetricThresholds>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorMetricThresholds>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorMetricThresholds System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorMetricThresholds>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorMetricThresholds>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorMetricThresholds>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapLandscapeMonitorPropertiesGrouping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorPropertiesGrouping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorPropertiesGrouping>
    {
        public SapLandscapeMonitorPropertiesGrouping() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorSidMapping> Landscape { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorSidMapping> SapApplication { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorPropertiesGrouping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorPropertiesGrouping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorPropertiesGrouping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorPropertiesGrouping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorPropertiesGrouping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorPropertiesGrouping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorPropertiesGrouping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapLandscapeMonitorProvisioningState : System.IEquatable<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapLandscapeMonitorProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorProvisioningState left, Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorProvisioningState left, Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapLandscapeMonitorSidMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorSidMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorSidMapping>
    {
        public SapLandscapeMonitorSidMapping() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TopSid { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorSidMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorSidMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorSidMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorSidMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorSidMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorSidMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorSidMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapLinuxConfiguration : Azure.ResourceManager.Workloads.Models.SapOSConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapLinuxConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapLinuxConfiguration>
    {
        public SapLinuxConfiguration() { }
        public bool? DisablePasswordAuthentication { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapSshKeyPair SshKeyPair { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Workloads.Models.SapSshPublicKey> SshPublicKeys { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.SapLinuxConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapLinuxConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapLinuxConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapLinuxConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapLinuxConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapLinuxConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapLinuxConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapMonitorPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapMonitorPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapMonitorPatch>
    {
        public SapMonitorPatch() { }
        public Azure.ResourceManager.Workloads.Models.UserAssignedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.SapMonitorPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapMonitorPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapMonitorPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapMonitorPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapMonitorPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapMonitorPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapMonitorPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapNetWeaverProviderInstanceProperties : Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapNetWeaverProviderInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapNetWeaverProviderInstanceProperties>
    {
        public SapNetWeaverProviderInstanceProperties() { }
        public string SapClientId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SapHostFileEntries { get { throw null; } }
        public string SapHostname { get { throw null; } set { } }
        public string SapInstanceNr { get { throw null; } set { } }
        public string SapPassword { get { throw null; } set { } }
        public System.Uri SapPasswordUri { get { throw null; } set { } }
        public string SapPortNumber { get { throw null; } set { } }
        public string SapSid { get { throw null; } set { } }
        public string SapUsername { get { throw null; } set { } }
        public System.Uri SslCertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapSslPreference? SslPreference { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.SapNetWeaverProviderInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapNetWeaverProviderInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapNetWeaverProviderInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapNetWeaverProviderInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapNetWeaverProviderInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapNetWeaverProviderInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapNetWeaverProviderInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class SapOSConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapOSConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapOSConfiguration>
    {
        protected SapOSConfiguration() { }
        Azure.ResourceManager.Workloads.Models.SapOSConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapOSConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapOSConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapOSConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapOSConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapOSConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapOSConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapOSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapOSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapOSProfile>
    {
        public SapOSProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapOSConfiguration OSConfiguration { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.SapOSProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapOSProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapOSProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapOSProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapOSProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapOSProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapOSProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapProductType : System.IEquatable<Azure.ResourceManager.Workloads.Models.SapProductType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapProductType(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SapProductType Ecc { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapProductType Other { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapProductType S4Hana { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.SapProductType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.SapProductType left, Azure.ResourceManager.Workloads.Models.SapProductType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.SapProductType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.SapProductType left, Azure.ResourceManager.Workloads.Models.SapProductType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapRoutingPreference : System.IEquatable<Azure.ResourceManager.Workloads.Models.SapRoutingPreference>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapRoutingPreference(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SapRoutingPreference Default { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapRoutingPreference RouteAll { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.SapRoutingPreference other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.SapRoutingPreference left, Azure.ResourceManager.Workloads.Models.SapRoutingPreference right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.SapRoutingPreference (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.SapRoutingPreference left, Azure.ResourceManager.Workloads.Models.SapRoutingPreference right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapSizingRecommendationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapSizingRecommendationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSizingRecommendationContent>
    {
        public SapSizingRecommendationContent(Azure.Core.AzureLocation appLocation, Azure.ResourceManager.Workloads.Models.SapEnvironmentType environment, Azure.ResourceManager.Workloads.Models.SapProductType sapProduct, Azure.ResourceManager.Workloads.Models.SapDeploymentType deploymentType, long saps, long dbMemory, Azure.ResourceManager.Workloads.Models.SapDatabaseType databaseType) { }
        public Azure.Core.AzureLocation AppLocation { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapDatabaseType DatabaseType { get { throw null; } }
        public long DBMemory { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapDatabaseScaleMethod? DBScaleMethod { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapDeploymentType DeploymentType { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapEnvironmentType Environment { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapHighAvailabilityType? HighAvailabilityType { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapProductType SapProduct { get { throw null; } }
        public long Saps { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.SapSizingRecommendationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapSizingRecommendationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapSizingRecommendationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapSizingRecommendationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSizingRecommendationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSizingRecommendationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSizingRecommendationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class SapSizingRecommendationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapSizingRecommendationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSizingRecommendationResult>
    {
        protected SapSizingRecommendationResult() { }
        Azure.ResourceManager.Workloads.Models.SapSizingRecommendationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapSizingRecommendationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapSizingRecommendationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapSizingRecommendationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSizingRecommendationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSizingRecommendationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSizingRecommendationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class SapSoftwareConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapSoftwareConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSoftwareConfiguration>
    {
        protected SapSoftwareConfiguration() { }
        Azure.ResourceManager.Workloads.Models.SapSoftwareConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapSoftwareConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapSoftwareConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapSoftwareConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSoftwareConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSoftwareConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSoftwareConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapSshKeyPair : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapSshKeyPair>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSshKeyPair>
    {
        public SapSshKeyPair() { }
        public string PrivateKey { get { throw null; } set { } }
        public string PublicKey { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.SapSshKeyPair System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapSshKeyPair>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapSshKeyPair>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapSshKeyPair System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSshKeyPair>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSshKeyPair>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSshKeyPair>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapSshPublicKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapSshPublicKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSshPublicKey>
    {
        public SapSshPublicKey() { }
        public string KeyData { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.SapSshPublicKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapSshPublicKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapSshPublicKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapSshPublicKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSshPublicKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSshPublicKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSshPublicKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapSslPreference : System.IEquatable<Azure.ResourceManager.Workloads.Models.SapSslPreference>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapSslPreference(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SapSslPreference Disabled { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapSslPreference RootCertificate { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapSslPreference ServerCertificate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.SapSslPreference other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.SapSslPreference left, Azure.ResourceManager.Workloads.Models.SapSslPreference right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.SapSslPreference (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.SapSslPreference left, Azure.ResourceManager.Workloads.Models.SapSslPreference right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapStopContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapStopContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapStopContent>
    {
        public SapStopContent() { }
        public long? SoftStopTimeoutSeconds { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.SapStopContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapStopContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapStopContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapStopContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapStopContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapStopContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapStopContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapSupportedResourceSkusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapSupportedResourceSkusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSupportedResourceSkusResult>
    {
        internal SapSupportedResourceSkusResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Workloads.Models.SapSupportedSku> SupportedSkus { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.SapSupportedResourceSkusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapSupportedResourceSkusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapSupportedResourceSkusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapSupportedResourceSkusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSupportedResourceSkusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSupportedResourceSkusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSupportedResourceSkusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapSupportedSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapSupportedSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSupportedSku>
    {
        internal SapSupportedSku() { }
        public bool? IsAppServerCertified { get { throw null; } }
        public bool? IsDatabaseCertified { get { throw null; } }
        public string VmSku { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.SapSupportedSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapSupportedSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapSupportedSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapSupportedSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSupportedSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSupportedSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSupportedSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapSupportedSkusContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapSupportedSkusContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSupportedSkusContent>
    {
        public SapSupportedSkusContent(Azure.Core.AzureLocation appLocation, Azure.ResourceManager.Workloads.Models.SapEnvironmentType environment, Azure.ResourceManager.Workloads.Models.SapProductType sapProduct, Azure.ResourceManager.Workloads.Models.SapDeploymentType deploymentType, Azure.ResourceManager.Workloads.Models.SapDatabaseType databaseType) { }
        public Azure.Core.AzureLocation AppLocation { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapDatabaseType DatabaseType { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapDeploymentType DeploymentType { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapEnvironmentType Environment { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapHighAvailabilityType? HighAvailabilityType { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapProductType SapProduct { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.SapSupportedSkusContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapSupportedSkusContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapSupportedSkusContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapSupportedSkusContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSupportedSkusContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSupportedSkusContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapSupportedSkusContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapVirtualInstanceErrorDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapVirtualInstanceErrorDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapVirtualInstanceErrorDetail>
    {
        internal SapVirtualInstanceErrorDetail() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Workloads.Models.SapVirtualInstanceErrorDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.SapVirtualInstanceErrorDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapVirtualInstanceErrorDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapVirtualInstanceErrorDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapVirtualInstanceErrorDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapVirtualInstanceErrorDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapVirtualInstanceErrorDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapVirtualInstanceErrorDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapVirtualInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapVirtualInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapVirtualInstancePatch>
    {
        public SapVirtualInstancePatch() { }
        public Azure.ResourceManager.Workloads.Models.UserAssignedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.SapVirtualInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapVirtualInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapVirtualInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapVirtualInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapVirtualInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapVirtualInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapVirtualInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapVirtualInstanceProvisioningState : System.IEquatable<Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapVirtualInstanceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState left, Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState left, Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapVirtualInstanceState : System.IEquatable<Azure.ResourceManager.Workloads.Models.SapVirtualInstanceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapVirtualInstanceState(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceState DiscoveryFailed { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceState DiscoveryInProgress { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceState DiscoveryPending { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceState InfrastructureDeploymentFailed { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceState InfrastructureDeploymentInProgress { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceState InfrastructureDeploymentPending { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceState RegistrationComplete { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceState SoftwareDetectionFailed { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceState SoftwareDetectionInProgress { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceState SoftwareInstallationFailed { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceState SoftwareInstallationInProgress { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceState SoftwareInstallationPending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.SapVirtualInstanceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.SapVirtualInstanceState left, Azure.ResourceManager.Workloads.Models.SapVirtualInstanceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.SapVirtualInstanceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.SapVirtualInstanceState left, Azure.ResourceManager.Workloads.Models.SapVirtualInstanceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapVirtualInstanceStatus : System.IEquatable<Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapVirtualInstanceStatus(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus PartiallyRunning { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus Running { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus SoftShutdown { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus Starting { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus Stopping { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus left, Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus left, Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapVirtualMachineConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapVirtualMachineConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapVirtualMachineConfiguration>
    {
        public SapVirtualMachineConfiguration(string vmSize, Azure.ResourceManager.Workloads.Models.SapImageReference imageReference, Azure.ResourceManager.Workloads.Models.SapOSProfile osProfile) { }
        public Azure.ResourceManager.Workloads.Models.SapImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapOSProfile OSProfile { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.SapVirtualMachineConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapVirtualMachineConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapVirtualMachineConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapVirtualMachineConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapVirtualMachineConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapVirtualMachineConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapVirtualMachineConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapWindowsConfiguration : Azure.ResourceManager.Workloads.Models.SapOSConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapWindowsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapWindowsConfiguration>
    {
        public SapWindowsConfiguration() { }
        Azure.ResourceManager.Workloads.Models.SapWindowsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapWindowsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SapWindowsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SapWindowsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapWindowsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapWindowsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SapWindowsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceInitiatedSoftwareConfiguration : Azure.ResourceManager.Workloads.Models.SapSoftwareConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ServiceInitiatedSoftwareConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ServiceInitiatedSoftwareConfiguration>
    {
        public ServiceInitiatedSoftwareConfiguration(System.Uri bomUri, string softwareVersion, string sapBitsStorageAccountId, string sapFqdn, string sshPrivateKey) { }
        public System.Uri BomUri { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.HighAvailabilitySoftwareConfiguration HighAvailabilitySoftwareConfiguration { get { throw null; } set { } }
        public string SapBitsStorageAccountId { get { throw null; } set { } }
        public string SapFqdn { get { throw null; } set { } }
        public string SoftwareVersion { get { throw null; } set { } }
        public string SshPrivateKey { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.ServiceInitiatedSoftwareConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ServiceInitiatedSoftwareConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ServiceInitiatedSoftwareConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.ServiceInitiatedSoftwareConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ServiceInitiatedSoftwareConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ServiceInitiatedSoftwareConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ServiceInitiatedSoftwareConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharedStorageResourceNames : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SharedStorageResourceNames>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SharedStorageResourceNames>
    {
        public SharedStorageResourceNames() { }
        public string SharedStorageAccountName { get { throw null; } set { } }
        public string SharedStorageAccountPrivateEndPointName { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.SharedStorageResourceNames System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SharedStorageResourceNames>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SharedStorageResourceNames>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SharedStorageResourceNames System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SharedStorageResourceNames>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SharedStorageResourceNames>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SharedStorageResourceNames>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SingleServerConfiguration : Azure.ResourceManager.Workloads.Models.InfrastructureConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SingleServerConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SingleServerConfiguration>
    {
        public SingleServerConfiguration(string appResourceGroup, Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.Workloads.Models.SapVirtualMachineConfiguration virtualMachineConfiguration) : base (default(string)) { }
        public Azure.ResourceManager.Workloads.Models.SingleServerCustomResourceNames CustomResourceNames { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapDatabaseType? DatabaseType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Workloads.Models.DiskVolumeConfiguration> DiskVolumeConfigurations { get { throw null; } }
        public bool? IsSecondaryIPEnabled { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapVirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.SingleServerConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SingleServerConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SingleServerConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SingleServerConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SingleServerConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SingleServerConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SingleServerConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class SingleServerCustomResourceNames : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SingleServerCustomResourceNames>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SingleServerCustomResourceNames>
    {
        protected SingleServerCustomResourceNames() { }
        Azure.ResourceManager.Workloads.Models.SingleServerCustomResourceNames System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SingleServerCustomResourceNames>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SingleServerCustomResourceNames>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SingleServerCustomResourceNames System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SingleServerCustomResourceNames>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SingleServerCustomResourceNames>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SingleServerCustomResourceNames>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SingleServerFullResourceNames : Azure.ResourceManager.Workloads.Models.SingleServerCustomResourceNames, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SingleServerFullResourceNames>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SingleServerFullResourceNames>
    {
        public SingleServerFullResourceNames() { }
        public Azure.ResourceManager.Workloads.Models.VirtualMachineResourceNames VirtualMachine { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.SingleServerFullResourceNames System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SingleServerFullResourceNames>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SingleServerFullResourceNames>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SingleServerFullResourceNames System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SingleServerFullResourceNames>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SingleServerFullResourceNames>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SingleServerFullResourceNames>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SingleServerRecommendationResult : Azure.ResourceManager.Workloads.Models.SapSizingRecommendationResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SingleServerRecommendationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SingleServerRecommendationResult>
    {
        internal SingleServerRecommendationResult() { }
        public string VmSku { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.SingleServerRecommendationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SingleServerRecommendationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SingleServerRecommendationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SingleServerRecommendationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SingleServerRecommendationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SingleServerRecommendationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SingleServerRecommendationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkipFileShareConfiguration : Azure.ResourceManager.Workloads.Models.FileShareConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SkipFileShareConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SkipFileShareConfiguration>
    {
        public SkipFileShareConfiguration() { }
        Azure.ResourceManager.Workloads.Models.SkipFileShareConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SkipFileShareConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SkipFileShareConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SkipFileShareConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SkipFileShareConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SkipFileShareConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SkipFileShareConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportedConfigurationsDiskDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SupportedConfigurationsDiskDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SupportedConfigurationsDiskDetails>
    {
        internal SupportedConfigurationsDiskDetails() { }
        public string DiskTier { get { throw null; } }
        public long? IopsReadWrite { get { throw null; } }
        public long? MaximumSupportedDiskCount { get { throw null; } }
        public long? MbpsReadWrite { get { throw null; } }
        public long? MinimumSupportedDiskCount { get { throw null; } }
        public long? SizeInGB { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.DiskDetailsDiskSkuName? SkuName { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.SupportedConfigurationsDiskDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SupportedConfigurationsDiskDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.SupportedConfigurationsDiskDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.SupportedConfigurationsDiskDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SupportedConfigurationsDiskDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SupportedConfigurationsDiskDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.SupportedConfigurationsDiskDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreeTierConfiguration : Azure.ResourceManager.Workloads.Models.InfrastructureConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ThreeTierConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ThreeTierConfiguration>
    {
        public ThreeTierConfiguration(string appResourceGroup, Azure.ResourceManager.Workloads.Models.CentralServerConfiguration centralServer, Azure.ResourceManager.Workloads.Models.ApplicationServerConfiguration applicationServer, Azure.ResourceManager.Workloads.Models.DatabaseConfiguration databaseServer) : base (default(string)) { }
        public Azure.ResourceManager.Workloads.Models.ApplicationServerConfiguration ApplicationServer { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.CentralServerConfiguration CentralServer { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.ThreeTierCustomResourceNames CustomResourceNames { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.DatabaseConfiguration DatabaseServer { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapHighAvailabilityType? HighAvailabilityType { get { throw null; } set { } }
        public bool? IsSecondaryIPEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.FileShareConfiguration StorageTransportFileShareConfiguration { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.ThreeTierConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ThreeTierConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ThreeTierConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.ThreeTierConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ThreeTierConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ThreeTierConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ThreeTierConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ThreeTierCustomResourceNames : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ThreeTierCustomResourceNames>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ThreeTierCustomResourceNames>
    {
        protected ThreeTierCustomResourceNames() { }
        Azure.ResourceManager.Workloads.Models.ThreeTierCustomResourceNames System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ThreeTierCustomResourceNames>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ThreeTierCustomResourceNames>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.ThreeTierCustomResourceNames System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ThreeTierCustomResourceNames>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ThreeTierCustomResourceNames>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ThreeTierCustomResourceNames>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreeTierFullResourceNames : Azure.ResourceManager.Workloads.Models.ThreeTierCustomResourceNames, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ThreeTierFullResourceNames>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ThreeTierFullResourceNames>
    {
        public ThreeTierFullResourceNames() { }
        public Azure.ResourceManager.Workloads.Models.ApplicationServerFullResourceNames ApplicationServer { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.CentralServerFullResourceNames CentralServer { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.DatabaseServerFullResourceNames DatabaseServer { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SharedStorageResourceNames SharedStorage { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.ThreeTierFullResourceNames System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ThreeTierFullResourceNames>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ThreeTierFullResourceNames>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.ThreeTierFullResourceNames System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ThreeTierFullResourceNames>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ThreeTierFullResourceNames>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ThreeTierFullResourceNames>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreeTierRecommendationResult : Azure.ResourceManager.Workloads.Models.SapSizingRecommendationResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ThreeTierRecommendationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ThreeTierRecommendationResult>
    {
        internal ThreeTierRecommendationResult() { }
        public long? ApplicationServerInstanceCount { get { throw null; } }
        public string ApplicationServerVmSku { get { throw null; } }
        public long? CentralServerInstanceCount { get { throw null; } }
        public string CentralServerVmSku { get { throw null; } }
        public long? DatabaseInstanceCount { get { throw null; } }
        public string DBVmSku { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.ThreeTierRecommendationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ThreeTierRecommendationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.ThreeTierRecommendationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.ThreeTierRecommendationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ThreeTierRecommendationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ThreeTierRecommendationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.ThreeTierRecommendationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserAssignedServiceIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.UserAssignedServiceIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.UserAssignedServiceIdentity>
    {
        public UserAssignedServiceIdentity(Azure.ResourceManager.Workloads.Models.ManagedServiceIdentityType managedServiceIdentityType) { }
        public Azure.ResourceManager.Workloads.Models.ManagedServiceIdentityType ManagedServiceIdentityType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        Azure.ResourceManager.Workloads.Models.UserAssignedServiceIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.UserAssignedServiceIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.UserAssignedServiceIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.UserAssignedServiceIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.UserAssignedServiceIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.UserAssignedServiceIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.UserAssignedServiceIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineResourceNames : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.VirtualMachineResourceNames>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.VirtualMachineResourceNames>
    {
        public VirtualMachineResourceNames() { }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> DataDiskNames { get { throw null; } }
        public string HostName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Workloads.Models.NetworkInterfaceResourceNames> NetworkInterfaces { get { throw null; } }
        public string OSDiskName { get { throw null; } set { } }
        public string VmName { get { throw null; } set { } }
        Azure.ResourceManager.Workloads.Models.VirtualMachineResourceNames System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.VirtualMachineResourceNames>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Workloads.Models.VirtualMachineResourceNames>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Workloads.Models.VirtualMachineResourceNames System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.VirtualMachineResourceNames>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.VirtualMachineResourceNames>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Workloads.Models.VirtualMachineResourceNames>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadMonitorProvisioningState : System.IEquatable<Azure.ResourceManager.Workloads.Models.WorkloadMonitorProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadMonitorProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.WorkloadMonitorProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.WorkloadMonitorProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.WorkloadMonitorProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.WorkloadMonitorProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.WorkloadMonitorProvisioningState Migrating { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.WorkloadMonitorProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.WorkloadMonitorProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.WorkloadMonitorProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.WorkloadMonitorProvisioningState left, Azure.ResourceManager.Workloads.Models.WorkloadMonitorProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.WorkloadMonitorProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.WorkloadMonitorProvisioningState left, Azure.ResourceManager.Workloads.Models.WorkloadMonitorProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
