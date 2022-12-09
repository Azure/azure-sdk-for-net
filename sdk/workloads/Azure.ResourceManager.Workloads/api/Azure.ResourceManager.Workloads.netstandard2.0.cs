namespace Azure.ResourceManager.Workloads
{
    public partial class PhpWorkloadResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PhpWorkloadResource() { }
        public virtual Azure.ResourceManager.Workloads.PhpWorkloadResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.PhpWorkloadResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.PhpWorkloadResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string phpWorkloadName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string deleteInfra = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string deleteInfra = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.PhpWorkloadResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.PhpWorkloadResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Workloads.WordPressInstanceResource GetWordPressInstanceResource() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.PhpWorkloadResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.PhpWorkloadResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.PhpWorkloadResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.PhpWorkloadResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.PhpWorkloadResource> Update(Azure.ResourceManager.Workloads.Models.PhpWorkloadResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.PhpWorkloadResource>> UpdateAsync(Azure.ResourceManager.Workloads.Models.PhpWorkloadResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PhpWorkloadResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Workloads.PhpWorkloadResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.PhpWorkloadResource>, System.Collections.IEnumerable
    {
        protected PhpWorkloadResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.PhpWorkloadResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string phpWorkloadName, Azure.ResourceManager.Workloads.PhpWorkloadResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.PhpWorkloadResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string phpWorkloadName, Azure.ResourceManager.Workloads.PhpWorkloadResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string phpWorkloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string phpWorkloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.PhpWorkloadResource> Get(string phpWorkloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Workloads.PhpWorkloadResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Workloads.PhpWorkloadResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.PhpWorkloadResource>> GetAsync(string phpWorkloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Workloads.PhpWorkloadResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Workloads.PhpWorkloadResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Workloads.PhpWorkloadResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Workloads.PhpWorkloadResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PhpWorkloadResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PhpWorkloadResourceData(Azure.Core.AzureLocation location, Azure.ResourceManager.Workloads.Models.WorkloadKind kind) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Workloads.Models.UserProfile AdminUserProfile { get { throw null; } set { } }
        public Azure.Core.AzureLocation? AppLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.BackupProfile BackupProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.CacheProfile CacheProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.NodeProfile ControllerProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.DatabaseProfile DatabaseProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.FileshareProfile FileshareProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.PhpWorkloadResourceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.WorkloadKind Kind { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.PhpVersion? PhpVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.PhpWorkloadProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SearchProfile SearchProfile { get { throw null; } set { } }
        public string SiteDomainName { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.WorkloadsSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.VmssNodesProfile WebNodesProfile { get { throw null; } set { } }
    }
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
        public Azure.ResourceManager.Workloads.Models.SapVirtualInstanceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus? Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualMachineId { get { throw null; } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.SapDatabaseInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.SapDatabaseInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.SapDatabaseInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.Core.ResourceIdentifier LogAnalyticsWorkspaceArmId { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MonitorSubnetId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MsiArmId { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.WorkloadMonitorProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.RoutingPreference? RoutingPreference { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult> Stop(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.StopContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult>> StopAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.Models.StopContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.SapVirtualInstanceResource> Update(Azure.ResourceManager.Workloads.Models.SapVirtualInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.SapVirtualInstanceResource>> UpdateAsync(Azure.ResourceManager.Workloads.Models.SapVirtualInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WordPressInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WordPressInstanceResource() { }
        public virtual Azure.ResourceManager.Workloads.WordPressInstanceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.WordPressInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.WordPressInstanceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Workloads.WordPressInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Workloads.WordPressInstanceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string phpWorkloadName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Workloads.WordPressInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.WordPressInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WordPressInstanceResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public WordPressInstanceResourceData() { }
        public string DatabaseName { get { throw null; } set { } }
        public string DatabaseUser { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.ApplicationProvisioningState? ProvisioningState { get { throw null; } }
        public System.Uri SiteUri { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.WordPressVersion? Version { get { throw null; } set { } }
    }
    public static partial class WorkloadsExtensions
    {
        public static Azure.ResourceManager.Workloads.PhpWorkloadResource GetPhpWorkloadResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Workloads.PhpWorkloadResource> GetPhpWorkloadResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string phpWorkloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Workloads.PhpWorkloadResource>> GetPhpWorkloadResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string phpWorkloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Workloads.PhpWorkloadResourceCollection GetPhpWorkloadResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Workloads.PhpWorkloadResource> GetPhpWorkloadResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Workloads.PhpWorkloadResource> GetPhpWorkloadResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Workloads.SapApplicationServerInstanceResource GetSapApplicationServerInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Workloads.SapCentralServerInstanceResource GetSapCentralServerInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Workloads.SapDatabaseInstanceResource GetSapDatabaseInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public static Azure.Pageable<Azure.ResourceManager.Workloads.Models.SkuDefinition> GetSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Workloads.Models.SkuDefinition> GetSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Workloads.WordPressInstanceResource GetWordPressInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
namespace Azure.ResourceManager.Workloads.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationProvisioningState : System.IEquatable<Azure.ResourceManager.Workloads.Models.ApplicationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.ApplicationProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.ApplicationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.ApplicationProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.ApplicationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.ApplicationProvisioningState Installing { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.ApplicationProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.ApplicationProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.ApplicationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.ApplicationProvisioningState left, Azure.ResourceManager.Workloads.Models.ApplicationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.ApplicationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.ApplicationProvisioningState left, Azure.ResourceManager.Workloads.Models.ApplicationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplicationServerConfiguration
    {
        public ApplicationServerConfiguration(Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.Workloads.Models.VirtualMachineConfiguration virtualMachineConfiguration, long instanceCount) { }
        public long InstanceCount { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.VirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureFrontDoorEnabled : System.IEquatable<Azure.ResourceManager.Workloads.Models.AzureFrontDoorEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureFrontDoorEnabled(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.AzureFrontDoorEnabled Disabled { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.AzureFrontDoorEnabled Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.AzureFrontDoorEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.AzureFrontDoorEnabled left, Azure.ResourceManager.Workloads.Models.AzureFrontDoorEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.AzureFrontDoorEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.AzureFrontDoorEnabled left, Azure.ResourceManager.Workloads.Models.AzureFrontDoorEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupProfile
    {
        public BackupProfile(Azure.ResourceManager.Workloads.Models.EnableBackup backupEnabled) { }
        public Azure.ResourceManager.Workloads.Models.EnableBackup BackupEnabled { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VaultResourceId { get { throw null; } }
    }
    public partial class CacheProfile
    {
        public CacheProfile(string skuName, Azure.ResourceManager.Workloads.Models.RedisCacheFamily family, long capacity) { }
        public Azure.Core.ResourceIdentifier CacheResourceId { get { throw null; } }
        public long Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.RedisCacheFamily Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
    }
    public partial class CentralServerConfiguration
    {
        public CentralServerConfiguration(Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.Workloads.Models.VirtualMachineConfiguration virtualMachineConfiguration, long instanceCount) { }
        public long InstanceCount { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.VirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
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
        public Azure.Core.ResourceIdentifier VirtualMachineId { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.CentralServerVirtualMachineType? VirtualMachineType { get { throw null; } }
    }
    public partial class DatabaseConfiguration
    {
        public DatabaseConfiguration(Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.Workloads.Models.VirtualMachineConfiguration virtualMachineConfiguration, long instanceCount) { }
        public Azure.ResourceManager.Workloads.Models.SapDatabaseType? DatabaseType { get { throw null; } set { } }
        public long InstanceCount { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.VirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
    }
    public partial class DatabaseProfile
    {
        public DatabaseProfile(Azure.ResourceManager.Workloads.Models.DatabaseType databaseType, string sku, Azure.ResourceManager.Workloads.Models.DatabaseTier tier) { }
        public int? BackupRetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.DatabaseType DatabaseType { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.HAEnabled? HAEnabled { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ServerResourceId { get { throw null; } }
        public string Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.EnableSslEnforcement? SslEnforcementEnabled { get { throw null; } set { } }
        public long? StorageInGB { get { throw null; } set { } }
        public long? StorageIops { get { throw null; } set { } }
        public string StorageSku { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.DatabaseTier Tier { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public enum DatabaseTier
    {
        Burstable = 0,
        GeneralPurpose = 1,
        MemoryOptimized = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseType : System.IEquatable<Azure.ResourceManager.Workloads.Models.DatabaseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseType(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.DatabaseType MySql { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.DatabaseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.DatabaseType left, Azure.ResourceManager.Workloads.Models.DatabaseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.DatabaseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.DatabaseType left, Azure.ResourceManager.Workloads.Models.DatabaseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabaseVmDetails
    {
        internal DatabaseVmDetails() { }
        public Azure.ResourceManager.Workloads.Models.SapVirtualInstanceStatus? Status { get { throw null; } }
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
    }
    public partial class DiskInfo
    {
        public DiskInfo(Azure.ResourceManager.Workloads.Models.DiskStorageType storageType) { }
        public long? SizeInGB { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.DiskStorageType StorageType { get { throw null; } set { } }
    }
    public enum DiskStorageType
    {
        PremiumLrs = 0,
        StandardLrs = 1,
        StandardSsdLrs = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnableBackup : System.IEquatable<Azure.ResourceManager.Workloads.Models.EnableBackup>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnableBackup(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.EnableBackup Disabled { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.EnableBackup Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.EnableBackup other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.EnableBackup left, Azure.ResourceManager.Workloads.Models.EnableBackup right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.EnableBackup (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.EnableBackup left, Azure.ResourceManager.Workloads.Models.EnableBackup right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnableSslEnforcement : System.IEquatable<Azure.ResourceManager.Workloads.Models.EnableSslEnforcement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnableSslEnforcement(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.EnableSslEnforcement Disabled { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.EnableSslEnforcement Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.EnableSslEnforcement other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.EnableSslEnforcement left, Azure.ResourceManager.Workloads.Models.EnableSslEnforcement right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.EnableSslEnforcement (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.EnableSslEnforcement left, Azure.ResourceManager.Workloads.Models.EnableSslEnforcement right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class FileshareProfile
    {
        public FileshareProfile(Azure.ResourceManager.Workloads.Models.FileShareType shareType, Azure.ResourceManager.Workloads.Models.FileShareStorageType storageType) { }
        public string ShareName { get { throw null; } }
        public long? ShareSizeInGB { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.FileShareType ShareType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageResourceId { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.FileShareStorageType StorageType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileShareStorageType : System.IEquatable<Azure.ResourceManager.Workloads.Models.FileShareStorageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileShareStorageType(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.FileShareStorageType PremiumLrs { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.FileShareStorageType StandardGrs { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.FileShareStorageType StandardLrs { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.FileShareStorageType StandardZrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.FileShareStorageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.FileShareStorageType left, Azure.ResourceManager.Workloads.Models.FileShareStorageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.FileShareStorageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.FileShareStorageType left, Azure.ResourceManager.Workloads.Models.FileShareStorageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileShareType : System.IEquatable<Azure.ResourceManager.Workloads.Models.FileShareType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileShareType(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.FileShareType AzureFiles { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.FileShareType NfsOnController { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.FileShareType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.FileShareType left, Azure.ResourceManager.Workloads.Models.FileShareType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.FileShareType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.FileShareType left, Azure.ResourceManager.Workloads.Models.FileShareType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GatewayServerProperties
    {
        public GatewayServerProperties() { }
        public Azure.ResourceManager.Workloads.Models.SapHealthState? Health { get { throw null; } }
        public long? Port { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HAEnabled : System.IEquatable<Azure.ResourceManager.Workloads.Models.HAEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HAEnabled(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.HAEnabled Disabled { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.HAEnabled Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.HAEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.HAEnabled left, Azure.ResourceManager.Workloads.Models.HAEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.HAEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.HAEnabled left, Azure.ResourceManager.Workloads.Models.HAEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HanaDBProviderInstanceProperties : Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties
    {
        public HanaDBProviderInstanceProperties() { }
        public string DBName { get { throw null; } set { } }
        public string DBPassword { get { throw null; } set { } }
        public System.Uri DBPasswordUri { get { throw null; } set { } }
        public System.Uri DBSslCertificateUri { get { throw null; } set { } }
        public string DBUsername { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public string InstanceNumber { get { throw null; } set { } }
        public string SqlPort { get { throw null; } set { } }
        public string SslHostNameInCertificate { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoadBalancerType : System.IEquatable<Azure.ResourceManager.Workloads.Models.LoadBalancerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoadBalancerType(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.LoadBalancerType ApplicationGateway { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.LoadBalancerType LoadBalancer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.LoadBalancerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.LoadBalancerType left, Azure.ResourceManager.Workloads.Models.LoadBalancerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.LoadBalancerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.LoadBalancerType left, Azure.ResourceManager.Workloads.Models.LoadBalancerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LocationType : System.IEquatable<Azure.ResourceManager.Workloads.Models.LocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LocationType(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.LocationType EdgeZone { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.LocationType Region { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.LocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.LocationType left, Azure.ResourceManager.Workloads.Models.LocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.LocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.LocationType left, Azure.ResourceManager.Workloads.Models.LocationType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class MsSqlServerProviderInstanceProperties : Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties
    {
        public MsSqlServerProviderInstanceProperties() { }
        public string DBPassword { get { throw null; } set { } }
        public System.Uri DBPasswordUri { get { throw null; } set { } }
        public string DBPort { get { throw null; } set { } }
        public string DBUsername { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public string SapSid { get { throw null; } set { } }
    }
    public partial class NetworkProfile
    {
        public NetworkProfile(Azure.ResourceManager.Workloads.Models.LoadBalancerType loadBalancerType) { }
        public Azure.ResourceManager.Workloads.Models.AzureFrontDoorEnabled? AzureFrontDoorEnabled { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AzureFrontDoorResourceId { get { throw null; } }
        public int? Capacity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier FrontEndPublicIPResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier LoadBalancerResourceId { get { throw null; } }
        public string LoadBalancerSku { get { throw null; } set { } }
        public string LoadBalancerTier { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.LoadBalancerType LoadBalancerType { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> OutboundPublicIPResourceIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier VNetResourceId { get { throw null; } }
    }
    public partial class NodeProfile
    {
        public NodeProfile(string nodeSku, Azure.ResourceManager.Workloads.Models.OSImageProfile osImage, Azure.ResourceManager.Workloads.Models.DiskInfo osDisk) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Workloads.Models.DiskInfo> DataDisks { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> NodeResourceIds { get { throw null; } }
        public string NodeSku { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.DiskInfo OSDisk { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.OSImageProfile OSImage { get { throw null; } set { } }
    }
    public abstract partial class OSConfiguration
    {
        protected OSConfiguration() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OSImageOffer : System.IEquatable<Azure.ResourceManager.Workloads.Models.OSImageOffer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OSImageOffer(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.OSImageOffer UbuntuServer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.OSImageOffer other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.OSImageOffer left, Azure.ResourceManager.Workloads.Models.OSImageOffer right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.OSImageOffer (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.OSImageOffer left, Azure.ResourceManager.Workloads.Models.OSImageOffer right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OSImageProfile
    {
        public OSImageProfile() { }
        public Azure.ResourceManager.Workloads.Models.OSImageOffer? Offer { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.OSImagePublisher? Publisher { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.OSImageSku? Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.OSImageVersion? Version { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OSImagePublisher : System.IEquatable<Azure.ResourceManager.Workloads.Models.OSImagePublisher>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OSImagePublisher(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.OSImagePublisher Canonical { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.OSImagePublisher other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.OSImagePublisher left, Azure.ResourceManager.Workloads.Models.OSImagePublisher right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.OSImagePublisher (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.OSImagePublisher left, Azure.ResourceManager.Workloads.Models.OSImagePublisher right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OSImageSku : System.IEquatable<Azure.ResourceManager.Workloads.Models.OSImageSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OSImageSku(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.OSImageSku Ubuntu16_04Lts { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.OSImageSku Ubuntu18_04Lts { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.OSImageSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.OSImageSku left, Azure.ResourceManager.Workloads.Models.OSImageSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.OSImageSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.OSImageSku left, Azure.ResourceManager.Workloads.Models.OSImageSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OSImageVersion : System.IEquatable<Azure.ResourceManager.Workloads.Models.OSImageVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OSImageVersion(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.OSImageVersion Latest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.OSImageVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.OSImageVersion left, Azure.ResourceManager.Workloads.Models.OSImageVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.OSImageVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.OSImageVersion left, Azure.ResourceManager.Workloads.Models.OSImageVersion right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class PatchResourceRequestBodyIdentity : Azure.ResourceManager.Workloads.Models.UserAssignedServiceIdentity
    {
        public PatchResourceRequestBodyIdentity(Azure.ResourceManager.Workloads.Models.ManagedServiceIdentityType managedServiceIdentityType) : base (default(Azure.ResourceManager.Workloads.Models.ManagedServiceIdentityType)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhpVersion : System.IEquatable<Azure.ResourceManager.Workloads.Models.PhpVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhpVersion(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.PhpVersion V7_2 { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.PhpVersion V7_3 { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.PhpVersion V7_4 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.PhpVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.PhpVersion left, Azure.ResourceManager.Workloads.Models.PhpVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.PhpVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.PhpVersion left, Azure.ResourceManager.Workloads.Models.PhpVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhpWorkloadProvisioningState : System.IEquatable<Azure.ResourceManager.Workloads.Models.PhpWorkloadProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhpWorkloadProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.PhpWorkloadProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.PhpWorkloadProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.PhpWorkloadProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.PhpWorkloadProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.PhpWorkloadProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.PhpWorkloadProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.PhpWorkloadProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.PhpWorkloadProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.PhpWorkloadProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.PhpWorkloadProvisioningState left, Azure.ResourceManager.Workloads.Models.PhpWorkloadProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.PhpWorkloadProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.PhpWorkloadProvisioningState left, Azure.ResourceManager.Workloads.Models.PhpWorkloadProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PhpWorkloadResourceIdentity : Azure.ResourceManager.Workloads.Models.UserAssignedServiceIdentity
    {
        public PhpWorkloadResourceIdentity(Azure.ResourceManager.Workloads.Models.ManagedServiceIdentityType managedServiceIdentityType) : base (default(Azure.ResourceManager.Workloads.Models.ManagedServiceIdentityType)) { }
    }
    public partial class PhpWorkloadResourcePatch
    {
        public PhpWorkloadResourcePatch() { }
        public Azure.ResourceManager.Workloads.Models.PatchResourceRequestBodyIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PrometheusHAClusterProviderInstanceProperties : Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties
    {
        public PrometheusHAClusterProviderInstanceProperties() { }
        public string ClusterName { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public System.Uri PrometheusUri { get { throw null; } set { } }
        public string Sid { get { throw null; } set { } }
    }
    public partial class PrometheusOSProviderInstanceProperties : Azure.ResourceManager.Workloads.Models.ProviderSpecificProperties
    {
        public PrometheusOSProviderInstanceProperties() { }
        public System.Uri PrometheusUri { get { throw null; } set { } }
    }
    public abstract partial class ProviderSpecificProperties
    {
        protected ProviderSpecificProperties() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisCacheFamily : System.IEquatable<Azure.ResourceManager.Workloads.Models.RedisCacheFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisCacheFamily(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.RedisCacheFamily C { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.RedisCacheFamily P { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.RedisCacheFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.RedisCacheFamily left, Azure.ResourceManager.Workloads.Models.RedisCacheFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.RedisCacheFamily (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.RedisCacheFamily left, Azure.ResourceManager.Workloads.Models.RedisCacheFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestrictionInfo
    {
        internal RestrictionInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
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
        public long? DiskCount { get { throw null; } }
        public long? DiskIopsReadWrite { get { throw null; } }
        public long? DiskMBpsReadWrite { get { throw null; } }
        public long? DiskSizeGB { get { throw null; } }
        public string DiskStorageType { get { throw null; } }
        public string DiskType { get { throw null; } }
        public string Volume { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Workloads.Models.SapDiskConfiguration> DiskConfigurations { get { throw null; } }
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
    public partial class SapMonitorPatch
    {
        public SapMonitorPatch() { }
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
        public System.Uri SapSslCertificateUri { get { throw null; } set { } }
        public string SapUsername { get { throw null; } set { } }
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
    public partial class SearchProfile : Azure.ResourceManager.Workloads.Models.NodeProfile
    {
        public SearchProfile(string nodeSku, Azure.ResourceManager.Workloads.Models.OSImageProfile osImage, Azure.ResourceManager.Workloads.Models.DiskInfo osDisk, Azure.ResourceManager.Workloads.Models.SearchType searchType) : base (default(string), default(Azure.ResourceManager.Workloads.Models.OSImageProfile), default(Azure.ResourceManager.Workloads.Models.DiskInfo)) { }
        public Azure.ResourceManager.Workloads.Models.SearchType SearchType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchType : System.IEquatable<Azure.ResourceManager.Workloads.Models.SearchType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchType(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SearchType Elastic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.SearchType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.SearchType left, Azure.ResourceManager.Workloads.Models.SearchType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.SearchType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.SearchType left, Azure.ResourceManager.Workloads.Models.SearchType right) { throw null; }
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
    public partial class SingleServerConfiguration : Azure.ResourceManager.Workloads.Models.InfrastructureConfiguration
    {
        public SingleServerConfiguration(string appResourceGroup, Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.Workloads.Models.VirtualMachineConfiguration virtualMachineConfiguration) : base (default(string)) { }
        public Azure.ResourceManager.Workloads.Models.SapDatabaseType? DatabaseType { get { throw null; } set { } }
        public bool? IsSecondaryIPEnabled { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.VirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
    }
    public partial class SingleServerRecommendationResult : Azure.ResourceManager.Workloads.Models.SapSizingRecommendationResult
    {
        internal SingleServerRecommendationResult() { }
        public string VmSku { get { throw null; } }
    }
    public partial class SkuCapability
    {
        internal SkuCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class SkuCost
    {
        internal SkuCost() { }
        public string ExtendedUnit { get { throw null; } }
        public string MeterId { get { throw null; } }
        public int? Quantity { get { throw null; } }
    }
    public partial class SkuDefinition
    {
        internal SkuDefinition() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Workloads.Models.SkuCapability> Capabilities { get { throw null; } }
        public System.BinaryData Capacity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Workloads.Models.SkuCost> Costs { get { throw null; } }
        public string Family { get { throw null; } }
        public string Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Workloads.Models.SkuLocationAndZones> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Workloads.Models.SkuRestriction> Restrictions { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class SkuLocationAndZones
    {
        internal SkuLocationAndZones() { }
        public System.Collections.Generic.IReadOnlyList<string> ExtendedLocations { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.LocationType? LocationType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Workloads.Models.SkuZoneDetail> ZoneDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class SkuRestriction
    {
        internal SkuRestriction() { }
        public Azure.ResourceManager.Workloads.Models.SkuRestrictionReasonCode? ReasonCode { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.RestrictionInfo RestrictionInfo { get { throw null; } }
        public Azure.ResourceManager.Workloads.Models.SkuRestrictionType? RestrictionType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuRestrictionReasonCode : System.IEquatable<Azure.ResourceManager.Workloads.Models.SkuRestrictionReasonCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuRestrictionReasonCode(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SkuRestrictionReasonCode NotAvailableForSubscription { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SkuRestrictionReasonCode NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SkuRestrictionReasonCode QuotaId { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.SkuRestrictionReasonCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.SkuRestrictionReasonCode left, Azure.ResourceManager.Workloads.Models.SkuRestrictionReasonCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.SkuRestrictionReasonCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.SkuRestrictionReasonCode left, Azure.ResourceManager.Workloads.Models.SkuRestrictionReasonCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuRestrictionType : System.IEquatable<Azure.ResourceManager.Workloads.Models.SkuRestrictionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuRestrictionType(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.SkuRestrictionType Location { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SkuRestrictionType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.SkuRestrictionType Zone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.SkuRestrictionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.SkuRestrictionType left, Azure.ResourceManager.Workloads.Models.SkuRestrictionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.SkuRestrictionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.SkuRestrictionType left, Azure.ResourceManager.Workloads.Models.SkuRestrictionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SkuZoneDetail
    {
        internal SkuZoneDetail() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Workloads.Models.SkuCapability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
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
    public partial class StopContent
    {
        public StopContent() { }
        public bool? HardStop { get { throw null; } set { } }
    }
    public partial class ThreeTierConfiguration : Azure.ResourceManager.Workloads.Models.InfrastructureConfiguration
    {
        public ThreeTierConfiguration(string appResourceGroup, Azure.ResourceManager.Workloads.Models.CentralServerConfiguration centralServer, Azure.ResourceManager.Workloads.Models.ApplicationServerConfiguration applicationServer, Azure.ResourceManager.Workloads.Models.DatabaseConfiguration databaseServer) : base (default(string)) { }
        public Azure.ResourceManager.Workloads.Models.ApplicationServerConfiguration ApplicationServer { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.CentralServerConfiguration CentralServer { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.DatabaseConfiguration DatabaseServer { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.SapHighAvailabilityType? HighAvailabilityType { get { throw null; } set { } }
        public bool? IsSecondaryIPEnabled { get { throw null; } set { } }
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
    public partial class UserProfile
    {
        public UserProfile(string userName, string sshPublicKey) { }
        public string SshPublicKey { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    public partial class VirtualMachineConfiguration
    {
        public VirtualMachineConfiguration(string vmSize, Azure.ResourceManager.Workloads.Models.ImageReference imageReference, Azure.ResourceManager.Workloads.Models.OSProfile osProfile) { }
        public Azure.ResourceManager.Workloads.Models.ImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.OSProfile OSProfile { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class VmssNodesProfile : Azure.ResourceManager.Workloads.Models.NodeProfile
    {
        public VmssNodesProfile(string nodeSku, Azure.ResourceManager.Workloads.Models.OSImageProfile osImage, Azure.ResourceManager.Workloads.Models.DiskInfo osDisk) : base (default(string), default(Azure.ResourceManager.Workloads.Models.OSImageProfile), default(Azure.ResourceManager.Workloads.Models.DiskInfo)) { }
        public int? AutoScaleMaxCount { get { throw null; } set { } }
        public int? AutoScaleMinCount { get { throw null; } set { } }
    }
    public partial class WindowsConfiguration : Azure.ResourceManager.Workloads.Models.OSConfiguration
    {
        public WindowsConfiguration() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WordPressVersion : System.IEquatable<Azure.ResourceManager.Workloads.Models.WordPressVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WordPressVersion(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.WordPressVersion V5_4_0 { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.WordPressVersion V5_4_1 { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.WordPressVersion V5_4_2 { get { throw null; } }
        public static Azure.ResourceManager.Workloads.Models.WordPressVersion V5_4_3 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.WordPressVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.WordPressVersion left, Azure.ResourceManager.Workloads.Models.WordPressVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.WordPressVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.WordPressVersion left, Azure.ResourceManager.Workloads.Models.WordPressVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadKind : System.IEquatable<Azure.ResourceManager.Workloads.Models.WorkloadKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadKind(string value) { throw null; }
        public static Azure.ResourceManager.Workloads.Models.WorkloadKind WordPress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Workloads.Models.WorkloadKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Workloads.Models.WorkloadKind left, Azure.ResourceManager.Workloads.Models.WorkloadKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Workloads.Models.WorkloadKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Workloads.Models.WorkloadKind left, Azure.ResourceManager.Workloads.Models.WorkloadKind right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class WorkloadsSku
    {
        public WorkloadsSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.Workloads.Models.WorkloadsSkuTier? Tier { get { throw null; } set { } }
    }
    public enum WorkloadsSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
}
