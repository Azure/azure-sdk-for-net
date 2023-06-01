namespace Azure.ResourceManager.ManagedNetworkFabric
{
    public partial class AccessControlListCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource>, System.Collections.IEnumerable
    {
        protected AccessControlListCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accessControlListName, Azure.ResourceManager.ManagedNetworkFabric.AccessControlListData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accessControlListName, Azure.ResourceManager.ManagedNetworkFabric.AccessControlListData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accessControlListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accessControlListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource> Get(string accessControlListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource>> GetAsync(string accessControlListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AccessControlListData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AccessControlListData(Azure.Core.AzureLocation location, Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamily addressFamily, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListPropertiesConditionsItem> conditions) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamily AddressFamily { get { throw null; } set { } }
        public string Annotation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListPropertiesConditionsItem> Conditions { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class AccessControlListResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AccessControlListResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.AccessControlListData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accessControlListName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource> Update(Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource>> UpdateAsync(Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExternalNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkResource>, System.Collections.IEnumerable
    {
        protected ExternalNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string externalNetworkName, Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string externalNetworkName, Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string externalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string externalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkResource> Get(string externalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkResource>> GetAsync(string externalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ExternalNetworkData : Azure.ResourceManager.Models.ResourceData
    {
        public ExternalNetworkData(Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption peeringOption) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> DisabledOnResources { get { throw null; } }
        public string ExportRoutePolicyId { get { throw null; } set { } }
        public string ImportRoutePolicyId { get { throw null; } set { } }
        public string NetworkToNetworkInterconnectId { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkPropertiesOptionAProperties OptionAProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBProperties OptionBProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption PeeringOption { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ExternalNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExternalNetworkResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation ClearArpEntries(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableOnResources body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ClearArpEntriesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableOnResources body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ClearIPv6Neighbors(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableOnResources body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ClearIPv6NeighborsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableOnResources body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string l3IsolationDomainName, string externalNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateBfdForBgpAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateBfdForBgpAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateBgpAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateBgpAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InternalNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkResource>, System.Collections.IEnumerable
    {
        protected InternalNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string internalNetworkName, Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string internalNetworkName, Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string internalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string internalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkResource> Get(string internalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkResource>> GetAsync(string internalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class InternalNetworkData : Azure.ResourceManager.Models.ResourceData
    {
        public InternalNetworkData(int vlanId) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> BfdDisabledOnResources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> BfdForStaticRoutesDisabledOnResources { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatchablePropertiesBgpConfiguration BgpConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> BgpDisabledOnResources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatchablePropertiesConnectedIPv4SubnetsItem> ConnectedIPv4Subnets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatchablePropertiesConnectedIPv6SubnetsItem> ConnectedIPv6Subnets { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DisabledOnResources { get { throw null; } }
        public string ExportRoutePolicyId { get { throw null; } set { } }
        public string ImportRoutePolicyId { get { throw null; } set { } }
        public int? Mtu { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatchablePropertiesStaticRouteConfiguration StaticRouteConfiguration { get { throw null; } set { } }
        public int VlanId { get { throw null; } set { } }
    }
    public partial class InternalNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InternalNetworkResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation ClearArpEntries(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableOnResources body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ClearArpEntriesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableOnResources body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ClearIPv6Neighbors(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableOnResources body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ClearIPv6NeighborsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableOnResources body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string l3IsolationDomainName, string internalNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateBfdForBgpAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateBfdForBgpAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateBfdForStaticRouteAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateBfdForStaticRouteAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateBgpAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateBgpAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IPCommunityListCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource>, System.Collections.IEnumerable
    {
        protected IPCommunityListCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ipCommunityListName, Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ipCommunityListName, Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ipCommunityListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ipCommunityListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource> Get(string ipCommunityListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource>> GetAsync(string ipCommunityListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IPCommunityListData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public IPCommunityListData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType? Action { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AdvertiseBoolean? Advertise { get { throw null; } set { } }
        public string Annotation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityListPropertiesCommunityMembersItem> CommunityMembers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityListPropertiesEvpnEsImportRouteTargetsItem> EvpnEsImportRouteTargets { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ExportBoolean? Export { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.GshutBoolean? Gshut { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.InternetBoolean? Internet { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.LocalASBoolean? LocalAS { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class IPCommunityListResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IPCommunityListResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ipCommunityListName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource> Update(Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityListPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource>> UpdateAsync(Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityListPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IPPrefixListCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource>, System.Collections.IEnumerable
    {
        protected IPPrefixListCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ipPrefixListName, Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ipPrefixListName, Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ipPrefixListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ipPrefixListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource> Get(string ipPrefixListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource>> GetAsync(string ipPrefixListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IPPrefixListData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public IPPrefixListData(Azure.Core.AzureLocation location, Azure.ResourceManager.ManagedNetworkFabric.Models.PrefixActionType action, int sequenceNumber, string networkAddress) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.PrefixActionType Action { get { throw null; } set { } }
        public string Annotation { get { throw null; } set { } }
        public string NetworkAddress { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public int SequenceNumber { get { throw null; } set { } }
    }
    public partial class IPPrefixListResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IPPrefixListResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ipPrefixListName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource> Update(Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixListPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource>> UpdateAsync(Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixListPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class L2IsolationDomainCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource>, System.Collections.IEnumerable
    {
        protected L2IsolationDomainCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string l2IsolationDomainName, Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string l2IsolationDomainName, Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string l2IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string l2IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource> Get(string l2IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource>> GetAsync(string l2IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class L2IsolationDomainData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public L2IsolationDomainData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> DisabledOnResources { get { throw null; } }
        public int? Mtu { get { throw null; } set { } }
        public string NetworkFabricId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public int? VlanId { get { throw null; } set { } }
    }
    public partial class L2IsolationDomainResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected L2IsolationDomainResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ClearArpTable(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableOnResources body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ClearArpTableAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableOnResources body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ClearNeighborTable(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableOnResources body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ClearNeighborTableAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableOnResources body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string l2IsolationDomainName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ManagedNetworkFabric.Models.ARPProperties>> GetArpEntries(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ManagedNetworkFabric.Models.ARPProperties>>> GetArpEntriesAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.L2IsolationDomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.L2IsolationDomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class L3IsolationDomainCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource>, System.Collections.IEnumerable
    {
        protected L3IsolationDomainCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string l3IsolationDomainName, Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string l3IsolationDomainName, Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string l3IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string l3IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource> Get(string l3IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource>> GetAsync(string l3IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class L3IsolationDomainData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public L3IsolationDomainData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState? AdministrativeState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.L3IsolationDomainPatchPropertiesAggregateRouteConfiguration AggregateRouteConfiguration { get { throw null; } set { } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.L3IsolationDomainPatchPropertiesConnectedSubnetRoutePolicy ConnectedSubnetRoutePolicy { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> DisabledOnResources { get { throw null; } }
        public string NetworkFabricId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> OptionBDisabledOnResources { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet? RedistributeConnectedSubnets { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute? RedistributeStaticRoutes { get { throw null; } set { } }
    }
    public partial class L3IsolationDomainResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected L3IsolationDomainResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ClearArpTable(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableOnResources body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ClearArpTableAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableOnResources body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ClearNeighborTable(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableOnResources body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ClearNeighborTableAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableOnResources body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string l3IsolationDomainName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkResource> GetExternalNetwork(string externalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkResource>> GetExternalNetworkAsync(string externalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkCollection GetExternalNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkResource> GetInternalNetwork(string internalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkResource>> GetInternalNetworkAsync(string internalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkCollection GetInternalNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.L3IsolationDomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.L3IsolationDomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateOptionBAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateOptionBAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ManagedNetworkFabricExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource> GetAccessControlList(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accessControlListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource>> GetAccessControlListAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accessControlListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource GetAccessControlListResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.AccessControlListCollection GetAccessControlLists(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource> GetAccessControlLists(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource> GetAccessControlListsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkResource GetExternalNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkResource GetInternalNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource> GetIPCommunityList(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ipCommunityListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource>> GetIPCommunityListAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ipCommunityListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource GetIPCommunityListResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListCollection GetIPCommunityLists(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource> GetIPCommunityLists(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListResource> GetIPCommunityListsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource> GetIPPrefixList(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ipPrefixListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource>> GetIPPrefixListAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ipPrefixListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource GetIPPrefixListResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListCollection GetIPPrefixLists(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource> GetIPPrefixLists(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListResource> GetIPPrefixListsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource> GetL2IsolationDomain(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string l2IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource>> GetL2IsolationDomainAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string l2IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource GetL2IsolationDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainCollection GetL2IsolationDomains(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource> GetL2IsolationDomains(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource> GetL2IsolationDomainsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource> GetL3IsolationDomain(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string l3IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource>> GetL3IsolationDomainAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string l3IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource GetL3IsolationDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainCollection GetL3IsolationDomains(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource> GetL3IsolationDomains(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource> GetL3IsolationDomainsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> GetNetworkDevice(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>> GetNetworkDeviceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource GetNetworkDeviceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceCollection GetNetworkDevices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> GetNetworkDevices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> GetNetworkDevicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource> GetNetworkDeviceSku(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string networkDeviceSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource>> GetNetworkDeviceSkuAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string networkDeviceSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource GetNetworkDeviceSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuCollection GetNetworkDeviceSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> GetNetworkFabric(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>> GetNetworkFabricAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> GetNetworkFabricController(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkFabricControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>> GetNetworkFabricControllerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkFabricControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource GetNetworkFabricControllerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerCollection GetNetworkFabricControllers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> GetNetworkFabricControllers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> GetNetworkFabricControllersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource GetNetworkFabricResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricCollection GetNetworkFabrics(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> GetNetworkFabrics(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> GetNetworkFabricsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource> GetNetworkFabricSku(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string networkFabricSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource>> GetNetworkFabricSkuAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string networkFabricSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource GetNetworkFabricSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuCollection GetNetworkFabricSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceResource GetNetworkInterfaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> GetNetworkRack(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkRackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>> GetNetworkRackAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkRackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource GetNetworkRackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkRackCollection GetNetworkRacks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> GetNetworkRacks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> GetNetworkRacksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackSkuResource> GetNetworkRackSku(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string networkRackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackSkuResource>> GetNetworkRackSkuAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string networkRackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkRackSkuResource GetNetworkRackSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkRackSkuCollection GetNetworkRackSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource GetNetworkToNetworkInterconnectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyCollection GetRoutePolicies(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource> GetRoutePolicies(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource> GetRoutePoliciesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource> GetRoutePolicy(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string routePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource>> GetRoutePolicyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string routePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource GetRoutePolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class NetworkDeviceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>, System.Collections.IEnumerable
    {
        protected NetworkDeviceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkDeviceName, Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkDeviceName, Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> Get(string networkDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>> GetAsync(string networkDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkDeviceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkDeviceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Annotation { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleType? NetworkDeviceRole { get { throw null; } set { } }
        public string NetworkDeviceSku { get { throw null; } set { } }
        public string NetworkRackId { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SerialNumber { get { throw null; } set { } }
        public string Version { get { throw null; } }
    }
    public partial class NetworkDeviceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkDeviceResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkDeviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.SupportPackageProperties> GenerateSupportPackage(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.SupportPackageProperties>> GenerateSupportPackageAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceResource> GetNetworkInterface(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceResource>> GetNetworkInterfaceAsync(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceCollection GetNetworkInterfaces() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.GetDeviceStatusProperties> GetStatus(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.GetDeviceStatusProperties>> GetStatusAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Reboot(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RebootAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestoreConfig(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreConfigAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDevicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDevicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdatePowerCycle(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdatePowerCycleProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdatePowerCycleAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdatePowerCycleProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateVersion(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateVersionProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateVersionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateVersionProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkDeviceSkuCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource>, System.Collections.IEnumerable
    {
        protected NetworkDeviceSkuCollection() { }
        public virtual Azure.Response<bool> Exists(string networkDeviceSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkDeviceSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource> Get(string networkDeviceSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource>> GetAsync(string networkDeviceSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkDeviceSkuData : Azure.ResourceManager.Models.ResourceData
    {
        public NetworkDeviceSkuData(string model) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceSkuPropertiesInterfacesItem> Interfaces { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceSkuPropertiesLimits Limits { get { throw null; } set { } }
        public string Manufacturer { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName> SupportedRoleTypes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceSkuPropertiesSupportedVersionsItem> SupportedVersions { get { throw null; } }
    }
    public partial class NetworkDeviceSkuResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkDeviceSkuResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string networkDeviceSkuName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFabricCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>, System.Collections.IEnumerable
    {
        protected NetworkFabricCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkFabricName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkFabricName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> Get(string networkFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>> GetAsync(string networkFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkFabricControllerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>, System.Collections.IEnumerable
    {
        protected NetworkFabricControllerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkFabricControllerName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkFabricControllerName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkFabricControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkFabricControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> Get(string networkFabricControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>> GetAsync(string networkFabricControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkFabricControllerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkFabricControllerData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Annotation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation> InfrastructureExpressRouteConnections { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerPropertiesInfrastructureServices InfrastructureServices { get { throw null; } }
        public string IPv4AddressSpace { get { throw null; } set { } }
        public string IPv6AddressSpace { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerPropertiesManagedResourceGroupConfiguration ManagedResourceGroupConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> NetworkFabricIds { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerOperationalState? OperationalState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation> WorkloadExpressRouteConnections { get { throw null; } }
        public bool? WorkloadManagementNetwork { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerPropertiesWorkloadServices WorkloadServices { get { throw null; } }
    }
    public partial class NetworkFabricControllerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFabricControllerResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkFabricControllerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DisableWorkloadManagementNetwork(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DisableWorkloadManagementNetworkAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation EnableWorkloadManagementNetwork(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> EnableWorkloadManagementNetworkAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFabricData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkFabricData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Annotation { get { throw null; } set { } }
        public int? FabricASN { get { throw null; } set { } }
        public string IPv4Prefix { get { throw null; } set { } }
        public string IPv6Prefix { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> L2IsolationDomains { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> L3IsolationDomains { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPropertiesManagementNetworkConfiguration ManagementNetworkConfiguration { get { throw null; } set { } }
        public string NetworkFabricControllerId { get { throw null; } set { } }
        public string NetworkFabricSku { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOperationalState? OperationalState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public int? RackCount { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Racks { get { throw null; } }
        public string RouterId { get { throw null; } }
        public int? ServerCountPerRack { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPropertiesTerminalServerConfiguration TerminalServerConfiguration { get { throw null; } set { } }
    }
    public partial class NetworkFabricResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFabricResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkFabricName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Deprovision(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeprovisionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource> GetNetworkToNetworkInterconnect(string networkToNetworkInterconnectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource>> GetNetworkToNetworkInterconnectAsync(string networkToNetworkInterconnectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectCollection GetNetworkToNetworkInterconnects() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Provision(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ProvisionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFabricSkuCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource>, System.Collections.IEnumerable
    {
        protected NetworkFabricSkuCollection() { }
        public virtual Azure.Response<bool> Exists(string networkFabricSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkFabricSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource> Get(string networkFabricSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource>> GetAsync(string networkFabricSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkFabricSkuData : Azure.ResourceManager.Models.ResourceData
    {
        public NetworkFabricSkuData() { }
        public System.Uri DetailsUri { get { throw null; } }
        public int? MaxComputeRacks { get { throw null; } set { } }
        public string MaxSupportedVer { get { throw null; } }
        public string MinSupportedVer { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string TypePropertiesType { get { throw null; } }
    }
    public partial class NetworkFabricSkuResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFabricSkuResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string networkFabricSkuName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkInterfaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceResource>, System.Collections.IEnumerable
    {
        protected NetworkInterfaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkInterfaceName, Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkInterfaceName, Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceResource> Get(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceResource>> GetAsync(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkInterfaceData : Azure.ResourceManager.Models.ResourceData
    {
        public NetworkInterfaceData() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public string ConnectedTo { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.InterfaceType? InterfaceType { get { throw null; } }
        public string IPv4Address { get { throw null; } }
        public string IPv6Address { get { throw null; } }
        public string PhysicalIdentifier { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class NetworkInterfaceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkInterfaceResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkDeviceName, string networkInterfaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.InterfaceStatus> GetStatus(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.InterfaceStatus>> GetStatusAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkInterfacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkInterfacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkRackCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>, System.Collections.IEnumerable
    {
        protected NetworkRackCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkRackName, Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkRackName, Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkRackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkRackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> Get(string networkRackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>> GetAsync(string networkRackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkRackData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkRackData(Azure.Core.AzureLocation location, string networkRackSku, string networkFabricId) : base (default(Azure.Core.AzureLocation)) { }
        public string Annotation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> NetworkDevices { get { throw null; } }
        public string NetworkFabricId { get { throw null; } set { } }
        public string NetworkRackSku { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class NetworkRackResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkRackResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkRackName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkRackSkuCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackSkuResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackSkuResource>, System.Collections.IEnumerable
    {
        protected NetworkRackSkuCollection() { }
        public virtual Azure.Response<bool> Exists(string networkRackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkRackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackSkuResource> Get(string networkRackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackSkuResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackSkuResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackSkuResource>> GetAsync(string networkRackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackSkuResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackSkuResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackSkuResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackSkuResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkRackSkuData : Azure.ResourceManager.Models.ResourceData
    {
        public NetworkRackSkuData(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackRoleName roleName) { }
        public int? MaximumServerCount { get { throw null; } set { } }
        public int? MaximumStorageCount { get { throw null; } set { } }
        public int? MaximumUplinks { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackSkuPropertiesNetworkDevicesItem> NetworkDevices { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackRoleName RoleName { get { throw null; } set { } }
    }
    public partial class NetworkRackSkuResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkRackSkuResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkRackSkuData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string networkRackSkuName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackSkuResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackSkuResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkToNetworkInterconnectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource>, System.Collections.IEnumerable
    {
        protected NetworkToNetworkInterconnectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkToNetworkInterconnectName, Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkToNetworkInterconnectName, Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkToNetworkInterconnectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkToNetworkInterconnectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource> Get(string networkToNetworkInterconnectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource>> GetAsync(string networkToNetworkInterconnectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkToNetworkInterconnectData : Azure.ResourceManager.Models.ResourceData
    {
        public NetworkToNetworkInterconnectData() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState? AdministrativeState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty? IsManagementType { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectPropertiesLayer2Configuration Layer2Configuration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.Layer3Configuration Layer3Configuration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty? UseOptionB { get { throw null; } set { } }
    }
    public partial class NetworkToNetworkInterconnectResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkToNetworkInterconnectResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkFabricName, string networkToNetworkInterconnectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoutePolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource>, System.Collections.IEnumerable
    {
        protected RoutePolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string routePolicyName, Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string routePolicyName, Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string routePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string routePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource> Get(string routePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource>> GetAsync(string routePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoutePolicyData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public RoutePolicyData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Annotation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyPropertiesConditionsItem> Conditions { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class RoutePolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoutePolicyResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string routePolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class AccessControlListPatch
    {
        public AccessControlListPatch() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamily? AddressFamily { get { throw null; } set { } }
        public string Annotation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListPatchPropertiesConditionsItem> Conditions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class AccessControlListPatchPropertiesConditionsItem : Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResource
    {
        public AccessControlListPatchPropertiesConditionsItem(int sequenceNumber, Azure.ResourceManager.ManagedNetworkFabric.Models.ConditionActionType action, string destinationAddress, string destinationPort, string sourceAddress, string sourcePort, int protocol) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConditionActionType Action { get { throw null; } set { } }
        public string DestinationAddress { get { throw null; } set { } }
        public string DestinationPort { get { throw null; } set { } }
        public int Protocol { get { throw null; } set { } }
        public int SequenceNumber { get { throw null; } set { } }
        public string SourceAddress { get { throw null; } set { } }
        public string SourcePort { get { throw null; } set { } }
    }
    public partial class AccessControlListPropertiesConditionsItem : Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResource
    {
        public AccessControlListPropertiesConditionsItem(int sequenceNumber, Azure.ResourceManager.ManagedNetworkFabric.Models.ConditionActionType action, string destinationAddress, string destinationPort, string sourceAddress, string sourcePort, int protocol) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConditionActionType Action { get { throw null; } set { } }
        public string DestinationAddress { get { throw null; } set { } }
        public string DestinationPort { get { throw null; } set { } }
        public int Protocol { get { throw null; } set { } }
        public int SequenceNumber { get { throw null; } set { } }
        public string SourceAddress { get { throw null; } set { } }
        public string SourcePort { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AddressFamily : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AddressFamily(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamily IPv4 { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamily IPv6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamily left, Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamily (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamily left, Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdministrativeState : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdministrativeState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState Disable { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState Enable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState left, Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState left, Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdvertiseBoolean : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.AdvertiseBoolean>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdvertiseBoolean(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AdvertiseBoolean False { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AdvertiseBoolean True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.AdvertiseBoolean other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.AdvertiseBoolean left, Azure.ResourceManager.ManagedNetworkFabric.Models.AdvertiseBoolean right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.AdvertiseBoolean (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.AdvertiseBoolean left, Azure.ResourceManager.ManagedNetworkFabric.Models.AdvertiseBoolean right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AllowASOverride : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AllowASOverride(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride Disable { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride Enable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride left, Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride left, Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AnnotationResource
    {
        public AnnotationResource() { }
        public string Annotation { get { throw null; } set { } }
    }
    public static partial class ArmManagedNetworkFabricModelFactory
    {
        public static Azure.ResourceManager.ManagedNetworkFabric.AccessControlListData AccessControlListData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamily addressFamily = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamily), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListPropertiesConditionsItem> conditions = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ARPProperties ARPProperties(string address = null, string age = null, string macAddress = null, string @interface = null, string state = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration BfdConfiguration(Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState?), int? interval = default(int?), int? multiplier = default(int?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkData ExternalNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string annotation = null, string networkToNetworkInterconnectId = null, System.Collections.Generic.IEnumerable<string> disabledOnResources = null, Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState?), Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption peeringOption = default(Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption), Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBProperties optionBProperties = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkPropertiesOptionAProperties optionAProperties = null, string importRoutePolicyId = null, string exportRoutePolicyId = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkPropertiesOptionAProperties ExternalNetworkPropertiesOptionAProperties(string primaryIPv4Prefix = null, string primaryIPv6Prefix = null, string secondaryIPv4Prefix = null, string secondaryIPv6Prefix = null, int? mtu = default(int?), int? vlanId = default(int?), int? fabricASN = default(int?), int? peerASN = default(int?), Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration bfdConfiguration = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.GetDeviceStatusProperties GetDeviceStatusProperties(Azure.ResourceManager.ManagedNetworkFabric.Models.OperationalStatus operationalStatus = default(Azure.ResourceManager.ManagedNetworkFabric.Models.OperationalStatus), Azure.ResourceManager.ManagedNetworkFabric.Models.PowerCycleState powerCycleState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.PowerCycleState), string serialNumber = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.InterfaceStatus InterfaceStatus(Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState?), string operationalStatus = null, string phyStatus = null, string transceiverStatus = null, string connectedTo = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkData InternalNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string annotation = null, int? mtu = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatchablePropertiesConnectedIPv4SubnetsItem> connectedIPv4Subnets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatchablePropertiesConnectedIPv6SubnetsItem> connectedIPv6Subnets = null, Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatchablePropertiesStaticRouteConfiguration staticRouteConfiguration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatchablePropertiesBgpConfiguration bgpConfiguration = null, string importRoutePolicyId = null, string exportRoutePolicyId = null, System.Collections.Generic.IEnumerable<string> disabledOnResources = null, Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState?), System.Collections.Generic.IEnumerable<string> bgpDisabledOnResources = null, System.Collections.Generic.IEnumerable<string> bfdDisabledOnResources = null, System.Collections.Generic.IEnumerable<string> bfdForStaticRoutesDisabledOnResources = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?), int vlanId = 0) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatchablePropertiesBgpConfiguration InternalNetworkPatchablePropertiesBgpConfiguration(string annotation = null, Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration bfdConfiguration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty? defaultRouteOriginate = default(Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty?), int? allowAS = default(int?), Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride? allowASOverride = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride?), int? fabricASN = default(int?), int peerASN = 0, System.Collections.Generic.IEnumerable<string> ipv4ListenRangePrefixes = null, System.Collections.Generic.IEnumerable<string> ipv6ListenRangePrefixes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatchablePropertiesBgpConfigurationIPv4NeighborAddressItem> ipv4NeighborAddress = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatchablePropertiesBgpConfigurationIPv6NeighborAddressItem> ipv6NeighborAddress = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatchablePropertiesBgpConfigurationIPv4NeighborAddressItem InternalNetworkPatchablePropertiesBgpConfigurationIPv4NeighborAddressItem(string address = null, string operationalState = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatchablePropertiesBgpConfigurationIPv6NeighborAddressItem InternalNetworkPatchablePropertiesBgpConfigurationIPv6NeighborAddressItem(string address = null, string operationalState = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.IPCommunityListData IPCommunityListData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType? action = default(Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType?), Azure.ResourceManager.ManagedNetworkFabric.Models.LocalASBoolean? localAS = default(Azure.ResourceManager.ManagedNetworkFabric.Models.LocalASBoolean?), Azure.ResourceManager.ManagedNetworkFabric.Models.GshutBoolean? gshut = default(Azure.ResourceManager.ManagedNetworkFabric.Models.GshutBoolean?), Azure.ResourceManager.ManagedNetworkFabric.Models.InternetBoolean? internet = default(Azure.ResourceManager.ManagedNetworkFabric.Models.InternetBoolean?), Azure.ResourceManager.ManagedNetworkFabric.Models.AdvertiseBoolean? advertise = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AdvertiseBoolean?), Azure.ResourceManager.ManagedNetworkFabric.Models.ExportBoolean? export = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ExportBoolean?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityListPropertiesCommunityMembersItem> communityMembers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityListPropertiesEvpnEsImportRouteTargetsItem> evpnEsImportRouteTargets = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.IPPrefixListData IPPrefixListData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, Azure.ResourceManager.ManagedNetworkFabric.Models.PrefixActionType action = default(Azure.ResourceManager.ManagedNetworkFabric.Models.PrefixActionType), int sequenceNumber = 0, string networkAddress = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainData L2IsolationDomainData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, string networkFabricId = null, int? vlanId = default(int?), int? mtu = default(int?), System.Collections.Generic.IEnumerable<string> disabledOnResources = null, Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState?), Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainData L3IsolationDomainData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet? redistributeConnectedSubnets = default(Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet?), Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute? redistributeStaticRoutes = default(Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute?), Azure.ResourceManager.ManagedNetworkFabric.Models.L3IsolationDomainPatchPropertiesAggregateRouteConfiguration aggregateRouteConfiguration = null, string description = null, Azure.ResourceManager.ManagedNetworkFabric.Models.L3IsolationDomainPatchPropertiesConnectedSubnetRoutePolicy connectedSubnetRoutePolicy = null, string networkFabricId = null, System.Collections.Generic.IEnumerable<string> disabledOnResources = null, Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState?), System.Collections.Generic.IEnumerable<string> optionBDisabledOnResources = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.L3IsolationDomainPatchPropertiesConnectedSubnetRoutePolicy L3IsolationDomainPatchPropertiesConnectedSubnetRoutePolicy(string exportRoutePolicyId = null, Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.Layer2Configuration Layer2Configuration(int? portCount = default(int?), int mtu = 0, System.Collections.Generic.IEnumerable<string> interfaces = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.Layer3Configuration Layer3Configuration(string primaryIPv4Prefix = null, string primaryIPv6Prefix = null, string secondaryIPv4Prefix = null, string secondaryIPv6Prefix = null, string importRoutePolicyId = null, string exportRoutePolicyId = null, int? peerASN = default(int?), int? vlanId = default(int?), int? fabricASN = default(int?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData NetworkDeviceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, string hostName = null, string serialNumber = null, string version = null, string networkDeviceSku = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleType? networkDeviceRole = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleType?), Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?), string networkRackId = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuData NetworkDeviceSkuData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string model = null, string manufacturer = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceSkuPropertiesSupportedVersionsItem> supportedVersions = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceSkuPropertiesLimits limits = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName> supportedRoleTypes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceSkuPropertiesInterfacesItem> interfaces = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData NetworkFabricControllerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation> infrastructureExpressRouteConnections = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation> workloadExpressRouteConnections = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerPropertiesInfrastructureServices infrastructureServices = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerPropertiesWorkloadServices workloadServices = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerPropertiesManagedResourceGroupConfiguration managedResourceGroupConfiguration = null, System.Collections.Generic.IEnumerable<string> networkFabricIds = null, bool? workloadManagementNetwork = default(bool?), string ipv4AddressSpace = null, string ipv6AddressSpace = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerOperationalState? operationalState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerOperationalState?), Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerPropertiesInfrastructureServices NetworkFabricControllerPropertiesInfrastructureServices(System.Collections.Generic.IEnumerable<string> ipv4AddressSpaces = null, System.Collections.Generic.IEnumerable<string> ipv6AddressSpaces = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerPropertiesWorkloadServices NetworkFabricControllerPropertiesWorkloadServices(System.Collections.Generic.IEnumerable<string> ipv4AddressSpaces = null, System.Collections.Generic.IEnumerable<string> ipv6AddressSpaces = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData NetworkFabricData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, System.Collections.Generic.IEnumerable<string> racks = null, System.Collections.Generic.IEnumerable<string> l2IsolationDomains = null, System.Collections.Generic.IEnumerable<string> l3IsolationDomains = null, string networkFabricSku = null, int? rackCount = default(int?), int? serverCountPerRack = default(int?), string ipv4Prefix = null, string ipv6Prefix = null, string routerId = null, int? fabricASN = default(int?), string networkFabricControllerId = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPropertiesTerminalServerConfiguration terminalServerConfiguration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPropertiesManagementNetworkConfiguration managementNetworkConfiguration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOperationalState? operationalState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOperationalState?), Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPropertiesManagementNetworkConfigurationInfrastructureVpnConfiguration NetworkFabricPropertiesManagementNetworkConfigurationInfrastructureVpnConfiguration(Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState?), string networkToNetworkInterconnectId = null, Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption? peeringOption = default(Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOptionBProperties optionBProperties = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOptionAProperties optionAProperties = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPropertiesManagementNetworkConfigurationWorkloadVpnConfiguration NetworkFabricPropertiesManagementNetworkConfigurationWorkloadVpnConfiguration(Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState?), Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption? peeringOption = default(Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption?), string networkToNetworkInterconnectId = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOptionAProperties optionAProperties = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOptionBProperties optionBProperties = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPropertiesTerminalServerConfiguration NetworkFabricPropertiesTerminalServerConfiguration(string primaryIPv4Prefix = null, string primaryIPv6Prefix = null, string secondaryIPv4Prefix = null, string secondaryIPv6Prefix = null, string networkDeviceId = null, string username = null, string password = null, string serialNumber = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuData NetworkFabricSkuData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string typePropertiesType = null, int? maxComputeRacks = default(int?), string minSupportedVer = null, string maxSupportedVer = null, System.Uri detailsUri = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceData NetworkInterfaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string annotation = null, string physicalIdentifier = null, Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState?), Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?), string connectedTo = null, Azure.ResourceManager.ManagedNetworkFabric.Models.InterfaceType? interfaceType = default(Azure.ResourceManager.ManagedNetworkFabric.Models.InterfaceType?), string ipv4Address = null, string ipv6Address = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData NetworkRackData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, string networkRackSku = null, string networkFabricId = null, System.Collections.Generic.IEnumerable<string> networkDevices = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkRackSkuData NetworkRackSkuData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackRoleName roleName = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackRoleName), int? maximumServerCount = default(int?), int? maximumStorageCount = default(int?), int? maximumUplinks = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackSkuPropertiesNetworkDevicesItem> networkDevices = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData NetworkToNetworkInterconnectData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState?), Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty? isManagementType = default(Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty?), Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty? useOptionB = default(Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectPropertiesLayer2Configuration layer2Configuration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.Layer3Configuration layer3Configuration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectPropertiesLayer2Configuration NetworkToNetworkInterconnectPropertiesLayer2Configuration(int? portCount = default(int?), int mtu = 0, System.Collections.Generic.IEnumerable<string> interfaces = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.OptionAProperties OptionAProperties(string primaryIPv4Prefix = null, string primaryIPv6Prefix = null, string secondaryIPv4Prefix = null, string secondaryIPv6Prefix = null, int? mtu = default(int?), int? vlanId = default(int?), int? fabricASN = default(int?), int? peerASN = default(int?), Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration bfdConfiguration = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.OptionAPropertiesBfdConfiguration OptionAPropertiesBfdConfiguration(int? interval = default(int?), int? multiplier = default(int?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyData RoutePolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyPropertiesConditionsItem> conditions = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.SupportPackageProperties SupportPackageProperties(string supportPackageURL = null) { throw null; }
    }
    public partial class ARPProperties
    {
        internal ARPProperties() { }
        public string Address { get { throw null; } }
        public string Age { get { throw null; } }
        public string Interface { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public string State { get { throw null; } }
    }
    public partial class BfdConfiguration
    {
        public BfdConfiguration() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState? AdministrativeState { get { throw null; } }
        public int? Interval { get { throw null; } }
        public int? Multiplier { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BooleanEnumProperty : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BooleanEnumProperty(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty False { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty left, Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty left, Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommunityActionType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommunityActionType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType Allow { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType left, Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType left, Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConditionActionType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.ConditionActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConditionActionType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ConditionActionType Allow { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ConditionActionType Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.ConditionActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.ConditionActionType left, Azure.ResourceManager.ManagedNetworkFabric.Models.ConditionActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.ConditionActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.ConditionActionType left, Azure.ResourceManager.ManagedNetworkFabric.Models.ConditionActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnabledDisabledState : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnabledDisabledState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState Disabled { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState left, Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState left, Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnableDisableOnResources
    {
        public EnableDisableOnResources() { }
        public System.Collections.Generic.IList<string> ResourceIds { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExportBoolean : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.ExportBoolean>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExportBoolean(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ExportBoolean False { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ExportBoolean True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.ExportBoolean other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.ExportBoolean left, Azure.ResourceManager.ManagedNetworkFabric.Models.ExportBoolean right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.ExportBoolean (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.ExportBoolean left, Azure.ResourceManager.ManagedNetworkFabric.Models.ExportBoolean right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExpressRouteConnectionInformation
    {
        public ExpressRouteConnectionInformation(string expressRouteCircuitId, string expressRouteAuthorizationKey) { }
        public string ExpressRouteAuthorizationKey { get { throw null; } set { } }
        public string ExpressRouteCircuitId { get { throw null; } set { } }
    }
    public partial class ExternalNetworkPatch
    {
        public ExternalNetworkPatch() { }
        public string Annotation { get { throw null; } set { } }
        public string ExportRoutePolicyId { get { throw null; } set { } }
        public string ImportRoutePolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.OptionAProperties OptionAProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBProperties OptionBProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption? PeeringOption { get { throw null; } set { } }
    }
    public partial class ExternalNetworkPropertiesOptionAProperties : Azure.ResourceManager.ManagedNetworkFabric.Models.OptionAProperties
    {
        public ExternalNetworkPropertiesOptionAProperties() { }
    }
    public partial class GetDeviceStatusProperties
    {
        internal GetDeviceStatusProperties() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.OperationalStatus OperationalStatus { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.PowerCycleState PowerCycleState { get { throw null; } }
        public string SerialNumber { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GshutBoolean : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.GshutBoolean>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GshutBoolean(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.GshutBoolean False { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.GshutBoolean True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.GshutBoolean other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.GshutBoolean left, Azure.ResourceManager.ManagedNetworkFabric.Models.GshutBoolean right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.GshutBoolean (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.GshutBoolean left, Azure.ResourceManager.ManagedNetworkFabric.Models.GshutBoolean right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InterfaceStatus
    {
        internal InterfaceStatus() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState? AdministrativeState { get { throw null; } }
        public string ConnectedTo { get { throw null; } }
        public string OperationalStatus { get { throw null; } }
        public string PhyStatus { get { throw null; } }
        public string TransceiverStatus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InterfaceType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.InterfaceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InterfaceType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.InterfaceType Data { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.InterfaceType Management { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.InterfaceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.InterfaceType left, Azure.ResourceManager.ManagedNetworkFabric.Models.InterfaceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.InterfaceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.InterfaceType left, Azure.ResourceManager.ManagedNetworkFabric.Models.InterfaceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InternalNetworkPatch
    {
        public InternalNetworkPatch() { }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatchablePropertiesBgpConfiguration BgpConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatchablePropertiesConnectedIPv4SubnetsItem> ConnectedIPv4Subnets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatchablePropertiesConnectedIPv6SubnetsItem> ConnectedIPv6Subnets { get { throw null; } }
        public string ExportRoutePolicyId { get { throw null; } set { } }
        public string ImportRoutePolicyId { get { throw null; } set { } }
        public int? Mtu { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatchablePropertiesStaticRouteConfiguration StaticRouteConfiguration { get { throw null; } set { } }
    }
    public partial class InternalNetworkPatchablePropertiesBgpConfiguration : Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResource
    {
        public InternalNetworkPatchablePropertiesBgpConfiguration(int peerASN) { }
        public int? AllowAS { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride? AllowASOverride { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration BfdConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty? DefaultRouteOriginate { get { throw null; } set { } }
        public int? FabricASN { get { throw null; } }
        public System.Collections.Generic.IList<string> IPv4ListenRangePrefixes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatchablePropertiesBgpConfigurationIPv4NeighborAddressItem> IPv4NeighborAddress { get { throw null; } }
        public System.Collections.Generic.IList<string> IPv6ListenRangePrefixes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatchablePropertiesBgpConfigurationIPv6NeighborAddressItem> IPv6NeighborAddress { get { throw null; } }
        public int PeerASN { get { throw null; } set { } }
    }
    public partial class InternalNetworkPatchablePropertiesBgpConfigurationIPv4NeighborAddressItem
    {
        public InternalNetworkPatchablePropertiesBgpConfigurationIPv4NeighborAddressItem() { }
        public string Address { get { throw null; } set { } }
        public string OperationalState { get { throw null; } }
    }
    public partial class InternalNetworkPatchablePropertiesBgpConfigurationIPv6NeighborAddressItem
    {
        public InternalNetworkPatchablePropertiesBgpConfigurationIPv6NeighborAddressItem() { }
        public string Address { get { throw null; } set { } }
        public string OperationalState { get { throw null; } }
    }
    public partial class InternalNetworkPatchablePropertiesConnectedIPv4SubnetsItem : Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResource
    {
        public InternalNetworkPatchablePropertiesConnectedIPv4SubnetsItem() { }
        public string Prefix { get { throw null; } set { } }
    }
    public partial class InternalNetworkPatchablePropertiesConnectedIPv6SubnetsItem : Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResource
    {
        public InternalNetworkPatchablePropertiesConnectedIPv6SubnetsItem() { }
        public string Prefix { get { throw null; } set { } }
    }
    public partial class InternalNetworkPatchablePropertiesStaticRouteConfiguration
    {
        public InternalNetworkPatchablePropertiesStaticRouteConfiguration() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration BfdConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatchablePropertiesStaticRouteConfigurationIPv4RoutesItem> IPv4Routes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatchablePropertiesStaticRouteConfigurationIPv6RoutesItem> IPv6Routes { get { throw null; } }
    }
    public partial class InternalNetworkPatchablePropertiesStaticRouteConfigurationIPv4RoutesItem
    {
        public InternalNetworkPatchablePropertiesStaticRouteConfigurationIPv4RoutesItem(string prefix, System.Collections.Generic.IEnumerable<string> nextHop) { }
        public System.Collections.Generic.IList<string> NextHop { get { throw null; } }
        public string Prefix { get { throw null; } set { } }
    }
    public partial class InternalNetworkPatchablePropertiesStaticRouteConfigurationIPv6RoutesItem
    {
        public InternalNetworkPatchablePropertiesStaticRouteConfigurationIPv6RoutesItem(string prefix, System.Collections.Generic.IEnumerable<string> nextHop) { }
        public System.Collections.Generic.IList<string> NextHop { get { throw null; } }
        public string Prefix { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InternetBoolean : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.InternetBoolean>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InternetBoolean(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.InternetBoolean False { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.InternetBoolean True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.InternetBoolean other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.InternetBoolean left, Azure.ResourceManager.ManagedNetworkFabric.Models.InternetBoolean right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.InternetBoolean (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.InternetBoolean left, Azure.ResourceManager.ManagedNetworkFabric.Models.InternetBoolean right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPCommunityListPatch
    {
        public IPCommunityListPatch() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType? Action { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AdvertiseBoolean? Advertise { get { throw null; } set { } }
        public string Annotation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityListPatchPropertiesCommunityMembersItem> CommunityMembers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityListPatchPropertiesEvpnEsImportRouteTargetsItem> EvpnEsImportRouteTargets { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ExportBoolean? Export { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.LocalASBoolean? LocalAS { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class IPCommunityListPatchPropertiesCommunityMembersItem : Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResource
    {
        public IPCommunityListPatchPropertiesCommunityMembersItem(string communityMember) { }
        public string CommunityMember { get { throw null; } set { } }
    }
    public partial class IPCommunityListPatchPropertiesEvpnEsImportRouteTargetsItem : Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResource
    {
        public IPCommunityListPatchPropertiesEvpnEsImportRouteTargetsItem(string evpnEsImportRouteTarget) { }
        public string EvpnEsImportRouteTarget { get { throw null; } set { } }
    }
    public partial class IPCommunityListPropertiesCommunityMembersItem : Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResource
    {
        public IPCommunityListPropertiesCommunityMembersItem(string communityMember) { }
        public string CommunityMember { get { throw null; } set { } }
    }
    public partial class IPCommunityListPropertiesEvpnEsImportRouteTargetsItem : Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResource
    {
        public IPCommunityListPropertiesEvpnEsImportRouteTargetsItem(string evpnEsImportRouteTarget) { }
        public string EvpnEsImportRouteTarget { get { throw null; } set { } }
    }
    public partial class IPPrefixListPatch
    {
        public IPPrefixListPatch() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.PrefixActionType? Action { get { throw null; } set { } }
        public string Annotation { get { throw null; } set { } }
        public string NetworkAddress { get { throw null; } set { } }
        public int? SequenceNumber { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsCurrentVersion : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.IsCurrentVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsCurrentVersion(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IsCurrentVersion False { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IsCurrentVersion True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.IsCurrentVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.IsCurrentVersion left, Azure.ResourceManager.ManagedNetworkFabric.Models.IsCurrentVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.IsCurrentVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.IsCurrentVersion left, Azure.ResourceManager.ManagedNetworkFabric.Models.IsCurrentVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsTestVersion : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.IsTestVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsTestVersion(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IsTestVersion False { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IsTestVersion True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.IsTestVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.IsTestVersion left, Azure.ResourceManager.ManagedNetworkFabric.Models.IsTestVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.IsTestVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.IsTestVersion left, Azure.ResourceManager.ManagedNetworkFabric.Models.IsTestVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class L2IsolationDomainPatch
    {
        public L2IsolationDomainPatch() { }
        public string Annotation { get { throw null; } set { } }
        public int? Mtu { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class L3IsolationDomainPatch
    {
        public L3IsolationDomainPatch() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.L3IsolationDomainPatchPropertiesAggregateRouteConfiguration AggregateRouteConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.L3IsolationDomainPatchPropertiesConnectedSubnetRoutePolicy ConnectedSubnetRoutePolicy { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet? RedistributeConnectedSubnets { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute? RedistributeStaticRoutes { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class L3IsolationDomainPatchPropertiesAggregateRouteConfiguration
    {
        public L3IsolationDomainPatchPropertiesAggregateRouteConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.L3IsolationDomainPatchPropertiesAggregateRouteConfigurationIPv4RoutesItem> IPv4Routes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.L3IsolationDomainPatchPropertiesAggregateRouteConfigurationIPv6RoutesItem> IPv6Routes { get { throw null; } }
    }
    public partial class L3IsolationDomainPatchPropertiesAggregateRouteConfigurationIPv4RoutesItem
    {
        public L3IsolationDomainPatchPropertiesAggregateRouteConfigurationIPv4RoutesItem() { }
        public string Prefix { get { throw null; } set { } }
    }
    public partial class L3IsolationDomainPatchPropertiesAggregateRouteConfigurationIPv6RoutesItem
    {
        public L3IsolationDomainPatchPropertiesAggregateRouteConfigurationIPv6RoutesItem() { }
        public string Prefix { get { throw null; } set { } }
    }
    public partial class L3IsolationDomainPatchPropertiesConnectedSubnetRoutePolicy
    {
        public L3IsolationDomainPatchPropertiesConnectedSubnetRoutePolicy() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState? AdministrativeState { get { throw null; } }
        public string ExportRoutePolicyId { get { throw null; } set { } }
    }
    public partial class Layer2Configuration
    {
        public Layer2Configuration(int mtu) { }
        public System.Collections.Generic.IReadOnlyList<string> Interfaces { get { throw null; } }
        public int Mtu { get { throw null; } set { } }
        public int? PortCount { get { throw null; } set { } }
    }
    public partial class Layer3Configuration : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricLayer3IPPrefixProperties
    {
        public Layer3Configuration() { }
        public string ExportRoutePolicyId { get { throw null; } set { } }
        public int? FabricASN { get { throw null; } }
        public string ImportRoutePolicyId { get { throw null; } set { } }
        public int? PeerASN { get { throw null; } set { } }
        public int? VlanId { get { throw null; } set { } }
    }
    public partial class Layer3IPPrefixProperties
    {
        public Layer3IPPrefixProperties() { }
        public string PrimaryIPv4Prefix { get { throw null; } set { } }
        public string PrimaryIPv6Prefix { get { throw null; } set { } }
        public string SecondaryIPv4Prefix { get { throw null; } set { } }
        public string SecondaryIPv6Prefix { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LocalASBoolean : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.LocalASBoolean>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LocalASBoolean(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.LocalASBoolean False { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.LocalASBoolean True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.LocalASBoolean other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.LocalASBoolean left, Azure.ResourceManager.ManagedNetworkFabric.Models.LocalASBoolean right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.LocalASBoolean (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.LocalASBoolean left, Azure.ResourceManager.ManagedNetworkFabric.Models.LocalASBoolean right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkDevicePatch
    {
        public NetworkDevicePatch() { }
        public string Annotation { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
        public string SerialNumber { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkDeviceRackRoleType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRackRoleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkDeviceRackRoleType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRackRoleType CE { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRackRoleType Management { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRackRoleType NPB { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRackRoleType ToR { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRackRoleType TS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRackRoleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRackRoleType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRackRoleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRackRoleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRackRoleType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRackRoleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkDeviceRoleName : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkDeviceRoleName(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName CE { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName Management { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName NPB { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName ToR { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName TS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkDeviceRoleType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkDeviceRoleType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleType CE { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleType Management { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleType NPB { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleType ToR { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleType TS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkDeviceSkuPropertiesInterfacesItem
    {
        public NetworkDeviceSkuPropertiesInterfacesItem() { }
        public string Identifier { get { throw null; } set { } }
        public string InterfaceType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceSkuPropertiesInterfacesPropertiesItemsItem> SupportedConnectorTypes { get { throw null; } }
    }
    public partial class NetworkDeviceSkuPropertiesInterfacesPropertiesItemsItem
    {
        public NetworkDeviceSkuPropertiesInterfacesPropertiesItemsItem() { }
        public string ConnectorType { get { throw null; } set { } }
        public int? MaxSpeedInMbps { get { throw null; } set { } }
    }
    public partial class NetworkDeviceSkuPropertiesLimits
    {
        public NetworkDeviceSkuPropertiesLimits() { }
        public int? MaxBidirectionalForwardingDetectionPeers { get { throw null; } set { } }
        public int? MaxBorderGatewayProtocolPeers { get { throw null; } set { } }
        public int? MaxSubInterfaces { get { throw null; } set { } }
        public int? MaxTunnelInterfaces { get { throw null; } set { } }
        public int? MaxVirtualRouterFunctions { get { throw null; } set { } }
        public int? PhysicalInterfaceCount { get { throw null; } set { } }
    }
    public partial class NetworkDeviceSkuPropertiesSupportedVersionsItem
    {
        public NetworkDeviceSkuPropertiesSupportedVersionsItem() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.IsCurrentVersion? IsCurrent { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.IsTestVersion? IsTest { get { throw null; } set { } }
        public string VendorFirmwareVersion { get { throw null; } set { } }
        public string VendorOSVersion { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkFabricControllerOperationalState : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerOperationalState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkFabricControllerOperationalState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerOperationalState Configuring { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerOperationalState Failed { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerOperationalState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerOperationalState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerOperationalState left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerOperationalState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerOperationalState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerOperationalState left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerOperationalState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkFabricControllerPatch
    {
        public NetworkFabricControllerPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation> InfrastructureExpressRouteConnections { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation> WorkloadExpressRouteConnections { get { throw null; } }
    }
    public partial class NetworkFabricControllerPropertiesInfrastructureServices
    {
        internal NetworkFabricControllerPropertiesInfrastructureServices() { }
        public System.Collections.Generic.IReadOnlyList<string> IPv4AddressSpaces { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPv6AddressSpaces { get { throw null; } }
    }
    public partial class NetworkFabricControllerPropertiesManagedResourceGroupConfiguration
    {
        public NetworkFabricControllerPropertiesManagedResourceGroupConfiguration() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class NetworkFabricControllerPropertiesWorkloadServices
    {
        internal NetworkFabricControllerPropertiesWorkloadServices() { }
        public System.Collections.Generic.IReadOnlyList<string> IPv4AddressSpaces { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPv6AddressSpaces { get { throw null; } }
    }
    public partial class NetworkFabricLayer3IPPrefixProperties
    {
        public NetworkFabricLayer3IPPrefixProperties() { }
        public string PrimaryIPv4Prefix { get { throw null; } set { } }
        public string PrimaryIPv6Prefix { get { throw null; } set { } }
        public string SecondaryIPv4Prefix { get { throw null; } set { } }
        public string SecondaryIPv6Prefix { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkFabricOperationalState : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOperationalState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkFabricOperationalState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOperationalState DeferredControl { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOperationalState Deprovisioned { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOperationalState Deprovisioning { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOperationalState ErrorDeprovisioning { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOperationalState ErrorProvisioning { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOperationalState Provisioned { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOperationalState Provisioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOperationalState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOperationalState left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOperationalState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOperationalState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOperationalState left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOperationalState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkFabricOptionAProperties : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricLayer3IPPrefixProperties
    {
        public NetworkFabricOptionAProperties() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.OptionAPropertiesBfdConfiguration BfdConfiguration { get { throw null; } set { } }
        public int? Mtu { get { throw null; } set { } }
        public int? PeerASN { get { throw null; } set { } }
        public int? VlanId { get { throw null; } set { } }
    }
    public partial class NetworkFabricOptionBProperties
    {
        public NetworkFabricOptionBProperties(System.Collections.Generic.IEnumerable<string> importRouteTargets, System.Collections.Generic.IEnumerable<string> exportRouteTargets) { }
        public System.Collections.Generic.IList<string> ExportRouteTargets { get { throw null; } }
        public System.Collections.Generic.IList<string> ImportRouteTargets { get { throw null; } }
    }
    public partial class NetworkFabricPatch
    {
        public NetworkFabricPatch() { }
        public string Annotation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> L2IsolationDomains { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> L3IsolationDomains { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Racks { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerPatchParametersTerminalServerConfiguration TerminalServerConfiguration { get { throw null; } set { } }
    }
    public partial class NetworkFabricPropertiesManagementNetworkConfiguration
    {
        public NetworkFabricPropertiesManagementNetworkConfiguration(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPropertiesManagementNetworkConfigurationInfrastructureVpnConfiguration infrastructureVpnConfiguration, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPropertiesManagementNetworkConfigurationWorkloadVpnConfiguration workloadVpnConfiguration) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPropertiesManagementNetworkConfigurationInfrastructureVpnConfiguration InfrastructureVpnConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPropertiesManagementNetworkConfigurationWorkloadVpnConfiguration WorkloadVpnConfiguration { get { throw null; } set { } }
    }
    public partial class NetworkFabricPropertiesManagementNetworkConfigurationInfrastructureVpnConfiguration
    {
        public NetworkFabricPropertiesManagementNetworkConfigurationInfrastructureVpnConfiguration(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOptionBProperties optionBProperties) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState? AdministrativeState { get { throw null; } }
        public string NetworkToNetworkInterconnectId { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOptionAProperties OptionAProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOptionBProperties OptionBProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption? PeeringOption { get { throw null; } set { } }
    }
    public partial class NetworkFabricPropertiesManagementNetworkConfigurationWorkloadVpnConfiguration
    {
        public NetworkFabricPropertiesManagementNetworkConfigurationWorkloadVpnConfiguration(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOptionBProperties optionBProperties) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.EnabledDisabledState? AdministrativeState { get { throw null; } }
        public string NetworkToNetworkInterconnectId { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOptionAProperties OptionAProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricOptionBProperties OptionBProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption? PeeringOption { get { throw null; } set { } }
    }
    public partial class NetworkFabricPropertiesTerminalServerConfiguration : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricLayer3IPPrefixProperties
    {
        public NetworkFabricPropertiesTerminalServerConfiguration() { }
        public string NetworkDeviceId { get { throw null; } }
        public string Password { get { throw null; } set { } }
        public string SerialNumber { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class NetworkInterfacePatch
    {
        public NetworkInterfacePatch() { }
        public string Annotation { get { throw null; } set { } }
    }
    public partial class NetworkRackPatch
    {
        public NetworkRackPatch() { }
        public System.BinaryData Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkRackRoleName : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackRoleName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkRackRoleName(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackRoleName AggregateRack { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackRoleName ComputeRack { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackRoleName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackRoleName left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackRoleName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackRoleName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackRoleName left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackRoleName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkRackSkuPropertiesNetworkDevicesItem
    {
        public NetworkRackSkuPropertiesNetworkDevicesItem() { }
        public string NetworkDeviceSkuName { get { throw null; } set { } }
        public int? RackSlot { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRackRoleType? RoleType { get { throw null; } set { } }
    }
    public partial class NetworkToNetworkInterconnectPropertiesLayer2Configuration : Azure.ResourceManager.ManagedNetworkFabric.Models.Layer2Configuration
    {
        public NetworkToNetworkInterconnectPropertiesLayer2Configuration(int mtu) : base (default(int)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalStatus : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.OperationalStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalStatus(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.OperationalStatus Booted { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.OperationalStatus BootPrompt { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.OperationalStatus Ztp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.OperationalStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.OperationalStatus left, Azure.ResourceManager.ManagedNetworkFabric.Models.OperationalStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.OperationalStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.OperationalStatus left, Azure.ResourceManager.ManagedNetworkFabric.Models.OperationalStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OptionAProperties : Azure.ResourceManager.ManagedNetworkFabric.Models.Layer3IPPrefixProperties
    {
        public OptionAProperties() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration BfdConfiguration { get { throw null; } set { } }
        public int? FabricASN { get { throw null; } }
        public int? Mtu { get { throw null; } set { } }
        public int? PeerASN { get { throw null; } set { } }
        public int? VlanId { get { throw null; } set { } }
    }
    public partial class OptionAPropertiesBfdConfiguration
    {
        public OptionAPropertiesBfdConfiguration() { }
        public int? Interval { get { throw null; } }
        public int? Multiplier { get { throw null; } }
    }
    public partial class OptionBProperties
    {
        public OptionBProperties() { }
        public System.Collections.Generic.IList<string> ExportRouteTargets { get { throw null; } }
        public System.Collections.Generic.IList<string> ImportRouteTargets { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PeeringOption : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PeeringOption(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption OptionA { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption OptionB { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption left, Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption left, Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PowerCycleState : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.PowerCycleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PowerCycleState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.PowerCycleState Off { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.PowerCycleState On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.PowerCycleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.PowerCycleState left, Azure.ResourceManager.ManagedNetworkFabric.Models.PowerCycleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.PowerCycleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.PowerCycleState left, Azure.ResourceManager.ManagedNetworkFabric.Models.PowerCycleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PowerEnd : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.PowerEnd>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PowerEnd(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.PowerEnd Primary { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.PowerEnd Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.PowerEnd other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.PowerEnd left, Azure.ResourceManager.ManagedNetworkFabric.Models.PowerEnd right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.PowerEnd (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.PowerEnd left, Azure.ResourceManager.ManagedNetworkFabric.Models.PowerEnd right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrefixActionType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.PrefixActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrefixActionType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.PrefixActionType Allow { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.PrefixActionType Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.PrefixActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.PrefixActionType left, Azure.ResourceManager.ManagedNetworkFabric.Models.PrefixActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.PrefixActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.PrefixActionType left, Azure.ResourceManager.ManagedNetworkFabric.Models.PrefixActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState left, Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState left, Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedistributeConnectedSubnet : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedistributeConnectedSubnet(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet False { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet left, Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet left, Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedistributeStaticRoute : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedistributeStaticRoute(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute False { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute left, Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute left, Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoutePolicyConditionsItemAction
    {
        public RoutePolicyConditionsItemAction() { }
        public string Action { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyPropertiesConditionsProperties Sets { get { throw null; } set { } }
    }
    public partial class RoutePolicyPatch
    {
        public RoutePolicyPatch() { }
        public System.BinaryData Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class RoutePolicyPropertiesConditionsItem : Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResource
    {
        public RoutePolicyPropertiesConditionsItem() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyConditionsItemAction Action { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyPropertiesConditionsItemMatch Match { get { throw null; } set { } }
        public int? SequenceNumber { get { throw null; } set { } }
    }
    public partial class RoutePolicyPropertiesConditionsItemMatch
    {
        public RoutePolicyPropertiesConditionsItemMatch() { }
        public System.Collections.Generic.IList<string> AccessControlListIds { get { throw null; } }
        public System.Collections.Generic.IList<string> IPCommunityListIds { get { throw null; } }
        public System.Collections.Generic.IList<string> IPExtendedCommunityListIds { get { throw null; } }
        public System.Collections.Generic.IList<string> IPPrefixListIds { get { throw null; } }
    }
    public partial class RoutePolicyPropertiesConditionsProperties
    {
        public RoutePolicyPropertiesConditionsProperties() { }
        public System.Collections.Generic.IList<string> IPCommunityListIds { get { throw null; } }
        public System.Collections.Generic.IList<string> IPExtendedCommunityListIds { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct State : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.State>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public State(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.State Off { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.State On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.State other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.State left, Azure.ResourceManager.ManagedNetworkFabric.Models.State right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.State (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.State left, Azure.ResourceManager.ManagedNetworkFabric.Models.State right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SupportPackageProperties
    {
        internal SupportPackageProperties() { }
        public string SupportPackageURL { get { throw null; } }
    }
    public partial class TerminalServerPatchableProperties
    {
        public TerminalServerPatchableProperties() { }
        public string Password { get { throw null; } set { } }
        public string SerialNumber { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class TerminalServerPatchParametersTerminalServerConfiguration : Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerPatchableProperties
    {
        public TerminalServerPatchParametersTerminalServerConfiguration() { }
    }
    public partial class UpdateAdministrativeState : Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableOnResources
    {
        public UpdateAdministrativeState() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? State { get { throw null; } set { } }
    }
    public partial class UpdatePowerCycleProperties
    {
        public UpdatePowerCycleProperties(Azure.ResourceManager.ManagedNetworkFabric.Models.PowerEnd powerEnd, Azure.ResourceManager.ManagedNetworkFabric.Models.State state) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.PowerEnd PowerEnd { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.State State { get { throw null; } }
    }
    public partial class UpdateVersionProperties
    {
        public UpdateVersionProperties(string skuVersion) { }
        public string SkuVersion { get { throw null; } }
    }
}
