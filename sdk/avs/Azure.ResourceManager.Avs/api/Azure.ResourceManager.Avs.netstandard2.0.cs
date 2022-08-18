namespace Azure.ResourceManager.Avs
{
    public partial class AddonCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AddonResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AddonResource>, System.Collections.IEnumerable
    {
        protected AddonCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AddonResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string addonName, Azure.ResourceManager.Avs.AddonData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AddonResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string addonName, Azure.ResourceManager.Avs.AddonData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AddonResource> Get(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.AddonResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.AddonResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AddonResource>> GetAsync(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.AddonResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AddonResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.AddonResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AddonResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AddonData : Azure.ResourceManager.Models.ResourceData
    {
        public AddonData() { }
        public Azure.ResourceManager.Avs.Models.AddonProperties Properties { get { throw null; } set { } }
    }
    public partial class AddonResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AddonResource() { }
        public virtual Azure.ResourceManager.Avs.AddonData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string addonName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AddonResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AddonResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AddonResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.AddonData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AddonResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.AddonData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class AvsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Avs.Models.Quota> CheckQuotaAvailabilityLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.Models.Quota>> CheckQuotaAvailabilityLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Avs.Models.Trial> CheckTrialAvailabilityLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.Models.Trial>> CheckTrialAvailabilityLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Avs.AddonResource GetAddonResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.CloudLinkResource GetCloudLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.ClusterResource GetClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.DatastoreResource GetDatastoreResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource GetExpressRouteAuthorizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.GlobalReachConnectionResource GetGlobalReachConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.HcxEnterpriseSiteResource GetHcxEnterpriseSiteResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.PlacementPolicyResource GetPlacementPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource> GetPrivateCloud(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource>> GetPrivateCloudAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Avs.PrivateCloudResource GetPrivateCloudResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.PrivateCloudCollection GetPrivateClouds(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Avs.PrivateCloudResource> GetPrivateClouds(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Avs.PrivateCloudResource> GetPrivateCloudsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Avs.ScriptCmdletResource GetScriptCmdletResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.ScriptExecutionResource GetScriptExecutionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.ScriptPackageResource GetScriptPackageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.VirtualMachineResource GetVirtualMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource GetWorkloadNetworkDhcpResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource GetWorkloadNetworkDnsServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource GetWorkloadNetworkDnsZoneResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource GetWorkloadNetworkGatewayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource GetWorkloadNetworkPortMirroringResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource GetWorkloadNetworkPublicIPResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource GetWorkloadNetworkSegmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource GetWorkloadNetworkVirtualMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource GetWorkloadNetworkVmGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class CloudLinkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.CloudLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.CloudLinkResource>, System.Collections.IEnumerable
    {
        protected CloudLinkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.CloudLinkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cloudLinkName, Azure.ResourceManager.Avs.CloudLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.CloudLinkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cloudLinkName, Azure.ResourceManager.Avs.CloudLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.CloudLinkResource> Get(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.CloudLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.CloudLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.CloudLinkResource>> GetAsync(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.CloudLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.CloudLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.CloudLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.CloudLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CloudLinkData : Azure.ResourceManager.Models.ResourceData
    {
        public CloudLinkData() { }
        public string LinkedCloud { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.CloudLinkStatus? Status { get { throw null; } }
    }
    public partial class CloudLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudLinkResource() { }
        public virtual Azure.ResourceManager.Avs.CloudLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string cloudLinkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.CloudLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.CloudLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.CloudLinkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.CloudLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.CloudLinkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.CloudLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.ClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.ClusterResource>, System.Collections.IEnumerable
    {
        protected ClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.ClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Avs.ClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.ClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Avs.ClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.ClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.ClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.ClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.ClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.ClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.ClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ClusterData : Azure.ResourceManager.Models.ResourceData
    {
        public ClusterData(Azure.ResourceManager.Avs.Models.AvsSku sku) { }
        public int? ClusterId { get { throw null; } }
        public int? ClusterSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Hosts { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ClusterProvisioningState? ProvisioningState { get { throw null; } }
        public string SkuName { get { throw null; } set { } }
    }
    public partial class ClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ClusterResource() { }
        public virtual Azure.ResourceManager.Avs.ClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.DatastoreResource> GetDatastore(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.DatastoreResource>> GetDatastoreAsync(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.DatastoreCollection GetDatastores() { throw null; }
        public virtual Azure.ResourceManager.Avs.PlacementPolicyCollection GetPlacementPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.PlacementPolicyResource> GetPlacementPolicy(string placementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.PlacementPolicyResource>> GetPlacementPolicyAsync(string placementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.VirtualMachineResource> GetVirtualMachine(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.VirtualMachineResource>> GetVirtualMachineAsync(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.VirtualMachineCollection GetVirtualMachines() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.ClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.ClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.ClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.ClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatastoreCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.DatastoreResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.DatastoreResource>, System.Collections.IEnumerable
    {
        protected DatastoreCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.DatastoreResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string datastoreName, Azure.ResourceManager.Avs.DatastoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.DatastoreResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string datastoreName, Azure.ResourceManager.Avs.DatastoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.DatastoreResource> Get(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.DatastoreResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.DatastoreResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.DatastoreResource>> GetAsync(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.DatastoreResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.DatastoreResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.DatastoreResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.DatastoreResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatastoreData : Azure.ResourceManager.Models.ResourceData
    {
        public DatastoreData() { }
        public Azure.ResourceManager.Avs.Models.DiskPoolVolume DiskPoolVolume { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetAppVolumeId { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.DatastoreProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.DatastoreStatus? Status { get { throw null; } }
    }
    public partial class DatastoreResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatastoreResource() { }
        public virtual Azure.ResourceManager.Avs.DatastoreData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string clusterName, string datastoreName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.DatastoreResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.DatastoreResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.DatastoreResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.DatastoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.DatastoreResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.DatastoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExpressRouteAuthorizationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource>, System.Collections.IEnumerable
    {
        protected ExpressRouteAuthorizationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationName, Azure.ResourceManager.Avs.ExpressRouteAuthorizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationName, Azure.ResourceManager.Avs.ExpressRouteAuthorizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource> Get(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource>> GetAsync(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ExpressRouteAuthorizationData : Azure.ResourceManager.Models.ResourceData
    {
        public ExpressRouteAuthorizationData() { }
        public string ExpressRouteAuthorizationId { get { throw null; } }
        public string ExpressRouteAuthorizationKey { get { throw null; } }
        public string ExpressRouteId { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ExpressRouteAuthorizationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExpressRouteAuthorizationResource() { }
        public virtual Azure.ResourceManager.Avs.ExpressRouteAuthorizationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string authorizationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.ExpressRouteAuthorizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.ExpressRouteAuthorizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GlobalReachConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.GlobalReachConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.GlobalReachConnectionResource>, System.Collections.IEnumerable
    {
        protected GlobalReachConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.GlobalReachConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string globalReachConnectionName, Azure.ResourceManager.Avs.GlobalReachConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.GlobalReachConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string globalReachConnectionName, Azure.ResourceManager.Avs.GlobalReachConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string globalReachConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string globalReachConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.GlobalReachConnectionResource> Get(string globalReachConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.GlobalReachConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.GlobalReachConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.GlobalReachConnectionResource>> GetAsync(string globalReachConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.GlobalReachConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.GlobalReachConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.GlobalReachConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.GlobalReachConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GlobalReachConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public GlobalReachConnectionData() { }
        public string AddressPrefix { get { throw null; } }
        public string AuthorizationKey { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus? CircuitConnectionStatus { get { throw null; } }
        public string ExpressRouteId { get { throw null; } set { } }
        public string PeerExpressRouteCircuit { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class GlobalReachConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GlobalReachConnectionResource() { }
        public virtual Azure.ResourceManager.Avs.GlobalReachConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string globalReachConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.GlobalReachConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.GlobalReachConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.GlobalReachConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.GlobalReachConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.GlobalReachConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.GlobalReachConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HcxEnterpriseSiteCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource>, System.Collections.IEnumerable
    {
        protected HcxEnterpriseSiteCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hcxEnterpriseSiteName, Azure.ResourceManager.Avs.HcxEnterpriseSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hcxEnterpriseSiteName, Azure.ResourceManager.Avs.HcxEnterpriseSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hcxEnterpriseSiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hcxEnterpriseSiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource> Get(string hcxEnterpriseSiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource>> GetAsync(string hcxEnterpriseSiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HcxEnterpriseSiteData : Azure.ResourceManager.Models.ResourceData
    {
        public HcxEnterpriseSiteData() { }
        public string ActivationKey { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus? Status { get { throw null; } }
    }
    public partial class HcxEnterpriseSiteResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HcxEnterpriseSiteResource() { }
        public virtual Azure.ResourceManager.Avs.HcxEnterpriseSiteData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string hcxEnterpriseSiteName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.HcxEnterpriseSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.HcxEnterpriseSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PlacementPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.PlacementPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.PlacementPolicyResource>, System.Collections.IEnumerable
    {
        protected PlacementPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.PlacementPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string placementPolicyName, Azure.ResourceManager.Avs.PlacementPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.PlacementPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string placementPolicyName, Azure.ResourceManager.Avs.PlacementPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string placementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string placementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.PlacementPolicyResource> Get(string placementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.PlacementPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.PlacementPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.PlacementPolicyResource>> GetAsync(string placementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.PlacementPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.PlacementPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.PlacementPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.PlacementPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PlacementPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public PlacementPolicyData() { }
        public Azure.ResourceManager.Avs.Models.PlacementPolicyProperties Properties { get { throw null; } set { } }
    }
    public partial class PlacementPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PlacementPolicyResource() { }
        public virtual Azure.ResourceManager.Avs.PlacementPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string clusterName, string placementPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.PlacementPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.PlacementPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.PlacementPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.PlacementPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.PlacementPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.PlacementPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateCloudCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.PrivateCloudResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.PrivateCloudResource>, System.Collections.IEnumerable
    {
        protected PrivateCloudCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.PrivateCloudResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateCloudName, Azure.ResourceManager.Avs.PrivateCloudData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.PrivateCloudResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateCloudName, Azure.ResourceManager.Avs.PrivateCloudData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource> Get(string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.PrivateCloudResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.PrivateCloudResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource>> GetAsync(string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.PrivateCloudResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.PrivateCloudResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.PrivateCloudResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.PrivateCloudResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateCloudData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PrivateCloudData(Azure.Core.AzureLocation location, Azure.ResourceManager.Avs.Models.AvsSku sku) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Avs.Models.AvailabilityProperties Availability { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.Circuit Circuit { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.Encryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.Endpoints Endpoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ExternalCloudLinks { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Avs.Models.IdentitySource> IdentitySources { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.InternetEnum? Internet { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.ManagementCluster ManagementCluster { get { throw null; } set { } }
        public string ManagementNetwork { get { throw null; } }
        public string NetworkBlock { get { throw null; } set { } }
        public string NsxtCertificateThumbprint { get { throw null; } }
        public string NsxtPassword { get { throw null; } set { } }
        public string ProvisioningNetwork { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.Circuit SecondaryCircuit { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public string VcenterCertificateThumbprint { get { throw null; } }
        public string VcenterPassword { get { throw null; } set { } }
        public string VmotionNetwork { get { throw null; } }
    }
    public partial class PrivateCloudResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateCloudResource() { }
        public virtual Azure.ResourceManager.Avs.PrivateCloudData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AddonResource> GetAddon(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AddonResource>> GetAddonAsync(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.AddonCollection GetAddons() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.Models.AdminCredentials> GetAdminCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.Models.AdminCredentials>> GetAdminCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.CloudLinkResource> GetCloudLink(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.CloudLinkResource>> GetCloudLinkAsync(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.CloudLinkCollection GetCloudLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ClusterResource> GetCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ClusterResource>> GetClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.ClusterCollection GetClusters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource> GetExpressRouteAuthorization(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource>> GetExpressRouteAuthorizationAsync(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.ExpressRouteAuthorizationCollection GetExpressRouteAuthorizations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.GlobalReachConnectionResource> GetGlobalReachConnection(string globalReachConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.GlobalReachConnectionResource>> GetGlobalReachConnectionAsync(string globalReachConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.GlobalReachConnectionCollection GetGlobalReachConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource> GetHcxEnterpriseSite(string hcxEnterpriseSiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource>> GetHcxEnterpriseSiteAsync(string hcxEnterpriseSiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.HcxEnterpriseSiteCollection GetHcxEnterpriseSites() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ScriptExecutionResource> GetScriptExecution(string scriptExecutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ScriptExecutionResource>> GetScriptExecutionAsync(string scriptExecutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.ScriptExecutionCollection GetScriptExecutions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ScriptPackageResource> GetScriptPackage(string scriptPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ScriptPackageResource>> GetScriptPackageAsync(string scriptPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.ScriptPackageCollection GetScriptPackages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource> GetWorkloadNetworkDhcp(string dhcpId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource>> GetWorkloadNetworkDhcpAsync(string dhcpId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkDhcpCollection GetWorkloadNetworkDhcps() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource> GetWorkloadNetworkDnsService(string dnsServiceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource>> GetWorkloadNetworkDnsServiceAsync(string dnsServiceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceCollection GetWorkloadNetworkDnsServices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource> GetWorkloadNetworkDnsZone(string dnsZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource>> GetWorkloadNetworkDnsZoneAsync(string dnsZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneCollection GetWorkloadNetworkDnsZones() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource> GetWorkloadNetworkGateway(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource>> GetWorkloadNetworkGatewayAsync(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkGatewayCollection GetWorkloadNetworkGateways() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource> GetWorkloadNetworkPortMirroring(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource>> GetWorkloadNetworkPortMirroringAsync(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringCollection GetWorkloadNetworkPortMirrorings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource> GetWorkloadNetworkPublicIP(string publicIPId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource>> GetWorkloadNetworkPublicIPAsync(string publicIPId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkPublicIPCollection GetWorkloadNetworkPublicIPs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource> GetWorkloadNetworkSegment(string segmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource>> GetWorkloadNetworkSegmentAsync(string segmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkSegmentCollection GetWorkloadNetworkSegments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource> GetWorkloadNetworkVirtualMachine(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource>> GetWorkloadNetworkVirtualMachineAsync(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineCollection GetWorkloadNetworkVirtualMachines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource> GetWorkloadNetworkVmGroup(string vmGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource>> GetWorkloadNetworkVmGroupAsync(string vmGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkVmGroupCollection GetWorkloadNetworkVmGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RotateNsxtPassword(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RotateNsxtPasswordAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RotateVcenterPassword(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RotateVcenterPasswordAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.PrivateCloudResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.PrivateCloudPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.PrivateCloudResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.PrivateCloudPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScriptCmdletCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.ScriptCmdletResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.ScriptCmdletResource>, System.Collections.IEnumerable
    {
        protected ScriptCmdletCollection() { }
        public virtual Azure.Response<bool> Exists(string scriptCmdletName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scriptCmdletName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ScriptCmdletResource> Get(string scriptCmdletName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.ScriptCmdletResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.ScriptCmdletResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ScriptCmdletResource>> GetAsync(string scriptCmdletName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.ScriptCmdletResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.ScriptCmdletResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.ScriptCmdletResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.ScriptCmdletResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScriptCmdletData : Azure.ResourceManager.Models.ResourceData
    {
        public ScriptCmdletData() { }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.ScriptParameter> Parameters { get { throw null; } }
        public string Timeout { get { throw null; } }
    }
    public partial class ScriptCmdletResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScriptCmdletResource() { }
        public virtual Azure.ResourceManager.Avs.ScriptCmdletData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string scriptPackageName, string scriptCmdletName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ScriptCmdletResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ScriptCmdletResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScriptExecutionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.ScriptExecutionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.ScriptExecutionResource>, System.Collections.IEnumerable
    {
        protected ScriptExecutionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.ScriptExecutionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scriptExecutionName, Azure.ResourceManager.Avs.ScriptExecutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.ScriptExecutionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scriptExecutionName, Azure.ResourceManager.Avs.ScriptExecutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scriptExecutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scriptExecutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ScriptExecutionResource> Get(string scriptExecutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.ScriptExecutionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.ScriptExecutionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ScriptExecutionResource>> GetAsync(string scriptExecutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.ScriptExecutionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.ScriptExecutionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.ScriptExecutionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.ScriptExecutionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScriptExecutionData : Azure.ResourceManager.Models.ResourceData
    {
        public ScriptExecutionData() { }
        public System.Collections.Generic.IReadOnlyList<string> Errors { get { throw null; } }
        public string FailureReason { get { throw null; } set { } }
        public System.DateTimeOffset? FinishedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Avs.Models.ScriptExecutionParameter> HiddenParameters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Information { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> NamedOutputs { get { throw null; } }
        public System.Collections.Generic.IList<string> Output { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Avs.Models.ScriptExecutionParameter> Parameters { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState? ProvisioningState { get { throw null; } }
        public string Retention { get { throw null; } set { } }
        public string ScriptCmdletId { get { throw null; } set { } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public System.DateTimeOffset? SubmittedOn { get { throw null; } }
        public string Timeout { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Warnings { get { throw null; } }
    }
    public partial class ScriptExecutionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScriptExecutionResource() { }
        public virtual Azure.ResourceManager.Avs.ScriptExecutionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string scriptExecutionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ScriptExecutionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ScriptExecutionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ScriptExecutionResource> GetExecutionLogs(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.ScriptOutputStreamType> scriptOutputStreamType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ScriptExecutionResource>> GetExecutionLogsAsync(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.ScriptOutputStreamType> scriptOutputStreamType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.ScriptExecutionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.ScriptExecutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.ScriptExecutionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.ScriptExecutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScriptPackageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.ScriptPackageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.ScriptPackageResource>, System.Collections.IEnumerable
    {
        protected ScriptPackageCollection() { }
        public virtual Azure.Response<bool> Exists(string scriptPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scriptPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ScriptPackageResource> Get(string scriptPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.ScriptPackageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.ScriptPackageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ScriptPackageResource>> GetAsync(string scriptPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.ScriptPackageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.ScriptPackageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.ScriptPackageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.ScriptPackageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScriptPackageData : Azure.ResourceManager.Models.ResourceData
    {
        public ScriptPackageData() { }
        public string Description { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class ScriptPackageResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScriptPackageResource() { }
        public virtual Azure.ResourceManager.Avs.ScriptPackageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string scriptPackageName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ScriptPackageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ScriptPackageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ScriptCmdletResource> GetScriptCmdlet(string scriptCmdletName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ScriptCmdletResource>> GetScriptCmdletAsync(string scriptCmdletName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.ScriptCmdletCollection GetScriptCmdlets() { throw null; }
    }
    public partial class VirtualMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.VirtualMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.VirtualMachineResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineCollection() { }
        public virtual Azure.Response<bool> Exists(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.VirtualMachineResource> Get(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.VirtualMachineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.VirtualMachineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.VirtualMachineResource>> GetAsync(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.VirtualMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.VirtualMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.VirtualMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.VirtualMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineData : Azure.ResourceManager.Models.ResourceData
    {
        public VirtualMachineData() { }
        public string DisplayName { get { throw null; } }
        public string FolderPath { get { throw null; } }
        public string MoRefId { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState? RestrictMovement { get { throw null; } }
    }
    public partial class VirtualMachineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineResource() { }
        public virtual Azure.ResourceManager.Avs.VirtualMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string clusterName, string virtualMachineId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.VirtualMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.VirtualMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestrictMovement(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovement restrictMovement, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestrictMovementAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovement restrictMovement, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadNetworkDhcpCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource>, System.Collections.IEnumerable
    {
        protected WorkloadNetworkDhcpCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dhcpId, Azure.ResourceManager.Avs.WorkloadNetworkDhcpData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dhcpId, Azure.ResourceManager.Avs.WorkloadNetworkDhcpData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dhcpId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dhcpId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource> Get(string dhcpId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource>> GetAsync(string dhcpId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadNetworkDhcpData : Azure.ResourceManager.Models.ResourceData
    {
        public WorkloadNetworkDhcpData() { }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpEntity Properties { get { throw null; } set { } }
    }
    public partial class WorkloadNetworkDhcpResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadNetworkDhcpResource() { }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkDhcpData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string dhcpId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkDhcpData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkDhcpData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadNetworkDnsServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource>, System.Collections.IEnumerable
    {
        protected WorkloadNetworkDnsServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dnsServiceId, Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dnsServiceId, Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dnsServiceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dnsServiceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource> Get(string dnsServiceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource>> GetAsync(string dnsServiceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadNetworkDnsServiceData : Azure.ResourceManager.Models.ResourceData
    {
        public WorkloadNetworkDnsServiceData() { }
        public string DefaultDnsZone { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string DnsServiceIP { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> FqdnZones { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum? LogLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState? ProvisioningState { get { throw null; } }
        public long? Revision { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.DnsServiceStatusEnum? Status { get { throw null; } }
    }
    public partial class WorkloadNetworkDnsServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadNetworkDnsServiceResource() { }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string dnsServiceId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadNetworkDnsZoneCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource>, System.Collections.IEnumerable
    {
        protected WorkloadNetworkDnsZoneCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dnsZoneId, Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dnsZoneId, Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dnsZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dnsZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource> Get(string dnsZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource>> GetAsync(string dnsZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadNetworkDnsZoneData : Azure.ResourceManager.Models.ResourceData
    {
        public WorkloadNetworkDnsZoneData() { }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServerIPs { get { throw null; } }
        public long? DnsServices { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Domain { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState? ProvisioningState { get { throw null; } }
        public long? Revision { get { throw null; } set { } }
        public string SourceIP { get { throw null; } set { } }
    }
    public partial class WorkloadNetworkDnsZoneResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadNetworkDnsZoneResource() { }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string dnsZoneId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadNetworkGatewayCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource>, System.Collections.IEnumerable
    {
        protected WorkloadNetworkGatewayCollection() { }
        public virtual Azure.Response<bool> Exists(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource> Get(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource>> GetAsync(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadNetworkGatewayData : Azure.ResourceManager.Models.ResourceData
    {
        public WorkloadNetworkGatewayData() { }
        public string DisplayName { get { throw null; } set { } }
        public string Path { get { throw null; } }
    }
    public partial class WorkloadNetworkGatewayResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadNetworkGatewayResource() { }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkGatewayData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string gatewayId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadNetworkPortMirroringCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource>, System.Collections.IEnumerable
    {
        protected WorkloadNetworkPortMirroringCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string portMirroringId, Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string portMirroringId, Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource> Get(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource>> GetAsync(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadNetworkPortMirroringData : Azure.ResourceManager.Models.ResourceData
    {
        public WorkloadNetworkPortMirroringData() { }
        public string Destination { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.PortMirroringDirectionEnum? Direction { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState? ProvisioningState { get { throw null; } }
        public long? Revision { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.PortMirroringStatusEnum? Status { get { throw null; } }
    }
    public partial class WorkloadNetworkPortMirroringResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadNetworkPortMirroringResource() { }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string portMirroringId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadNetworkPublicIPCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource>, System.Collections.IEnumerable
    {
        protected WorkloadNetworkPublicIPCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string publicIPId, Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string publicIPId, Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string publicIPId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string publicIPId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource> Get(string publicIPId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource>> GetAsync(string publicIPId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadNetworkPublicIPData : Azure.ResourceManager.Models.ResourceData
    {
        public WorkloadNetworkPublicIPData() { }
        public string DisplayName { get { throw null; } set { } }
        public long? NumberOfPublicIPs { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState? ProvisioningState { get { throw null; } }
        public string PublicIPBlock { get { throw null; } }
    }
    public partial class WorkloadNetworkPublicIPResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadNetworkPublicIPResource() { }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string publicIPId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadNetworkSegmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource>, System.Collections.IEnumerable
    {
        protected WorkloadNetworkSegmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string segmentId, Azure.ResourceManager.Avs.WorkloadNetworkSegmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string segmentId, Azure.ResourceManager.Avs.WorkloadNetworkSegmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string segmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string segmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource> Get(string segmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource>> GetAsync(string segmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadNetworkSegmentData : Azure.ResourceManager.Models.ResourceData
    {
        public WorkloadNetworkSegmentData() { }
        public string ConnectedGateway { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentPortVif> PortVif { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState? ProvisioningState { get { throw null; } }
        public long? Revision { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.SegmentStatusEnum? Status { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentSubnet Subnet { get { throw null; } set { } }
    }
    public partial class WorkloadNetworkSegmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadNetworkSegmentResource() { }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkSegmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string segmentId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkSegmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkSegmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadNetworkVirtualMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource>, System.Collections.IEnumerable
    {
        protected WorkloadNetworkVirtualMachineCollection() { }
        public virtual Azure.Response<bool> Exists(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource> Get(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource>> GetAsync(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadNetworkVirtualMachineData : Azure.ResourceManager.Models.ResourceData
    {
        public WorkloadNetworkVirtualMachineData() { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.VmTypeEnum? VmType { get { throw null; } }
    }
    public partial class WorkloadNetworkVirtualMachineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadNetworkVirtualMachineResource() { }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string virtualMachineId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadNetworkVmGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource>, System.Collections.IEnumerable
    {
        protected WorkloadNetworkVmGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vmGroupId, Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vmGroupId, Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vmGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vmGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource> Get(string vmGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource>> GetAsync(string vmGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadNetworkVmGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public WorkloadNetworkVmGroupData() { }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Members { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState? ProvisioningState { get { throw null; } }
        public long? Revision { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.VmGroupStatusEnum? Status { get { throw null; } }
    }
    public partial class WorkloadNetworkVmGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadNetworkVmGroupResource() { }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string vmGroupId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Avs.Models
{
    public partial class AddonHcxProperties : Azure.ResourceManager.Avs.Models.AddonProperties
    {
        public AddonHcxProperties(string offer) { }
        public string Offer { get { throw null; } set { } }
    }
    public partial class AddonProperties
    {
        public AddonProperties() { }
        public Azure.ResourceManager.Avs.Models.AddonProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AddonProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.AddonProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AddonProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AddonProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AddonProvisioningState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AddonProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AddonProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AddonProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AddonProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AddonProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AddonProvisioningState left, Azure.ResourceManager.Avs.Models.AddonProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AddonProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AddonProvisioningState left, Azure.ResourceManager.Avs.Models.AddonProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AddonSrmProperties : Azure.ResourceManager.Avs.Models.AddonProperties
    {
        public AddonSrmProperties() { }
        public string LicenseKey { get { throw null; } set { } }
    }
    public partial class AddonVrProperties : Azure.ResourceManager.Avs.Models.AddonProperties
    {
        public AddonVrProperties(int vrsCount) { }
        public int VrsCount { get { throw null; } set { } }
    }
    public partial class AdminCredentials
    {
        internal AdminCredentials() { }
        public string NsxtPassword { get { throw null; } }
        public string NsxtUsername { get { throw null; } }
        public string VcenterPassword { get { throw null; } }
        public string VcenterUsername { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AffinityType : System.IEquatable<Azure.ResourceManager.Avs.Models.AffinityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AffinityType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AffinityType Affinity { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AffinityType AntiAffinity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AffinityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AffinityType left, Azure.ResourceManager.Avs.Models.AffinityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AffinityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AffinityType left, Azure.ResourceManager.Avs.Models.AffinityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvailabilityProperties
    {
        public AvailabilityProperties() { }
        public int? SecondaryZone { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvailabilityStrategy? Strategy { get { throw null; } set { } }
        public int? Zone { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvailabilityStrategy : System.IEquatable<Azure.ResourceManager.Avs.Models.AvailabilityStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvailabilityStrategy(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvailabilityStrategy DualZone { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvailabilityStrategy SingleZone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvailabilityStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvailabilityStrategy left, Azure.ResourceManager.Avs.Models.AvailabilityStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvailabilityStrategy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvailabilityStrategy left, Azure.ResourceManager.Avs.Models.AvailabilityStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvsSku
    {
        public AvsSku(string name) { }
        public string Name { get { throw null; } set { } }
    }
    public partial class Circuit
    {
        public Circuit() { }
        public string ExpressRouteId { get { throw null; } }
        public string ExpressRoutePrivatePeeringId { get { throw null; } }
        public string PrimarySubnet { get { throw null; } }
        public string SecondarySubnet { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudLinkStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.CloudLinkStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudLinkStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.CloudLinkStatus Active { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.CloudLinkStatus Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.CloudLinkStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.CloudLinkStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.CloudLinkStatus Failed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.CloudLinkStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.CloudLinkStatus left, Azure.ResourceManager.Avs.Models.CloudLinkStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.CloudLinkStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.CloudLinkStatus left, Azure.ResourceManager.Avs.Models.CloudLinkStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterPatch
    {
        public ClusterPatch() { }
        public int? ClusterSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Hosts { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.ClusterProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ClusterProvisioningState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ClusterProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ClusterProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ClusterProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ClusterProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.ClusterProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.ClusterProvisioningState left, Azure.ResourceManager.Avs.Models.ClusterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.ClusterProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.ClusterProvisioningState left, Azure.ResourceManager.Avs.Models.ClusterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CommonClusterProperties
    {
        public CommonClusterProperties() { }
        public int? ClusterId { get { throw null; } }
        public int? ClusterSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Hosts { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ClusterProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatastoreProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.DatastoreProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatastoreProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.DatastoreProvisioningState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.DatastoreProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.DatastoreProvisioningState left, Azure.ResourceManager.Avs.Models.DatastoreProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.DatastoreProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.DatastoreProvisioningState left, Azure.ResourceManager.Avs.Models.DatastoreProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatastoreStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.DatastoreStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatastoreStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.DatastoreStatus Accessible { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreStatus Attached { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreStatus DeadOrError { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreStatus Detached { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreStatus Inaccessible { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreStatus LostCommunication { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.DatastoreStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.DatastoreStatus left, Azure.ResourceManager.Avs.Models.DatastoreStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.DatastoreStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.DatastoreStatus left, Azure.ResourceManager.Avs.Models.DatastoreStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskPoolVolume
    {
        public DiskPoolVolume(string targetId, string lunName) { }
        public string LunName { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.MountOptionEnum? MountOption { get { throw null; } set { } }
        public string Path { get { throw null; } }
        public string TargetId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsServiceLogLevelEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsServiceLogLevelEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum Debug { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum Error { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum Fatal { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum Info { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum left, Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum left, Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsServiceStatusEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.DnsServiceStatusEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsServiceStatusEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.DnsServiceStatusEnum Failure { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DnsServiceStatusEnum Success { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.DnsServiceStatusEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.DnsServiceStatusEnum left, Azure.ResourceManager.Avs.Models.DnsServiceStatusEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.DnsServiceStatusEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.DnsServiceStatusEnum left, Azure.ResourceManager.Avs.Models.DnsServiceStatusEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Encryption
    {
        public Encryption() { }
        public Azure.ResourceManager.Avs.Models.EncryptionKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.EncryptionState? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionKeyStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.EncryptionKeyStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionKeyStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.EncryptionKeyStatus AccessDenied { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.EncryptionKeyStatus Connected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.EncryptionKeyStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.EncryptionKeyStatus left, Azure.ResourceManager.Avs.Models.EncryptionKeyStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.EncryptionKeyStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.EncryptionKeyStatus left, Azure.ResourceManager.Avs.Models.EncryptionKeyStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EncryptionKeyVaultProperties
    {
        public EncryptionKeyVaultProperties() { }
        public string KeyName { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.EncryptionKeyStatus? KeyState { get { throw null; } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.EncryptionVersionType? VersionType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionState : System.IEquatable<Azure.ResourceManager.Avs.Models.EncryptionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.EncryptionState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.EncryptionState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.EncryptionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.EncryptionState left, Azure.ResourceManager.Avs.Models.EncryptionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.EncryptionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.EncryptionState left, Azure.ResourceManager.Avs.Models.EncryptionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionVersionType : System.IEquatable<Azure.ResourceManager.Avs.Models.EncryptionVersionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionVersionType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.EncryptionVersionType AutoDetected { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.EncryptionVersionType Fixed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.EncryptionVersionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.EncryptionVersionType left, Azure.ResourceManager.Avs.Models.EncryptionVersionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.EncryptionVersionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.EncryptionVersionType left, Azure.ResourceManager.Avs.Models.EncryptionVersionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Endpoints
    {
        internal Endpoints() { }
        public string HcxCloudManager { get { throw null; } }
        public string NsxtManager { get { throw null; } }
        public string Vcsa { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExpressRouteAuthorizationProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExpressRouteAuthorizationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState left, Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState left, Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GlobalReachConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GlobalReachConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState left, Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState left, Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GlobalReachConnectionStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GlobalReachConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus Connected { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus Connecting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus Disconnected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus left, Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus left, Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HcxEnterpriseSiteStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HcxEnterpriseSiteStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus Available { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus Consumed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus Deactivated { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus Deleted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus left, Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus left, Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IdentitySource
    {
        public IdentitySource() { }
        public string Alias { get { throw null; } set { } }
        public string BaseGroupDN { get { throw null; } set { } }
        public string BaseUserDN { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string PrimaryServer { get { throw null; } set { } }
        public string SecondaryServer { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.SslEnum? Ssl { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InternetEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.InternetEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InternetEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.InternetEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.InternetEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.InternetEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.InternetEnum left, Azure.ResourceManager.Avs.Models.InternetEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.InternetEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.InternetEnum left, Azure.ResourceManager.Avs.Models.InternetEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagementCluster : Azure.ResourceManager.Avs.Models.CommonClusterProperties
    {
        public ManagementCluster() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MountOptionEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.MountOptionEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MountOptionEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.MountOptionEnum Attach { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.MountOptionEnum Mount { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.MountOptionEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.MountOptionEnum left, Azure.ResourceManager.Avs.Models.MountOptionEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.MountOptionEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.MountOptionEnum left, Azure.ResourceManager.Avs.Models.MountOptionEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OptionalParamEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.OptionalParamEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OptionalParamEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.OptionalParamEnum Optional { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.OptionalParamEnum Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.OptionalParamEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.OptionalParamEnum left, Azure.ResourceManager.Avs.Models.OptionalParamEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.OptionalParamEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.OptionalParamEnum left, Azure.ResourceManager.Avs.Models.OptionalParamEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlacementPolicyPatch
    {
        public PlacementPolicyPatch() { }
        public System.Collections.Generic.IList<string> HostMembers { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.PlacementPolicyState? State { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VmMembers { get { throw null; } }
    }
    public partial class PlacementPolicyProperties
    {
        public PlacementPolicyProperties() { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.PlacementPolicyState? State { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlacementPolicyProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlacementPolicyProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState left, Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState left, Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlacementPolicyState : System.IEquatable<Azure.ResourceManager.Avs.Models.PlacementPolicyState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlacementPolicyState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.PlacementPolicyState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PlacementPolicyState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.PlacementPolicyState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.PlacementPolicyState left, Azure.ResourceManager.Avs.Models.PlacementPolicyState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.PlacementPolicyState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.PlacementPolicyState left, Azure.ResourceManager.Avs.Models.PlacementPolicyState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PortMirroringDirectionEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.PortMirroringDirectionEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PortMirroringDirectionEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.PortMirroringDirectionEnum Bidirectional { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PortMirroringDirectionEnum Egress { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PortMirroringDirectionEnum Ingress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.PortMirroringDirectionEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.PortMirroringDirectionEnum left, Azure.ResourceManager.Avs.Models.PortMirroringDirectionEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.PortMirroringDirectionEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.PortMirroringDirectionEnum left, Azure.ResourceManager.Avs.Models.PortMirroringDirectionEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PortMirroringStatusEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.PortMirroringStatusEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PortMirroringStatusEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.PortMirroringStatusEnum Failure { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PortMirroringStatusEnum Success { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.PortMirroringStatusEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.PortMirroringStatusEnum left, Azure.ResourceManager.Avs.Models.PortMirroringStatusEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.PortMirroringStatusEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.PortMirroringStatusEnum left, Azure.ResourceManager.Avs.Models.PortMirroringStatusEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateCloudPatch
    {
        public PrivateCloudPatch() { }
        public Azure.ResourceManager.Avs.Models.AvailabilityProperties Availability { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.Encryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Avs.Models.IdentitySource> IdentitySources { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.InternetEnum? Internet { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.ManagementCluster ManagementCluster { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateCloudProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateCloudProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState left, Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState left, Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PSCredentialExecutionParameter : Azure.ResourceManager.Avs.Models.ScriptExecutionParameter
    {
        public PSCredentialExecutionParameter(string name) : base (default(string)) { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class Quota
    {
        internal Quota() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> HostsRemaining { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.QuotaEnabled? QuotaEnabled { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuotaEnabled : System.IEquatable<Azure.ResourceManager.Avs.Models.QuotaEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuotaEnabled(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.QuotaEnabled Disabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.QuotaEnabled Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.QuotaEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.QuotaEnabled left, Azure.ResourceManager.Avs.Models.QuotaEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.QuotaEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.QuotaEnabled left, Azure.ResourceManager.Avs.Models.QuotaEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScriptExecutionParameter
    {
        public ScriptExecutionParameter(string name) { }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptExecutionProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptExecutionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState Cancelling { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState left, Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState left, Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptOutputStreamType : System.IEquatable<Azure.ResourceManager.Avs.Models.ScriptOutputStreamType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptOutputStreamType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ScriptOutputStreamType Error { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptOutputStreamType Information { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptOutputStreamType Output { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptOutputStreamType Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.ScriptOutputStreamType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.ScriptOutputStreamType left, Azure.ResourceManager.Avs.Models.ScriptOutputStreamType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.ScriptOutputStreamType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.ScriptOutputStreamType left, Azure.ResourceManager.Avs.Models.ScriptOutputStreamType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScriptParameter
    {
        internal ScriptParameter() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.OptionalParamEnum? Optional { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ScriptParameterType? ParameterType { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.VisibilityParameterEnum? Visibility { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptParameterType : System.IEquatable<Azure.ResourceManager.Avs.Models.ScriptParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptParameterType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ScriptParameterType Bool { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptParameterType Credential { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptParameterType Float { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptParameterType Int { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptParameterType SecureString { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.ScriptParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.ScriptParameterType left, Azure.ResourceManager.Avs.Models.ScriptParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.ScriptParameterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.ScriptParameterType left, Azure.ResourceManager.Avs.Models.ScriptParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScriptSecureStringExecutionParameter : Azure.ResourceManager.Avs.Models.ScriptExecutionParameter
    {
        public ScriptSecureStringExecutionParameter(string name) : base (default(string)) { }
        public string SecureValue { get { throw null; } set { } }
    }
    public partial class ScriptStringExecutionParameter : Azure.ResourceManager.Avs.Models.ScriptExecutionParameter
    {
        public ScriptStringExecutionParameter(string name) : base (default(string)) { }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SegmentStatusEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.SegmentStatusEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SegmentStatusEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.SegmentStatusEnum Failure { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.SegmentStatusEnum Success { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.SegmentStatusEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.SegmentStatusEnum left, Azure.ResourceManager.Avs.Models.SegmentStatusEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.SegmentStatusEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.SegmentStatusEnum left, Azure.ResourceManager.Avs.Models.SegmentStatusEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SslEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.SslEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SslEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.SslEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.SslEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.SslEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.SslEnum left, Azure.ResourceManager.Avs.Models.SslEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.SslEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.SslEnum left, Azure.ResourceManager.Avs.Models.SslEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Trial
    {
        internal Trial() { }
        public int? AvailableHosts { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.TrialStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrialStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.TrialStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrialStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.TrialStatus TrialAvailable { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.TrialStatus TrialDisabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.TrialStatus TrialUsed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.TrialStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.TrialStatus left, Azure.ResourceManager.Avs.Models.TrialStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.TrialStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.TrialStatus left, Azure.ResourceManager.Avs.Models.TrialStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachineRestrictMovement
    {
        public VirtualMachineRestrictMovement() { }
        public Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState? RestrictMovement { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineRestrictMovementState : System.IEquatable<Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineRestrictMovementState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState left, Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState left, Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VisibilityParameterEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.VisibilityParameterEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VisibilityParameterEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.VisibilityParameterEnum Hidden { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.VisibilityParameterEnum Visible { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.VisibilityParameterEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.VisibilityParameterEnum left, Azure.ResourceManager.Avs.Models.VisibilityParameterEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.VisibilityParameterEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.VisibilityParameterEnum left, Azure.ResourceManager.Avs.Models.VisibilityParameterEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmGroupStatusEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.VmGroupStatusEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmGroupStatusEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.VmGroupStatusEnum Failure { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.VmGroupStatusEnum Success { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.VmGroupStatusEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.VmGroupStatusEnum left, Azure.ResourceManager.Avs.Models.VmGroupStatusEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.VmGroupStatusEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.VmGroupStatusEnum left, Azure.ResourceManager.Avs.Models.VmGroupStatusEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VmHostPlacementPolicyProperties : Azure.ResourceManager.Avs.Models.PlacementPolicyProperties
    {
        public VmHostPlacementPolicyProperties(System.Collections.Generic.IEnumerable<string> vmMembers, System.Collections.Generic.IEnumerable<string> hostMembers, Azure.ResourceManager.Avs.Models.AffinityType affinityType) { }
        public Azure.ResourceManager.Avs.Models.AffinityType AffinityType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> HostMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> VmMembers { get { throw null; } }
    }
    public partial class VmPlacementPolicyProperties : Azure.ResourceManager.Avs.Models.PlacementPolicyProperties
    {
        public VmPlacementPolicyProperties(System.Collections.Generic.IEnumerable<string> vmMembers, Azure.ResourceManager.Avs.Models.AffinityType affinityType) { }
        public Azure.ResourceManager.Avs.Models.AffinityType AffinityType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VmMembers { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmTypeEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.VmTypeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmTypeEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.VmTypeEnum Edge { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.VmTypeEnum Regular { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.VmTypeEnum Service { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.VmTypeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.VmTypeEnum left, Azure.ResourceManager.Avs.Models.VmTypeEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.VmTypeEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.VmTypeEnum left, Azure.ResourceManager.Avs.Models.VmTypeEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkloadNetworkDhcpEntity
    {
        public WorkloadNetworkDhcpEntity() { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState? ProvisioningState { get { throw null; } }
        public long? Revision { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Segments { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkDhcpProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkDhcpProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkloadNetworkDhcpRelay : Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpEntity
    {
        public WorkloadNetworkDhcpRelay() { }
        public System.Collections.Generic.IList<string> ServerAddresses { get { throw null; } }
    }
    public partial class WorkloadNetworkDhcpServer : Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpEntity
    {
        public WorkloadNetworkDhcpServer() { }
        public long? LeaseTime { get { throw null; } set { } }
        public string ServerAddress { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkDnsServiceProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkDnsServiceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkDnsZoneProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkDnsZoneProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkPortMirroringProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkPortMirroringProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkPublicIPProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkPublicIPProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkloadNetworkSegmentPortVif
    {
        internal WorkloadNetworkSegmentPortVif() { }
        public string PortName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkSegmentProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkSegmentProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkloadNetworkSegmentSubnet
    {
        public WorkloadNetworkSegmentSubnet() { }
        public System.Collections.Generic.IList<string> DhcpRanges { get { throw null; } }
        public string GatewayAddress { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkVmGroupProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkVmGroupProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
