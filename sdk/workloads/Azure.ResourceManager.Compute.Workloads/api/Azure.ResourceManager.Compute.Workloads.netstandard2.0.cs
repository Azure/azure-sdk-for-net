namespace Azure.ResourceManager.Compute.Workloads
{
    public partial class MonitorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Workloads.MonitorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Workloads.MonitorResource>, System.Collections.IEnumerable
    {
        protected MonitorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.MonitorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.Compute.Workloads.MonitorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.MonitorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.Compute.Workloads.MonitorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.MonitorResource> Get(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Workloads.MonitorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Workloads.MonitorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.MonitorResource>> GetAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.Workloads.MonitorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Workloads.MonitorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.Workloads.MonitorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Workloads.MonitorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MonitorData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MonitorData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AppLocation { get { throw null; } set { } }
        public Azure.ResponseError Errors { get { throw null; } }
        public string LogAnalyticsWorkspaceArmId { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public string MonitorSubnet { get { throw null; } set { } }
        public string MsiArmId { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.WorkloadMonitorProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.RoutingPreference? RoutingPreference { get { throw null; } set { } }
    }
    public partial class MonitorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MonitorResource() { }
        public virtual Azure.ResourceManager.Compute.Workloads.MonitorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.MonitorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.MonitorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.MonitorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.MonitorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.ProviderInstanceResource> GetProviderInstance(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.ProviderInstanceResource>> GetProviderInstanceAsync(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Workloads.ProviderInstanceCollection GetProviderInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.MonitorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.MonitorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.MonitorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.MonitorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.MonitorResource> Update(Azure.ResourceManager.Compute.Workloads.Models.MonitorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.MonitorResource>> UpdateAsync(Azure.ResourceManager.Compute.Workloads.Models.MonitorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PhpWorkloadResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PhpWorkloadResource() { }
        public virtual Azure.ResourceManager.Compute.Workloads.PhpWorkloadResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string phpWorkloadName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string deleteInfra = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string deleteInfra = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Workloads.WordpressInstanceResource GetWordpressInstanceResource() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource> Update(Azure.ResourceManager.Compute.Workloads.Models.PhpWorkloadResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource>> UpdateAsync(Azure.ResourceManager.Compute.Workloads.Models.PhpWorkloadResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PhpWorkloadResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource>, System.Collections.IEnumerable
    {
        protected PhpWorkloadResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string phpWorkloadName, Azure.ResourceManager.Compute.Workloads.PhpWorkloadResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string phpWorkloadName, Azure.ResourceManager.Compute.Workloads.PhpWorkloadResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string phpWorkloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string phpWorkloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource> Get(string phpWorkloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource>> GetAsync(string phpWorkloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PhpWorkloadResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PhpWorkloadResourceData(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.Workloads.Models.WorkloadKind kind) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Workloads.Models.UserProfile AdminUserProfile { get { throw null; } set { } }
        public string AppLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.BackupProfile BackupProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.CacheProfile CacheProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.NodeProfile ControllerProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.DatabaseProfile DatabaseProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.FileshareProfile FileshareProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.PhpWorkloadResourceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.WorkloadKind Kind { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.PHPVersion? PhpVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.PhpWorkloadProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SearchProfile SearchProfile { get { throw null; } set { } }
        public string SiteDomainName { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.WorkloadsSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.VmssNodesProfile WebNodesProfile { get { throw null; } set { } }
    }
    public partial class ProviderInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Workloads.ProviderInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Workloads.ProviderInstanceResource>, System.Collections.IEnumerable
    {
        protected ProviderInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.ProviderInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string providerInstanceName, Azure.ResourceManager.Compute.Workloads.ProviderInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.ProviderInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string providerInstanceName, Azure.ResourceManager.Compute.Workloads.ProviderInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.ProviderInstanceResource> Get(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Workloads.ProviderInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Workloads.ProviderInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.ProviderInstanceResource>> GetAsync(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.Workloads.ProviderInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Workloads.ProviderInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.Workloads.ProviderInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Workloads.ProviderInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProviderInstanceData : Azure.ResourceManager.Models.ResourceData
    {
        public ProviderInstanceData() { }
        public Azure.ResponseError Errors { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.ProviderSpecificProperties ProviderSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.WorkloadMonitorProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ProviderInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProviderInstanceResource() { }
        public virtual Azure.ResourceManager.Compute.Workloads.ProviderInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string providerInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.ProviderInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.ProviderInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.ProviderInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Workloads.ProviderInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.ProviderInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Workloads.ProviderInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SapApplicationServerInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource>, System.Collections.IEnumerable
    {
        protected SapApplicationServerInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationInstanceName, Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationInstanceName, Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource> Get(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource>> GetAsync(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapApplicationServerInstanceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SapApplicationServerInstanceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Workloads.Models.ErrorDefinition ErrorsProperties { get { throw null; } }
        public long? GatewayPort { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapHealthState? Health { get { throw null; } }
        public string Hostname { get { throw null; } }
        public long? IcmHttpPort { get { throw null; } }
        public long? IcmHttpsPort { get { throw null; } }
        public string InstanceNo { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public string KernelPatch { get { throw null; } }
        public string KernelVersion { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceStatus? Status { get { throw null; } }
        public string Subnet { get { throw null; } }
        public string VirtualMachineId { get { throw null; } }
    }
    public partial class SapApplicationServerInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SapApplicationServerInstanceResource() { }
        public virtual Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sapVirtualInstanceName, string applicationInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Workloads.Models.SapApplicationServerInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Workloads.Models.SapApplicationServerInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SapCentralServerInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource>, System.Collections.IEnumerable
    {
        protected SapCentralServerInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string centralInstanceName, Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string centralInstanceName, Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource> Get(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource>> GetAsync(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapCentralServerInstanceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SapCentralServerInstanceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Workloads.Models.EnqueueReplicationServerProperties EnqueueReplicationServerProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.EnqueueServerProperties EnqueueServerProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.ErrorDefinition ErrorsProperties { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.GatewayServerProperties GatewayServerProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapHealthState? Health { get { throw null; } }
        public string InstanceNo { get { throw null; } }
        public string KernelPatch { get { throw null; } }
        public string KernelVersion { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.MessageServerProperties MessageServerProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceStatus? Status { get { throw null; } }
        public string Subnet { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Workloads.Models.CentralServerVmDetails> VmDetails { get { throw null; } }
    }
    public partial class SapCentralServerInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SapCentralServerInstanceResource() { }
        public virtual Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sapVirtualInstanceName, string centralInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Workloads.Models.SapCentralServerInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Workloads.Models.SapCentralServerInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SapDatabaseInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource>, System.Collections.IEnumerable
    {
        protected SapDatabaseInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseInstanceName, Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseInstanceName, Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource> Get(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource>> GetAsync(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapDatabaseInstanceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SapDatabaseInstanceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string DatabaseSid { get { throw null; } }
        public string DatabaseType { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.ErrorDefinition ErrorsProperties { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceStatus? Status { get { throw null; } }
        public string Subnet { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Workloads.Models.DatabaseVmDetails> VmDetails { get { throw null; } }
    }
    public partial class SapDatabaseInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SapDatabaseInstanceResource() { }
        public virtual Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sapVirtualInstanceName, string databaseInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SapVirtualInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource>, System.Collections.IEnumerable
    {
        protected SapVirtualInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sapVirtualInstanceName, Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sapVirtualInstanceName, Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource> Get(string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource>> GetAsync(string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapVirtualInstanceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SapVirtualInstanceData(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.Workloads.Models.SapEnvironmentType environment, Azure.ResourceManager.Compute.Workloads.Models.SapProductType sapProduct, Azure.ResourceManager.Compute.Workloads.Models.SapConfiguration configuration) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Workloads.Models.SapConfiguration Configuration { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapEnvironmentType Environment { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.ErrorDefinition ErrorsProperties { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapHealthState? Health { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.UserAssignedServiceIdentity Identity { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapProductType SapProduct { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceState? State { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceStatus? Status { get { throw null; } }
    }
    public partial class SapVirtualInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SapVirtualInstanceResource() { }
        public virtual Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sapVirtualInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource> GetSapApplicationServerInstance(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource>> GetSapApplicationServerInstanceAsync(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceCollection GetSapApplicationServerInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource> GetSapCentralServerInstance(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource>> GetSapCentralServerInstanceAsync(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceCollection GetSapCentralServerInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource> GetSapDatabaseInstance(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource>> GetSapDatabaseInstanceAsync(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceCollection GetSapDatabaseInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult> Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult>> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult> Stop(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Workloads.Models.StopContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult>> StopAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Workloads.Models.StopContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource> Update(Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource>> UpdateAsync(Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WordpressInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WordpressInstanceResource() { }
        public virtual Azure.ResourceManager.Compute.Workloads.WordpressInstanceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.WordpressInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Workloads.WordpressInstanceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.WordpressInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Workloads.WordpressInstanceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string phpWorkloadName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.WordpressInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.WordpressInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WordpressInstanceResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public WordpressInstanceResourceData() { }
        public string DatabaseName { get { throw null; } set { } }
        public string DatabaseUser { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.ApplicationProvisioningState? ProvisioningState { get { throw null; } }
        public System.Uri SiteUri { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.WordpressVersions? Version { get { throw null; } set { } }
    }
    public static partial class WorkloadsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Compute.Workloads.MonitorResource> GetMonitor(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.MonitorResource>> GetMonitorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.MonitorResource GetMonitorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.MonitorCollection GetMonitors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Workloads.MonitorResource> GetMonitors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Workloads.MonitorResource> GetMonitorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource GetPhpWorkloadResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource> GetPhpWorkloadResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string phpWorkloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource>> GetPhpWorkloadResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string phpWorkloadName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.PhpWorkloadResourceCollection GetPhpWorkloadResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource> GetPhpWorkloadResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Workloads.PhpWorkloadResource> GetPhpWorkloadResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.ProviderInstanceResource GetProviderInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.SapApplicationServerInstanceResource GetSapApplicationServerInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.SapCentralServerInstanceResource GetSapCentralServerInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.SapDatabaseInstanceResource GetSapDatabaseInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource> GetSapVirtualInstance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource>> GetSapVirtualInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource GetSapVirtualInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceCollection GetSapVirtualInstances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource> GetSapVirtualInstances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Workloads.SapVirtualInstanceResource> GetSapVirtualInstancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Workloads.Models.SkuDefinition> GetSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Workloads.Models.SkuDefinition> GetSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.WordpressInstanceResource GetWordpressInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Workloads.Models.SapAvailabilityZoneDetailsResult> SapAvailabilityZoneDetails(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.Compute.Workloads.Models.SapAvailabilityZoneDetailsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.Models.SapAvailabilityZoneDetailsResult>> SapAvailabilityZoneDetailsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.Compute.Workloads.Models.SapAvailabilityZoneDetailsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Workloads.Models.SapDiskConfigurationsResult> SapDiskConfigurations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.Compute.Workloads.Models.SapDiskConfigurationsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.Models.SapDiskConfigurationsResult>> SapDiskConfigurationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.Compute.Workloads.Models.SapDiskConfigurationsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Workloads.Models.SapSizingRecommendationResult> SapSizingRecommendations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.Compute.Workloads.Models.SapSizingRecommendationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.Models.SapSizingRecommendationResult>> SapSizingRecommendationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.Compute.Workloads.Models.SapSizingRecommendationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Workloads.Models.SapSupportedResourceSkusResult> SapSupportedSku(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.Compute.Workloads.Models.SapSupportedSkusContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.Models.SapSupportedResourceSkusResult>> SapSupportedSkuAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.Compute.Workloads.Models.SapSupportedSkusContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Compute.Workloads.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationProvisioningState : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.ApplicationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.ApplicationProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.ApplicationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.ApplicationProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.ApplicationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.ApplicationProvisioningState Installing { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.ApplicationProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.ApplicationProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.ApplicationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.ApplicationProvisioningState left, Azure.ResourceManager.Compute.Workloads.Models.ApplicationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.ApplicationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.ApplicationProvisioningState left, Azure.ResourceManager.Compute.Workloads.Models.ApplicationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplicationServerConfiguration
    {
        public ApplicationServerConfiguration(string subnetId, Azure.ResourceManager.Compute.Workloads.Models.VirtualMachineConfiguration virtualMachineConfiguration, long instanceCount) { }
        public long InstanceCount { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.VirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureFrontDoorEnabled : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.AzureFrontDoorEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureFrontDoorEnabled(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.AzureFrontDoorEnabled Disabled { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.AzureFrontDoorEnabled Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.AzureFrontDoorEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.AzureFrontDoorEnabled left, Azure.ResourceManager.Compute.Workloads.Models.AzureFrontDoorEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.AzureFrontDoorEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.AzureFrontDoorEnabled left, Azure.ResourceManager.Compute.Workloads.Models.AzureFrontDoorEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupProfile
    {
        public BackupProfile(Azure.ResourceManager.Compute.Workloads.Models.EnableBackup backupEnabled) { }
        public Azure.ResourceManager.Compute.Workloads.Models.EnableBackup BackupEnabled { get { throw null; } set { } }
        public string VaultResourceId { get { throw null; } }
    }
    public partial class CacheProfile
    {
        public CacheProfile(string skuName, Azure.ResourceManager.Compute.Workloads.Models.RedisCacheFamily family, long capacity) { }
        public string CacheResourceId { get { throw null; } }
        public long Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.RedisCacheFamily Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
    }
    public partial class CentralServerConfiguration
    {
        public CentralServerConfiguration(string subnetId, Azure.ResourceManager.Compute.Workloads.Models.VirtualMachineConfiguration virtualMachineConfiguration, long instanceCount) { }
        public long InstanceCount { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.VirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CentralServerVirtualMachineType : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.CentralServerVirtualMachineType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CentralServerVirtualMachineType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.CentralServerVirtualMachineType Ascs { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.CentralServerVirtualMachineType ERS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.CentralServerVirtualMachineType ERSInactive { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.CentralServerVirtualMachineType Primary { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.CentralServerVirtualMachineType Secondary { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.CentralServerVirtualMachineType Standby { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.CentralServerVirtualMachineType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.CentralServerVirtualMachineType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.CentralServerVirtualMachineType left, Azure.ResourceManager.Compute.Workloads.Models.CentralServerVirtualMachineType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.CentralServerVirtualMachineType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.CentralServerVirtualMachineType left, Azure.ResourceManager.Compute.Workloads.Models.CentralServerVirtualMachineType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CentralServerVmDetails
    {
        internal CentralServerVmDetails() { }
        public string VirtualMachineId { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.CentralServerVirtualMachineType? VirtualMachineType { get { throw null; } }
    }
    public partial class DatabaseConfiguration
    {
        public DatabaseConfiguration(string subnetId, Azure.ResourceManager.Compute.Workloads.Models.VirtualMachineConfiguration virtualMachineConfiguration, long instanceCount) { }
        public Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseType? DatabaseType { get { throw null; } set { } }
        public long InstanceCount { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.VirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
    }
    public partial class DatabaseProfile
    {
        public DatabaseProfile(Azure.ResourceManager.Compute.Workloads.Models.DatabaseType databaseType, string sku, Azure.ResourceManager.Compute.Workloads.Models.DatabaseTier tier) { }
        public int? BackupRetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.DatabaseType DatabaseType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.HAEnabled? HaEnabled { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        public string ServerResourceId { get { throw null; } }
        public string Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.EnableSslEnforcement? SslEnforcementEnabled { get { throw null; } set { } }
        public long? StorageInGB { get { throw null; } set { } }
        public long? StorageIops { get { throw null; } set { } }
        public string StorageSku { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.DatabaseTier Tier { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public enum DatabaseTier
    {
        Burstable = 0,
        GeneralPurpose = 1,
        MemoryOptimized = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseType : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.DatabaseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.DatabaseType MySql { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.DatabaseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.DatabaseType left, Azure.ResourceManager.Compute.Workloads.Models.DatabaseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.DatabaseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.DatabaseType left, Azure.ResourceManager.Compute.Workloads.Models.DatabaseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabaseVmDetails
    {
        internal DatabaseVmDetails() { }
        public Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceStatus? Status { get { throw null; } }
        public string VirtualMachineId { get { throw null; } }
    }
    public partial class DB2ProviderInstanceProperties : Azure.ResourceManager.Compute.Workloads.Models.ProviderSpecificProperties
    {
        public DB2ProviderInstanceProperties() { }
        public string DbName { get { throw null; } set { } }
        public string DbPassword { get { throw null; } set { } }
        public System.Uri DbPasswordUri { get { throw null; } set { } }
        public string DbPort { get { throw null; } set { } }
        public string DbUsername { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public string SapSid { get { throw null; } set { } }
    }
    public partial class DeployerVmPackages
    {
        public DeployerVmPackages() { }
        public string StorageAccountId { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class DeploymentConfiguration : Azure.ResourceManager.Compute.Workloads.Models.SapConfiguration
    {
        public DeploymentConfiguration() { }
        public string AppLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.InfrastructureConfiguration InfrastructureConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.SoftwareConfiguration SoftwareConfiguration { get { throw null; } set { } }
    }
    public partial class DeploymentWithOSConfiguration : Azure.ResourceManager.Compute.Workloads.Models.SapConfiguration
    {
        public DeploymentWithOSConfiguration() { }
        public string AppLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.InfrastructureConfiguration InfrastructureConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.OSSapConfiguration OSSapConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.SoftwareConfiguration SoftwareConfiguration { get { throw null; } set { } }
    }
    public partial class DiscoveryConfiguration : Azure.ResourceManager.Compute.Workloads.Models.SapConfiguration
    {
        public DiscoveryConfiguration() { }
        public string AppLocation { get { throw null; } }
        public string CentralServerVmId { get { throw null; } set { } }
    }
    public partial class DiskInfo
    {
        public DiskInfo(Azure.ResourceManager.Compute.Workloads.Models.DiskStorageType storageType) { }
        public long? SizeInGB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.DiskStorageType StorageType { get { throw null; } set { } }
    }
    public enum DiskStorageType
    {
        PremiumLRS = 0,
        StandardLRS = 1,
        StandardSSDLRS = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnableBackup : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.EnableBackup>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnableBackup(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.EnableBackup Disabled { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.EnableBackup Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.EnableBackup other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.EnableBackup left, Azure.ResourceManager.Compute.Workloads.Models.EnableBackup right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.EnableBackup (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.EnableBackup left, Azure.ResourceManager.Compute.Workloads.Models.EnableBackup right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnableSslEnforcement : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.EnableSslEnforcement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnableSslEnforcement(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.EnableSslEnforcement Disabled { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.EnableSslEnforcement Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.EnableSslEnforcement other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.EnableSslEnforcement left, Azure.ResourceManager.Compute.Workloads.Models.EnableSslEnforcement right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.EnableSslEnforcement (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.EnableSslEnforcement left, Azure.ResourceManager.Compute.Workloads.Models.EnableSslEnforcement right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnqueueReplicationServerProperties
    {
        public EnqueueReplicationServerProperties() { }
        public Azure.ResourceManager.Compute.Workloads.Models.EnqueueReplicationServerType? ErsVersion { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapHealthState? Health { get { throw null; } }
        public string Hostname { get { throw null; } }
        public string InstanceNo { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public string KernelPatch { get { throw null; } }
        public string KernelVersion { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnqueueReplicationServerType : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.EnqueueReplicationServerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnqueueReplicationServerType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.EnqueueReplicationServerType EnqueueReplicator1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.EnqueueReplicationServerType EnqueueReplicator2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.EnqueueReplicationServerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.EnqueueReplicationServerType left, Azure.ResourceManager.Compute.Workloads.Models.EnqueueReplicationServerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.EnqueueReplicationServerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.EnqueueReplicationServerType left, Azure.ResourceManager.Compute.Workloads.Models.EnqueueReplicationServerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnqueueServerProperties
    {
        public EnqueueServerProperties() { }
        public Azure.ResourceManager.Compute.Workloads.Models.SapHealthState? Health { get { throw null; } }
        public string Hostname { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public long? Port { get { throw null; } }
    }
    public partial class ErrorDefinition
    {
        internal ErrorDefinition() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Workloads.Models.ErrorDefinition> Details { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class FileshareProfile
    {
        public FileshareProfile(Azure.ResourceManager.Compute.Workloads.Models.FileShareType shareType, Azure.ResourceManager.Compute.Workloads.Models.FileShareStorageType storageType) { }
        public string ShareName { get { throw null; } }
        public long? ShareSizeInGB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.FileShareType ShareType { get { throw null; } set { } }
        public string StorageResourceId { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.FileShareStorageType StorageType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileShareStorageType : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.FileShareStorageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileShareStorageType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.FileShareStorageType PremiumLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.FileShareStorageType StandardGRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.FileShareStorageType StandardLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.FileShareStorageType StandardZRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.FileShareStorageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.FileShareStorageType left, Azure.ResourceManager.Compute.Workloads.Models.FileShareStorageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.FileShareStorageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.FileShareStorageType left, Azure.ResourceManager.Compute.Workloads.Models.FileShareStorageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileShareType : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.FileShareType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileShareType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.FileShareType AzureFiles { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.FileShareType NfsOnController { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.FileShareType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.FileShareType left, Azure.ResourceManager.Compute.Workloads.Models.FileShareType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.FileShareType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.FileShareType left, Azure.ResourceManager.Compute.Workloads.Models.FileShareType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GatewayServerProperties
    {
        public GatewayServerProperties() { }
        public Azure.ResourceManager.Compute.Workloads.Models.SapHealthState? Health { get { throw null; } }
        public long? Port { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HAEnabled : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.HAEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HAEnabled(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.HAEnabled Disabled { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.HAEnabled Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.HAEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.HAEnabled left, Azure.ResourceManager.Compute.Workloads.Models.HAEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.HAEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.HAEnabled left, Azure.ResourceManager.Compute.Workloads.Models.HAEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HanaDbProviderInstanceProperties : Azure.ResourceManager.Compute.Workloads.Models.ProviderSpecificProperties
    {
        public HanaDbProviderInstanceProperties() { }
        public string DbName { get { throw null; } set { } }
        public string DbPassword { get { throw null; } set { } }
        public System.Uri DbPasswordUri { get { throw null; } set { } }
        public System.Uri DbSslCertificateUri { get { throw null; } set { } }
        public string DbUsername { get { throw null; } set { } }
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
    public partial class InfrastructureConfiguration
    {
        public InfrastructureConfiguration(string appResourceGroup) { }
        public string AppResourceGroup { get { throw null; } set { } }
    }
    public partial class LinuxConfiguration : Azure.ResourceManager.Compute.Workloads.Models.OSConfiguration
    {
        public LinuxConfiguration() { }
        public bool? DisablePasswordAuthentication { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.SshKeyPair SshKeyPair { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Workloads.Models.SshPublicKey> SshPublicKeys { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoadBalancerType : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.LoadBalancerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoadBalancerType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.LoadBalancerType ApplicationGateway { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.LoadBalancerType LoadBalancer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.LoadBalancerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.LoadBalancerType left, Azure.ResourceManager.Compute.Workloads.Models.LoadBalancerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.LoadBalancerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.LoadBalancerType left, Azure.ResourceManager.Compute.Workloads.Models.LoadBalancerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LocationType : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.LocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LocationType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.LocationType EdgeZone { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.LocationType Region { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.LocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.LocationType left, Azure.ResourceManager.Compute.Workloads.Models.LocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.LocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.LocationType left, Azure.ResourceManager.Compute.Workloads.Models.LocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedServiceIdentityType : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.ManagedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.ManagedServiceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.ManagedServiceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.ManagedServiceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.ManagedServiceIdentityType left, Azure.ResourceManager.Compute.Workloads.Models.ManagedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.ManagedServiceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.ManagedServiceIdentityType left, Azure.ResourceManager.Compute.Workloads.Models.ManagedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MessageServerProperties
    {
        public MessageServerProperties() { }
        public Azure.ResourceManager.Compute.Workloads.Models.SapHealthState? Health { get { throw null; } }
        public string Hostname { get { throw null; } }
        public long? HttpPort { get { throw null; } }
        public long? HttpsPort { get { throw null; } }
        public long? InternalMsPort { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public long? MsPort { get { throw null; } }
    }
    public partial class MonitorPatch
    {
        public MonitorPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class MsSqlServerProviderInstanceProperties : Azure.ResourceManager.Compute.Workloads.Models.ProviderSpecificProperties
    {
        public MsSqlServerProviderInstanceProperties() { }
        public string DbPassword { get { throw null; } set { } }
        public System.Uri DbPasswordUri { get { throw null; } set { } }
        public string DbPort { get { throw null; } set { } }
        public string DbUsername { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public string SapSid { get { throw null; } set { } }
    }
    public partial class NetworkProfile
    {
        public NetworkProfile(Azure.ResourceManager.Compute.Workloads.Models.LoadBalancerType loadBalancerType) { }
        public Azure.ResourceManager.Compute.Workloads.Models.AzureFrontDoorEnabled? AzureFrontDoorEnabled { get { throw null; } set { } }
        public string AzureFrontDoorResourceId { get { throw null; } }
        public int? Capacity { get { throw null; } set { } }
        public string FrontEndPublicIPResourceId { get { throw null; } }
        public string LoadBalancerResourceId { get { throw null; } }
        public string LoadBalancerSku { get { throw null; } set { } }
        public string LoadBalancerTier { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.LoadBalancerType LoadBalancerType { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> OutboundPublicIPResourceIds { get { throw null; } }
        public string VNetResourceId { get { throw null; } }
    }
    public partial class NodeProfile
    {
        public NodeProfile(string nodeSku, Azure.ResourceManager.Compute.Workloads.Models.OSImageProfile osImage, Azure.ResourceManager.Compute.Workloads.Models.DiskInfo osDisk) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Workloads.Models.DiskInfo> DataDisks { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> NodeResourceIds { get { throw null; } }
        public string NodeSku { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.DiskInfo OSDisk { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.OSImageProfile OSImage { get { throw null; } set { } }
    }
    public partial class OperationStatusResult
    {
        internal OperationStatusResult() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult> Operations { get { throw null; } }
        public float? PercentComplete { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class OSConfiguration
    {
        public OSConfiguration() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OSImageOffer : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.OSImageOffer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OSImageOffer(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.OSImageOffer UbuntuServer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.OSImageOffer other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.OSImageOffer left, Azure.ResourceManager.Compute.Workloads.Models.OSImageOffer right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.OSImageOffer (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.OSImageOffer left, Azure.ResourceManager.Compute.Workloads.Models.OSImageOffer right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OSImageProfile
    {
        public OSImageProfile() { }
        public Azure.ResourceManager.Compute.Workloads.Models.OSImageOffer? Offer { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.OSImagePublisher? Publisher { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.OSImageSku? Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.OSImageVersion? Version { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OSImagePublisher : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.OSImagePublisher>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OSImagePublisher(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.OSImagePublisher Canonical { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.OSImagePublisher other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.OSImagePublisher left, Azure.ResourceManager.Compute.Workloads.Models.OSImagePublisher right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.OSImagePublisher (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.OSImagePublisher left, Azure.ResourceManager.Compute.Workloads.Models.OSImagePublisher right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OSImageSku : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.OSImageSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OSImageSku(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.OSImageSku Eighteen04LTS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.OSImageSku Sixteen04LTS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.OSImageSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.OSImageSku left, Azure.ResourceManager.Compute.Workloads.Models.OSImageSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.OSImageSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.OSImageSku left, Azure.ResourceManager.Compute.Workloads.Models.OSImageSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OSImageVersion : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.OSImageVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OSImageVersion(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.OSImageVersion Latest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.OSImageVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.OSImageVersion left, Azure.ResourceManager.Compute.Workloads.Models.OSImageVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.OSImageVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.OSImageVersion left, Azure.ResourceManager.Compute.Workloads.Models.OSImageVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OSProfile
    {
        public OSProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.OSConfiguration OSConfiguration { get { throw null; } set { } }
    }
    public partial class OSSapConfiguration
    {
        public OSSapConfiguration() { }
        public Azure.ResourceManager.Compute.Workloads.Models.DeployerVmPackages DeployerVmPackages { get { throw null; } set { } }
        public string SapFqdn { get { throw null; } set { } }
    }
    public partial class PatchResourceRequestBodyIdentity : Azure.ResourceManager.Compute.Workloads.Models.UserAssignedServiceIdentity
    {
        public PatchResourceRequestBodyIdentity(Azure.ResourceManager.Compute.Workloads.Models.ManagedServiceIdentityType managedServiceIdentityType) : base (default(Azure.ResourceManager.Compute.Workloads.Models.ManagedServiceIdentityType)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PHPVersion : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.PHPVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PHPVersion(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.PHPVersion Seven2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.PHPVersion Seven3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.PHPVersion Seven4 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.PHPVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.PHPVersion left, Azure.ResourceManager.Compute.Workloads.Models.PHPVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.PHPVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.PHPVersion left, Azure.ResourceManager.Compute.Workloads.Models.PHPVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PhpWorkloadProvisioningState : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.PhpWorkloadProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PhpWorkloadProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.PhpWorkloadProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.PhpWorkloadProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.PhpWorkloadProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.PhpWorkloadProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.PhpWorkloadProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.PhpWorkloadProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.PhpWorkloadProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.PhpWorkloadProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.PhpWorkloadProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.PhpWorkloadProvisioningState left, Azure.ResourceManager.Compute.Workloads.Models.PhpWorkloadProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.PhpWorkloadProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.PhpWorkloadProvisioningState left, Azure.ResourceManager.Compute.Workloads.Models.PhpWorkloadProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PhpWorkloadResourceIdentity : Azure.ResourceManager.Compute.Workloads.Models.UserAssignedServiceIdentity
    {
        public PhpWorkloadResourceIdentity(Azure.ResourceManager.Compute.Workloads.Models.ManagedServiceIdentityType managedServiceIdentityType) : base (default(Azure.ResourceManager.Compute.Workloads.Models.ManagedServiceIdentityType)) { }
    }
    public partial class PhpWorkloadResourcePatch
    {
        public PhpWorkloadResourcePatch() { }
        public Azure.ResourceManager.Compute.Workloads.Models.PatchResourceRequestBodyIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PrometheusHaClusterProviderInstanceProperties : Azure.ResourceManager.Compute.Workloads.Models.ProviderSpecificProperties
    {
        public PrometheusHaClusterProviderInstanceProperties() { }
        public string ClusterName { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public System.Uri PrometheusUri { get { throw null; } set { } }
        public string Sid { get { throw null; } set { } }
    }
    public partial class PrometheusOSProviderInstanceProperties : Azure.ResourceManager.Compute.Workloads.Models.ProviderSpecificProperties
    {
        public PrometheusOSProviderInstanceProperties() { }
        public System.Uri PrometheusUri { get { throw null; } set { } }
    }
    public partial class ProviderSpecificProperties
    {
        public ProviderSpecificProperties() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisCacheFamily : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.RedisCacheFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisCacheFamily(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.RedisCacheFamily C { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.RedisCacheFamily P { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.RedisCacheFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.RedisCacheFamily left, Azure.ResourceManager.Compute.Workloads.Models.RedisCacheFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.RedisCacheFamily (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.RedisCacheFamily left, Azure.ResourceManager.Compute.Workloads.Models.RedisCacheFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoutingPreference : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.RoutingPreference>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoutingPreference(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.RoutingPreference Default { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.RoutingPreference RouteAll { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.RoutingPreference other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.RoutingPreference left, Azure.ResourceManager.Compute.Workloads.Models.RoutingPreference right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.RoutingPreference (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.RoutingPreference left, Azure.ResourceManager.Compute.Workloads.Models.RoutingPreference right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapApplicationServerInstancePatch
    {
        public SapApplicationServerInstancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class SapAvailabilityZoneDetailsContent
    {
        public SapAvailabilityZoneDetailsContent(string appLocation, Azure.ResourceManager.Compute.Workloads.Models.SapProductType sapProduct, Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseType databaseType) { }
        public string AppLocation { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseType DatabaseType { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapProductType SapProduct { get { throw null; } }
    }
    public partial class SapAvailabilityZoneDetailsResult
    {
        internal SapAvailabilityZoneDetailsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Workloads.Models.SapAvailabilityZonePair> AvailabilityZonePairs { get { throw null; } }
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
    public partial class SapConfiguration
    {
        public SapConfiguration() { }
    }
    public partial class SapDatabaseInstancePatch
    {
        public SapDatabaseInstancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapDatabaseScaleMethod : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseScaleMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapDatabaseScaleMethod(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseScaleMethod ScaleUp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseScaleMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseScaleMethod left, Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseScaleMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseScaleMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseScaleMethod left, Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseScaleMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapDatabaseType : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapDatabaseType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseType DB2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseType Hana { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseType left, Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseType left, Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapDeploymentType : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.SapDeploymentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapDeploymentType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapDeploymentType SingleServer { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapDeploymentType ThreeTier { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.SapDeploymentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.SapDeploymentType left, Azure.ResourceManager.Compute.Workloads.Models.SapDeploymentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.SapDeploymentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.SapDeploymentType left, Azure.ResourceManager.Compute.Workloads.Models.SapDeploymentType right) { throw null; }
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
        public SapDiskConfigurationsContent(string appLocation, Azure.ResourceManager.Compute.Workloads.Models.SapEnvironmentType environment, Azure.ResourceManager.Compute.Workloads.Models.SapProductType sapProduct, Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseType databaseType, Azure.ResourceManager.Compute.Workloads.Models.SapDeploymentType deploymentType, string dbVmSku) { }
        public string AppLocation { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseType DatabaseType { get { throw null; } }
        public string DbVmSku { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapDeploymentType DeploymentType { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapEnvironmentType Environment { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapProductType SapProduct { get { throw null; } }
    }
    public partial class SapDiskConfigurationsResult
    {
        internal SapDiskConfigurationsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Workloads.Models.SapDiskConfiguration> DiskConfigurations { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapEnvironmentType : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.SapEnvironmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapEnvironmentType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapEnvironmentType NonProd { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapEnvironmentType Prod { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.SapEnvironmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.SapEnvironmentType left, Azure.ResourceManager.Compute.Workloads.Models.SapEnvironmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.SapEnvironmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.SapEnvironmentType left, Azure.ResourceManager.Compute.Workloads.Models.SapEnvironmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapHealthState : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.SapHealthState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapHealthState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapHealthState Degraded { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapHealthState Healthy { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapHealthState Unhealthy { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapHealthState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.SapHealthState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.SapHealthState left, Azure.ResourceManager.Compute.Workloads.Models.SapHealthState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.SapHealthState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.SapHealthState left, Azure.ResourceManager.Compute.Workloads.Models.SapHealthState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapHighAvailabilityType : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.SapHighAvailabilityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapHighAvailabilityType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapHighAvailabilityType AvailabilitySet { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapHighAvailabilityType AvailabilityZone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.SapHighAvailabilityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.SapHighAvailabilityType left, Azure.ResourceManager.Compute.Workloads.Models.SapHighAvailabilityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.SapHighAvailabilityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.SapHighAvailabilityType left, Azure.ResourceManager.Compute.Workloads.Models.SapHighAvailabilityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapInstallWithoutOSConfigSoftwareConfiguration : Azure.ResourceManager.Compute.Workloads.Models.SoftwareConfiguration
    {
        public SapInstallWithoutOSConfigSoftwareConfiguration(System.Uri bomUri, string sapBitsStorageAccountId, string softwareVersion) { }
        public System.Uri BomUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.HighAvailabilitySoftwareConfiguration HighAvailabilitySoftwareConfiguration { get { throw null; } set { } }
        public string SapBitsStorageAccountId { get { throw null; } set { } }
        public string SoftwareVersion { get { throw null; } set { } }
    }
    public partial class SapNetWeaverProviderInstanceProperties : Azure.ResourceManager.Compute.Workloads.Models.ProviderSpecificProperties
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
    public readonly partial struct SapProductType : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.SapProductType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapProductType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapProductType ECC { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapProductType Other { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapProductType S4Hana { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.SapProductType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.SapProductType left, Azure.ResourceManager.Compute.Workloads.Models.SapProductType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.SapProductType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.SapProductType left, Azure.ResourceManager.Compute.Workloads.Models.SapProductType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapSizingRecommendationContent
    {
        public SapSizingRecommendationContent(string appLocation, Azure.ResourceManager.Compute.Workloads.Models.SapEnvironmentType environment, Azure.ResourceManager.Compute.Workloads.Models.SapProductType sapProduct, Azure.ResourceManager.Compute.Workloads.Models.SapDeploymentType deploymentType, long saps, long dbMemory, Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseType databaseType) { }
        public string AppLocation { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseType DatabaseType { get { throw null; } }
        public long DbMemory { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseScaleMethod? DbScaleMethod { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapDeploymentType DeploymentType { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapEnvironmentType Environment { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapHighAvailabilityType? HighAvailabilityType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapProductType SapProduct { get { throw null; } }
        public long Saps { get { throw null; } }
    }
    public partial class SapSizingRecommendationResult
    {
        internal SapSizingRecommendationResult() { }
    }
    public partial class SapSupportedResourceSkusResult
    {
        internal SapSupportedResourceSkusResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Workloads.Models.SapSupportedSku> SupportedSkus { get { throw null; } }
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
        public SapSupportedSkusContent(string appLocation, Azure.ResourceManager.Compute.Workloads.Models.SapEnvironmentType environment, Azure.ResourceManager.Compute.Workloads.Models.SapProductType sapProduct, Azure.ResourceManager.Compute.Workloads.Models.SapDeploymentType deploymentType, Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseType databaseType) { }
        public string AppLocation { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseType DatabaseType { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapDeploymentType DeploymentType { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapEnvironmentType Environment { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapHighAvailabilityType? HighAvailabilityType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapProductType SapProduct { get { throw null; } }
    }
    public partial class SapVirtualInstancePatch
    {
        public SapVirtualInstancePatch() { }
        public Azure.ResourceManager.Compute.Workloads.Models.UserAssignedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapVirtualInstanceProvisioningState : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapVirtualInstanceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceProvisioningState left, Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceProvisioningState left, Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapVirtualInstanceState : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapVirtualInstanceState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceState DiscoveryFailed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceState DiscoveryInProgress { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceState DiscoveryPending { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceState InfrastructureDeploymentFailed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceState InfrastructureDeploymentInProgress { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceState InfrastructureDeploymentPending { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceState RegistrationComplete { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceState SoftwareInstallationFailed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceState SoftwareInstallationInProgress { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceState SoftwareInstallationPending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceState left, Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceState left, Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapVirtualInstanceStatus : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapVirtualInstanceStatus(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceStatus PartiallyRunning { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceStatus Running { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceStatus Starting { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceStatus Stopping { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceStatus Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceStatus left, Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceStatus left, Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SearchProfile : Azure.ResourceManager.Compute.Workloads.Models.NodeProfile
    {
        public SearchProfile(string nodeSku, Azure.ResourceManager.Compute.Workloads.Models.OSImageProfile osImage, Azure.ResourceManager.Compute.Workloads.Models.DiskInfo osDisk, Azure.ResourceManager.Compute.Workloads.Models.SearchType searchType) : base (default(string), default(Azure.ResourceManager.Compute.Workloads.Models.OSImageProfile), default(Azure.ResourceManager.Compute.Workloads.Models.DiskInfo)) { }
        public Azure.ResourceManager.Compute.Workloads.Models.SearchType SearchType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchType : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.SearchType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.SearchType Elastic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.SearchType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.SearchType left, Azure.ResourceManager.Compute.Workloads.Models.SearchType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.SearchType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.SearchType left, Azure.ResourceManager.Compute.Workloads.Models.SearchType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceInitiatedSoftwareConfiguration : Azure.ResourceManager.Compute.Workloads.Models.SoftwareConfiguration
    {
        public ServiceInitiatedSoftwareConfiguration(System.Uri bomUri, string softwareVersion, string sapBitsStorageAccountId, string sapFqdn, string sshPrivateKey) { }
        public System.Uri BomUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.HighAvailabilitySoftwareConfiguration HighAvailabilitySoftwareConfiguration { get { throw null; } set { } }
        public string SapBitsStorageAccountId { get { throw null; } set { } }
        public string SapFqdn { get { throw null; } set { } }
        public string SoftwareVersion { get { throw null; } set { } }
        public string SshPrivateKey { get { throw null; } set { } }
    }
    public partial class SingleServerConfiguration : Azure.ResourceManager.Compute.Workloads.Models.InfrastructureConfiguration
    {
        public SingleServerConfiguration(string appResourceGroup, string subnetId, Azure.ResourceManager.Compute.Workloads.Models.VirtualMachineConfiguration virtualMachineConfiguration) : base (default(string)) { }
        public Azure.ResourceManager.Compute.Workloads.Models.SapDatabaseType? DatabaseType { get { throw null; } set { } }
        public bool? IsSecondaryIPEnabled { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.VirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
    }
    public partial class SingleServerRecommendationResult : Azure.ResourceManager.Compute.Workloads.Models.SapSizingRecommendationResult
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Workloads.Models.SkuCapability> Capabilities { get { throw null; } }
        public System.BinaryData Capacity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Workloads.Models.SkuCost> Costs { get { throw null; } }
        public string Family { get { throw null; } }
        public string Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Workloads.Models.SkuLocationAndZones> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Workloads.Models.SkuRestriction> Restrictions { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class SkuLocationAndZones
    {
        internal SkuLocationAndZones() { }
        public System.Collections.Generic.IReadOnlyList<string> ExtendedLocations { get { throw null; } }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.LocationType? LocationType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Workloads.Models.SkuZoneDetail> ZoneDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class SkuRestriction
    {
        internal SkuRestriction() { }
        public Azure.ResourceManager.Compute.Workloads.Models.SkuRestrictionReasonCode? ReasonCode { get { throw null; } }
        public System.BinaryData RestrictionInfo { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SkuRestrictionType? RestrictionType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuRestrictionReasonCode : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.SkuRestrictionReasonCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuRestrictionReasonCode(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.SkuRestrictionReasonCode NotAvailableForSubscription { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SkuRestrictionReasonCode NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SkuRestrictionReasonCode QuotaId { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.SkuRestrictionReasonCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.SkuRestrictionReasonCode left, Azure.ResourceManager.Compute.Workloads.Models.SkuRestrictionReasonCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.SkuRestrictionReasonCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.SkuRestrictionReasonCode left, Azure.ResourceManager.Compute.Workloads.Models.SkuRestrictionReasonCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuRestrictionType : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.SkuRestrictionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuRestrictionType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.SkuRestrictionType Location { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SkuRestrictionType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SkuRestrictionType Zone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.SkuRestrictionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.SkuRestrictionType left, Azure.ResourceManager.Compute.Workloads.Models.SkuRestrictionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.SkuRestrictionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.SkuRestrictionType left, Azure.ResourceManager.Compute.Workloads.Models.SkuRestrictionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SkuZoneDetail
    {
        internal SkuZoneDetail() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Workloads.Models.SkuCapability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class SoftwareConfiguration
    {
        public SoftwareConfiguration() { }
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
    public partial class ThreeTierConfiguration : Azure.ResourceManager.Compute.Workloads.Models.InfrastructureConfiguration
    {
        public ThreeTierConfiguration(string appResourceGroup, Azure.ResourceManager.Compute.Workloads.Models.CentralServerConfiguration centralServer, Azure.ResourceManager.Compute.Workloads.Models.ApplicationServerConfiguration applicationServer, Azure.ResourceManager.Compute.Workloads.Models.DatabaseConfiguration databaseServer) : base (default(string)) { }
        public Azure.ResourceManager.Compute.Workloads.Models.ApplicationServerConfiguration ApplicationServer { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.CentralServerConfiguration CentralServer { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.DatabaseConfiguration DatabaseServer { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapHighAvailabilityType? HighAvailabilityType { get { throw null; } set { } }
        public bool? IsSecondaryIPEnabled { get { throw null; } set { } }
    }
    public partial class ThreeTierRecommendationResult : Azure.ResourceManager.Compute.Workloads.Models.SapSizingRecommendationResult
    {
        internal ThreeTierRecommendationResult() { }
        public long? ApplicationServerInstanceCount { get { throw null; } }
        public string ApplicationServerVmSku { get { throw null; } }
        public long? CentralServerInstanceCount { get { throw null; } }
        public string CentralServerVmSku { get { throw null; } }
        public long? DatabaseInstanceCount { get { throw null; } }
        public string DbVmSku { get { throw null; } }
    }
    public partial class UserAssignedServiceIdentity
    {
        public UserAssignedServiceIdentity(Azure.ResourceManager.Compute.Workloads.Models.ManagedServiceIdentityType managedServiceIdentityType) { }
        public Azure.ResourceManager.Compute.Workloads.Models.ManagedServiceIdentityType ManagedServiceIdentityType { get { throw null; } set { } }
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
        public VirtualMachineConfiguration(string vmSize, Azure.ResourceManager.Compute.Workloads.Models.ImageReference imageReference, Azure.ResourceManager.Compute.Workloads.Models.OSProfile osProfile) { }
        public Azure.ResourceManager.Compute.Workloads.Models.ImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.OSProfile OSProfile { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class VmssNodesProfile : Azure.ResourceManager.Compute.Workloads.Models.NodeProfile
    {
        public VmssNodesProfile(string nodeSku, Azure.ResourceManager.Compute.Workloads.Models.OSImageProfile osImage, Azure.ResourceManager.Compute.Workloads.Models.DiskInfo osDisk) : base (default(string), default(Azure.ResourceManager.Compute.Workloads.Models.OSImageProfile), default(Azure.ResourceManager.Compute.Workloads.Models.DiskInfo)) { }
        public int? AutoScaleMaxCount { get { throw null; } set { } }
        public int? AutoScaleMinCount { get { throw null; } set { } }
    }
    public partial class WindowsConfiguration : Azure.ResourceManager.Compute.Workloads.Models.OSConfiguration
    {
        public WindowsConfiguration() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WordpressVersions : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.WordpressVersions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WordpressVersions(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.WordpressVersions Five4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.WordpressVersions Five41 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.WordpressVersions Five42 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.WordpressVersions Five43 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.WordpressVersions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.WordpressVersions left, Azure.ResourceManager.Compute.Workloads.Models.WordpressVersions right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.WordpressVersions (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.WordpressVersions left, Azure.ResourceManager.Compute.Workloads.Models.WordpressVersions right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadKind : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.WorkloadKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadKind(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.WorkloadKind WordPress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.WorkloadKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.WorkloadKind left, Azure.ResourceManager.Compute.Workloads.Models.WorkloadKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.WorkloadKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.WorkloadKind left, Azure.ResourceManager.Compute.Workloads.Models.WorkloadKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadMonitorProvisioningState : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.WorkloadMonitorProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadMonitorProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.WorkloadMonitorProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.WorkloadMonitorProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.WorkloadMonitorProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.WorkloadMonitorProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.WorkloadMonitorProvisioningState Migrating { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.WorkloadMonitorProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.WorkloadMonitorProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.WorkloadMonitorProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.WorkloadMonitorProvisioningState left, Azure.ResourceManager.Compute.Workloads.Models.WorkloadMonitorProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.WorkloadMonitorProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.WorkloadMonitorProvisioningState left, Azure.ResourceManager.Compute.Workloads.Models.WorkloadMonitorProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkloadsSku
    {
        public WorkloadsSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.WorkloadsSkuTier? Tier { get { throw null; } set { } }
    }
    public enum WorkloadsSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
}
