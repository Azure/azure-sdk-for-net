namespace Azure.ResourceManager.Avs
{
    public partial class AvsCloudLinkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsCloudLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsCloudLinkResource>, System.Collections.IEnumerable
    {
        protected AvsCloudLinkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsCloudLinkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cloudLinkName, Azure.ResourceManager.Avs.AvsCloudLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsCloudLinkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cloudLinkName, Azure.ResourceManager.Avs.AvsCloudLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsCloudLinkResource> Get(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.AvsCloudLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.AvsCloudLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsCloudLinkResource>> GetAsync(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.AvsCloudLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsCloudLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.AvsCloudLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsCloudLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvsCloudLinkData : Azure.ResourceManager.Models.ResourceData
    {
        public AvsCloudLinkData() { }
        public Azure.Core.ResourceIdentifier LinkedCloud { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus? Status { get { throw null; } }
    }
    public partial class AvsCloudLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvsCloudLinkResource() { }
        public virtual Azure.ResourceManager.Avs.AvsCloudLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string cloudLinkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsCloudLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsCloudLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsCloudLinkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.AvsCloudLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsCloudLinkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.AvsCloudLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class AvsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaAvailabilityResult> CheckAvsQuotaAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaAvailabilityResult>> CheckAvsQuotaAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialAvailabilityResult> CheckAvsTrialAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Avs.Models.AvsSku sku = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialAvailabilityResult> CheckAvsTrialAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialAvailabilityResult>> CheckAvsTrialAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Avs.Models.AvsSku sku = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialAvailabilityResult>> CheckAvsTrialAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.ResourceManager.Avs.AvsCloudLinkResource GetAvsCloudLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource> GetAvsPrivateCloud(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource GetAvsPrivateCloudAddonResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource>> GetAvsPrivateCloudAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource GetAvsPrivateCloudClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource GetAvsPrivateCloudClusterVirtualMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource GetAvsPrivateCloudDatastoreResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.AvsPrivateCloudResource GetAvsPrivateCloudResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.AvsPrivateCloudCollection GetAvsPrivateClouds(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Avs.AvsPrivateCloudResource> GetAvsPrivateClouds(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Avs.AvsPrivateCloudResource> GetAvsPrivateCloudsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource GetExpressRouteAuthorizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.GlobalReachConnectionResource GetGlobalReachConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.HcxEnterpriseSiteResource GetHcxEnterpriseSiteResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.PlacementPolicyResource GetPlacementPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.ScriptCmdletResource GetScriptCmdletResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.ScriptExecutionResource GetScriptExecutionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.ScriptPackageResource GetScriptPackageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource GetWorkloadNetworkDhcpResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource GetWorkloadNetworkDnsServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource GetWorkloadNetworkDnsZoneResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource GetWorkloadNetworkGatewayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource GetWorkloadNetworkPortMirroringProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource GetWorkloadNetworkPublicIPResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkResource GetWorkloadNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource GetWorkloadNetworkSegmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource GetWorkloadNetworkVirtualMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource GetWorkloadNetworkVmGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class AvsPrivateCloudAddonCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource>, System.Collections.IEnumerable
    {
        protected AvsPrivateCloudAddonCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string addonName, Azure.ResourceManager.Avs.AvsPrivateCloudAddonData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string addonName, Azure.ResourceManager.Avs.AvsPrivateCloudAddonData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource> Get(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource>> GetAsync(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvsPrivateCloudAddonData : Azure.ResourceManager.Models.ResourceData
    {
        public AvsPrivateCloudAddonData() { }
        public Azure.ResourceManager.Avs.Models.AvsPrivateCloudAddonProperties Properties { get { throw null; } set { } }
    }
    public partial class AvsPrivateCloudAddonResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvsPrivateCloudAddonResource() { }
        public virtual Azure.ResourceManager.Avs.AvsPrivateCloudAddonData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string addonName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.AvsPrivateCloudAddonData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.AvsPrivateCloudAddonData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AvsPrivateCloudClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource>, System.Collections.IEnumerable
    {
        protected AvsPrivateCloudClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Avs.AvsPrivateCloudClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Avs.AvsPrivateCloudClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvsPrivateCloudClusterData : Azure.ResourceManager.Models.ResourceData
    {
        public AvsPrivateCloudClusterData(Azure.ResourceManager.Avs.Models.AvsSku sku) { }
        public int? ClusterId { get { throw null; } }
        public int? ClusterSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Hosts { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState? ProvisioningState { get { throw null; } }
        public string SkuName { get { throw null; } set { } }
    }
    public partial class AvsPrivateCloudClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvsPrivateCloudClusterResource() { }
        public virtual Azure.ResourceManager.Avs.AvsPrivateCloudClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource> GetAvsPrivateCloudClusterVirtualMachine(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource>> GetAvsPrivateCloudClusterVirtualMachineAsync(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineCollection GetAvsPrivateCloudClusterVirtualMachines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource> GetAvsPrivateCloudDatastore(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource>> GetAvsPrivateCloudDatastoreAsync(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreCollection GetAvsPrivateCloudDatastores() { throw null; }
        public virtual Azure.ResourceManager.Avs.PlacementPolicyCollection GetPlacementPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.PlacementPolicyResource> GetPlacementPolicy(string placementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.PlacementPolicyResource>> GetPlacementPolicyAsync(string placementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.Models.AvsClusterZone> GetZones(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.Models.AvsClusterZone> GetZonesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AvsPrivateCloudClusterVirtualMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource>, System.Collections.IEnumerable
    {
        protected AvsPrivateCloudClusterVirtualMachineCollection() { }
        public virtual Azure.Response<bool> Exists(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource> Get(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource>> GetAsync(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvsPrivateCloudClusterVirtualMachineData : Azure.ResourceManager.Models.ResourceData
    {
        public AvsPrivateCloudClusterVirtualMachineData() { }
        public string DisplayName { get { throw null; } }
        public string FolderPath { get { throw null; } }
        public string MoRefId { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState? RestrictMovement { get { throw null; } }
    }
    public partial class AvsPrivateCloudClusterVirtualMachineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvsPrivateCloudClusterVirtualMachineResource() { }
        public virtual Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string clusterName, string virtualMachineId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestrictMovement(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterVirtualMachineRestrictMovement restrictMovement, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestrictMovementAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterVirtualMachineRestrictMovement restrictMovement, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AvsPrivateCloudCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudResource>, System.Collections.IEnumerable
    {
        protected AvsPrivateCloudCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateCloudName, Azure.ResourceManager.Avs.AvsPrivateCloudData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateCloudName, Azure.ResourceManager.Avs.AvsPrivateCloudData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource> Get(string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.AvsPrivateCloudResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.AvsPrivateCloudResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource>> GetAsync(string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.AvsPrivateCloudResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.AvsPrivateCloudResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvsPrivateCloudData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AvsPrivateCloudData(Azure.Core.AzureLocation location, Azure.ResourceManager.Avs.Models.AvsSku sku) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Avs.Models.PrivateCloudAvailabilityProperties Availability { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.ExpressRouteCircuit Circuit { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.CustomerManagedEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsPrivateCloudEndpoints Endpoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> ExternalCloudLinks { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Avs.Models.SingleSignOnIdentitySource> IdentitySources { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.InternetConnectivityState? Internet { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsManagementCluster ManagementCluster { get { throw null; } set { } }
        public string ManagementNetwork { get { throw null; } }
        public string NetworkBlock { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum? NsxPublicIPQuotaRaised { get { throw null; } }
        public string NsxtCertificateThumbprint { get { throw null; } }
        public string NsxtPassword { get { throw null; } set { } }
        public string ProvisioningNetwork { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ExpressRouteCircuit SecondaryCircuit { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public string VCenterCertificateThumbprint { get { throw null; } }
        public string VCenterPassword { get { throw null; } set { } }
        public string VMotionNetwork { get { throw null; } }
    }
    public partial class AvsPrivateCloudDatastoreCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource>, System.Collections.IEnumerable
    {
        protected AvsPrivateCloudDatastoreCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string datastoreName, Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string datastoreName, Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource> Get(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource>> GetAsync(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvsPrivateCloudDatastoreData : Azure.ResourceManager.Models.ResourceData
    {
        public AvsPrivateCloudDatastoreData() { }
        public Azure.ResourceManager.Avs.Models.DiskPoolVolume DiskPoolVolume { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetAppVolumeId { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.DatastoreStatus? Status { get { throw null; } }
    }
    public partial class AvsPrivateCloudDatastoreResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvsPrivateCloudDatastoreResource() { }
        public virtual Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string clusterName, string datastoreName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AvsPrivateCloudResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvsPrivateCloudResource() { }
        public virtual Azure.ResourceManager.Avs.AvsPrivateCloudData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.Models.AdminCredentials> GetAdminCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.Models.AdminCredentials>> GetAdminCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsCloudLinkResource> GetAvsCloudLink(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsCloudLinkResource>> GetAvsCloudLinkAsync(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.AvsCloudLinkCollection GetAvsCloudLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource> GetAvsPrivateCloudAddon(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource>> GetAvsPrivateCloudAddonAsync(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.AvsPrivateCloudAddonCollection GetAvsPrivateCloudAddons() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource> GetAvsPrivateCloudCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource>> GetAvsPrivateCloudClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.AvsPrivateCloudClusterCollection GetAvsPrivateCloudClusters() { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkResource> GetWorkloadNetwork(Azure.ResourceManager.Avs.Models.WorkloadNetworkName workloadNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkResource>> GetWorkloadNetworkAsync(Azure.ResourceManager.Avs.Models.WorkloadNetworkName workloadNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource> GetWorkloadNetworkPortMirroringProfile(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource>> GetWorkloadNetworkPortMirroringProfileAsync(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileCollection GetWorkloadNetworkPortMirroringProfiles() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource> GetWorkloadNetworkPublicIP(string publicIPId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource>> GetWorkloadNetworkPublicIPAsync(string publicIPId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkPublicIPCollection GetWorkloadNetworkPublicIPs() { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkCollection GetWorkloadNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource> GetWorkloadNetworkSegment(string segmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource>> GetWorkloadNetworkSegmentAsync(string segmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkSegmentCollection GetWorkloadNetworkSegments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource> GetWorkloadNetworkVirtualMachine(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource>> GetWorkloadNetworkVirtualMachineAsync(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineCollection GetWorkloadNetworkVirtualMachines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource> GetWorkloadNetworkVmGroup(string vmGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource>> GetWorkloadNetworkVmGroupAsync(string vmGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkVmGroupCollection GetWorkloadNetworkVmGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RotateNsxtPassword(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RotateNsxtPasswordAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RotateVCenterPassword(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RotateVCenterPasswordAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.AvsPrivateCloudPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.AvsPrivateCloudPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.Core.ResourceIdentifier ExpressRouteAuthorizationId { get { throw null; } }
        public string ExpressRouteAuthorizationKey { get { throw null; } }
        public Azure.Core.ResourceIdentifier ExpressRouteId { get { throw null; } set { } }
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
        public Azure.Core.ResourceIdentifier ExpressRouteId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PeerExpressRouteCircuit { get { throw null; } set { } }
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
        public System.TimeSpan? Timeout { get { throw null; } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Avs.Models.ScriptExecutionParameterDetails> HiddenParameters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Information { get { throw null; } }
        public System.BinaryData NamedOutputs { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Output { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Avs.Models.ScriptExecutionParameterDetails> Parameters { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState? ProvisioningState { get { throw null; } }
        public string Retention { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ScriptCmdletId { get { throw null; } set { } }
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
        public string Company { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
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
    public partial class WorkloadNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkResource>, System.Collections.IEnumerable
    {
        protected WorkloadNetworkCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Avs.Models.WorkloadNetworkName workloadNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Avs.Models.WorkloadNetworkName workloadNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkResource> Get(Azure.ResourceManager.Avs.Models.WorkloadNetworkName workloadNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.WorkloadNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.WorkloadNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkResource>> GetAsync(Azure.ResourceManager.Avs.Models.WorkloadNetworkName workloadNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadNetworkData : Azure.ResourceManager.Models.ResourceData
    {
        public WorkloadNetworkData() { }
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
        public System.Net.IPAddress DnsServiceIP { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> FqdnZones { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.DnsServiceLogLevel? LogLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState? ProvisioningState { get { throw null; } }
        public long? Revision { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.DnsServiceStatus? Status { get { throw null; } }
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
        public System.Collections.Generic.IList<System.Net.IPAddress> DnsServerIPs { get { throw null; } }
        public long? DnsServices { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Domain { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState? ProvisioningState { get { throw null; } }
        public long? Revision { get { throw null; } set { } }
        public System.Net.IPAddress SourceIP { get { throw null; } set { } }
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
    public partial class WorkloadNetworkPortMirroringProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource>, System.Collections.IEnumerable
    {
        protected WorkloadNetworkPortMirroringProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string portMirroringId, Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string portMirroringId, Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource> Get(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource>> GetAsync(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadNetworkPortMirroringProfileData : Azure.ResourceManager.Models.ResourceData
    {
        public WorkloadNetworkPortMirroringProfileData() { }
        public string Destination { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection? Direction { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState? ProvisioningState { get { throw null; } }
        public long? Revision { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.PortMirroringProfileStatus? Status { get { throw null; } }
    }
    public partial class WorkloadNetworkPortMirroringProfileResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadNetworkPortMirroringProfileResource() { }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string portMirroringId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class WorkloadNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadNetworkResource() { }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, Azure.ResourceManager.Avs.Models.WorkloadNetworkName workloadNetworkName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentStatus? Status { get { throw null; } }
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
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType? VmType { get { throw null; } }
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
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupStatus? Status { get { throw null; } }
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
    public partial class AddonArcProperties : Azure.ResourceManager.Avs.Models.AvsPrivateCloudAddonProperties
    {
        public AddonArcProperties() { }
        public string VCenter { get { throw null; } set { } }
    }
    public partial class AddonHcxProperties : Azure.ResourceManager.Avs.Models.AvsPrivateCloudAddonProperties
    {
        public AddonHcxProperties(string offer) { }
        public string Offer { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AddonProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.AddonProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AddonProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AddonProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AddonProvisioningState Canceled { get { throw null; } }
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
    public partial class AddonSrmProperties : Azure.ResourceManager.Avs.Models.AvsPrivateCloudAddonProperties
    {
        public AddonSrmProperties() { }
        public string LicenseKey { get { throw null; } set { } }
    }
    public partial class AddonVrProperties : Azure.ResourceManager.Avs.Models.AvsPrivateCloudAddonProperties
    {
        public AddonVrProperties(int vrsCount) { }
        public int VrsCount { get { throw null; } set { } }
    }
    public partial class AdminCredentials
    {
        internal AdminCredentials() { }
        public string NsxtPassword { get { throw null; } }
        public string NsxtUsername { get { throw null; } }
        public string VCenterPassword { get { throw null; } }
        public string VCenterUsername { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsCloudLinkStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsCloudLinkStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus Active { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus Failed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus left, Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus left, Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvsClusterZone
    {
        internal AvsClusterZone() { }
        public System.Collections.Generic.IReadOnlyList<string> Hosts { get { throw null; } }
        public string Zone { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsEncryptionKeyStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsEncryptionKeyStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsEncryptionKeyStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsEncryptionKeyStatus AccessDenied { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsEncryptionKeyStatus Connected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsEncryptionKeyStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsEncryptionKeyStatus left, Azure.ResourceManager.Avs.Models.AvsEncryptionKeyStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsEncryptionKeyStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsEncryptionKeyStatus left, Azure.ResourceManager.Avs.Models.AvsEncryptionKeyStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvsEncryptionKeyVaultProperties
    {
        public AvsEncryptionKeyVaultProperties() { }
        public string AutoDetectedKeyVersion { get { throw null; } }
        public string KeyName { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsEncryptionKeyStatus? KeyState { get { throw null; } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsEncryptionVersionType? VersionType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsEncryptionState : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsEncryptionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsEncryptionState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsEncryptionState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsEncryptionState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsEncryptionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsEncryptionState left, Azure.ResourceManager.Avs.Models.AvsEncryptionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsEncryptionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsEncryptionState left, Azure.ResourceManager.Avs.Models.AvsEncryptionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsEncryptionVersionType : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsEncryptionVersionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsEncryptionVersionType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsEncryptionVersionType AutoDetected { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsEncryptionVersionType Fixed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsEncryptionVersionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsEncryptionVersionType left, Azure.ResourceManager.Avs.Models.AvsEncryptionVersionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsEncryptionVersionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsEncryptionVersionType left, Azure.ResourceManager.Avs.Models.AvsEncryptionVersionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvsManagementCluster : Azure.ResourceManager.Avs.Models.CommonClusterProperties
    {
        public AvsManagementCluster() { }
    }
    public static partial class AvsModelFactory
    {
        public static Azure.ResourceManager.Avs.Models.AddonArcProperties AddonArcProperties(Azure.ResourceManager.Avs.Models.AddonProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AddonProvisioningState?), string vCenter = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AddonHcxProperties AddonHcxProperties(Azure.ResourceManager.Avs.Models.AddonProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AddonProvisioningState?), string offer = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AddonSrmProperties AddonSrmProperties(Azure.ResourceManager.Avs.Models.AddonProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AddonProvisioningState?), string licenseKey = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AddonVrProperties AddonVrProperties(Azure.ResourceManager.Avs.Models.AddonProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AddonProvisioningState?), int vrsCount = 0) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AdminCredentials AdminCredentials(string nsxtUsername = null, string nsxtPassword = null, string vCenterUsername = null, string vCenterPassword = null) { throw null; }
        public static Azure.ResourceManager.Avs.AvsCloudLinkData AvsCloudLinkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus? status = default(Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus?), Azure.Core.ResourceIdentifier linkedCloud = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsClusterZone AvsClusterZone(System.Collections.Generic.IEnumerable<string> hosts = null, string zone = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsEncryptionKeyVaultProperties AvsEncryptionKeyVaultProperties(string keyName = null, string keyVersion = null, string autoDetectedKeyVersion = null, System.Uri keyVaultUri = null, Azure.ResourceManager.Avs.Models.AvsEncryptionKeyStatus? keyState = default(Azure.ResourceManager.Avs.Models.AvsEncryptionKeyStatus?), Azure.ResourceManager.Avs.Models.AvsEncryptionVersionType? versionType = default(Azure.ResourceManager.Avs.Models.AvsEncryptionVersionType?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsManagementCluster AvsManagementCluster(int? clusterSize = default(int?), Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState?), int? clusterId = default(int?), System.Collections.Generic.IEnumerable<string> hosts = null) { throw null; }
        public static Azure.ResourceManager.Avs.AvsPrivateCloudAddonData AvsPrivateCloudAddonData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.AvsPrivateCloudAddonProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudAddonProperties AvsPrivateCloudAddonProperties(string addonType = "Unknown", Azure.ResourceManager.Avs.Models.AddonProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AddonProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Avs.AvsPrivateCloudClusterData AvsPrivateCloudClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string skuName = null, int? clusterSize = default(int?), Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState?), int? clusterId = default(int?), System.Collections.Generic.IEnumerable<string> hosts = null) { throw null; }
        public static Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineData AvsPrivateCloudClusterVirtualMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, string moRefId = null, string folderPath = null, Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState? restrictMovement = default(Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState?)) { throw null; }
        public static Azure.ResourceManager.Avs.AvsPrivateCloudData AvsPrivateCloudData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string skuName = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Avs.Models.AvsManagementCluster managementCluster = null, Azure.ResourceManager.Avs.Models.InternetConnectivityState? internet = default(Azure.ResourceManager.Avs.Models.InternetConnectivityState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.SingleSignOnIdentitySource> identitySources = null, Azure.ResourceManager.Avs.Models.PrivateCloudAvailabilityProperties availability = null, Azure.ResourceManager.Avs.Models.CustomerManagedEncryption encryption = null, Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState?), Azure.ResourceManager.Avs.Models.ExpressRouteCircuit circuit = null, Azure.ResourceManager.Avs.Models.AvsPrivateCloudEndpoints endpoints = null, string networkBlock = null, string managementNetwork = null, string provisioningNetwork = null, string vMotionNetwork = null, string vCenterPassword = null, string nsxtPassword = null, string vCenterCertificateThumbprint = null, string nsxtCertificateThumbprint = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> externalCloudLinks = null, Azure.ResourceManager.Avs.Models.ExpressRouteCircuit secondaryCircuit = null, Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum? nsxPublicIPQuotaRaised = default(Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum?)) { throw null; }
        public static Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData AvsPrivateCloudDatastoreData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState?), Azure.Core.ResourceIdentifier netAppVolumeId = null, Azure.ResourceManager.Avs.Models.DiskPoolVolume diskPoolVolume = null, Azure.ResourceManager.Avs.Models.DatastoreStatus? status = default(Azure.ResourceManager.Avs.Models.DatastoreStatus?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudEndpoints AvsPrivateCloudEndpoints(string nsxtManager = null, string vcsa = null, string hcxCloudManager = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaAvailabilityResult AvsSubscriptionQuotaAvailabilityResult(System.Collections.Generic.IReadOnlyDictionary<string, int> hostsRemaining = null, Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaEnabled? quotaEnabled = default(Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaEnabled?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialAvailabilityResult AvsSubscriptionTrialAvailabilityResult(Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus? status = default(Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus?), int? availableHosts = default(int?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.CommonClusterProperties CommonClusterProperties(int? clusterSize = default(int?), Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState?), int? clusterId = default(int?), System.Collections.Generic.IEnumerable<string> hosts = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.DiskPoolVolume DiskPoolVolume(Azure.Core.ResourceIdentifier targetId = null, string lunName = null, Azure.ResourceManager.Avs.Models.LunMountMode? mountOption = default(Azure.ResourceManager.Avs.Models.LunMountMode?), string path = null) { throw null; }
        public static Azure.ResourceManager.Avs.ExpressRouteAuthorizationData ExpressRouteAuthorizationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState?), Azure.Core.ResourceIdentifier expressRouteAuthorizationId = null, string expressRouteAuthorizationKey = null, Azure.Core.ResourceIdentifier expressRouteId = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ExpressRouteCircuit ExpressRouteCircuit(string primarySubnet = null, string secondarySubnet = null, Azure.Core.ResourceIdentifier expressRouteId = null, Azure.Core.ResourceIdentifier expressRoutePrivatePeeringId = null) { throw null; }
        public static Azure.ResourceManager.Avs.GlobalReachConnectionData GlobalReachConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState?), string addressPrefix = null, string authorizationKey = null, Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus? circuitConnectionStatus = default(Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus?), Azure.Core.ResourceIdentifier peerExpressRouteCircuit = null, Azure.Core.ResourceIdentifier expressRouteId = null) { throw null; }
        public static Azure.ResourceManager.Avs.HcxEnterpriseSiteData HcxEnterpriseSiteData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string activationKey = null, Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus? status = default(Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus?)) { throw null; }
        public static Azure.ResourceManager.Avs.PlacementPolicyData PlacementPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.PlacementPolicyProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.PlacementPolicyProperties PlacementPolicyProperties(string policyType = "Unknown", Azure.ResourceManager.Avs.Models.PlacementPolicyState? state = default(Azure.ResourceManager.Avs.Models.PlacementPolicyState?), string displayName = null, Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Avs.ScriptCmdletData ScriptCmdletData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, System.TimeSpan? timeout = default(System.TimeSpan?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.ScriptParameter> parameters = null) { throw null; }
        public static Azure.ResourceManager.Avs.ScriptExecutionData ScriptExecutionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier scriptCmdletId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.ScriptExecutionParameterDetails> parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.ScriptExecutionParameterDetails> hiddenParameters = null, string failureReason = null, string timeout = null, string retention = null, System.DateTimeOffset? submittedOn = default(System.DateTimeOffset?), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? finishedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState?), System.Collections.Generic.IEnumerable<string> output = null, System.BinaryData namedOutputs = null, System.Collections.Generic.IEnumerable<string> information = null, System.Collections.Generic.IEnumerable<string> warnings = null, System.Collections.Generic.IEnumerable<string> errors = null) { throw null; }
        public static Azure.ResourceManager.Avs.ScriptPackageData ScriptPackageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, string version = null, string company = null, System.Uri uri = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ScriptParameter ScriptParameter(Azure.ResourceManager.Avs.Models.ScriptParameterType? parameterType = default(Azure.ResourceManager.Avs.Models.ScriptParameterType?), string name = null, string description = null, Azure.ResourceManager.Avs.Models.ParameterVisibilityStatus? visibility = default(Azure.ResourceManager.Avs.Models.ParameterVisibilityStatus?), Azure.ResourceManager.Avs.Models.ParameterOptionalityStatus? optional = default(Azure.ResourceManager.Avs.Models.ParameterOptionalityStatus?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyProperties VmHostPlacementPolicyProperties(Azure.ResourceManager.Avs.Models.PlacementPolicyState? state = default(Azure.ResourceManager.Avs.Models.PlacementPolicyState?), string displayName = null, Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> vmMembers = null, System.Collections.Generic.IEnumerable<string> hostMembers = null, Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType affinityType = default(Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType), Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength? affinityStrength = default(Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength?), Azure.ResourceManager.Avs.Models.AzureHybridBenefitType? azureHybridBenefitType = default(Azure.ResourceManager.Avs.Models.AzureHybridBenefitType?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.VmPlacementPolicyProperties VmPlacementPolicyProperties(Azure.ResourceManager.Avs.Models.PlacementPolicyState? state = default(Azure.ResourceManager.Avs.Models.PlacementPolicyState?), string displayName = null, Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> vmMembers = null, Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType affinityType = default(Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType)) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkData WorkloadNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkDhcpData WorkloadNetworkDhcpData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpEntity properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpEntity WorkloadNetworkDhcpEntity(string dhcpType = "Unknown", string displayName = null, System.Collections.Generic.IEnumerable<string> segments = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState?), long? revision = default(long?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpRelay WorkloadNetworkDhcpRelay(string displayName = null, System.Collections.Generic.IEnumerable<string> segments = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState?), long? revision = default(long?), System.Collections.Generic.IEnumerable<string> serverAddresses = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpServer WorkloadNetworkDhcpServer(string displayName = null, System.Collections.Generic.IEnumerable<string> segments = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState?), long? revision = default(long?), string serverAddress = null, long? leaseTime = default(long?)) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData WorkloadNetworkDnsServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, System.Net.IPAddress dnsServiceIP = null, string defaultDnsZone = null, System.Collections.Generic.IEnumerable<string> fqdnZones = null, Azure.ResourceManager.Avs.Models.DnsServiceLogLevel? logLevel = default(Azure.ResourceManager.Avs.Models.DnsServiceLogLevel?), Azure.ResourceManager.Avs.Models.DnsServiceStatus? status = default(Azure.ResourceManager.Avs.Models.DnsServiceStatus?), Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState?), long? revision = default(long?)) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData WorkloadNetworkDnsZoneData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, System.Collections.Generic.IEnumerable<string> domain = null, System.Collections.Generic.IEnumerable<System.Net.IPAddress> dnsServerIPs = null, System.Net.IPAddress sourceIP = null, long? dnsServices = default(long?), Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState?), long? revision = default(long?)) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkGatewayData WorkloadNetworkGatewayData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, string path = null) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData WorkloadNetworkPortMirroringProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection? direction = default(Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection?), string source = null, string destination = null, Azure.ResourceManager.Avs.Models.PortMirroringProfileStatus? status = default(Azure.ResourceManager.Avs.Models.PortMirroringProfileStatus?), Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState?), long? revision = default(long?)) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData WorkloadNetworkPublicIPData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, long? numberOfPublicIPs = default(long?), string publicIPBlock = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkSegmentData WorkloadNetworkSegmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, string connectedGateway = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentSubnet subnet = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentPortVif> portVif = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentStatus? status = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentStatus?), Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState?), long? revision = default(long?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentPortVif WorkloadNetworkSegmentPortVif(string portName = null) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineData WorkloadNetworkVirtualMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType? vmType = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType?)) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData WorkloadNetworkVmGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, System.Collections.Generic.IEnumerable<string> members = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupStatus? status = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupStatus?), Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState?), long? revision = default(long?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsPlacementPolicyAffinityType : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsPlacementPolicyAffinityType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType Affinity { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType AntiAffinity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType left, Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType left, Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class AvsPrivateCloudAddonProperties
    {
        protected AvsPrivateCloudAddonProperties() { }
        public Azure.ResourceManager.Avs.Models.AddonProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class AvsPrivateCloudClusterPatch
    {
        public AvsPrivateCloudClusterPatch() { }
        public int? ClusterSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Hosts { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsPrivateCloudClusterProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsPrivateCloudClusterProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState left, Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState left, Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvsPrivateCloudClusterVirtualMachineRestrictMovement
    {
        public AvsPrivateCloudClusterVirtualMachineRestrictMovement() { }
        public Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState? RestrictMovement { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsPrivateCloudDatastoreProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsPrivateCloudDatastoreProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState left, Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState left, Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvsPrivateCloudEndpoints
    {
        internal AvsPrivateCloudEndpoints() { }
        public string HcxCloudManager { get { throw null; } }
        public string NsxtManager { get { throw null; } }
        public string Vcsa { get { throw null; } }
    }
    public partial class AvsPrivateCloudPatch
    {
        public AvsPrivateCloudPatch() { }
        public Azure.ResourceManager.Avs.Models.PrivateCloudAvailabilityProperties Availability { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.CustomerManagedEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Avs.Models.SingleSignOnIdentitySource> IdentitySources { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.InternetConnectivityState? Internet { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsManagementCluster ManagementCluster { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsPrivateCloudProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsPrivateCloudProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState left, Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState left, Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvsSku
    {
        public AvsSku(string name) { }
        public string Name { get { throw null; } set { } }
    }
    public partial class AvsSubscriptionQuotaAvailabilityResult
    {
        internal AvsSubscriptionQuotaAvailabilityResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> HostsRemaining { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaEnabled? QuotaEnabled { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsSubscriptionQuotaEnabled : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsSubscriptionQuotaEnabled(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaEnabled Disabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaEnabled Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaEnabled left, Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaEnabled left, Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvsSubscriptionTrialAvailabilityResult
    {
        internal AvsSubscriptionTrialAvailabilityResult() { }
        public int? AvailableHosts { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsSubscriptionTrialStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsSubscriptionTrialStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus TrialAvailable { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus TrialDisabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus TrialUsed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus left, Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus left, Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureHybridBenefitType : System.IEquatable<Azure.ResourceManager.Avs.Models.AzureHybridBenefitType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureHybridBenefitType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AzureHybridBenefitType None { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AzureHybridBenefitType SqlHost { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AzureHybridBenefitType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AzureHybridBenefitType left, Azure.ResourceManager.Avs.Models.AzureHybridBenefitType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AzureHybridBenefitType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AzureHybridBenefitType left, Azure.ResourceManager.Avs.Models.AzureHybridBenefitType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CommonClusterProperties
    {
        public CommonClusterProperties() { }
        public int? ClusterId { get { throw null; } }
        public int? ClusterSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Hosts { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class CustomerManagedEncryption
    {
        public CustomerManagedEncryption() { }
        public Azure.ResourceManager.Avs.Models.AvsEncryptionKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsEncryptionState? Status { get { throw null; } set { } }
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
        public DiskPoolVolume(Azure.Core.ResourceIdentifier targetId, string lunName) { }
        public string LunName { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.LunMountMode? MountOption { get { throw null; } set { } }
        public string Path { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsServiceLogLevel : System.IEquatable<Azure.ResourceManager.Avs.Models.DnsServiceLogLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsServiceLogLevel(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.DnsServiceLogLevel Debug { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DnsServiceLogLevel Error { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DnsServiceLogLevel Fatal { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DnsServiceLogLevel Info { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DnsServiceLogLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.DnsServiceLogLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.DnsServiceLogLevel left, Azure.ResourceManager.Avs.Models.DnsServiceLogLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.DnsServiceLogLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.DnsServiceLogLevel left, Azure.ResourceManager.Avs.Models.DnsServiceLogLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsServiceStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.DnsServiceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsServiceStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.DnsServiceStatus Failure { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DnsServiceStatus Success { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.DnsServiceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.DnsServiceStatus left, Azure.ResourceManager.Avs.Models.DnsServiceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.DnsServiceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.DnsServiceStatus left, Azure.ResourceManager.Avs.Models.DnsServiceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExpressRouteAuthorizationProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExpressRouteAuthorizationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState Canceled { get { throw null; } }
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
    public partial class ExpressRouteCircuit
    {
        public ExpressRouteCircuit() { }
        public Azure.Core.ResourceIdentifier ExpressRouteId { get { throw null; } }
        public Azure.Core.ResourceIdentifier ExpressRoutePrivatePeeringId { get { throw null; } }
        public string PrimarySubnet { get { throw null; } }
        public string SecondarySubnet { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GlobalReachConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GlobalReachConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState Canceled { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InternetConnectivityState : System.IEquatable<Azure.ResourceManager.Avs.Models.InternetConnectivityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InternetConnectivityState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.InternetConnectivityState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.InternetConnectivityState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.InternetConnectivityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.InternetConnectivityState left, Azure.ResourceManager.Avs.Models.InternetConnectivityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.InternetConnectivityState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.InternetConnectivityState left, Azure.ResourceManager.Avs.Models.InternetConnectivityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LunMountMode : System.IEquatable<Azure.ResourceManager.Avs.Models.LunMountMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LunMountMode(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.LunMountMode Attach { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.LunMountMode Mount { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.LunMountMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.LunMountMode left, Azure.ResourceManager.Avs.Models.LunMountMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.LunMountMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.LunMountMode left, Azure.ResourceManager.Avs.Models.LunMountMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NsxPublicIPQuotaRaisedEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NsxPublicIPQuotaRaisedEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum left, Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum left, Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ParameterOptionalityStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.ParameterOptionalityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParameterOptionalityStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ParameterOptionalityStatus Optional { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ParameterOptionalityStatus Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.ParameterOptionalityStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.ParameterOptionalityStatus left, Azure.ResourceManager.Avs.Models.ParameterOptionalityStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.ParameterOptionalityStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.ParameterOptionalityStatus left, Azure.ResourceManager.Avs.Models.ParameterOptionalityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ParameterVisibilityStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.ParameterVisibilityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParameterVisibilityStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ParameterVisibilityStatus Hidden { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ParameterVisibilityStatus Visible { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.ParameterVisibilityStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.ParameterVisibilityStatus left, Azure.ResourceManager.Avs.Models.ParameterVisibilityStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.ParameterVisibilityStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.ParameterVisibilityStatus left, Azure.ResourceManager.Avs.Models.ParameterVisibilityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlacementPolicyPatch
    {
        public PlacementPolicyPatch() { }
        public Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength? AffinityStrength { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AzureHybridBenefitType? AzureHybridBenefitType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> HostMembers { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.PlacementPolicyState? State { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> VmMembers { get { throw null; } }
    }
    public abstract partial class PlacementPolicyProperties
    {
        protected PlacementPolicyProperties() { }
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
        public static Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState Canceled { get { throw null; } }
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
    public readonly partial struct PortMirroringProfileDirection : System.IEquatable<Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PortMirroringProfileDirection(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection Bidirectional { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection Egress { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection Ingress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection left, Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection left, Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PortMirroringProfileStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.PortMirroringProfileStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PortMirroringProfileStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.PortMirroringProfileStatus Failure { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PortMirroringProfileStatus Success { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.PortMirroringProfileStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.PortMirroringProfileStatus left, Azure.ResourceManager.Avs.Models.PortMirroringProfileStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.PortMirroringProfileStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.PortMirroringProfileStatus left, Azure.ResourceManager.Avs.Models.PortMirroringProfileStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateCloudAvailabilityProperties
    {
        public PrivateCloudAvailabilityProperties() { }
        public int? SecondaryZone { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvailabilityStrategy? Strategy { get { throw null; } set { } }
        public int? Zone { get { throw null; } set { } }
    }
    public partial class PSCredentialExecutionParameterDetails : Azure.ResourceManager.Avs.Models.ScriptExecutionParameterDetails
    {
        public PSCredentialExecutionParameterDetails(string name) : base (default(string)) { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public abstract partial class ScriptExecutionParameterDetails
    {
        protected ScriptExecutionParameterDetails(string name) { }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptExecutionProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptExecutionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState Canceled { get { throw null; } }
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
        public Azure.ResourceManager.Avs.Models.ParameterOptionalityStatus? Optional { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ScriptParameterType? ParameterType { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ParameterVisibilityStatus? Visibility { get { throw null; } }
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
    public partial class ScriptSecureStringExecutionParameterDetails : Azure.ResourceManager.Avs.Models.ScriptExecutionParameterDetails
    {
        public ScriptSecureStringExecutionParameterDetails(string name) : base (default(string)) { }
        public string SecureValue { get { throw null; } set { } }
    }
    public partial class ScriptStringExecutionParameterDetails : Azure.ResourceManager.Avs.Models.ScriptExecutionParameterDetails
    {
        public ScriptStringExecutionParameterDetails(string name) : base (default(string)) { }
        public string Value { get { throw null; } set { } }
    }
    public partial class SingleSignOnIdentitySource
    {
        public SingleSignOnIdentitySource() { }
        public string Alias { get { throw null; } set { } }
        public string BaseGroupDN { get { throw null; } set { } }
        public string BaseUserDN { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public System.Uri PrimaryServer { get { throw null; } set { } }
        public System.Uri SecondaryServer { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.SslCertificateStatus? Ssl { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SslCertificateStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.SslCertificateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SslCertificateStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.SslCertificateStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.SslCertificateStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.SslCertificateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.SslCertificateStatus left, Azure.ResourceManager.Avs.Models.SslCertificateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.SslCertificateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.SslCertificateStatus left, Azure.ResourceManager.Avs.Models.SslCertificateStatus right) { throw null; }
        public override string ToString() { throw null; }
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
    public readonly partial struct VmHostPlacementPolicyAffinityStrength : System.IEquatable<Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmHostPlacementPolicyAffinityStrength(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength Must { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength Should { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength left, Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength left, Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VmHostPlacementPolicyProperties : Azure.ResourceManager.Avs.Models.PlacementPolicyProperties
    {
        public VmHostPlacementPolicyProperties(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> vmMembers, System.Collections.Generic.IEnumerable<string> hostMembers, Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType affinityType) { }
        public Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength? AffinityStrength { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType AffinityType { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AzureHybridBenefitType? AzureHybridBenefitType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> HostMembers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> VmMembers { get { throw null; } }
    }
    public partial class VmPlacementPolicyProperties : Azure.ResourceManager.Avs.Models.PlacementPolicyProperties
    {
        public VmPlacementPolicyProperties(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> vmMembers, Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType affinityType) { }
        public Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType AffinityType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> VmMembers { get { throw null; } }
    }
    public abstract partial class WorkloadNetworkDhcpEntity
    {
        protected WorkloadNetworkDhcpEntity() { }
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
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState Canceled { get { throw null; } }
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
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState Canceled { get { throw null; } }
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
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState Canceled { get { throw null; } }
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
    public readonly partial struct WorkloadNetworkName : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkName(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkName left, Azure.ResourceManager.Avs.Models.WorkloadNetworkName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkName left, Azure.ResourceManager.Avs.Models.WorkloadNetworkName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkPortMirroringProfileProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkPortMirroringProfileProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkPublicIPProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkPublicIPProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState Canceled { get { throw null; } }
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
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState Canceled { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkSegmentStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkSegmentStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentStatus Failure { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentStatus Success { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentStatus left, Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentStatus left, Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentStatus right) { throw null; }
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
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState Canceled { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkVmGroupStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkVmGroupStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupStatus Failure { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupStatus Success { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupStatus left, Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupStatus left, Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkVmType : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkVmType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType Edge { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType Regular { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType Service { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType left, Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType left, Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
