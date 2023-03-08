namespace Azure.ResourceManager.MobileNetwork
{
    public partial class AttachedDataNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource>, System.Collections.IEnumerable
    {
        protected AttachedDataNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string attachedDataNetworkName, Azure.ResourceManager.MobileNetwork.AttachedDataNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string attachedDataNetworkName, Azure.ResourceManager.MobileNetwork.AttachedDataNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string attachedDataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string attachedDataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource> Get(string attachedDataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource>> GetAsync(string attachedDataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AttachedDataNetworkData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AttachedDataNetworkData(Azure.Core.AzureLocation location, Azure.ResourceManager.MobileNetwork.Models.InterfaceProperties userPlaneDataInterface, System.Collections.Generic.IEnumerable<string> dnsAddresses) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<string> DnsAddresses { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.NaptConfiguration NaptConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<string> UserEquipmentAddressPoolPrefix { get { throw null; } }
        public System.Collections.Generic.IList<string> UserEquipmentStaticAddressPoolPrefix { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.InterfaceProperties UserPlaneDataInterface { get { throw null; } set { } }
    }
    public partial class AttachedDataNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AttachedDataNetworkResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.AttachedDataNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string packetCoreControlPlaneName, string packetCoreDataPlaneName, string attachedDataNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource> Update(Azure.ResourceManager.MobileNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource>> UpdateAsync(Azure.ResourceManager.MobileNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.DataNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.DataNetworkResource>, System.Collections.IEnumerable
    {
        protected DataNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.DataNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataNetworkName, Azure.ResourceManager.MobileNetwork.DataNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.DataNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataNetworkName, Azure.ResourceManager.MobileNetwork.DataNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.DataNetworkResource> Get(string dataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.DataNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.DataNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.DataNetworkResource>> GetAsync(string dataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.DataNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.DataNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.DataNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.DataNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataNetworkData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DataNetworkData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class DataNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataNetworkResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.DataNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.DataNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.DataNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mobileNetworkName, string dataNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.DataNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.DataNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.DataNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.DataNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.DataNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.DataNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.DataNetworkResource> Update(Azure.ResourceManager.MobileNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.DataNetworkResource>> UpdateAsync(Azure.ResourceManager.MobileNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MobileNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>, System.Collections.IEnumerable
    {
        protected MobileNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string mobileNetworkName, Azure.ResourceManager.MobileNetwork.MobileNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string mobileNetworkName, Azure.ResourceManager.MobileNetwork.MobileNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string mobileNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string mobileNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> Get(string mobileNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>> GetAsync(string mobileNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MobileNetworkData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MobileNetworkData(Azure.Core.AzureLocation location, Azure.ResourceManager.MobileNetwork.Models.PlmnId publicLandMobileNetworkIdentifier) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.MobileNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.PlmnId PublicLandMobileNetworkIdentifier { get { throw null; } set { } }
        public string ServiceKey { get { throw null; } }
    }
    public static partial class MobileNetworkExtensions
    {
        public static Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource GetAttachedDataNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.DataNetworkResource GetDataNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> GetMobileNetwork(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string mobileNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>> GetMobileNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string mobileNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkResource GetMobileNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkCollection GetMobileNetworks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> GetMobileNetworks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> GetMobileNetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> GetPacketCoreControlPlane(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string packetCoreControlPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>> GetPacketCoreControlPlaneAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string packetCoreControlPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource GetPacketCoreControlPlaneResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneCollection GetPacketCoreControlPlanes(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> GetPacketCoreControlPlanes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> GetPacketCoreControlPlanesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionResource> GetPacketCoreControlPlaneVersion(this Azure.ResourceManager.Resources.TenantResource tenantResource, string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionResource>> GetPacketCoreControlPlaneVersionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionResource GetPacketCoreControlPlaneVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionCollection GetPacketCoreControlPlaneVersions(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource GetPacketCoreDataPlaneResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.ServiceResource GetServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MobileNetwork.SimGroupResource> GetSimGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string simGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SimGroupResource>> GetSimGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string simGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.SimGroupResource GetSimGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.SimGroupCollection GetSimGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MobileNetwork.SimGroupResource> GetSimGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.SimGroupResource> GetSimGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.SimPolicyResource GetSimPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.SimResource GetSimResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.SiteResource GetSiteResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.SliceResource GetSliceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MobileNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MobileNetworkResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mobileNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.DataNetworkResource> GetDataNetwork(string dataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.DataNetworkResource>> GetDataNetworkAsync(string dataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.DataNetworkCollection GetDataNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.ServiceResource> GetService(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.ServiceResource>> GetServiceAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.ServiceCollection GetServices() { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.SimPolicyCollection GetSimPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SimPolicyResource> GetSimPolicy(string simPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SimPolicyResource>> GetSimPolicyAsync(string simPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SiteResource> GetSite(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SiteResource>> GetSiteAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.SiteCollection GetSites() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SliceResource> GetSlice(string sliceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SliceResource>> GetSliceAsync(string sliceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.SliceCollection GetSlices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> Update(Azure.ResourceManager.MobileNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>> UpdateAsync(Azure.ResourceManager.MobileNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PacketCoreControlPlaneCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>, System.Collections.IEnumerable
    {
        protected PacketCoreControlPlaneCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string packetCoreControlPlaneName, Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string packetCoreControlPlaneName, Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string packetCoreControlPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string packetCoreControlPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> Get(string packetCoreControlPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>> GetAsync(string packetCoreControlPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PacketCoreControlPlaneData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PacketCoreControlPlaneData(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> sites, Azure.ResourceManager.MobileNetwork.Models.PlatformConfiguration platform, Azure.ResourceManager.MobileNetwork.Models.InterfaceProperties controlPlaneAccessInterface, Azure.ResourceManager.MobileNetwork.Models.BillingSku sku, Azure.ResourceManager.MobileNetwork.Models.LocalDiagnosticsAccessConfiguration localDiagnosticsAccess) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.MobileNetwork.Models.InterfaceProperties ControlPlaneAccessInterface { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.CoreNetworkType? CoreNetworkTechnology { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.Installation Installation { get { throw null; } }
        public System.BinaryData InteropSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.LocalDiagnosticsAccessConfiguration LocalDiagnosticsAccess { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.PlatformConfiguration Platform { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string RollbackVersion { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Sites { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.BillingSku Sku { get { throw null; } set { } }
        public int? UeMtu { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class PacketCoreControlPlaneResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PacketCoreControlPlaneResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus> CollectDiagnosticsPackage(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.Models.PacketCoreControlPlaneCollectDiagnosticsPackage packetCoreControlPlaneCollectDiagnosticsPackage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus>> CollectDiagnosticsPackageAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.Models.PacketCoreControlPlaneCollectDiagnosticsPackage packetCoreControlPlaneCollectDiagnosticsPackage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string packetCoreControlPlaneName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> GetPacketCoreDataPlane(string packetCoreDataPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>> GetPacketCoreDataPlaneAsync(string packetCoreDataPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneCollection GetPacketCoreDataPlanes() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus> Reinstall(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus>> ReinstallAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus> Rollback(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus>> RollbackAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> Update(Azure.ResourceManager.MobileNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>> UpdateAsync(Azure.ResourceManager.MobileNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PacketCoreControlPlaneVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionResource>, System.Collections.IEnumerable
    {
        protected PacketCoreControlPlaneVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionResource> Get(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionResource>> GetAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PacketCoreControlPlaneVersionData : Azure.ResourceManager.Models.ResourceData
    {
        public PacketCoreControlPlaneVersionData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.Platform> Platforms { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PacketCoreControlPlaneVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PacketCoreControlPlaneVersionResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string versionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PacketCoreDataPlaneCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>, System.Collections.IEnumerable
    {
        protected PacketCoreDataPlaneCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string packetCoreDataPlaneName, Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string packetCoreDataPlaneName, Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string packetCoreDataPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string packetCoreDataPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> Get(string packetCoreDataPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>> GetAsync(string packetCoreDataPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PacketCoreDataPlaneData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PacketCoreDataPlaneData(Azure.Core.AzureLocation location, Azure.ResourceManager.MobileNetwork.Models.InterfaceProperties userPlaneAccessInterface) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.MobileNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.InterfaceProperties UserPlaneAccessInterface { get { throw null; } set { } }
    }
    public partial class PacketCoreDataPlaneResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PacketCoreDataPlaneResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string packetCoreControlPlaneName, string packetCoreDataPlaneName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource> GetAttachedDataNetwork(string attachedDataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.AttachedDataNetworkResource>> GetAttachedDataNetworkAsync(string attachedDataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.AttachedDataNetworkCollection GetAttachedDataNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> Update(Azure.ResourceManager.MobileNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>> UpdateAsync(Azure.ResourceManager.MobileNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.ServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.ServiceResource>, System.Collections.IEnumerable
    {
        protected ServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.ServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.MobileNetwork.ServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.ServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.MobileNetwork.ServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.ServiceResource> Get(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.ServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.ServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.ServiceResource>> GetAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.ServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.ServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.ServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.ServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServiceData(Azure.Core.AzureLocation location, int servicePrecedence, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.PccRuleConfiguration> pccRules) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.PccRuleConfiguration> PccRules { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public int ServicePrecedence { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.QosPolicy ServiceQosPolicy { get { throw null; } set { } }
    }
    public partial class ServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.ServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.ServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.ServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mobileNetworkName, string serviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.ServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.ServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.ServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.ServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.ServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.ServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.ServiceResource> Update(Azure.ResourceManager.MobileNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.ServiceResource>> UpdateAsync(Azure.ResourceManager.MobileNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SimCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.SimResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.SimResource>, System.Collections.IEnumerable
    {
        protected SimCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.SimResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string simName, Azure.ResourceManager.MobileNetwork.SimData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.SimResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string simName, Azure.ResourceManager.MobileNetwork.SimData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string simName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string simName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SimResource> Get(string simName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.SimResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.SimResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SimResource>> GetAsync(string simName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.SimResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.SimResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.SimResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.SimResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SimData : Azure.ResourceManager.Models.ResourceData
    {
        public SimData(string internationalMobileSubscriberIdentity) { }
        public string AuthenticationKey { get { throw null; } set { } }
        public string DeviceType { get { throw null; } set { } }
        public string IntegratedCircuitCardIdentifier { get { throw null; } set { } }
        public string InternationalMobileSubscriberIdentity { get { throw null; } set { } }
        public string OperatorKeyCode { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SimPolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.SimState? SimState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.MobileNetwork.Models.SiteProvisioningState> SiteProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.SimStaticIPProperties> StaticIPConfiguration { get { throw null; } }
        public string VendorKeyFingerprint { get { throw null; } }
        public string VendorName { get { throw null; } }
    }
    public partial class SimGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.SimGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.SimGroupResource>, System.Collections.IEnumerable
    {
        protected SimGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.SimGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string simGroupName, Azure.ResourceManager.MobileNetwork.SimGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.SimGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string simGroupName, Azure.ResourceManager.MobileNetwork.SimGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string simGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string simGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SimGroupResource> Get(string simGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.SimGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.SimGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SimGroupResource>> GetAsync(string simGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.SimGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.SimGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.SimGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.SimGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SimGroupData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SimGroupData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Uri KeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MobileNetworkId { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class SimGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SimGroupResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.SimGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SimGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SimGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus> BulkDeleteSim(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.Models.SimDeleteList simDeleteList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus>> BulkDeleteSimAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.Models.SimDeleteList simDeleteList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus> BulkUploadEncryptedSim(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.Models.EncryptedSimUploadList encryptedSimUploadList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus>> BulkUploadEncryptedSimAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.Models.EncryptedSimUploadList encryptedSimUploadList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus> BulkUploadSim(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.Models.SimUploadList simUploadList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus>> BulkUploadSimAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.Models.SimUploadList simUploadList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string simGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SimGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SimGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SimResource> GetSim(string simName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SimResource>> GetSimAsync(string simName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.SimCollection GetSims() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SimGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SimGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SimGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SimGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SimGroupResource> Update(Azure.ResourceManager.MobileNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SimGroupResource>> UpdateAsync(Azure.ResourceManager.MobileNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SimPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.SimPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.SimPolicyResource>, System.Collections.IEnumerable
    {
        protected SimPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.SimPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string simPolicyName, Azure.ResourceManager.MobileNetwork.SimPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.SimPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string simPolicyName, Azure.ResourceManager.MobileNetwork.SimPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string simPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string simPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SimPolicyResource> Get(string simPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.SimPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.SimPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SimPolicyResource>> GetAsync(string simPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.SimPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.SimPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.SimPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.SimPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SimPolicyData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SimPolicyData(Azure.Core.AzureLocation location, Azure.ResourceManager.MobileNetwork.Models.Ambr ueAmbr, Azure.ResourceManager.Resources.Models.WritableSubResource defaultSlice, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.SliceConfiguration> sliceConfigurations) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.Core.ResourceIdentifier DefaultSliceId { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public int? RegistrationTimer { get { throw null; } set { } }
        public int? RfspIndex { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.MobileNetwork.Models.SiteProvisioningState> SiteProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.SliceConfiguration> SliceConfigurations { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.Ambr UeAmbr { get { throw null; } set { } }
    }
    public partial class SimPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SimPolicyResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.SimPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SimPolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SimPolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mobileNetworkName, string simPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SimPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SimPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SimPolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SimPolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SimPolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SimPolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SimPolicyResource> Update(Azure.ResourceManager.MobileNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SimPolicyResource>> UpdateAsync(Azure.ResourceManager.MobileNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SimResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SimResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.SimData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string simGroupName, string simName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SimResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SimResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.SimResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.SimData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.SimResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.SimData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.SiteResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.SiteResource>, System.Collections.IEnumerable
    {
        protected SiteCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.SiteResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.MobileNetwork.SiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.SiteResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.MobileNetwork.SiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SiteResource> Get(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.SiteResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.SiteResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SiteResource>> GetAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.SiteResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.SiteResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.SiteResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.SiteResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SiteData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> NetworkFunctions { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class SiteResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.SiteData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SiteResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SiteResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mobileNetworkName, string siteName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SiteResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SiteResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SiteResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SiteResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SiteResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SiteResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SiteResource> Update(Azure.ResourceManager.MobileNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SiteResource>> UpdateAsync(Azure.ResourceManager.MobileNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SliceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.SliceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.SliceResource>, System.Collections.IEnumerable
    {
        protected SliceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.SliceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sliceName, Azure.ResourceManager.MobileNetwork.SliceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.SliceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sliceName, Azure.ResourceManager.MobileNetwork.SliceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sliceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sliceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SliceResource> Get(string sliceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.SliceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.SliceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SliceResource>> GetAsync(string sliceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.SliceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.SliceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.SliceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.SliceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SliceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SliceData(Azure.Core.AzureLocation location, Azure.ResourceManager.MobileNetwork.Models.Snssai snssai) : base (default(Azure.Core.AzureLocation)) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.Snssai Snssai { get { throw null; } set { } }
    }
    public partial class SliceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SliceResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.SliceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SliceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SliceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mobileNetworkName, string sliceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SliceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SliceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SliceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SliceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SliceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SliceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SliceResource> Update(Azure.ResourceManager.MobileNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SliceResource>> UpdateAsync(Azure.ResourceManager.MobileNetwork.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MobileNetwork.Mock
{
    public partial class MobileNetworkResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected MobileNetworkResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> GetMobileNetworks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> GetMobileNetworksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PacketCoreControlPlaneResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected PacketCoreControlPlaneResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> GetPacketCoreControlPlanes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> GetPacketCoreControlPlanesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ResourceGroupResourceExtensionClient() { }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkCollection GetMobileNetworks() { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneCollection GetPacketCoreControlPlanes() { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.SimGroupCollection GetSimGroups() { throw null; }
    }
    public partial class SimGroupResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected SimGroupResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.SimGroupResource> GetSimGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.SimGroupResource> GetSimGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected TenantResourceExtensionClient() { }
        public virtual Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionCollection GetPacketCoreControlPlaneVersions() { throw null; }
    }
}
namespace Azure.ResourceManager.MobileNetwork.Models
{
    public partial class Ambr
    {
        public Ambr(string uplink, string downlink) { }
        public string Downlink { get { throw null; } set { } }
        public string Uplink { get { throw null; } set { } }
    }
    public partial class AsyncOperationStatus
    {
        internal AsyncOperationStatus() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public double? PercentComplete { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthenticationType : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.AuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.AuthenticationType AAD { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.AuthenticationType Password { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.AuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.AuthenticationType left, Azure.ResourceManager.MobileNetwork.Models.AuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.AuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.AuthenticationType left, Azure.ResourceManager.MobileNetwork.Models.AuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingSku : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.BillingSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingSku(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.BillingSku G0 { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.BillingSku G1 { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.BillingSku G10 { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.BillingSku G2 { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.BillingSku G3 { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.BillingSku G4 { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.BillingSku G5 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.BillingSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.BillingSku left, Azure.ResourceManager.MobileNetwork.Models.BillingSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.BillingSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.BillingSku left, Azure.ResourceManager.MobileNetwork.Models.BillingSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CertificateProvisioning
    {
        internal CertificateProvisioning() { }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioningState? State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateProvisioningState : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioningState NotProvisioned { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioningState Provisioned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioningState left, Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioningState left, Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum CoreNetworkType
    {
        FiveGC = 0,
        EPC = 1,
    }
    public partial class DataNetworkConfiguration
    {
        public DataNetworkConfiguration(Azure.ResourceManager.Resources.Models.WritableSubResource dataNetwork, Azure.ResourceManager.MobileNetwork.Models.Ambr sessionAmbr, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> allowedServices) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.PduSessionType> AdditionalAllowedSessionTypes { get { throw null; } }
        public int? AllocationAndRetentionPriorityLevel { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> AllowedServices { get { throw null; } }
        public Azure.Core.ResourceIdentifier DataNetworkId { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.PduSessionType? DefaultSessionType { get { throw null; } set { } }
        public int? FiveQi { get { throw null; } set { } }
        public int? MaximumNumberOfBufferedPackets { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.PreemptionCapability? PreemptionCapability { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.PreemptionVulnerability? PreemptionVulnerability { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.Ambr SessionAmbr { get { throw null; } set { } }
    }
    public partial class EncryptedSimUploadList
    {
        public EncryptedSimUploadList(int version, int azureKeyIdentifier, string vendorKeyFingerprint, string encryptedTransportKey, string signedTransportKey, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.SimNameAndEncryptedProperties> sims) { }
        public int AzureKeyIdentifier { get { throw null; } }
        public string EncryptedTransportKey { get { throw null; } }
        public string SignedTransportKey { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.SimNameAndEncryptedProperties> Sims { get { throw null; } }
        public string VendorKeyFingerprint { get { throw null; } }
        public int Version { get { throw null; } }
    }
    public partial class HttpsServerCertificate
    {
        public HttpsServerCertificate(System.Uri certificateUri) { }
        public System.Uri CertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioning Provisioning { get { throw null; } }
    }
    public partial class Installation
    {
        internal Installation() { }
        public Azure.Core.ResourceIdentifier OperationId { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.InstallationState? State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InstallationState : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.InstallationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InstallationState(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.InstallationState Failed { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.InstallationState Installed { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.InstallationState Installing { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.InstallationState Reinstalling { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.InstallationState RollingBack { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.InstallationState Uninstalled { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.InstallationState Uninstalling { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.InstallationState Updating { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.InstallationState Upgrading { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.InstallationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.InstallationState left, Azure.ResourceManager.MobileNetwork.Models.InstallationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.InstallationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.InstallationState left, Azure.ResourceManager.MobileNetwork.Models.InstallationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InterfaceProperties
    {
        public InterfaceProperties() { }
        public string IPv4Address { get { throw null; } set { } }
        public string IPv4Gateway { get { throw null; } set { } }
        public string IPv4Subnet { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class LocalDiagnosticsAccessConfiguration
    {
        public LocalDiagnosticsAccessConfiguration(Azure.ResourceManager.MobileNetwork.Models.AuthenticationType authenticationType) { }
        public Azure.ResourceManager.MobileNetwork.Models.AuthenticationType AuthenticationType { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.HttpsServerCertificate HttpsServerCertificate { get { throw null; } set { } }
    }
    public partial class NaptConfiguration
    {
        public NaptConfiguration() { }
        public Azure.ResourceManager.MobileNetwork.Models.NaptEnabled? Enabled { get { throw null; } set { } }
        public int? PinholeLimits { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.PinholeTimeouts PinholeTimeouts { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.PortRange PortRange { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.PortReuseHoldTimes PortReuseHoldTime { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NaptEnabled : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.NaptEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NaptEnabled(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.NaptEnabled Disabled { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.NaptEnabled Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.NaptEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.NaptEnabled left, Azure.ResourceManager.MobileNetwork.Models.NaptEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.NaptEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.NaptEnabled left, Azure.ResourceManager.MobileNetwork.Models.NaptEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ObsoleteVersion : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.ObsoleteVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ObsoleteVersion(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.ObsoleteVersion NotObsolete { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.ObsoleteVersion Obsolete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.ObsoleteVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.ObsoleteVersion left, Azure.ResourceManager.MobileNetwork.Models.ObsoleteVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.ObsoleteVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.ObsoleteVersion left, Azure.ResourceManager.MobileNetwork.Models.ObsoleteVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PacketCoreControlPlaneCollectDiagnosticsPackage
    {
        public PacketCoreControlPlaneCollectDiagnosticsPackage(System.Uri storageAccountBlobUri) { }
        public System.Uri StorageAccountBlobUri { get { throw null; } }
    }
    public partial class PccRuleConfiguration
    {
        public PccRuleConfiguration(string ruleName, int rulePrecedence, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.ServiceDataFlowTemplate> serviceDataFlowTemplates) { }
        public string RuleName { get { throw null; } set { } }
        public int RulePrecedence { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.PccRuleQosPolicy RuleQosPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.ServiceDataFlowTemplate> ServiceDataFlowTemplates { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.TrafficControlPermission? TrafficControl { get { throw null; } set { } }
    }
    public partial class PccRuleQosPolicy : Azure.ResourceManager.MobileNetwork.Models.QosPolicy
    {
        public PccRuleQosPolicy(Azure.ResourceManager.MobileNetwork.Models.Ambr maximumBitRate) : base (default(Azure.ResourceManager.MobileNetwork.Models.Ambr)) { }
        public Azure.ResourceManager.MobileNetwork.Models.Ambr GuaranteedBitRate { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PduSessionType : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.PduSessionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PduSessionType(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.PduSessionType IPv4 { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.PduSessionType IPv6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.PduSessionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.PduSessionType left, Azure.ResourceManager.MobileNetwork.Models.PduSessionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.PduSessionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.PduSessionType left, Azure.ResourceManager.MobileNetwork.Models.PduSessionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PinholeTimeouts
    {
        public PinholeTimeouts() { }
        public int? Icmp { get { throw null; } set { } }
        public int? Tcp { get { throw null; } set { } }
        public int? Udp { get { throw null; } set { } }
    }
    public partial class Platform
    {
        public Platform() { }
        public string MaximumPlatformSoftwareVersion { get { throw null; } set { } }
        public string MinimumPlatformSoftwareVersion { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.ObsoleteVersion? ObsoleteVersion { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.PlatformType? PlatformType { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.RecommendedVersion? RecommendedVersion { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.VersionState? VersionState { get { throw null; } set { } }
    }
    public partial class PlatformConfiguration
    {
        public PlatformConfiguration(Azure.ResourceManager.MobileNetwork.Models.PlatformType platformType) { }
        public Azure.Core.ResourceIdentifier AzureStackEdgeDeviceId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WritableSubResource> AzureStackEdgeDevices { get { throw null; } }
        public Azure.Core.ResourceIdentifier AzureStackHciClusterId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ConnectedClusterId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CustomLocationId { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.PlatformType PlatformType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlatformType : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.PlatformType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlatformType(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.PlatformType AKSHCI { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.PlatformType ThreePAzureStackHCI { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.PlatformType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.PlatformType left, Azure.ResourceManager.MobileNetwork.Models.PlatformType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.PlatformType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.PlatformType left, Azure.ResourceManager.MobileNetwork.Models.PlatformType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlmnId
    {
        public PlmnId(string mcc, string mnc) { }
        public string Mcc { get { throw null; } set { } }
        public string Mnc { get { throw null; } set { } }
    }
    public partial class PortRange
    {
        public PortRange() { }
        public int? MaxPort { get { throw null; } set { } }
        public int? MinPort { get { throw null; } set { } }
    }
    public partial class PortReuseHoldTimes
    {
        public PortReuseHoldTimes() { }
        public int? Tcp { get { throw null; } set { } }
        public int? Udp { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PreemptionCapability : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.PreemptionCapability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PreemptionCapability(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.PreemptionCapability MayPreempt { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.PreemptionCapability NotPreempt { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.PreemptionCapability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.PreemptionCapability left, Azure.ResourceManager.MobileNetwork.Models.PreemptionCapability right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.PreemptionCapability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.PreemptionCapability left, Azure.ResourceManager.MobileNetwork.Models.PreemptionCapability right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PreemptionVulnerability : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.PreemptionVulnerability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PreemptionVulnerability(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.PreemptionVulnerability NotPreemptable { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.PreemptionVulnerability Preemptable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.PreemptionVulnerability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.PreemptionVulnerability left, Azure.ResourceManager.MobileNetwork.Models.PreemptionVulnerability right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.PreemptionVulnerability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.PreemptionVulnerability left, Azure.ResourceManager.MobileNetwork.Models.PreemptionVulnerability right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.ProvisioningState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.ProvisioningState left, Azure.ResourceManager.MobileNetwork.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.ProvisioningState left, Azure.ResourceManager.MobileNetwork.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QosPolicy
    {
        public QosPolicy(Azure.ResourceManager.MobileNetwork.Models.Ambr maximumBitRate) { }
        public int? AllocationAndRetentionPriorityLevel { get { throw null; } set { } }
        public int? FiveQi { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.Ambr MaximumBitRate { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.PreemptionCapability? PreemptionCapability { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.PreemptionVulnerability? PreemptionVulnerability { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendedVersion : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.RecommendedVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendedVersion(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.RecommendedVersion NotRecommended { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.RecommendedVersion Recommended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.RecommendedVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.RecommendedVersion left, Azure.ResourceManager.MobileNetwork.Models.RecommendedVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.RecommendedVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.RecommendedVersion left, Azure.ResourceManager.MobileNetwork.Models.RecommendedVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SdfDirection : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.SdfDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SdfDirection(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.SdfDirection Bidirectional { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.SdfDirection Downlink { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.SdfDirection Uplink { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.SdfDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.SdfDirection left, Azure.ResourceManager.MobileNetwork.Models.SdfDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.SdfDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.SdfDirection left, Azure.ResourceManager.MobileNetwork.Models.SdfDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceDataFlowTemplate
    {
        public ServiceDataFlowTemplate(string templateName, Azure.ResourceManager.MobileNetwork.Models.SdfDirection direction, System.Collections.Generic.IEnumerable<string> protocol, System.Collections.Generic.IEnumerable<string> remoteIPList) { }
        public Azure.ResourceManager.MobileNetwork.Models.SdfDirection Direction { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Ports { get { throw null; } }
        public System.Collections.Generic.IList<string> Protocol { get { throw null; } }
        public System.Collections.Generic.IList<string> RemoteIPList { get { throw null; } }
        public string TemplateName { get { throw null; } set { } }
    }
    public partial class SimDeleteList
    {
        public SimDeleteList(System.Collections.Generic.IEnumerable<string> sims) { }
        public System.Collections.Generic.IList<string> Sims { get { throw null; } }
    }
    public partial class SimNameAndEncryptedProperties
    {
        public SimNameAndEncryptedProperties(string name, string internationalMobileSubscriberIdentity) { }
        public string DeviceType { get { throw null; } set { } }
        public string EncryptedCredentials { get { throw null; } set { } }
        public string IntegratedCircuitCardIdentifier { get { throw null; } set { } }
        public string InternationalMobileSubscriberIdentity { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SimPolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.SimState? SimState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.MobileNetwork.Models.SiteProvisioningState> SiteProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.SimStaticIPProperties> StaticIPConfiguration { get { throw null; } }
        public string VendorKeyFingerprint { get { throw null; } }
        public string VendorName { get { throw null; } }
    }
    public partial class SimNameAndProperties
    {
        public SimNameAndProperties(string name, string internationalMobileSubscriberIdentity) { }
        public string AuthenticationKey { get { throw null; } set { } }
        public string DeviceType { get { throw null; } set { } }
        public string IntegratedCircuitCardIdentifier { get { throw null; } set { } }
        public string InternationalMobileSubscriberIdentity { get { throw null; } }
        public string Name { get { throw null; } }
        public string OperatorKeyCode { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SimPolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.SimState? SimState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.MobileNetwork.Models.SiteProvisioningState> SiteProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.SimStaticIPProperties> StaticIPConfiguration { get { throw null; } }
        public string VendorKeyFingerprint { get { throw null; } }
        public string VendorName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SimState : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.SimState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SimState(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.SimState Disabled { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.SimState Enabled { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.SimState Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.SimState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.SimState left, Azure.ResourceManager.MobileNetwork.Models.SimState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.SimState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.SimState left, Azure.ResourceManager.MobileNetwork.Models.SimState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SimStaticIPProperties
    {
        public SimStaticIPProperties() { }
        public Azure.Core.ResourceIdentifier AttachedDataNetworkId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SliceId { get { throw null; } set { } }
        public string StaticIPIPv4Address { get { throw null; } set { } }
    }
    public partial class SimUploadList
    {
        public SimUploadList(System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.SimNameAndProperties> sims) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.SimNameAndProperties> Sims { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SiteProvisioningState : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.SiteProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SiteProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.SiteProvisioningState Adding { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.SiteProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.SiteProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.SiteProvisioningState NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.SiteProvisioningState Provisioned { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.SiteProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.SiteProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.SiteProvisioningState left, Azure.ResourceManager.MobileNetwork.Models.SiteProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.SiteProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.SiteProvisioningState left, Azure.ResourceManager.MobileNetwork.Models.SiteProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SliceConfiguration
    {
        public SliceConfiguration(Azure.ResourceManager.Resources.Models.WritableSubResource slice, Azure.ResourceManager.Resources.Models.WritableSubResource defaultDataNetwork, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.DataNetworkConfiguration> dataNetworkConfigurations) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.DataNetworkConfiguration> DataNetworkConfigurations { get { throw null; } }
        public Azure.Core.ResourceIdentifier DefaultDataNetworkId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SliceId { get { throw null; } set { } }
    }
    public partial class Snssai
    {
        public Snssai(int sst) { }
        public string Sd { get { throw null; } set { } }
        public int Sst { get { throw null; } set { } }
    }
    public partial class TagsObject
    {
        public TagsObject() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficControlPermission : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.TrafficControlPermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficControlPermission(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.TrafficControlPermission Blocked { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.TrafficControlPermission Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.TrafficControlPermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.TrafficControlPermission left, Azure.ResourceManager.MobileNetwork.Models.TrafficControlPermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.TrafficControlPermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.TrafficControlPermission left, Azure.ResourceManager.MobileNetwork.Models.TrafficControlPermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VersionState : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.VersionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VersionState(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.VersionState Active { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.VersionState Deprecated { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.VersionState Preview { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.VersionState Unknown { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.VersionState Validating { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.VersionState ValidationFailed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.VersionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.VersionState left, Azure.ResourceManager.MobileNetwork.Models.VersionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.VersionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.VersionState left, Azure.ResourceManager.MobileNetwork.Models.VersionState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
