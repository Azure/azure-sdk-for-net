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
    public partial class SAPApplicationServerInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource>, System.Collections.IEnumerable
    {
        protected SAPApplicationServerInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationInstanceName, Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationInstanceName, Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource> Get(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource>> GetAsync(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SAPApplicationServerInstanceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SAPApplicationServerInstanceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Workloads.Models.ErrorDefinition ErrorsProperties { get { throw null; } }
        public long? GatewayPort { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPHealthState? Health { get { throw null; } }
        public string Hostname { get { throw null; } }
        public long? IcmHttpPort { get { throw null; } }
        public long? IcmHttpsPort { get { throw null; } }
        public string InstanceNo { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public string KernelPatch { get { throw null; } }
        public string KernelVersion { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceStatus? Status { get { throw null; } }
        public string Subnet { get { throw null; } }
        public string VirtualMachineId { get { throw null; } }
    }
    public partial class SAPApplicationServerInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SAPApplicationServerInstanceResource() { }
        public virtual Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sapVirtualInstanceName, string applicationInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Workloads.Models.SAPApplicationServerInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Workloads.Models.SAPApplicationServerInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SAPCentralServerInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource>, System.Collections.IEnumerable
    {
        protected SAPCentralServerInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string centralInstanceName, Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string centralInstanceName, Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource> Get(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource>> GetAsync(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SAPCentralServerInstanceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SAPCentralServerInstanceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Workloads.Models.EnqueueReplicationServerProperties EnqueueReplicationServerProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.EnqueueServerProperties EnqueueServerProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.ErrorDefinition ErrorsProperties { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.GatewayServerProperties GatewayServerProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPHealthState? Health { get { throw null; } }
        public string InstanceNo { get { throw null; } }
        public string KernelPatch { get { throw null; } }
        public string KernelVersion { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.MessageServerProperties MessageServerProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceStatus? Status { get { throw null; } }
        public string Subnet { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Workloads.Models.CentralServerVmDetails> VmDetails { get { throw null; } }
    }
    public partial class SAPCentralServerInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SAPCentralServerInstanceResource() { }
        public virtual Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sapVirtualInstanceName, string centralInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Workloads.Models.SAPCentralServerInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Workloads.Models.SAPCentralServerInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SAPDatabaseInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource>, System.Collections.IEnumerable
    {
        protected SAPDatabaseInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseInstanceName, Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseInstanceName, Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource> Get(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource>> GetAsync(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SAPDatabaseInstanceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SAPDatabaseInstanceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string DatabaseSid { get { throw null; } }
        public string DatabaseType { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.ErrorDefinition ErrorsProperties { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceStatus? Status { get { throw null; } }
        public string Subnet { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Workloads.Models.DatabaseVmDetails> VmDetails { get { throw null; } }
    }
    public partial class SAPDatabaseInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SAPDatabaseInstanceResource() { }
        public virtual Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sapVirtualInstanceName, string databaseInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SAPVirtualInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource>, System.Collections.IEnumerable
    {
        protected SAPVirtualInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sapVirtualInstanceName, Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sapVirtualInstanceName, Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource> Get(string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource>> GetAsync(string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SAPVirtualInstanceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SAPVirtualInstanceData(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.Workloads.Models.SAPEnvironmentType environment, Azure.ResourceManager.Compute.Workloads.Models.SAPProductType sapProduct, Azure.ResourceManager.Compute.Workloads.Models.SAPConfiguration configuration) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPConfiguration Configuration { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPEnvironmentType Environment { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.ErrorDefinition ErrorsProperties { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPHealthState? Health { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.UserAssignedServiceIdentity Identity { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.SapVirtualInstanceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPProductType SapProduct { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceState? State { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceStatus? Status { get { throw null; } }
    }
    public partial class SAPVirtualInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SAPVirtualInstanceResource() { }
        public virtual Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sapVirtualInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource> GetSAPApplicationServerInstance(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource>> GetSAPApplicationServerInstanceAsync(string applicationInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceCollection GetSAPApplicationServerInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource> GetSAPCentralServerInstance(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource>> GetSAPCentralServerInstanceAsync(string centralInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceCollection GetSAPCentralServerInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource> GetSAPDatabaseInstance(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource>> GetSAPDatabaseInstanceAsync(string databaseInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceCollection GetSAPDatabaseInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult> Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult>> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult> Stop(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Workloads.Models.StopContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Workloads.Models.OperationStatusResult>> StopAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Workloads.Models.StopContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource> Update(Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource>> UpdateAsync(Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.Compute.Workloads.SAPApplicationServerInstanceResource GetSAPApplicationServerInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.SAPCentralServerInstanceResource GetSAPCentralServerInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.SAPDatabaseInstanceResource GetSAPDatabaseInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource> GetSAPVirtualInstance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource>> GetSAPVirtualInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sapVirtualInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource GetSAPVirtualInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceCollection GetSAPVirtualInstances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource> GetSAPVirtualInstances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Workloads.SAPVirtualInstanceResource> GetSAPVirtualInstancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Workloads.Models.SkuDefinition> GetSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Workloads.Models.SkuDefinition> GetSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.WordpressInstanceResource GetWordpressInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Workloads.Models.SAPAvailabilityZoneDetailsResult> SAPAvailabilityZoneDetails(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.Compute.Workloads.Models.SAPAvailabilityZoneDetailsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.Models.SAPAvailabilityZoneDetailsResult>> SAPAvailabilityZoneDetailsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.Compute.Workloads.Models.SAPAvailabilityZoneDetailsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Workloads.Models.SAPDiskConfigurationsResult> SAPDiskConfigurations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.Compute.Workloads.Models.SAPDiskConfigurationsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.Models.SAPDiskConfigurationsResult>> SAPDiskConfigurationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.Compute.Workloads.Models.SAPDiskConfigurationsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Workloads.Models.SAPSizingRecommendationResult> SAPSizingRecommendations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.Compute.Workloads.Models.SAPSizingRecommendationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.Models.SAPSizingRecommendationResult>> SAPSizingRecommendationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.Compute.Workloads.Models.SAPSizingRecommendationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Workloads.Models.SAPSupportedResourceSkusResult> SAPSupportedSku(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.Compute.Workloads.Models.SAPSupportedSkusContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Workloads.Models.SAPSupportedResourceSkusResult>> SAPSupportedSkuAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.Compute.Workloads.Models.SAPSupportedSkusContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseType? DatabaseType { get { throw null; } set { } }
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
        public Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceStatus? Status { get { throw null; } }
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
    public partial class DeploymentConfiguration : Azure.ResourceManager.Compute.Workloads.Models.SAPConfiguration
    {
        public DeploymentConfiguration() { }
        public string AppLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.InfrastructureConfiguration InfrastructureConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.SoftwareConfiguration SoftwareConfiguration { get { throw null; } set { } }
    }
    public partial class DeploymentWithOSConfiguration : Azure.ResourceManager.Compute.Workloads.Models.SAPConfiguration
    {
        public DeploymentWithOSConfiguration() { }
        public string AppLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.InfrastructureConfiguration InfrastructureConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.OSSapConfiguration OSSapConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.SoftwareConfiguration SoftwareConfiguration { get { throw null; } set { } }
    }
    public partial class DiscoveryConfiguration : Azure.ResourceManager.Compute.Workloads.Models.SAPConfiguration
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
        public Azure.ResourceManager.Compute.Workloads.Models.SAPHealthState? Health { get { throw null; } }
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
        public Azure.ResourceManager.Compute.Workloads.Models.SAPHealthState? Health { get { throw null; } }
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
        public Azure.ResourceManager.Compute.Workloads.Models.SAPHealthState? Health { get { throw null; } }
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
        public Azure.ResourceManager.Compute.Workloads.Models.SAPHealthState? Health { get { throw null; } }
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
    public partial class SAPApplicationServerInstancePatch
    {
        public SAPApplicationServerInstancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class SAPAvailabilityZoneDetailsContent
    {
        public SAPAvailabilityZoneDetailsContent(string appLocation, Azure.ResourceManager.Compute.Workloads.Models.SAPProductType sapProduct, Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseType databaseType) { }
        public string AppLocation { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseType DatabaseType { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPProductType SapProduct { get { throw null; } }
    }
    public partial class SAPAvailabilityZoneDetailsResult
    {
        internal SAPAvailabilityZoneDetailsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Workloads.Models.SAPAvailabilityZonePair> AvailabilityZonePairs { get { throw null; } }
    }
    public partial class SAPAvailabilityZonePair
    {
        internal SAPAvailabilityZonePair() { }
        public long? ZoneA { get { throw null; } }
        public long? ZoneB { get { throw null; } }
    }
    public partial class SAPCentralServerInstancePatch
    {
        public SAPCentralServerInstancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class SAPConfiguration
    {
        public SAPConfiguration() { }
    }
    public partial class SAPDatabaseInstancePatch
    {
        public SAPDatabaseInstancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SAPDatabaseScaleMethod : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseScaleMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SAPDatabaseScaleMethod(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseScaleMethod ScaleUp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseScaleMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseScaleMethod left, Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseScaleMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseScaleMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseScaleMethod left, Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseScaleMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SAPDatabaseType : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SAPDatabaseType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseType DB2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseType Hana { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseType left, Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseType left, Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SAPDeploymentType : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.SAPDeploymentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SAPDeploymentType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPDeploymentType SingleServer { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPDeploymentType ThreeTier { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.SAPDeploymentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.SAPDeploymentType left, Azure.ResourceManager.Compute.Workloads.Models.SAPDeploymentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.SAPDeploymentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.SAPDeploymentType left, Azure.ResourceManager.Compute.Workloads.Models.SAPDeploymentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SAPDiskConfiguration
    {
        internal SAPDiskConfiguration() { }
        public long? DiskCount { get { throw null; } }
        public long? DiskIopsReadWrite { get { throw null; } }
        public long? DiskMBpsReadWrite { get { throw null; } }
        public long? DiskSizeGB { get { throw null; } }
        public string DiskStorageType { get { throw null; } }
        public string DiskType { get { throw null; } }
        public string Volume { get { throw null; } }
    }
    public partial class SAPDiskConfigurationsContent
    {
        public SAPDiskConfigurationsContent(string appLocation, Azure.ResourceManager.Compute.Workloads.Models.SAPEnvironmentType environment, Azure.ResourceManager.Compute.Workloads.Models.SAPProductType sapProduct, Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseType databaseType, Azure.ResourceManager.Compute.Workloads.Models.SAPDeploymentType deploymentType, string dbVmSku) { }
        public string AppLocation { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseType DatabaseType { get { throw null; } }
        public string DbVmSku { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPDeploymentType DeploymentType { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPEnvironmentType Environment { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPProductType SapProduct { get { throw null; } }
    }
    public partial class SAPDiskConfigurationsResult
    {
        internal SAPDiskConfigurationsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Workloads.Models.SAPDiskConfiguration> DiskConfigurations { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SAPEnvironmentType : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.SAPEnvironmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SAPEnvironmentType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPEnvironmentType NonProd { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPEnvironmentType Prod { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.SAPEnvironmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.SAPEnvironmentType left, Azure.ResourceManager.Compute.Workloads.Models.SAPEnvironmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.SAPEnvironmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.SAPEnvironmentType left, Azure.ResourceManager.Compute.Workloads.Models.SAPEnvironmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SAPHealthState : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.SAPHealthState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SAPHealthState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPHealthState Degraded { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPHealthState Healthy { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPHealthState Unhealthy { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPHealthState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.SAPHealthState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.SAPHealthState left, Azure.ResourceManager.Compute.Workloads.Models.SAPHealthState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.SAPHealthState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.SAPHealthState left, Azure.ResourceManager.Compute.Workloads.Models.SAPHealthState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SAPHighAvailabilityType : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.SAPHighAvailabilityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SAPHighAvailabilityType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPHighAvailabilityType AvailabilitySet { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPHighAvailabilityType AvailabilityZone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.SAPHighAvailabilityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.SAPHighAvailabilityType left, Azure.ResourceManager.Compute.Workloads.Models.SAPHighAvailabilityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.SAPHighAvailabilityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.SAPHighAvailabilityType left, Azure.ResourceManager.Compute.Workloads.Models.SAPHighAvailabilityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SAPInstallWithoutOSConfigSoftwareConfiguration : Azure.ResourceManager.Compute.Workloads.Models.SoftwareConfiguration
    {
        public SAPInstallWithoutOSConfigSoftwareConfiguration(System.Uri bomUri, string sapBitsStorageAccountId, string softwareVersion) { }
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
    public readonly partial struct SAPProductType : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.SAPProductType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SAPProductType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPProductType ECC { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPProductType Other { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPProductType S4Hana { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.SAPProductType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.SAPProductType left, Azure.ResourceManager.Compute.Workloads.Models.SAPProductType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.SAPProductType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.SAPProductType left, Azure.ResourceManager.Compute.Workloads.Models.SAPProductType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SAPSizingRecommendationContent
    {
        public SAPSizingRecommendationContent(string appLocation, Azure.ResourceManager.Compute.Workloads.Models.SAPEnvironmentType environment, Azure.ResourceManager.Compute.Workloads.Models.SAPProductType sapProduct, Azure.ResourceManager.Compute.Workloads.Models.SAPDeploymentType deploymentType, long saps, long dbMemory, Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseType databaseType) { }
        public string AppLocation { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseType DatabaseType { get { throw null; } }
        public long DbMemory { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseScaleMethod? DbScaleMethod { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPDeploymentType DeploymentType { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPEnvironmentType Environment { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPHighAvailabilityType? HighAvailabilityType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPProductType SapProduct { get { throw null; } }
        public long Saps { get { throw null; } }
    }
    public partial class SAPSizingRecommendationResult
    {
        internal SAPSizingRecommendationResult() { }
    }
    public partial class SAPSupportedResourceSkusResult
    {
        internal SAPSupportedResourceSkusResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Workloads.Models.SAPSupportedSku> SupportedSkus { get { throw null; } }
    }
    public partial class SAPSupportedSku
    {
        internal SAPSupportedSku() { }
        public bool? IsAppServerCertified { get { throw null; } }
        public bool? IsDatabaseCertified { get { throw null; } }
        public string VmSku { get { throw null; } }
    }
    public partial class SAPSupportedSkusContent
    {
        public SAPSupportedSkusContent(string appLocation, Azure.ResourceManager.Compute.Workloads.Models.SAPEnvironmentType environment, Azure.ResourceManager.Compute.Workloads.Models.SAPProductType sapProduct, Azure.ResourceManager.Compute.Workloads.Models.SAPDeploymentType deploymentType, Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseType databaseType) { }
        public string AppLocation { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseType DatabaseType { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPDeploymentType DeploymentType { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPEnvironmentType Environment { get { throw null; } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPHighAvailabilityType? HighAvailabilityType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.SAPProductType SapProduct { get { throw null; } }
    }
    public partial class SAPVirtualInstancePatch
    {
        public SAPVirtualInstancePatch() { }
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
    public readonly partial struct SAPVirtualInstanceState : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SAPVirtualInstanceState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceState DiscoveryFailed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceState DiscoveryInProgress { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceState DiscoveryPending { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceState InfrastructureDeploymentFailed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceState InfrastructureDeploymentInProgress { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceState InfrastructureDeploymentPending { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceState RegistrationComplete { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceState SoftwareInstallationFailed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceState SoftwareInstallationInProgress { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceState SoftwareInstallationPending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceState left, Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceState left, Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SAPVirtualInstanceStatus : System.IEquatable<Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SAPVirtualInstanceStatus(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceStatus PartiallyRunning { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceStatus Running { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceStatus Starting { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceStatus Stopping { get { throw null; } }
        public static Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceStatus Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceStatus left, Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceStatus left, Azure.ResourceManager.Compute.Workloads.Models.SAPVirtualInstanceStatus right) { throw null; }
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
        public Azure.ResourceManager.Compute.Workloads.Models.SAPDatabaseType? DatabaseType { get { throw null; } set { } }
        public bool? IsSecondaryIPEnabled { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Workloads.Models.VirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
    }
    public partial class SingleServerRecommendationResult : Azure.ResourceManager.Compute.Workloads.Models.SAPSizingRecommendationResult
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
        public Azure.ResourceManager.Compute.Workloads.Models.SAPHighAvailabilityType? HighAvailabilityType { get { throw null; } set { } }
        public bool? IsSecondaryIPEnabled { get { throw null; } set { } }
    }
    public partial class ThreeTierRecommendationResult : Azure.ResourceManager.Compute.Workloads.Models.SAPSizingRecommendationResult
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
