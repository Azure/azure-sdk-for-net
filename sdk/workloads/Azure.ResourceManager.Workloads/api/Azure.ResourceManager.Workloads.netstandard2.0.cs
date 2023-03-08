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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapApplicationServerInstanceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SapApplicationServerInstanceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult> StopInstance(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.StopRequest body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult>> StopInstanceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.StopRequest body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.SapCentralServerInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapCentralServerInstanceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SapCentralServerInstanceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult> StopInstance(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.StopRequest body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult>> StopInstanceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.StopRequest body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapDatabaseInstanceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SapDatabaseInstanceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string DatabaseSid { get { throw null; } }
        public string DatabaseType { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapVirtualInstanceErrorDetail ErrorsProperties { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public Azure.Core.ResourceIdentifier LoadBalancerDetailsId { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus? Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Workloads.Models.DatabaseVmDetails> VmDetails { get { throw null; } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult> StopInstance(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.StopRequest body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult>> StopInstanceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.StopRequest body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.SapDatabaseInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.SapDatabaseInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SapLandscapeMonitorData : Azure.ResourceManager.Models.ResourceData
    {
        public SapLandscapeMonitorData() { }
        public Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorPropertiesGrouping Grouping { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorMetricThresholds> TopMetricsThresholds { get { throw null; } }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Workloads.SapMonitorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Workloads.SapMonitorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Workloads.SapMonitorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.SapMonitorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapMonitorData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SapMonitorData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.Core.AzureLocation? AppLocation { get { throw null; } set { } }
        public Azure.ResponseError Errors { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.UserAssignedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogAnalyticsWorkspaceArmId { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MonitorSubnetId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MsiArmId { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.WorkloadMonitorProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.RoutingPreference? RoutingPreference { get { throw null; } set { } }
        public string StorageAccountArmId { get { throw null; } }
        public string ZoneRedundancyPreference { get { throw null; } set { } }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Workloads.SapProviderInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Workloads.SapProviderInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Workloads.SapProviderInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.SapProviderInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapProviderInstanceData : Azure.ResourceManager.Models.ResourceData
    {
        public SapProviderInstanceData() { }
        public Azure.ResponseError Errors { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.UserAssignedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties ProviderSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.WorkloadMonitorProvisioningState? ProvisioningState { get { throw null; } }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Workloads.SapVirtualInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Workloads.SapVirtualInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Workloads.SapVirtualInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.SapVirtualInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapVirtualInstanceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SapVirtualInstanceData(Azure.Core.AzureLocation location, Azure.ResourceManager.Workloads.Models.SapEnvironmentType environment, Azure.ResourceManager.Workloads.Models.SapProductType sapProduct, Azure.ResourceManager.Workloads.Models.SapConfiguration configuration) : base (default(Azure.Core.AzureLocation)) { }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult> Stop(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.StopRequest body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult>> StopAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.StopRequest body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
namespace Azure.ResourceManager.Workloads.Mock
{
    public partial class ResourceGroupResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ResourceGroupResourceExtensionClient() { }
        public virtual Azure.ResourceManager.Workloads.SapMonitorCollection GetSapMonitors() { throw null; }
        public virtual Azure.ResourceManager.Workloads.SapVirtualInstanceCollection GetSapVirtualInstances() { throw null; }
    }
    public partial class SapMonitorResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected SapMonitorResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Workloads.SapMonitorResource> GetSapMonitors(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Workloads.SapMonitorResource> GetSapMonitorsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SapVirtualInstanceResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected SapVirtualInstanceResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Workloads.SapVirtualInstanceResource> GetSapVirtualInstances(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Workloads.SapVirtualInstanceResource> GetSapVirtualInstancesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected SubscriptionResourceExtensionClient() { }
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
    public partial class ApplicationServerConfiguration
    {
        public ApplicationServerConfiguration(Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.Workloads.Models.VirtualMachineConfiguration virtualMachineConfiguration, long instanceCount) { }
        public long InstanceCount { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.VirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
    }
    public partial class ApplicationServerFullResourceNames
    {
        public ApplicationServerFullResourceNames() { }
        public string AvailabilitySetName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Workloads.Models.VirtualMachineResourceNames> VirtualMachines { get { throw null; } }
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
    public partial class ApplicationServerVmDetails
    {
        internal ApplicationServerVmDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> StorageDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualMachineId { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.ApplicationServerVirtualMachineType? VirtualMachineType { get { throw null; } }
    }
    public partial class CentralServerConfiguration
    {
        public CentralServerConfiguration(Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.Workloads.Models.VirtualMachineConfiguration virtualMachineConfiguration, long instanceCount) { }
        public long InstanceCount { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.VirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
    }
    public partial class CentralServerFullResourceNames
    {
        public CentralServerFullResourceNames() { }
        public string AvailabilitySetName { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.LoadBalancerResourceNames LoadBalancer { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Workloads.Models.VirtualMachineResourceNames> VirtualMachines { get { throw null; } }
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
    public partial class CentralServerVmDetails
    {
        internal CentralServerVmDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> StorageDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualMachineId { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.CentralServerVirtualMachineType? VirtualMachineType { get { throw null; } }
    }
    public partial class CreateAndMountFileShareConfiguration : Azure.ResourceManager.Workloads.Models.FileShareConfiguration
    {
        public CreateAndMountFileShareConfiguration() { }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
    }
    public partial class DatabaseConfiguration
    {
        public DatabaseConfiguration(Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.Workloads.Models.VirtualMachineConfiguration virtualMachineConfiguration, long instanceCount) { }
        public Azure.ResourceManager.Workloads.Models.SapDatabaseType? DatabaseType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Workloads.Models.DiskVolumeConfiguration> DiskVolumeConfigurations { get { throw null; } }
        public long InstanceCount { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.VirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
    }
    public partial class DatabaseServerFullResourceNames
    {
        public DatabaseServerFullResourceNames() { }
        public string AvailabilitySetName { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.LoadBalancerResourceNames LoadBalancer { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Workloads.Models.VirtualMachineResourceNames> VirtualMachines { get { throw null; } }
    }
    public partial class DatabaseVmDetails
    {
        internal DatabaseVmDetails() { }
        public Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> StorageDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualMachineId { get { throw null; } }
    }
    public partial class DB2ProviderInstanceProperties : Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties
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
        public Azure.ResourceManager.Workloads.Models.SslPreference? SslPreference { get { throw null; } set { } }
    }
    public partial class DeployerVmPackages
    {
        public DeployerVmPackages() { }
        public string StorageAccountId { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class DeploymentConfiguration : Azure.ResourceManager.Workloads.Models.SapConfiguration
    {
        public DeploymentConfiguration() { }
        public Azure.Core.AzureLocation? AppLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.InfrastructureConfiguration InfrastructureConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SoftwareConfiguration SoftwareConfiguration { get { throw null; } set { } }
    }
    public partial class DeploymentWithOSConfiguration : Azure.ResourceManager.Workloads.Models.SapConfiguration
    {
        public DeploymentWithOSConfiguration() { }
        public Azure.Core.AzureLocation? AppLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.InfrastructureConfiguration InfrastructureConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.OSSapConfiguration OSSapConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SoftwareConfiguration SoftwareConfiguration { get { throw null; } set { } }
    }
    public partial class DiscoveryConfiguration : Azure.ResourceManager.Workloads.Models.SapConfiguration
    {
        public DiscoveryConfiguration() { }
        public Azure.Core.AzureLocation? AppLocation { get { throw null; } }
        public string CentralServerVmId { get { throw null; } set { } }
        public string ManagedRgStorageAccountName { get { throw null; } set { } }
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
    public partial class DiskVolumeConfiguration
    {
        public DiskVolumeConfiguration() { }
        public long? Count { get { throw null; } set { } }
        public long? SizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.DiskDetailsDiskSkuName? SkuName { get { throw null; } set { } }
    }
    public partial class EnqueueReplicationServerProperties
    {
        public EnqueueReplicationServerProperties() { }
        public Azure.ResourceManager.Workloads.Models.EnqueueReplicationServerType? ErsVersion { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapHealthState? Health { get { throw null; } }
        public string Hostname { get { throw null; } }
        public string InstanceNo { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public string KernelPatch { get { throw null; } }
        public string KernelVersion { get { throw null; } }
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
    public partial class EnqueueServerProperties
    {
        public EnqueueServerProperties() { }
        public Azure.ResourceManager.Workloads.Models.SapHealthState? Health { get { throw null; } }
        public string Hostname { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public long? Port { get { throw null; } }
    }
    public partial class ExternalInstallationSoftwareConfiguration : Azure.ResourceManager.Workloads.Models.SoftwareConfiguration
    {
        public ExternalInstallationSoftwareConfiguration() { }
        public string CentralServerVmId { get { throw null; } set { } }
    }
    public abstract partial class FileShareConfiguration
    {
        protected FileShareConfiguration() { }
    }
    public partial class GatewayServerProperties
    {
        public GatewayServerProperties() { }
        public Azure.ResourceManager.Workloads.Models.SapHealthState? Health { get { throw null; } }
        public long? Port { get { throw null; } }
    }
    public partial class HanaDBProviderInstanceProperties : Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties
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
        public Azure.ResourceManager.Workloads.Models.SslPreference? SslPreference { get { throw null; } set { } }
    }
    public partial class HighAvailabilitySoftwareConfiguration
    {
        public HighAvailabilitySoftwareConfiguration(string fencingClientId, string fencingClientPassword) { }
        public string FencingClientId { get { throw null; } set { } }
        public string FencingClientPassword { get { throw null; } set { } }
    }
    public partial class ImageReference
    {
        public ImageReference() { }
        public string ExactVersion { get { throw null; } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string SharedGalleryImageId { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public abstract partial class InfrastructureConfiguration
    {
        protected InfrastructureConfiguration(string appResourceGroup) { }
        public string AppResourceGroup { get { throw null; } set { } }
    }
    public partial class LinuxConfiguration : Azure.ResourceManager.Workloads.Models.OSConfiguration
    {
        public LinuxConfiguration() { }
        public bool? DisablePasswordAuthentication { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SshKeyPair SshKeyPair { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Workloads.Models.SshPublicKey> SshPublicKeys { get { throw null; } }
    }
    public partial class LoadBalancerResourceNames
    {
        public LoadBalancerResourceNames() { }
        public System.Collections.Generic.IList<string> BackendPoolNames { get { throw null; } }
        public System.Collections.Generic.IList<string> FrontendIPConfigurationNames { get { throw null; } }
        public System.Collections.Generic.IList<string> HealthProbeNames { get { throw null; } }
        public string LoadBalancerName { get { throw null; } set { } }
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
    public partial class MessageServerProperties
    {
        public MessageServerProperties() { }
        public Azure.ResourceManager.Workloads.Models.SapHealthState? Health { get { throw null; } }
        public string Hostname { get { throw null; } }
        public long? HttpPort { get { throw null; } }
        public long? HttpsPort { get { throw null; } }
        public long? InternalMsPort { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public long? MsPort { get { throw null; } }
    }
    public partial class MountFileShareConfiguration : Azure.ResourceManager.Workloads.Models.FileShareConfiguration
    {
        public MountFileShareConfiguration(string id, string privateEndpointId) { }
        public string Id { get { throw null; } set { } }
        public string PrivateEndpointId { get { throw null; } set { } }
    }
    public partial class MsSqlServerProviderInstanceProperties : Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties
    {
        public MsSqlServerProviderInstanceProperties() { }
        public string DBPassword { get { throw null; } set { } }
        public System.Uri DBPasswordUri { get { throw null; } set { } }
        public string DBPort { get { throw null; } set { } }
        public string DBUsername { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public string SapSid { get { throw null; } set { } }
        public System.Uri SslCertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SslPreference? SslPreference { get { throw null; } set { } }
    }
    public partial class NetworkInterfaceResourceNames
    {
        public NetworkInterfaceResourceNames() { }
        public string NetworkInterfaceName { get { throw null; } set { } }
    }
    public abstract partial class OSConfiguration
    {
        protected OSConfiguration() { }
    }
    public partial class OSProfile
    {
        public OSProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.OSConfiguration OSConfiguration { get { throw null; } set { } }
    }
    public partial class OSSapConfiguration
    {
        public OSSapConfiguration() { }
        public Azure.ResourceManager.Workloads.Models.DeployerVmPackages DeployerVmPackages { get { throw null; } set { } }
        public string SapFqdn { get { throw null; } set { } }
    }
    public partial class PrometheusHAClusterProviderInstanceProperties : Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties
    {
        public PrometheusHAClusterProviderInstanceProperties() { }
        public string ClusterName { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public System.Uri PrometheusUri { get { throw null; } set { } }
        public string Sid { get { throw null; } set { } }
        public System.Uri SslCertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SslPreference? SslPreference { get { throw null; } set { } }
    }
    public partial class PrometheusOSProviderInstanceProperties : Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties
    {
        public PrometheusOSProviderInstanceProperties() { }
        public System.Uri PrometheusUri { get { throw null; } set { } }
        public string SapSid { get { throw null; } set { } }
        public System.Uri SslCertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SslPreference? SslPreference { get { throw null; } set { } }
    }
    public abstract partial class ProviderSpecificProperties
    {
        protected ProviderSpecificProperties() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoutingPreference : System.IEquatable<Azure.ResourceManager.Workloads.Models.RoutingPreference>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoutingPreference(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.RoutingPreference Default { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.RoutingPreference RouteAll { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.RoutingPreference other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.RoutingPreference left, Azure.ResourceManager.Workloads.Models.RoutingPreference right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.RoutingPreference (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.RoutingPreference left, Azure.ResourceManager.Workloads.Models.RoutingPreference right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapApplicationServerInstancePatch
    {
        public SapApplicationServerInstancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class SapAvailabilityZoneDetailsContent
    {
        public SapAvailabilityZoneDetailsContent(Azure.Core.AzureLocation appLocation, Azure.ResourceManager.Workloads.Models.SapProductType sapProduct, Azure.ResourceManager.Workloads.Models.SapDatabaseType databaseType) { }
        public Azure.Core.AzureLocation AppLocation { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapDatabaseType DatabaseType { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapProductType SapProduct { get { throw null; } }
    }
    public partial class SapAvailabilityZoneDetailsResult
    {
        internal SapAvailabilityZoneDetailsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Workloads.Models.SapAvailabilityZonePair> AvailabilityZonePairs { get { throw null; } }
    }
    public partial class SapAvailabilityZonePair
    {
        internal SapAvailabilityZonePair() { }
        public long? ZoneA { get { throw null; } }
        public long? ZoneB { get { throw null; } }
    }
    public partial class SapCentralServerInstancePatch
    {
        public SapCentralServerInstancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public abstract partial class SapConfiguration
    {
        protected SapConfiguration() { }
    }
    public partial class SapDatabaseInstancePatch
    {
        public SapDatabaseInstancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
    public partial class SapDiskConfiguration
    {
        internal SapDiskConfiguration() { }
        public Azure.ResourceManager.Workloads.Models.DiskVolumeConfiguration RecommendedConfiguration { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Workloads.Models.SupportedConfigurationsDiskDetails> SupportedConfigurations { get { throw null; } }
    }
    public partial class SapDiskConfigurationsContent
    {
        public SapDiskConfigurationsContent(Azure.Core.AzureLocation appLocation, Azure.ResourceManager.Workloads.Models.SapEnvironmentType environment, Azure.ResourceManager.Workloads.Models.SapProductType sapProduct, Azure.ResourceManager.Workloads.Models.SapDatabaseType databaseType, Azure.ResourceManager.Workloads.Models.SapDeploymentType deploymentType, string dbVmSku) { }
        public Azure.Core.AzureLocation AppLocation { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapDatabaseType DatabaseType { get { throw null; } }
        public string DBVmSku { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapDeploymentType DeploymentType { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapEnvironmentType Environment { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapProductType SapProduct { get { throw null; } }
    }
    public partial class SapDiskConfigurationsResult
    {
        internal SapDiskConfigurationsResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Workloads.Models.SapDiskConfiguration> VolumeConfigurations { get { throw null; } }
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
    public partial class SapInstallWithoutOSConfigSoftwareConfiguration : Azure.ResourceManager.Workloads.Models.SoftwareConfiguration
    {
        public SapInstallWithoutOSConfigSoftwareConfiguration(System.Uri bomUri, string sapBitsStorageAccountId, string softwareVersion) { }
        public System.Uri BomUri { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.HighAvailabilitySoftwareConfiguration HighAvailabilitySoftwareConfiguration { get { throw null; } set { } }
        public string SapBitsStorageAccountId { get { throw null; } set { } }
        public string SoftwareVersion { get { throw null; } set { } }
    }
    public partial class SapLandscapeMonitorMetricThresholds
    {
        public SapLandscapeMonitorMetricThresholds() { }
        public float? Green { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public float? Red { get { throw null; } set { } }
        public float? Yellow { get { throw null; } set { } }
    }
    public partial class SapLandscapeMonitorPropertiesGrouping
    {
        public SapLandscapeMonitorPropertiesGrouping() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorSidMapping> Landscape { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Workloads.Models.SapLandscapeMonitorSidMapping> SapApplication { get { throw null; } }
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
    public partial class SapLandscapeMonitorSidMapping
    {
        public SapLandscapeMonitorSidMapping() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TopSid { get { throw null; } }
    }
    public partial class SapMonitorPatch
    {
        public SapMonitorPatch() { }
        public Azure.ResourceManager.Workloads.Models.UserAssignedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class SapNetWeaverProviderInstanceProperties : Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties
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
        public Azure.ResourceManager.Workloads.Models.SslPreference? SslPreference { get { throw null; } set { } }
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
    public partial class SapSizingRecommendationContent
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
    }
    public abstract partial class SapSizingRecommendationResult
    {
        protected SapSizingRecommendationResult() { }
    }
    public partial class SapSupportedResourceSkusResult
    {
        internal SapSupportedResourceSkusResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Workloads.Models.SapSupportedSku> SupportedSkus { get { throw null; } }
    }
    public partial class SapSupportedSku
    {
        internal SapSupportedSku() { }
        public bool? IsAppServerCertified { get { throw null; } }
        public bool? IsDatabaseCertified { get { throw null; } }
        public string VmSku { get { throw null; } }
    }
    public partial class SapSupportedSkusContent
    {
        public SapSupportedSkusContent(Azure.Core.AzureLocation appLocation, Azure.ResourceManager.Workloads.Models.SapEnvironmentType environment, Azure.ResourceManager.Workloads.Models.SapProductType sapProduct, Azure.ResourceManager.Workloads.Models.SapDeploymentType deploymentType, Azure.ResourceManager.Workloads.Models.SapDatabaseType databaseType) { }
        public Azure.Core.AzureLocation AppLocation { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapDatabaseType DatabaseType { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapDeploymentType DeploymentType { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapEnvironmentType Environment { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapHighAvailabilityType? HighAvailabilityType { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapProductType SapProduct { get { throw null; } }
    }
    public partial class SapVirtualInstanceErrorDetail
    {
        internal SapVirtualInstanceErrorDetail() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Workloads.Models.SapVirtualInstanceErrorDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class SapVirtualInstancePatch
    {
        public SapVirtualInstancePatch() { }
        public Azure.ResourceManager.Workloads.Models.UserAssignedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
    public partial class ServiceInitiatedSoftwareConfiguration : Azure.ResourceManager.Workloads.Models.SoftwareConfiguration
    {
        public ServiceInitiatedSoftwareConfiguration(System.Uri bomUri, string softwareVersion, string sapBitsStorageAccountId, string sapFqdn, string sshPrivateKey) { }
        public System.Uri BomUri { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.HighAvailabilitySoftwareConfiguration HighAvailabilitySoftwareConfiguration { get { throw null; } set { } }
        public string SapBitsStorageAccountId { get { throw null; } set { } }
        public string SapFqdn { get { throw null; } set { } }
        public string SoftwareVersion { get { throw null; } set { } }
        public string SshPrivateKey { get { throw null; } set { } }
    }
    public partial class SharedStorageResourceNames
    {
        public SharedStorageResourceNames() { }
        public string SharedStorageAccountName { get { throw null; } set { } }
        public string SharedStorageAccountPrivateEndPointName { get { throw null; } set { } }
    }
    public partial class SingleServerConfiguration : Azure.ResourceManager.Workloads.Models.InfrastructureConfiguration
    {
        public SingleServerConfiguration(string appResourceGroup, Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.Workloads.Models.VirtualMachineConfiguration virtualMachineConfiguration) : base (default(string)) { }
        public Azure.ResourceManager.Workloads.Models.SingleServerCustomResourceNames CustomResourceNames { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapDatabaseType? DatabaseType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Workloads.Models.DiskVolumeConfiguration> DiskVolumeConfigurations { get { throw null; } }
        public bool? IsSecondaryIPEnabled { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.VirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
    }
    public abstract partial class SingleServerCustomResourceNames
    {
        protected SingleServerCustomResourceNames() { }
    }
    public partial class SingleServerFullResourceNames : Azure.ResourceManager.Workloads.Models.SingleServerCustomResourceNames
    {
        public SingleServerFullResourceNames() { }
        public Azure.ResourceManager.Workloads.Models.VirtualMachineResourceNames VirtualMachine { get { throw null; } set { } }
    }
    public partial class SingleServerRecommendationResult : Azure.ResourceManager.Workloads.Models.SapSizingRecommendationResult
    {
        internal SingleServerRecommendationResult() { }
        public string VmSku { get { throw null; } }
    }
    public partial class SkipFileShareConfiguration : Azure.ResourceManager.Workloads.Models.FileShareConfiguration
    {
        public SkipFileShareConfiguration() { }
    }
    public abstract partial class SoftwareConfiguration
    {
        protected SoftwareConfiguration() { }
    }
    public partial class SshKeyPair
    {
        public SshKeyPair() { }
        public string PrivateKey { get { throw null; } set { } }
        public string PublicKey { get { throw null; } set { } }
    }
    public partial class SshPublicKey
    {
        public SshPublicKey() { }
        public string KeyData { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SslPreference : System.IEquatable<Azure.ResourceManager.Workloads.Models.SslPreference>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SslPreference(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SslPreference Disabled { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SslPreference RootCertificate { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SslPreference ServerCertificate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.SslPreference other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.SslPreference left, Azure.ResourceManager.Workloads.Models.SslPreference right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.SslPreference (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.SslPreference left, Azure.ResourceManager.Workloads.Models.SslPreference right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StopRequest
    {
        public StopRequest() { }
        public long? SoftStopTimeoutSeconds { get { throw null; } set { } }
    }
    public partial class SupportedConfigurationsDiskDetails
    {
        internal SupportedConfigurationsDiskDetails() { }
        public string DiskTier { get { throw null; } }
        public long? IopsReadWrite { get { throw null; } }
        public long? MaximumSupportedDiskCount { get { throw null; } }
        public long? MbpsReadWrite { get { throw null; } }
        public long? MinimumSupportedDiskCount { get { throw null; } }
        public long? SizeGB { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.DiskDetailsDiskSkuName? SkuName { get { throw null; } }
    }
    public partial class ThreeTierConfiguration : Azure.ResourceManager.Workloads.Models.InfrastructureConfiguration
    {
        public ThreeTierConfiguration(string appResourceGroup, Azure.ResourceManager.Workloads.Models.CentralServerConfiguration centralServer, Azure.ResourceManager.Workloads.Models.ApplicationServerConfiguration applicationServer, Azure.ResourceManager.Workloads.Models.DatabaseConfiguration databaseServer) : base (default(string)) { }
        public Azure.ResourceManager.Workloads.Models.ApplicationServerConfiguration ApplicationServer { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.CentralServerConfiguration CentralServer { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.ThreeTierCustomResourceNames CustomResourceNames { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.DatabaseConfiguration DatabaseServer { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapHighAvailabilityType? HighAvailabilityType { get { throw null; } set { } }
        public bool? IsSecondaryIPEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.FileShareConfiguration StorageTransportFileShareConfiguration { get { throw null; } set { } }
    }
    public abstract partial class ThreeTierCustomResourceNames
    {
        protected ThreeTierCustomResourceNames() { }
    }
    public partial class ThreeTierFullResourceNames : Azure.ResourceManager.Workloads.Models.ThreeTierCustomResourceNames
    {
        public ThreeTierFullResourceNames() { }
        public Azure.ResourceManager.Workloads.Models.ApplicationServerFullResourceNames ApplicationServer { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.CentralServerFullResourceNames CentralServer { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.DatabaseServerFullResourceNames DatabaseServer { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SharedStorageResourceNames SharedStorage { get { throw null; } set { } }
    }
    public partial class ThreeTierRecommendationResult : Azure.ResourceManager.Workloads.Models.SapSizingRecommendationResult
    {
        internal ThreeTierRecommendationResult() { }
        public long? ApplicationServerInstanceCount { get { throw null; } }
        public string ApplicationServerVmSku { get { throw null; } }
        public long? CentralServerInstanceCount { get { throw null; } }
        public string CentralServerVmSku { get { throw null; } }
        public long? DatabaseInstanceCount { get { throw null; } }
        public string DBVmSku { get { throw null; } }
    }
    public partial class UserAssignedServiceIdentity
    {
        public UserAssignedServiceIdentity(Azure.ResourceManager.Workloads.Models.ManagedServiceIdentityType managedServiceIdentityType) { }
        public Azure.ResourceManager.Workloads.Models.ManagedServiceIdentityType ManagedServiceIdentityType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    public partial class VirtualMachineConfiguration
    {
        public VirtualMachineConfiguration(string vmSize, Azure.ResourceManager.Workloads.Models.ImageReference imageReference, Azure.ResourceManager.Workloads.Models.OSProfile osProfile) { }
        public Azure.ResourceManager.Workloads.Models.ImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.OSProfile OSProfile { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class VirtualMachineResourceNames
    {
        public VirtualMachineResourceNames() { }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> DataDiskNames { get { throw null; } }
        public string HostName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Workloads.Models.NetworkInterfaceResourceNames> NetworkInterfaces { get { throw null; } }
        public string OSDiskName { get { throw null; } set { } }
        public string VmName { get { throw null; } set { } }
    }
    public partial class WindowsConfiguration : Azure.ResourceManager.Workloads.Models.OSConfiguration
    {
        public WindowsConfiguration() { }
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
