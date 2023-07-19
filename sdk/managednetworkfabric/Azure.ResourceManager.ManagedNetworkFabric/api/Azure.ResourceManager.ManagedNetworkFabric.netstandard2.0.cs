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
        public AccessControlListData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Uri AclsUri { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? ConfigurationState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationType? ConfigurationType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonDynamicMatchConfiguration> DynamicMatchConfigurations { get { throw null; } }
        public System.DateTimeOffset? LastSyncedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchConfiguration> MatchConfigurations { get { throw null; } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> Resync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> ResyncAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.AccessControlListResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResponse> ValidateConfiguration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResponse>> ValidateConfigurationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? ConfigurationState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicy ExportRoutePolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExportRoutePolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicy ImportRoutePolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ImportRoutePolicyId { get { throw null; } set { } }
        public string NetworkToNetworkInterconnectId { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkPropertiesOptionAProperties OptionAProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.L3OptionBProperties OptionBProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption PeeringOption { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ExternalNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExternalNetworkResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string l3IsolationDomainName, string externalNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> UpdateStaticRouteBfdAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> UpdateStaticRouteBfdAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPropertiesBgpConfiguration BgpConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? ConfigurationState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnet> ConnectedIPv4Subnets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnet> ConnectedIPv6Subnets { get { throw null; } }
        public Azure.Core.ResourceIdentifier EgressAclId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicy ExportRoutePolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExportRoutePolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.Extension? Extension { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicy ImportRoutePolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ImportRoutePolicyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier IngressAclId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled? IsMonitoringEnabled { get { throw null; } set { } }
        public int? Mtu { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPropertiesStaticRouteConfiguration StaticRouteConfiguration { get { throw null; } set { } }
        public int VlanId { get { throw null; } set { } }
    }
    public partial class InternalNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InternalNetworkResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string l3IsolationDomainName, string internalNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> UpdateBgpAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> UpdateBgpAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> UpdateStaticRouteBfdAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> UpdateStaticRouteBfdAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InternetGatewayCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource>, System.Collections.IEnumerable
    {
        protected InternetGatewayCollection() { }
        public virtual Azure.Response<bool> Exists(string internetGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string internetGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource> Get(string internetGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource>> GetAsync(string internetGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class InternetGatewayData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public InternetGatewayData(Azure.Core.AzureLocation location, Azure.ResourceManager.ManagedNetworkFabric.Models.GatewayType typePropertiesType, Azure.Core.ResourceIdentifier networkFabricControllerId) : base (default(Azure.Core.AzureLocation)) { }
        public string Annotation { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier InternetGatewayRuleId { get { throw null; } set { } }
        public string IPv4Address { get { throw null; } }
        public Azure.Core.ResourceIdentifier NetworkFabricControllerId { get { throw null; } set { } }
        public int? Port { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.GatewayType TypePropertiesType { get { throw null; } set { } }
    }
    public partial class InternetGatewayResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InternetGatewayResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string internetGatewayName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InternetGatewayRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource>, System.Collections.IEnumerable
    {
        protected InternetGatewayRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string internetGatewayRuleName, Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string internetGatewayRuleName, Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string internetGatewayRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string internetGatewayRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource> Get(string internetGatewayRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource>> GetAsync(string internetGatewayRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class InternetGatewayRuleData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public InternetGatewayRuleData(Azure.Core.AzureLocation location, Azure.ResourceManager.ManagedNetworkFabric.Models.RuleProperties ruleProperties) : base (default(Azure.Core.AzureLocation)) { }
        public string Annotation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> InternetGatewayIds { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.RuleProperties RuleProperties { get { throw null; } set { } }
    }
    public partial class InternetGatewayRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InternetGatewayRuleResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string internetGatewayRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IPCommunityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource>, System.Collections.IEnumerable
    {
        protected IPCommunityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ipCommunityName, Azure.ResourceManager.ManagedNetworkFabric.IPCommunityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ipCommunityName, Azure.ResourceManager.ManagedNetworkFabric.IPCommunityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ipCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ipCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource> Get(string ipCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource>> GetAsync(string ipCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IPCommunityData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public IPCommunityData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? ConfigurationState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityRule> IPCommunityRules { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class IPCommunityResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IPCommunityResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.IPCommunityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ipCommunityName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IPExtendedCommunityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource>, System.Collections.IEnumerable
    {
        protected IPExtendedCommunityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ipExtendedCommunityName, Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ipExtendedCommunityName, Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ipExtendedCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ipExtendedCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource> Get(string ipExtendedCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource>> GetAsync(string ipExtendedCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IPExtendedCommunityData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public IPExtendedCommunityData(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityRule> ipExtendedCommunityRules) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? ConfigurationState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityRule> IPExtendedCommunityRules { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class IPExtendedCommunityResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IPExtendedCommunityResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ipExtendedCommunityName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IPPrefixCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource>, System.Collections.IEnumerable
    {
        protected IPPrefixCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ipPrefixName, Azure.ResourceManager.ManagedNetworkFabric.IPPrefixData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ipPrefixName, Azure.ResourceManager.ManagedNetworkFabric.IPPrefixData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ipPrefixName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ipPrefixName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource> Get(string ipPrefixName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource>> GetAsync(string ipPrefixName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IPPrefixData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public IPPrefixData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? ConfigurationState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRule> IPPrefixRules { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class IPPrefixResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IPPrefixResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.IPPrefixData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ipPrefixName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public L2IsolationDomainData(Azure.Core.AzureLocation location, Azure.Core.ResourceIdentifier networkFabricId, int vlanId) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? ConfigurationState { get { throw null; } }
        public int? Mtu { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkFabricId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public int VlanId { get { throw null; } set { } }
    }
    public partial class L2IsolationDomainResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected L2IsolationDomainResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> CommitConfiguration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> CommitConfigurationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string l2IsolationDomainName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.L2IsolationDomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForDeviceUpdate> UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForDeviceUpdate>> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.L2IsolationDomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResponse> ValidateConfiguration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResponse>> ValidateConfigurationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public L3IsolationDomainData(Azure.Core.AzureLocation location, Azure.Core.ResourceIdentifier networkFabricId) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? AdministrativeState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRouteConfiguration AggregateRouteConfiguration { get { throw null; } set { } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? ConfigurationState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnetRoutePolicy ConnectedSubnetRoutePolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkFabricId { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> CommitConfiguration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> CommitConfigurationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForDeviceUpdate> UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForDeviceUpdate>> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.L3IsolationDomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResponse> ValidateConfiguration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResponse>> ValidateConfigurationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource> GetInternetGateway(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string internetGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource>> GetInternetGatewayAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string internetGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource GetInternetGatewayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource> GetInternetGatewayRule(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string internetGatewayRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource>> GetInternetGatewayRuleAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string internetGatewayRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource GetInternetGatewayRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleCollection GetInternetGatewayRules(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource> GetInternetGatewayRules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleResource> GetInternetGatewayRulesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayCollection GetInternetGateways(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource> GetInternetGateways(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayResource> GetInternetGatewaysAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.IPCommunityCollection GetIPCommunities(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource> GetIPCommunities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource> GetIPCommunitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource> GetIPCommunity(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ipCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource>> GetIPCommunityAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ipCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.IPCommunityResource GetIPCommunityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityCollection GetIPExtendedCommunities(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource> GetIPExtendedCommunities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource> GetIPExtendedCommunitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource> GetIPExtendedCommunity(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ipExtendedCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource>> GetIPExtendedCommunityAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ipExtendedCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityResource GetIPExtendedCommunityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource> GetIPPrefix(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ipPrefixName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource>> GetIPPrefixAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ipPrefixName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.IPPrefixCollection GetIPPrefixes(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource> GetIPPrefixes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource> GetIPPrefixesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.IPPrefixResource GetIPPrefixResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource> GetNeighborGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string neighborGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource>> GetNeighborGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string neighborGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource GetNeighborGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupCollection GetNeighborGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource> GetNeighborGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource> GetNeighborGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> GetNetworkPacketBroker(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkPacketBrokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>> GetNetworkPacketBrokerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkPacketBrokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource GetNetworkPacketBrokerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerCollection GetNetworkPacketBrokers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> GetNetworkPacketBrokers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> GetNetworkPacketBrokersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> GetNetworkRack(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkRackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>> GetNetworkRackAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkRackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource GetNetworkRackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkRackCollection GetNetworkRacks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> GetNetworkRacks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> GetNetworkRacksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> GetNetworkTap(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkTapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>> GetNetworkTapAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkTapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource GetNetworkTapResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> GetNetworkTapRule(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkTapRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>> GetNetworkTapRuleAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkTapRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource GetNetworkTapRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleCollection GetNetworkTapRules(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> GetNetworkTapRules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> GetNetworkTapRulesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkTapCollection GetNetworkTaps(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> GetNetworkTaps(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> GetNetworkTapsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource GetNetworkToNetworkInterconnectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyCollection GetRoutePolicies(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource> GetRoutePolicies(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource> GetRoutePoliciesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource> GetRoutePolicy(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string routePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource>> GetRoutePolicyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string routePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource GetRoutePolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class NeighborGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource>, System.Collections.IEnumerable
    {
        protected NeighborGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string neighborGroupName, Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string neighborGroupName, Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string neighborGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string neighborGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource> Get(string neighborGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource>> GetAsync(string neighborGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NeighborGroupData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NeighborGroupData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborGroupDestination Destination { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> NetworkTapIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> NetworkTapRuleIds { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class NeighborGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NeighborGroupResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string neighborGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? ConfigurationState { get { throw null; } }
        public string HostName { get { throw null; } set { } }
        public string ManagementIPv4Address { get { throw null; } }
        public string ManagementIPv6Address { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole? NetworkDeviceRole { get { throw null; } }
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
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceResource> GetNetworkInterface(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceResource>> GetNetworkInterfaceAsync(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceCollection GetNetworkInterfaces() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> Reboot(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.RebootProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> RebootAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.RebootProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> RefreshConfiguration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> RefreshConfigurationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDevicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateDeviceAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateDeviceAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDevicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> Upgrade(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateVersion body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> UpgradeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateVersion body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceInterfaceProperties> Interfaces { get { throw null; } }
        public string Manufacturer { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName> SupportedRoleTypes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.SupportedVersionProperties> SupportedVersions { get { throw null; } }
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
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ControllerServices InfrastructureServices { get { throw null; } }
        public string IPv4AddressSpace { get { throw null; } set { } }
        public string IPv6AddressSpace { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled? IsWorkloadManagementNetworkEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ManagedResourceGroupConfiguration ManagedResourceGroupConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> NetworkFabricIds { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NfcSku? NfcSku { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> TenantInternetGatewayIds { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation> WorkloadExpressRouteConnections { get { throw null; } }
        public bool? WorkloadManagementNetwork { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ControllerServices WorkloadServices { get { throw null; } }
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
        public NetworkFabricData(Azure.Core.AzureLocation location, string networkFabricSku, Azure.Core.ResourceIdentifier networkFabricControllerId, int serverCountPerRack, string ipv4Prefix, long fabricASN, Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerConfiguration terminalServerConfiguration, Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationProperties managementNetworkConfiguration) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? ConfigurationState { get { throw null; } }
        public long FabricASN { get { throw null; } set { } }
        public string FabricVersion { get { throw null; } }
        public string IPv4Prefix { get { throw null; } set { } }
        public string IPv6Prefix { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> L2IsolationDomains { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> L3IsolationDomains { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationProperties ManagementNetworkConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkFabricControllerId { get { throw null; } set { } }
        public string NetworkFabricSku { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public int? RackCount { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Racks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RouterIds { get { throw null; } }
        public int ServerCountPerRack { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerConfiguration TerminalServerConfiguration { get { throw null; } set { } }
    }
    public partial class NetworkFabricResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFabricResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> CommitConfiguration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> CommitConfigurationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkFabricName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForDeviceUpdate> Deprovision(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForDeviceUpdate>> DeprovisionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource> GetNetworkToNetworkInterconnect(string networkToNetworkInterconnectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource>> GetNetworkToNetworkInterconnectAsync(string networkToNetworkInterconnectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectCollection GetNetworkToNetworkInterconnects() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResponse> GetTopology(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResponse>> GetTopologyAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForDeviceUpdate> Provision(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForDeviceUpdate>> ProvisionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> RefreshConfiguration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> RefreshConfigurationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> UpdateInfraManagementBfdConfiguration(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> UpdateInfraManagementBfdConfigurationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> UpdateWorkloadManagementBfdConfiguration(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> UpdateWorkloadManagementBfdConfigurationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> Upgrade(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateVersion body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> UpgradeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateVersion body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResponse> ValidateConfiguration(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResponse>> ValidateConfigurationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public string Details { get { throw null; } }
        public int? MaxComputeRacks { get { throw null; } set { } }
        public int? MaximumServerCount { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedVersions { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.FabricSkuType? TypePropertiesType { get { throw null; } }
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
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? AdministrativeState { get { throw null; } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkInterfacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkInterfacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkPacketBrokerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>, System.Collections.IEnumerable
    {
        protected NetworkPacketBrokerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkPacketBrokerName, Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkPacketBrokerName, Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkPacketBrokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkPacketBrokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> Get(string networkPacketBrokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>> GetAsync(string networkPacketBrokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkPacketBrokerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkPacketBrokerData(Azure.Core.AzureLocation location, Azure.Core.ResourceIdentifier networkFabricId) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> NeighborGroupIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> NetworkDeviceIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier NetworkFabricId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> NetworkTapIds { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> SourceInterfaceIds { get { throw null; } }
    }
    public partial class NetworkPacketBrokerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkPacketBrokerResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkPacketBrokerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkPacketBrokerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkPacketBrokerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public NetworkRackData(Azure.Core.AzureLocation location, Azure.Core.ResourceIdentifier networkFabricId) : base (default(Azure.Core.AzureLocation)) { }
        public string Annotation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> NetworkDevices { get { throw null; } }
        public Azure.Core.ResourceIdentifier NetworkFabricId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType? NetworkRackType { get { throw null; } set { } }
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
    public partial class NetworkTapCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>, System.Collections.IEnumerable
    {
        protected NetworkTapCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkTapName, Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkTapName, Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkTapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkTapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> Get(string networkTapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>> GetAsync(string networkTapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkTapData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkTapData(Azure.Core.AzureLocation location, Azure.Core.ResourceIdentifier networkPacketBrokerId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPropertiesDestinationsItem> destinations) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? ConfigurationState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPropertiesDestinationsItem> Destinations { get { throw null; } }
        public Azure.Core.ResourceIdentifier NetworkPacketBrokerId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.PollingType? PollingType { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceTapRuleId { get { throw null; } }
    }
    public partial class NetworkTapResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkTapResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkTapName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> Resync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> ResyncAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForDeviceUpdate> UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForDeviceUpdate>> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkTapRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>, System.Collections.IEnumerable
    {
        protected NetworkTapRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkTapRuleName, Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkTapRuleName, Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkTapRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkTapRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> Get(string networkTapRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>> GetAsync(string networkTapRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkTapRuleData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkTapRuleData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? ConfigurationState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationType? ConfigurationType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonDynamicMatchConfiguration> DynamicMatchConfigurations { get { throw null; } }
        public System.DateTimeOffset? LastSyncedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchConfiguration> MatchConfigurations { get { throw null; } }
        public string NetworkTapId { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond? PollingIntervalInSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Uri TapRulesUri { get { throw null; } set { } }
    }
    public partial class NetworkTapRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkTapRuleResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkTapRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> Resync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> ResyncAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResponse> ValidateConfiguration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResponse>> ValidateConfigurationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public NetworkToNetworkInterconnectData(Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty useOptionB) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? AdministrativeState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? ConfigurationState { get { throw null; } }
        public Azure.Core.ResourceIdentifier EgressAclId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicyInformation ExportRoutePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicyInformation ImportRoutePolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier IngressAclId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.IsManagementType? IsManagementType { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.Layer2Configuration Layer2Configuration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NniType? NniType { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NpbStaticRouteConfiguration NpbStaticRouteConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectPropertiesOptionBLayer3Configuration OptionBLayer3Configuration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty UseOptionB { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> UpdateNpbStaticRouteBfdAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> UpdateNpbStaticRouteBfdAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public RoutePolicyData(Azure.Core.AzureLocation location, Azure.Core.ResourceIdentifier networkFabricId) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType? AddressFamilyType { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? ConfigurationState { get { throw null; } }
        public Azure.Core.ResourceIdentifier NetworkFabricId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyStatementProperties> Statements { get { throw null; } }
    }
    public partial class RoutePolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoutePolicyResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate> CommitConfiguration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate>> CommitConfigurationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForDeviceUpdate> UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForDeviceUpdate>> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeState body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResponse> ValidateConfiguration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResponse>> ValidateConfigurationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class AccessControlListAction
    {
        public AccessControlListAction() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AclActionType? AclActionType { get { throw null; } set { } }
        public string CounterName { get { throw null; } set { } }
    }
    public partial class AccessControlListMatchCondition : Azure.ResourceManager.ManagedNetworkFabric.Models.CommonMatchConditions
    {
        public AccessControlListMatchCondition() { }
        public System.Collections.Generic.IList<string> DscpMarkings { get { throw null; } }
        public System.Collections.Generic.IList<string> EtherTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> Fragments { get { throw null; } }
        public System.Collections.Generic.IList<string> IPLengths { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListPortCondition PortCondition { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TtlValues { get { throw null; } }
    }
    public partial class AccessControlListMatchConfiguration
    {
        public AccessControlListMatchConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListAction> Actions { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.IPAddressType? IPAddressType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchCondition> MatchConditions { get { throw null; } }
        public string MatchConfigurationName { get { throw null; } set { } }
        public long? SequenceNumber { get { throw null; } set { } }
    }
    public partial class AccessControlListPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch
    {
        public AccessControlListPatch() { }
        public System.Uri AclsUri { get { throw null; } set { } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationType? ConfigurationType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonDynamicMatchConfiguration> DynamicMatchConfigurations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchConfiguration> MatchConfigurations { get { throw null; } }
    }
    public partial class AccessControlListPortCondition : Azure.ResourceManager.ManagedNetworkFabric.Models.PortCondition
    {
        public AccessControlListPortCondition(Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol layer4Protocol) : base (default(Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol)) { }
        public System.Collections.Generic.IList<string> Flags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AclActionType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.AclActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AclActionType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AclActionType Count { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AclActionType Drop { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AclActionType Log { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.AclActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.AclActionType left, Azure.ResourceManager.ManagedNetworkFabric.Models.AclActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.AclActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.AclActionType left, Azure.ResourceManager.ManagedNetworkFabric.Models.AclActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ActionIPCommunityProperties : Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityAddOperationProperties
    {
        public ActionIPCommunityProperties() { }
        public System.Collections.Generic.IList<string> DeleteIPCommunityIds { get { throw null; } }
        public System.Collections.Generic.IList<string> SetIPCommunityIds { get { throw null; } }
    }
    public partial class ActionIPExtendedCommunityProperties : Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityAddOperationProperties
    {
        public ActionIPExtendedCommunityProperties() { }
        public System.Collections.Generic.IList<string> DeleteIPExtendedCommunityIds { get { throw null; } }
        public System.Collections.Generic.IList<string> SetIPExtendedCommunityIds { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AddressFamilyType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AddressFamilyType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType IPv4 { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType IPv6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType left, Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType left, Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdministrativeState : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdministrativeState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState Disabled { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState Enabled { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState MAT { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState RMA { get { throw null; } }
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
    public partial class AggregateRoute
    {
        public AggregateRoute(string prefix) { }
        public string Prefix { get { throw null; } set { } }
    }
    public partial class AggregateRouteConfiguration
    {
        public AggregateRouteConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRoute> IPv4Routes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRoute> IPv6Routes { get { throw null; } }
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
        public static Azure.ResourceManager.ManagedNetworkFabric.AccessControlListData AccessControlListData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationType? configurationType = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationType?), System.Uri aclsUri = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchConfiguration> matchConfigurations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonDynamicMatchConfiguration> dynamicMatchConfigurations = null, System.DateTimeOffset? lastSyncedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration BfdConfiguration(Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState?), int? intervalInMilliSeconds = default(int?), int? multiplier = default(int?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.BgpConfiguration BgpConfiguration(string annotation = null, Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration bfdConfiguration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty? defaultRouteOriginate = default(Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty?), int? allowAS = default(int?), Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride? allowASOverride = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride?), long? fabricASN = default(long?), long? peerASN = default(long?), System.Collections.Generic.IEnumerable<string> ipv4ListenRangePrefixes = null, System.Collections.Generic.IEnumerable<string> ipv6ListenRangePrefixes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborAddress> ipv4NeighborAddress = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborAddress> ipv6NeighborAddress = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForDeviceUpdate CommonPostActionResponseForDeviceUpdate(Azure.ResponseError error = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState?), System.Collections.Generic.IEnumerable<string> successfulDevices = null, System.Collections.Generic.IEnumerable<string> failedDevices = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.CommonPostActionResponseForStateUpdate CommonPostActionResponseForStateUpdate(Azure.ResponseError error = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ControllerServices ControllerServices(System.Collections.Generic.IEnumerable<string> ipv4AddressSpaces = null, System.Collections.Generic.IEnumerable<string> ipv6AddressSpaces = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ErrorResponse ErrorResponse(Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.ExternalNetworkData ExternalNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string annotation = null, Azure.Core.ResourceIdentifier importRoutePolicyId = null, Azure.Core.ResourceIdentifier exportRoutePolicyId = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicy importRoutePolicy = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicy exportRoutePolicy = null, string networkToNetworkInterconnectId = null, Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption peeringOption = default(Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption), Azure.ResourceManager.ManagedNetworkFabric.Models.L3OptionBProperties optionBProperties = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkPropertiesOptionAProperties optionAProperties = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkPatchPropertiesOptionAProperties ExternalNetworkPatchPropertiesOptionAProperties(string primaryIPv4Prefix = null, string primaryIPv6Prefix = null, string secondaryIPv4Prefix = null, string secondaryIPv6Prefix = null, int? mtu = default(int?), int? vlanId = default(int?), long? fabricASN = default(long?), long? peerASN = default(long?), Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration bfdConfiguration = null, Azure.Core.ResourceIdentifier ingressAclId = null, Azure.Core.ResourceIdentifier egressAclId = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkPropertiesOptionAProperties ExternalNetworkPropertiesOptionAProperties(string primaryIPv4Prefix = null, string primaryIPv6Prefix = null, string secondaryIPv4Prefix = null, string secondaryIPv6Prefix = null, int? mtu = default(int?), int? vlanId = default(int?), long? fabricASN = default(long?), long? peerASN = default(long?), Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration bfdConfiguration = null, Azure.Core.ResourceIdentifier ingressAclId = null, Azure.Core.ResourceIdentifier egressAclId = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.InternalNetworkData InternalNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string annotation = null, int? mtu = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnet> connectedIPv4Subnets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnet> connectedIPv6Subnets = null, Azure.Core.ResourceIdentifier importRoutePolicyId = null, Azure.Core.ResourceIdentifier exportRoutePolicyId = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicy importRoutePolicy = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicy exportRoutePolicy = null, Azure.Core.ResourceIdentifier ingressAclId = null, Azure.Core.ResourceIdentifier egressAclId = null, Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled? isMonitoringEnabled = default(Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled?), Azure.ResourceManager.ManagedNetworkFabric.Models.Extension? extension = default(Azure.ResourceManager.ManagedNetworkFabric.Models.Extension?), int vlanId = 0, Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPropertiesBgpConfiguration bgpConfiguration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPropertiesStaticRouteConfiguration staticRouteConfiguration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkPropertiesBgpConfiguration InternalNetworkPropertiesBgpConfiguration(string annotation = null, Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration bfdConfiguration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty? defaultRouteOriginate = default(Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty?), int? allowAS = default(int?), Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride? allowASOverride = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride?), long? fabricASN = default(long?), long? peerASN = default(long?), System.Collections.Generic.IEnumerable<string> ipv4ListenRangePrefixes = null, System.Collections.Generic.IEnumerable<string> ipv6ListenRangePrefixes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborAddress> ipv4NeighborAddress = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborAddress> ipv6NeighborAddress = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayData InternetGatewayData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, Azure.Core.ResourceIdentifier internetGatewayRuleId = null, string ipv4Address = null, int? port = default(int?), Azure.ResourceManager.ManagedNetworkFabric.Models.GatewayType typePropertiesType = default(Azure.ResourceManager.ManagedNetworkFabric.Models.GatewayType), Azure.Core.ResourceIdentifier networkFabricControllerId = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.InternetGatewayRuleData InternetGatewayRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, Azure.ResourceManager.ManagedNetworkFabric.Models.RuleProperties ruleProperties = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?), System.Collections.Generic.IEnumerable<string> internetGatewayIds = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.IPCommunityData IPCommunityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityRule> ipCommunityRules = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.IPExtendedCommunityData IPExtendedCommunityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityRule> ipExtendedCommunityRules = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.IPPrefixData IPPrefixData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRule> ipPrefixRules = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.L2IsolationDomainData L2IsolationDomainData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, Azure.Core.ResourceIdentifier networkFabricId = null, int vlanId = 0, int? mtu = default(int?), Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.L3IsolationDomainData L3IsolationDomainData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet? redistributeConnectedSubnets = default(Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet?), Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute? redistributeStaticRoutes = default(Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute?), Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRouteConfiguration aggregateRouteConfiguration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnetRoutePolicy connectedSubnetRoutePolicy = null, Azure.Core.ResourceIdentifier networkFabricId = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborAddress NeighborAddress(string address = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NeighborGroupData NeighborGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborGroupDestination destination = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> networkTapIds = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> networkTapRuleIds = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData NetworkDeviceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, string hostName = null, string serialNumber = null, string version = null, string networkDeviceSku = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole? networkDeviceRole = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole?), string networkRackId = null, string managementIPv4Address = null, string managementIPv6Address = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuData NetworkDeviceSkuData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string model = null, string manufacturer = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.SupportedVersionProperties> supportedVersions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName> supportedRoleTypes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceInterfaceProperties> interfaces = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData NetworkFabricControllerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation> infrastructureExpressRouteConnections = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation> workloadExpressRouteConnections = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ControllerServices infrastructureServices = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ControllerServices workloadServices = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ManagedResourceGroupConfiguration managedResourceGroupConfiguration = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> networkFabricIds = null, bool? workloadManagementNetwork = default(bool?), Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled? isWorkloadManagementNetworkEnabled = default(Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> tenantInternetGatewayIds = null, string ipv4AddressSpace = null, string ipv6AddressSpace = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NfcSku? nfcSku = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NfcSku?), Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData NetworkFabricData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, string networkFabricSku = null, string fabricVersion = null, System.Collections.Generic.IEnumerable<string> routerIds = null, Azure.Core.ResourceIdentifier networkFabricControllerId = null, int? rackCount = default(int?), int serverCountPerRack = 0, string ipv4Prefix = null, string ipv6Prefix = null, long fabricASN = (long)0, Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerConfiguration terminalServerConfiguration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationProperties managementNetworkConfiguration = null, System.Collections.Generic.IEnumerable<string> racks = null, System.Collections.Generic.IEnumerable<string> l2IsolationDomains = null, System.Collections.Generic.IEnumerable<string> l3IsolationDomains = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuData NetworkFabricSkuData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ManagedNetworkFabric.Models.FabricSkuType? typePropertiesType = default(Azure.ResourceManager.ManagedNetworkFabric.Models.FabricSkuType?), int? maxComputeRacks = default(int?), int? maximumServerCount = default(int?), System.Collections.Generic.IEnumerable<string> supportedVersions = null, string details = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkInterfaceData NetworkInterfaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string annotation = null, string physicalIdentifier = null, string connectedTo = null, Azure.ResourceManager.ManagedNetworkFabric.Models.InterfaceType? interfaceType = default(Azure.ResourceManager.ManagedNetworkFabric.Models.InterfaceType?), string ipv4Address = null, string ipv6Address = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData NetworkPacketBrokerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.Core.ResourceIdentifier networkFabricId = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> networkDeviceIds = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> sourceInterfaceIds = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> networkTapIds = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> neighborGroupIds = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData NetworkRackData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType? networkRackType = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType?), Azure.Core.ResourceIdentifier networkFabricId = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> networkDevices = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData NetworkTapData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, Azure.Core.ResourceIdentifier networkPacketBrokerId = null, Azure.Core.ResourceIdentifier sourceTapRuleId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPropertiesDestinationsItem> destinations = null, Azure.ResourceManager.ManagedNetworkFabric.Models.PollingType? pollingType = default(Azure.ResourceManager.ManagedNetworkFabric.Models.PollingType?), Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData NetworkTapRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationType? configurationType = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationType?), System.Uri tapRulesUri = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchConfiguration> matchConfigurations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonDynamicMatchConfiguration> dynamicMatchConfigurations = null, string networkTapId = null, Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond? pollingIntervalInSeconds = default(Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond?), System.DateTimeOffset? lastSyncedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData NetworkToNetworkInterconnectData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NniType? nniType = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NniType?), Azure.ResourceManager.ManagedNetworkFabric.Models.IsManagementType? isManagementType = default(Azure.ResourceManager.ManagedNetworkFabric.Models.IsManagementType?), Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty useOptionB = default(Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty), Azure.ResourceManager.ManagedNetworkFabric.Models.Layer2Configuration layer2Configuration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectPropertiesOptionBLayer3Configuration optionBLayer3Configuration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NpbStaticRouteConfiguration npbStaticRouteConfiguration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicyInformation importRoutePolicy = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicyInformation exportRoutePolicy = null, Azure.Core.ResourceIdentifier egressAclId = null, Azure.Core.ResourceIdentifier ingressAclId = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectPatch NetworkToNetworkInterconnectPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ManagedNetworkFabric.Models.Layer2Configuration layer2Configuration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBLayer3Configuration optionBLayer3Configuration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NpbStaticRouteConfiguration npbStaticRouteConfiguration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicyInformation importRoutePolicy = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicyInformation exportRoutePolicy = null, Azure.Core.ResourceIdentifier egressAclId = null, Azure.Core.ResourceIdentifier ingressAclId = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectPropertiesOptionBLayer3Configuration NetworkToNetworkInterconnectPropertiesOptionBLayer3Configuration(string primaryIPv4Prefix = null, string primaryIPv6Prefix = null, string secondaryIPv4Prefix = null, string secondaryIPv6Prefix = null, long? peerASN = default(long?), int? vlanId = default(int?), long? fabricASN = default(long?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBLayer3Configuration OptionBLayer3Configuration(string primaryIPv4Prefix = null, string primaryIPv6Prefix = null, string secondaryIPv4Prefix = null, string secondaryIPv6Prefix = null, long? peerASN = default(long?), int? vlanId = default(int?), long? fabricASN = default(long?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.RoutePolicyData RoutePolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyStatementProperties> statements = null, Azure.Core.ResourceIdentifier networkFabricId = null, Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType? addressFamilyType = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType?), Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerConfiguration TerminalServerConfiguration(string username = null, string password = null, string serialNumber = null, string networkDeviceId = null, string primaryIPv4Prefix = null, string primaryIPv6Prefix = null, string secondaryIPv4Prefix = null, string secondaryIPv6Prefix = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResponse ValidateConfigurationResponse(Azure.ResponseError error = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState?), System.Uri uri = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationProperties VpnConfigurationProperties(Azure.Core.ResourceIdentifier networkToNetworkInterconnectId = null, Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState?), Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption peeringOption = default(Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption), Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBProperties optionBProperties = null, Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPropertiesOptionAProperties optionAProperties = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BfdAdministrativeState : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BfdAdministrativeState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState Disabled { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState Enabled { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState MAT { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState RMA { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState left, Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState left, Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BfdConfiguration
    {
        public BfdConfiguration() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState? AdministrativeState { get { throw null; } }
        public int? IntervalInMilliSeconds { get { throw null; } set { } }
        public int? Multiplier { get { throw null; } set { } }
    }
    public partial class BgpConfiguration : Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResource
    {
        public BgpConfiguration() { }
        public int? AllowAS { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride? AllowASOverride { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration BfdConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty? DefaultRouteOriginate { get { throw null; } set { } }
        public long? FabricASN { get { throw null; } }
        public System.Collections.Generic.IList<string> IPv4ListenRangePrefixes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborAddress> IPv4NeighborAddress { get { throw null; } }
        public System.Collections.Generic.IList<string> IPv6ListenRangePrefixes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborAddress> IPv6NeighborAddress { get { throw null; } }
        public long? PeerASN { get { throw null; } set { } }
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
    public partial class CommonDynamicMatchConfiguration
    {
        public CommonDynamicMatchConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.IPGroupProperties> IPGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.PortGroupProperties> PortGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.VlanGroupProperties> VlanGroups { get { throw null; } }
    }
    public partial class CommonMatchConditions
    {
        public CommonMatchConditions() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.IPMatchCondition IPCondition { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProtocolTypes { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.VlanMatchCondition VlanMatchCondition { get { throw null; } set { } }
    }
    public partial class CommonPostActionResponseForDeviceUpdate : Azure.ResourceManager.ManagedNetworkFabric.Models.ErrorResponse
    {
        internal CommonPostActionResponseForDeviceUpdate() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? ConfigurationState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FailedDevices { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SuccessfulDevices { get { throw null; } }
    }
    public partial class CommonPostActionResponseForStateUpdate : Azure.ResourceManager.ManagedNetworkFabric.Models.ErrorResponse
    {
        internal CommonPostActionResponseForStateUpdate() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? ConfigurationState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommunityActionType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommunityActionType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType Deny { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType Permit { get { throw null; } }
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
    public readonly partial struct Condition : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.Condition>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Condition(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.Condition EqualTo { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.Condition GreaterThanOrEqualTo { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.Condition LesserThanOrEqualTo { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.Condition Range { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.Condition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.Condition left, Azure.ResourceManager.ManagedNetworkFabric.Models.Condition right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.Condition (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.Condition left, Azure.ResourceManager.ManagedNetworkFabric.Models.Condition right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfigurationState : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfigurationState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState DeferredControl { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState Deprovisioned { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState Deprovisioning { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState ErrorDeprovisioning { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState ErrorProvisioning { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState Failed { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState Provisioned { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState Rejected { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState left, Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState left, Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfigurationType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfigurationType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationType File { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationType Inline { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationType left, Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationType left, Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectedSubnet : Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResource
    {
        public ConnectedSubnet(string prefix) { }
        public string Prefix { get { throw null; } set { } }
    }
    public partial class ConnectedSubnetRoutePolicy
    {
        public ConnectedSubnetRoutePolicy() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.L3ExportRoutePolicy ExportRoutePolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExportRoutePolicyId { get { throw null; } set { } }
    }
    public partial class ControllerServices
    {
        internal ControllerServices() { }
        public System.Collections.Generic.IReadOnlyList<string> IPv4AddressSpaces { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPv6AddressSpaces { get { throw null; } }
    }
    public partial class DestinationProperties
    {
        public DestinationProperties() { }
        public Azure.Core.ResourceIdentifier DestinationId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DestinationTapRuleId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.DestinationType? DestinationType { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.IsolationDomainProperties IsolationDomainProperties { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DestinationType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.DestinationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DestinationType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.DestinationType Direct { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.DestinationType IsolationDomain { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.DestinationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.DestinationType left, Azure.ResourceManager.ManagedNetworkFabric.Models.DestinationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.DestinationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.DestinationType left, Azure.ResourceManager.ManagedNetworkFabric.Models.DestinationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceAdministrativeState : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceAdministrativeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceAdministrativeState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceAdministrativeState GracefulQuarantine { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceAdministrativeState Quarantine { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceAdministrativeState Resync { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceAdministrativeState RMA { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceAdministrativeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceAdministrativeState left, Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceAdministrativeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceAdministrativeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceAdministrativeState left, Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceAdministrativeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceInterfaceProperties
    {
        public DeviceInterfaceProperties() { }
        public string Identifier { get { throw null; } set { } }
        public string InterfaceType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.SupportedConnectorProperties> SupportedConnectorTypes { get { throw null; } }
    }
    public partial class EnableDisableOnResources
    {
        public EnableDisableOnResources() { }
        public System.Collections.Generic.IList<string> ResourceIds { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnableDisableState : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnableDisableState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableState Disable { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableState Enable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableState left, Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableState left, Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Encapsulation : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.Encapsulation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Encapsulation(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.Encapsulation GRE { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.Encapsulation None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.Encapsulation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.Encapsulation left, Azure.ResourceManager.ManagedNetworkFabric.Models.Encapsulation right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.Encapsulation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.Encapsulation left, Azure.ResourceManager.ManagedNetworkFabric.Models.Encapsulation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncapsulationType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.EncapsulationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncapsulationType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.EncapsulationType GTPv1 { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.EncapsulationType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.EncapsulationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.EncapsulationType left, Azure.ResourceManager.ManagedNetworkFabric.Models.EncapsulationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.EncapsulationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.EncapsulationType left, Azure.ResourceManager.ManagedNetworkFabric.Models.EncapsulationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ErrorResponse
    {
        internal ErrorResponse() { }
        public Azure.ResponseError Error { get { throw null; } }
    }
    public partial class ExportRoutePolicy
    {
        public ExportRoutePolicy() { }
        public Azure.Core.ResourceIdentifier ExportIPv4RoutePolicyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExportIPv6RoutePolicyId { get { throw null; } set { } }
    }
    public partial class ExportRoutePolicyInformation
    {
        public ExportRoutePolicyInformation() { }
        public Azure.Core.ResourceIdentifier ExportIPv4RoutePolicyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExportIPv6RoutePolicyId { get { throw null; } set { } }
    }
    public partial class ExpressRouteConnectionInformation
    {
        public ExpressRouteConnectionInformation(Azure.Core.ResourceIdentifier expressRouteCircuitId) { }
        public string ExpressRouteAuthorizationKey { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExpressRouteCircuitId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Extension : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.Extension>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Extension(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.Extension NoExtension { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.Extension NPB { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.Extension other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.Extension left, Azure.ResourceManager.ManagedNetworkFabric.Models.Extension right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.Extension (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.Extension left, Azure.ResourceManager.ManagedNetworkFabric.Models.Extension right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExternalNetworkPatch
    {
        public ExternalNetworkPatch() { }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicy ExportRoutePolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExportRoutePolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicy ImportRoutePolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ImportRoutePolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkPatchPropertiesOptionAProperties OptionAProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.L3OptionBProperties OptionBProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption? PeeringOption { get { throw null; } set { } }
    }
    public partial class ExternalNetworkPatchPropertiesOptionAProperties : Azure.ResourceManager.ManagedNetworkFabric.Models.Layer3IPPrefixProperties
    {
        public ExternalNetworkPatchPropertiesOptionAProperties() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration BfdConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier EgressAclId { get { throw null; } set { } }
        public long? FabricASN { get { throw null; } }
        public Azure.Core.ResourceIdentifier IngressAclId { get { throw null; } set { } }
        public int? Mtu { get { throw null; } set { } }
        public long? PeerASN { get { throw null; } set { } }
        public int? VlanId { get { throw null; } set { } }
    }
    public partial class ExternalNetworkPropertiesOptionAProperties : Azure.ResourceManager.ManagedNetworkFabric.Models.Layer3IPPrefixProperties
    {
        public ExternalNetworkPropertiesOptionAProperties() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration BfdConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier EgressAclId { get { throw null; } set { } }
        public long? FabricASN { get { throw null; } }
        public Azure.Core.ResourceIdentifier IngressAclId { get { throw null; } set { } }
        public int? Mtu { get { throw null; } set { } }
        public long? PeerASN { get { throw null; } set { } }
        public int? VlanId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FabricSkuType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.FabricSkuType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FabricSkuType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.FabricSkuType MultiRack { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.FabricSkuType SingleRack { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.FabricSkuType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.FabricSkuType left, Azure.ResourceManager.ManagedNetworkFabric.Models.FabricSkuType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.FabricSkuType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.FabricSkuType left, Azure.ResourceManager.ManagedNetworkFabric.Models.FabricSkuType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GatewayType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.GatewayType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GatewayType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.GatewayType Infrastructure { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.GatewayType Workload { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.GatewayType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.GatewayType left, Azure.ResourceManager.ManagedNetworkFabric.Models.GatewayType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.GatewayType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.GatewayType left, Azure.ResourceManager.ManagedNetworkFabric.Models.GatewayType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImportRoutePolicy
    {
        public ImportRoutePolicy() { }
        public Azure.Core.ResourceIdentifier ImportIPv4RoutePolicyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ImportIPv6RoutePolicyId { get { throw null; } set { } }
    }
    public partial class ImportRoutePolicyInformation
    {
        public ImportRoutePolicyInformation() { }
        public Azure.Core.ResourceIdentifier ImportIPv4RoutePolicyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ImportIPv6RoutePolicyId { get { throw null; } set { } }
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
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BgpConfiguration BgpConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnet> ConnectedIPv4Subnets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnet> ConnectedIPv6Subnets { get { throw null; } }
        public Azure.Core.ResourceIdentifier EgressAclId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicy ExportRoutePolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExportRoutePolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicy ImportRoutePolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ImportRoutePolicyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier IngressAclId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled? IsMonitoringEnabled { get { throw null; } set { } }
        public int? Mtu { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfiguration StaticRouteConfiguration { get { throw null; } set { } }
    }
    public partial class InternalNetworkPropertiesBgpConfiguration : Azure.ResourceManager.ManagedNetworkFabric.Models.BgpConfiguration
    {
        public InternalNetworkPropertiesBgpConfiguration() { }
    }
    public partial class InternalNetworkPropertiesStaticRouteConfiguration : Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfiguration
    {
        public InternalNetworkPropertiesStaticRouteConfiguration() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.Extension? Extension { get { throw null; } set { } }
    }
    public partial class InternetGatewayPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch
    {
        public InternetGatewayPatch() { }
        public Azure.Core.ResourceIdentifier InternetGatewayRuleId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InternetGatewayRuleAction : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRuleAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InternetGatewayRuleAction(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRuleAction Allow { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRuleAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRuleAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRuleAction left, Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRuleAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRuleAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRuleAction left, Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRuleAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InternetGatewayRulePatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch
    {
        public InternetGatewayRulePatch() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPAddressType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.IPAddressType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPAddressType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IPAddressType IPv4 { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IPAddressType IPv6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.IPAddressType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.IPAddressType left, Azure.ResourceManager.ManagedNetworkFabric.Models.IPAddressType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.IPAddressType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.IPAddressType left, Azure.ResourceManager.ManagedNetworkFabric.Models.IPAddressType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPCommunityAddOperationProperties
    {
        public IPCommunityAddOperationProperties() { }
        public System.Collections.Generic.IList<string> AddIPCommunityIds { get { throw null; } }
    }
    public partial class IPCommunityIdList
    {
        public IPCommunityIdList() { }
        public System.Collections.Generic.IList<string> IPCommunityIds { get { throw null; } }
    }
    public partial class IPCommunityPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch
    {
        public IPCommunityPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityRule> IPCommunityRules { get { throw null; } }
    }
    public partial class IPCommunityRule
    {
        public IPCommunityRule(Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType action, long sequenceNumber, System.Collections.Generic.IEnumerable<string> communityMembers) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> CommunityMembers { get { throw null; } }
        public long SequenceNumber { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity> WellKnownCommunities { get { throw null; } }
    }
    public partial class IPExtendedCommunityAddOperationProperties
    {
        public IPExtendedCommunityAddOperationProperties() { }
        public System.Collections.Generic.IList<string> AddIPExtendedCommunityIds { get { throw null; } }
    }
    public partial class IPExtendedCommunityPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch
    {
        public IPExtendedCommunityPatch() { }
        public string Annotation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityRule> IPExtendedCommunityRules { get { throw null; } }
    }
    public partial class IPExtendedCommunityRule
    {
        public IPExtendedCommunityRule(Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType action, long sequenceNumber, System.Collections.Generic.IEnumerable<string> routeTargets) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RouteTargets { get { throw null; } }
        public long SequenceNumber { get { throw null; } set { } }
    }
    public partial class IPGroupProperties
    {
        public IPGroupProperties() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.IPAddressType? IPAddressType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> IPPrefixes { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class IPMatchCondition
    {
        public IPMatchCondition() { }
        public System.Collections.Generic.IList<string> IPGroupNames { get { throw null; } }
        public System.Collections.Generic.IList<string> IPPrefixValues { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.PrefixType? PrefixType { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.SourceDestinationType? SourceDestinationType { get { throw null; } set { } }
    }
    public partial class IPPrefixPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch
    {
        public IPPrefixPatch() { }
        public string Annotation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRule> IPPrefixRules { get { throw null; } }
    }
    public partial class IPPrefixRule
    {
        public IPPrefixRule(Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType action, long sequenceNumber, string networkPrefix) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType Action { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.Condition? Condition { get { throw null; } set { } }
        public string NetworkPrefix { get { throw null; } set { } }
        public long SequenceNumber { get { throw null; } set { } }
        public string SubnetMaskLength { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsManagementType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.IsManagementType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsManagementType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IsManagementType False { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IsManagementType True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.IsManagementType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.IsManagementType left, Azure.ResourceManager.ManagedNetworkFabric.Models.IsManagementType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.IsManagementType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.IsManagementType left, Azure.ResourceManager.ManagedNetworkFabric.Models.IsManagementType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsMonitoringEnabled : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsMonitoringEnabled(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled False { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled left, Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled left, Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IsolationDomainProperties
    {
        public IsolationDomainProperties() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.Encapsulation? Encapsulation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> NeighborGroupIds { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsWorkloadManagementNetworkEnabled : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsWorkloadManagementNetworkEnabled(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled False { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled left, Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled left, Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class L2IsolationDomainPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch
    {
        public L2IsolationDomainPatch() { }
        public string Annotation { get { throw null; } set { } }
        public int? Mtu { get { throw null; } set { } }
    }
    public partial class L3ExportRoutePolicy
    {
        public L3ExportRoutePolicy() { }
        public Azure.Core.ResourceIdentifier ExportIPv4RoutePolicyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExportIPv6RoutePolicyId { get { throw null; } set { } }
    }
    public partial class L3IsolationDomainPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch
    {
        public L3IsolationDomainPatch() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRouteConfiguration AggregateRouteConfiguration { get { throw null; } set { } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnetRoutePolicy ConnectedSubnetRoutePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet? RedistributeConnectedSubnets { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute? RedistributeStaticRoutes { get { throw null; } set { } }
    }
    public partial class L3OptionBProperties
    {
        public L3OptionBProperties() { }
        public System.Collections.Generic.IList<string> ExportRouteTargets { get { throw null; } }
        public System.Collections.Generic.IList<string> ImportRouteTargets { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.RouteTargetInformation RouteTargets { get { throw null; } set { } }
    }
    public partial class Layer2Configuration
    {
        public Layer2Configuration() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> Interfaces { get { throw null; } }
        public int? Mtu { get { throw null; } set { } }
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
    public readonly partial struct Layer4Protocol : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Layer4Protocol(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol TCP { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol UDP { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol left, Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol left, Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedResourceGroupConfiguration
    {
        public ManagedResourceGroupConfiguration() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class ManagementNetworkConfigurationPatchableProperties
    {
        public ManagementNetworkConfigurationPatchableProperties() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPatchableProperties InfrastructureVpnConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPatchableProperties WorkloadVpnConfiguration { get { throw null; } set { } }
    }
    public partial class ManagementNetworkConfigurationProperties
    {
        public ManagementNetworkConfigurationProperties(Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationProperties infrastructureVpnConfiguration, Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationProperties workloadVpnConfiguration) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationProperties InfrastructureVpnConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationProperties WorkloadVpnConfiguration { get { throw null; } set { } }
    }
    public partial class NeighborAddress
    {
        public NeighborAddress() { }
        public string Address { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? ConfigurationState { get { throw null; } }
    }
    public partial class NeighborGroupDestination
    {
        public NeighborGroupDestination() { }
        public System.Collections.Generic.IList<string> IPv4Addresses { get { throw null; } }
        public System.Collections.Generic.IList<string> IPv6Addresses { get { throw null; } }
    }
    public partial class NeighborGroupPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch
    {
        public NeighborGroupPatch() { }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborGroupDestination Destination { get { throw null; } set { } }
    }
    public partial class NetworkDevicePatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch
    {
        public NetworkDevicePatch() { }
        public string Annotation { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
        public string SerialNumber { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkDeviceRole : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkDeviceRole(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole CE { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole Management { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole NPB { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole ToR { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole TS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole right) { throw null; }
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
    public partial class NetworkFabricControllerPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch
    {
        public NetworkFabricControllerPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation> InfrastructureExpressRouteConnections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation> WorkloadExpressRouteConnections { get { throw null; } }
    }
    public partial class NetworkFabricPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch
    {
        public NetworkFabricPatch() { }
        public string Annotation { get { throw null; } set { } }
        public long? FabricASN { get { throw null; } set { } }
        public string IPv4Prefix { get { throw null; } set { } }
        public string IPv6Prefix { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationPatchableProperties ManagementNetworkConfiguration { get { throw null; } set { } }
        public int? RackCount { get { throw null; } set { } }
        public int? ServerCountPerRack { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatchablePropertiesTerminalServerConfiguration TerminalServerConfiguration { get { throw null; } set { } }
    }
    public partial class NetworkFabricPatchablePropertiesTerminalServerConfiguration : Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerPatchableProperties
    {
        public NetworkFabricPatchablePropertiesTerminalServerConfiguration() { }
        public string PrimaryIPv4Prefix { get { throw null; } set { } }
        public string PrimaryIPv6Prefix { get { throw null; } set { } }
        public string SecondaryIPv4Prefix { get { throw null; } set { } }
        public string SecondaryIPv6Prefix { get { throw null; } set { } }
    }
    public partial class NetworkInterfacePatch
    {
        public NetworkInterfacePatch() { }
        public string Annotation { get { throw null; } set { } }
    }
    public partial class NetworkPacketBrokerPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch
    {
        public NetworkPacketBrokerPatch() { }
    }
    public partial class NetworkRackPatch
    {
        public NetworkRackPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkRackType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkRackType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType Aggregate { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType Combined { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType Compute { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkTapPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch
    {
        public NetworkTapPatch() { }
        public string Annotation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPatchableParametersDestinationsItem> Destinations { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.PollingType? PollingType { get { throw null; } set { } }
    }
    public partial class NetworkTapPatchableParametersDestinationsItem : Azure.ResourceManager.ManagedNetworkFabric.Models.DestinationProperties
    {
        public NetworkTapPatchableParametersDestinationsItem() { }
    }
    public partial class NetworkTapPropertiesDestinationsItem : Azure.ResourceManager.ManagedNetworkFabric.Models.DestinationProperties
    {
        public NetworkTapPropertiesDestinationsItem() { }
    }
    public partial class NetworkTapRuleAction
    {
        public NetworkTapRuleAction() { }
        public Azure.Core.ResourceIdentifier DestinationId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty? IsTimestampEnabled { get { throw null; } set { } }
        public string MatchConfigurationName { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType? TapRuleActionType { get { throw null; } set { } }
        public string Truncate { get { throw null; } set { } }
    }
    public partial class NetworkTapRuleMatchCondition : Azure.ResourceManager.ManagedNetworkFabric.Models.CommonMatchConditions
    {
        public NetworkTapRuleMatchCondition() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.EncapsulationType? EncapsulationType { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.PortCondition PortCondition { get { throw null; } set { } }
    }
    public partial class NetworkTapRuleMatchConfiguration
    {
        public NetworkTapRuleMatchConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleAction> Actions { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.IPAddressType? IPAddressType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchCondition> MatchConditions { get { throw null; } }
        public string MatchConfigurationName { get { throw null; } set { } }
        public long? SequenceNumber { get { throw null; } set { } }
    }
    public partial class NetworkTapRulePatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch
    {
        public NetworkTapRulePatch() { }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationType? ConfigurationType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonDynamicMatchConfiguration> DynamicMatchConfigurations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchConfiguration> MatchConfigurations { get { throw null; } }
        public System.Uri TapRulesUri { get { throw null; } set { } }
    }
    public partial class NetworkToNetworkInterconnectPatch : Azure.ResourceManager.Models.ResourceData
    {
        public NetworkToNetworkInterconnectPatch() { }
        public Azure.Core.ResourceIdentifier EgressAclId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicyInformation ExportRoutePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicyInformation ImportRoutePolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier IngressAclId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.Layer2Configuration Layer2Configuration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NpbStaticRouteConfiguration NpbStaticRouteConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBLayer3Configuration OptionBLayer3Configuration { get { throw null; } set { } }
    }
    public partial class NetworkToNetworkInterconnectPropertiesOptionBLayer3Configuration : Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBLayer3Configuration
    {
        public NetworkToNetworkInterconnectPropertiesOptionBLayer3Configuration() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NfcSku : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NfcSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NfcSku(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NfcSku Basic { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NfcSku HighPerformance { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NfcSku Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NfcSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NfcSku left, Azure.ResourceManager.ManagedNetworkFabric.Models.NfcSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NfcSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NfcSku left, Azure.ResourceManager.ManagedNetworkFabric.Models.NfcSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NniType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NniType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NniType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NniType CE { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NniType NPB { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NniType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NniType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NniType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NniType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NniType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NniType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NpbStaticRouteConfiguration
    {
        public NpbStaticRouteConfiguration() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration BfdConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteProperties> IPv4Routes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteProperties> IPv6Routes { get { throw null; } }
    }
    public partial class OptionAProperties
    {
        public OptionAProperties() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration BfdConfiguration { get { throw null; } set { } }
        public int? Mtu { get { throw null; } set { } }
        public long? PeerASN { get { throw null; } set { } }
        public int? VlanId { get { throw null; } set { } }
    }
    public partial class OptionBLayer3Configuration : Azure.ResourceManager.ManagedNetworkFabric.Models.Layer3IPPrefixProperties
    {
        public OptionBLayer3Configuration() { }
        public long? FabricASN { get { throw null; } }
        public long? PeerASN { get { throw null; } set { } }
        public int? VlanId { get { throw null; } set { } }
    }
    public partial class OptionBProperties
    {
        public OptionBProperties() { }
        public System.Collections.Generic.IList<string> ExportRouteTargets { get { throw null; } }
        public System.Collections.Generic.IList<string> ImportRouteTargets { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.RouteTargetInformation RouteTargets { get { throw null; } set { } }
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
    public readonly partial struct PollingIntervalInSecond : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond>
    {
        private readonly int _dummyPrimitive;
        public PollingIntervalInSecond(int value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond Ninety { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond OneHundredTwenty { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond Sixty { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond Thirty { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond left, Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond (int value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond left, Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PollingType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.PollingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PollingType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.PollingType Pull { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.PollingType Push { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.PollingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.PollingType left, Azure.ResourceManager.ManagedNetworkFabric.Models.PollingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.PollingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.PollingType left, Azure.ResourceManager.ManagedNetworkFabric.Models.PollingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PortCondition
    {
        public PortCondition(Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol layer4Protocol) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol Layer4Protocol { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PortGroupNames { get { throw null; } }
        public System.Collections.Generic.IList<string> Ports { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.PortType? PortType { get { throw null; } set { } }
    }
    public partial class PortGroupProperties
    {
        public PortGroupProperties() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Ports { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PortType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.PortType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PortType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.PortType DestinationPort { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.PortType SourcePort { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.PortType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.PortType left, Azure.ResourceManager.ManagedNetworkFabric.Models.PortType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.PortType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.PortType left, Azure.ResourceManager.ManagedNetworkFabric.Models.PortType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrefixType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.PrefixType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrefixType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.PrefixType LongestPrefix { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.PrefixType Prefix { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.PrefixType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.PrefixType left, Azure.ResourceManager.ManagedNetworkFabric.Models.PrefixType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.PrefixType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.PrefixType left, Azure.ResourceManager.ManagedNetworkFabric.Models.PrefixType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ProvisioningState Accepted { get { throw null; } }
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
    public partial class RebootProperties
    {
        public RebootProperties() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.RebootType? RebootType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RebootType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.RebootType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RebootType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.RebootType GracefulRebootWithoutZTP { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.RebootType GracefulRebootWithZTP { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.RebootType UngracefulRebootWithoutZTP { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.RebootType UngracefulRebootWithZTP { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.RebootType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.RebootType left, Azure.ResourceManager.ManagedNetworkFabric.Models.RebootType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.RebootType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.RebootType left, Azure.ResourceManager.ManagedNetworkFabric.Models.RebootType right) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoutePolicyActionType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoutePolicyActionType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyActionType Continue { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyActionType Deny { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyActionType Permit { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyActionType left, Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyActionType left, Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoutePolicyConditionType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoutePolicyConditionType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyConditionType And { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyConditionType Or { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyConditionType left, Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyConditionType left, Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoutePolicyPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch
    {
        public RoutePolicyPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyStatementProperties> Statements { get { throw null; } }
    }
    public partial class RoutePolicyStatementProperties : Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResource
    {
        public RoutePolicyStatementProperties(long sequenceNumber, Azure.ResourceManager.ManagedNetworkFabric.Models.StatementConditionProperties condition, Azure.ResourceManager.ManagedNetworkFabric.Models.StatementActionProperties action) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.StatementActionProperties Action { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.StatementConditionProperties Condition { get { throw null; } set { } }
        public long SequenceNumber { get { throw null; } set { } }
    }
    public partial class RouteTargetInformation
    {
        public RouteTargetInformation() { }
        public System.Collections.Generic.IList<string> ExportIPv4RouteTargets { get { throw null; } }
        public System.Collections.Generic.IList<string> ExportIPv6RouteTargets { get { throw null; } }
        public System.Collections.Generic.IList<string> ImportIPv4RouteTargets { get { throw null; } }
        public System.Collections.Generic.IList<string> ImportIPv6RouteTargets { get { throw null; } }
    }
    public partial class RuleProperties
    {
        public RuleProperties(Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRuleAction action, System.Collections.Generic.IEnumerable<string> addressList) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRuleAction Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AddressList { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceDestinationType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.SourceDestinationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceDestinationType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.SourceDestinationType DestinationIP { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.SourceDestinationType SourceIP { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.SourceDestinationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.SourceDestinationType left, Azure.ResourceManager.ManagedNetworkFabric.Models.SourceDestinationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.SourceDestinationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.SourceDestinationType left, Azure.ResourceManager.ManagedNetworkFabric.Models.SourceDestinationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StatementActionProperties
    {
        public StatementActionProperties(Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyActionType actionType) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyActionType ActionType { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ActionIPCommunityProperties IPCommunityProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ActionIPExtendedCommunityProperties IPExtendedCommunityProperties { get { throw null; } set { } }
        public long? LocalPreference { get { throw null; } set { } }
    }
    public partial class StatementConditionProperties : Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityIdList
    {
        public StatementConditionProperties() { }
        public System.Collections.Generic.IList<string> IPExtendedCommunityIds { get { throw null; } }
        public string IPPrefixId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyConditionType? RoutePolicyConditionType { get { throw null; } set { } }
    }
    public partial class StaticRouteConfiguration
    {
        public StaticRouteConfiguration() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration BfdConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteProperties> IPv4Routes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteProperties> IPv6Routes { get { throw null; } }
    }
    public partial class StaticRouteProperties
    {
        public StaticRouteProperties(string prefix, System.Collections.Generic.IEnumerable<string> nextHop) { }
        public System.Collections.Generic.IList<string> NextHop { get { throw null; } }
        public string Prefix { get { throw null; } set { } }
    }
    public partial class SupportedConnectorProperties
    {
        public SupportedConnectorProperties() { }
        public string ConnectorType { get { throw null; } set { } }
        public int? MaxSpeedInMbps { get { throw null; } set { } }
    }
    public partial class SupportedVersionProperties
    {
        public SupportedVersionProperties() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BooleanEnumProperty? IsDefault { get { throw null; } set { } }
        public string VendorFirmwareVersion { get { throw null; } set { } }
        public string VendorOSVersion { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TapRuleActionType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TapRuleActionType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType Count { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType Drop { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType Goto { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType Log { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType Mirror { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType Redirect { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType Replicate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType left, Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType left, Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TerminalServerConfiguration : Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerPatchableProperties
    {
        public TerminalServerConfiguration() { }
        public string NetworkDeviceId { get { throw null; } }
        public string PrimaryIPv4Prefix { get { throw null; } set { } }
        public string PrimaryIPv6Prefix { get { throw null; } set { } }
        public string SecondaryIPv4Prefix { get { throw null; } set { } }
        public string SecondaryIPv6Prefix { get { throw null; } set { } }
    }
    public partial class TerminalServerPatchableProperties
    {
        public TerminalServerPatchableProperties() { }
        public string Password { get { throw null; } set { } }
        public string SerialNumber { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class UpdateAdministrativeState : Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableOnResources
    {
        public UpdateAdministrativeState() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableState? State { get { throw null; } set { } }
    }
    public partial class UpdateDeviceAdministrativeState : Azure.ResourceManager.ManagedNetworkFabric.Models.EnableDisableOnResources
    {
        public UpdateDeviceAdministrativeState() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceAdministrativeState? State { get { throw null; } set { } }
    }
    public partial class UpdateVersion
    {
        public UpdateVersion() { }
        public string Version { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidateAction : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidateAction(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateAction Cabling { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateAction Configuration { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateAction Connectivity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateAction left, Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateAction left, Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ValidateConfigurationProperties
    {
        public ValidateConfigurationProperties() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateAction? ValidateAction { get { throw null; } set { } }
    }
    public partial class ValidateConfigurationResponse : Azure.ResourceManager.ManagedNetworkFabric.Models.ErrorResponse
    {
        internal ValidateConfigurationResponse() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConfigurationState? ConfigurationState { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class VlanGroupProperties
    {
        public VlanGroupProperties() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Vlans { get { throw null; } }
    }
    public partial class VlanMatchCondition
    {
        public VlanMatchCondition() { }
        public System.Collections.Generic.IList<string> InnerVlans { get { throw null; } }
        public System.Collections.Generic.IList<string> VlanGroupNames { get { throw null; } }
        public System.Collections.Generic.IList<string> Vlans { get { throw null; } }
    }
    public partial class VpnConfigurationPatchableProperties
    {
        public VpnConfigurationPatchableProperties() { }
        public Azure.Core.ResourceIdentifier NetworkToNetworkInterconnectId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPatchablePropertiesOptionAProperties OptionAProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBProperties OptionBProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption? PeeringOption { get { throw null; } set { } }
    }
    public partial class VpnConfigurationPatchablePropertiesOptionAProperties : Azure.ResourceManager.ManagedNetworkFabric.Models.OptionAProperties
    {
        public VpnConfigurationPatchablePropertiesOptionAProperties() { }
        public string PrimaryIPv4Prefix { get { throw null; } set { } }
        public string PrimaryIPv6Prefix { get { throw null; } set { } }
        public string SecondaryIPv4Prefix { get { throw null; } set { } }
        public string SecondaryIPv6Prefix { get { throw null; } set { } }
    }
    public partial class VpnConfigurationProperties
    {
        public VpnConfigurationProperties(Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption peeringOption) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeState? AdministrativeState { get { throw null; } }
        public Azure.Core.ResourceIdentifier NetworkToNetworkInterconnectId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPropertiesOptionAProperties OptionAProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBProperties OptionBProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption PeeringOption { get { throw null; } set { } }
    }
    public partial class VpnConfigurationPropertiesOptionAProperties : Azure.ResourceManager.ManagedNetworkFabric.Models.OptionAProperties
    {
        public VpnConfigurationPropertiesOptionAProperties() { }
        public string PrimaryIPv4Prefix { get { throw null; } set { } }
        public string PrimaryIPv6Prefix { get { throw null; } set { } }
        public string SecondaryIPv4Prefix { get { throw null; } set { } }
        public string SecondaryIPv6Prefix { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WellKnownCommunity : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WellKnownCommunity(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity GShut { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity Internet { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity LocalAS { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity NoAdvertise { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity NoExport { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity left, Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity left, Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity right) { throw null; }
        public override string ToString() { throw null; }
    }
}
