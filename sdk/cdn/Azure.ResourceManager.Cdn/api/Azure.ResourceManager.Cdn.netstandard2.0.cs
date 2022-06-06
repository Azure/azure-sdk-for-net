namespace Azure.ResourceManager.Cdn
{
    public partial class AfdCustomDomainCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.AfdCustomDomainResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.AfdCustomDomainResource>, System.Collections.IEnumerable
    {
        protected AfdCustomDomainCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdCustomDomainResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string customDomainName, Azure.ResourceManager.Cdn.AfdCustomDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdCustomDomainResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string customDomainName, Azure.ResourceManager.Cdn.AfdCustomDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdCustomDomainResource> Get(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.AfdCustomDomainResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.AfdCustomDomainResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdCustomDomainResource>> GetAsync(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.AfdCustomDomainResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.AfdCustomDomainResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.AfdCustomDomainResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.AfdCustomDomainResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AfdCustomDomainData : Azure.ResourceManager.Models.ResourceData
    {
        public AfdCustomDomainData() { }
        public Azure.ResourceManager.Cdn.Models.AfdDeploymentStatus? DeploymentStatus { get { throw null; } }
        public Azure.Core.ResourceIdentifier DnsZoneId { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.DomainValidationState? DomainValidationState { get { throw null; } }
        public string HostName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PreValidatedCustomDomainResourceId { get { throw null; } set { } }
        public string ProfileName { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.AfdProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.AfdCustomDomainHttpsContent TlsSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.DomainValidationProperties ValidationProperties { get { throw null; } }
    }
    public partial class AfdCustomDomainResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AfdCustomDomainResource() { }
        public virtual Azure.ResourceManager.Cdn.AfdCustomDomainData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string customDomainName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdCustomDomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdCustomDomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RefreshValidationToken(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RefreshValidationTokenAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdCustomDomainResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.AfdCustomDomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdCustomDomainResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.AfdCustomDomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AfdEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.AfdEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.AfdEndpointResource>, System.Collections.IEnumerable
    {
        protected AfdEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.Cdn.AfdEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.Cdn.AfdEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdEndpointResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.AfdEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.AfdEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdEndpointResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.AfdEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.AfdEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.AfdEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.AfdEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AfdEndpointData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AfdEndpointData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Cdn.Models.DomainNameLabelScope? AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.AfdDeploymentStatus? DeploymentStatus { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.EnabledState? EnabledState { get { throw null; } set { } }
        public string HostName { get { throw null; } }
        public string ProfileName { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.AfdProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class AfdEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AfdEndpointResource() { }
        public virtual Azure.ResourceManager.Cdn.AfdEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdEndpointResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdEndpointResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdRouteResource> GetAfdRoute(string routeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdRouteResource>> GetAfdRouteAsync(string routeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Cdn.AfdRouteCollection GetAfdRoutes() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.Models.CdnUsage> GetResourceUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.Models.CdnUsage> GetResourceUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PurgeContent(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.AfdPurgeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PurgeContentAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.AfdPurgeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdEndpointResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdEndpointResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdEndpointResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdEndpointResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.AfdEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.AfdEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.ValidateCustomDomainResult> ValidateCustomDomain(Azure.ResourceManager.Cdn.Models.ValidateCustomDomainContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.ValidateCustomDomainResult>> ValidateCustomDomainAsync(Azure.ResourceManager.Cdn.Models.ValidateCustomDomainContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AfdOriginCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.AfdOriginResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.AfdOriginResource>, System.Collections.IEnumerable
    {
        protected AfdOriginCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdOriginResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string originName, Azure.ResourceManager.Cdn.AfdOriginData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdOriginResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string originName, Azure.ResourceManager.Cdn.AfdOriginData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdOriginResource> Get(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.AfdOriginResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.AfdOriginResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdOriginResource>> GetAsync(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.AfdOriginResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.AfdOriginResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.AfdOriginResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.AfdOriginResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AfdOriginData : Azure.ResourceManager.Models.ResourceData
    {
        public AfdOriginData() { }
        public Azure.ResourceManager.Cdn.Models.AfdDeploymentStatus? DeploymentStatus { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.EnabledState? EnabledState { get { throw null; } set { } }
        public bool? EnforceCertificateNameCheck { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
        public int? HttpPort { get { throw null; } set { } }
        public int? HttpsPort { get { throw null; } set { } }
        public string OriginGroupName { get { throw null; } }
        public string OriginHostHeader { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier OriginId { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.AfdProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.SharedPrivateLinkResourceProperties SharedPrivateLinkResource { get { throw null; } set { } }
        public int? Weight { get { throw null; } set { } }
    }
    public partial class AfdOriginGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.AfdOriginGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.AfdOriginGroupResource>, System.Collections.IEnumerable
    {
        protected AfdOriginGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdOriginGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string originGroupName, Azure.ResourceManager.Cdn.AfdOriginGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdOriginGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string originGroupName, Azure.ResourceManager.Cdn.AfdOriginGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdOriginGroupResource> Get(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.AfdOriginGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.AfdOriginGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdOriginGroupResource>> GetAsync(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.AfdOriginGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.AfdOriginGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.AfdOriginGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.AfdOriginGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AfdOriginGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public AfdOriginGroupData() { }
        public Azure.ResourceManager.Cdn.Models.AfdDeploymentStatus? DeploymentStatus { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.HealthProbeSettings HealthProbeSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.LoadBalancingSettings LoadBalancingSettings { get { throw null; } set { } }
        public string ProfileName { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.AfdProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.EnabledState? SessionAffinityState { get { throw null; } set { } }
        public int? TrafficRestorationTimeInMinutes { get { throw null; } set { } }
    }
    public partial class AfdOriginGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AfdOriginGroupResource() { }
        public virtual Azure.ResourceManager.Cdn.AfdOriginGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string originGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdOriginGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdOriginResource> GetAfdOrigin(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdOriginResource>> GetAfdOriginAsync(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Cdn.AfdOriginCollection GetAfdOrigins() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdOriginGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.Models.CdnUsage> GetResourceUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.Models.CdnUsage> GetResourceUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdOriginGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.AfdOriginGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdOriginGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.AfdOriginGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AfdOriginResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AfdOriginResource() { }
        public virtual Azure.ResourceManager.Cdn.AfdOriginData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string originGroupName, string originName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdOriginResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdOriginResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdOriginResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.AfdOriginPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdOriginResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.AfdOriginPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AfdRouteCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.AfdRouteResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.AfdRouteResource>, System.Collections.IEnumerable
    {
        protected AfdRouteCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdRouteResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string routeName, Azure.ResourceManager.Cdn.AfdRouteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdRouteResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string routeName, Azure.ResourceManager.Cdn.AfdRouteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string routeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string routeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdRouteResource> Get(string routeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.AfdRouteResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.AfdRouteResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdRouteResource>> GetAsync(string routeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.AfdRouteResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.AfdRouteResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.AfdRouteResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.AfdRouteResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AfdRouteData : Azure.ResourceManager.Models.ResourceData
    {
        public AfdRouteData() { }
        public Azure.ResourceManager.Cdn.Models.AfdRouteCacheConfiguration CacheConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.ActivatedResourceReference> CustomDomains { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.AfdDeploymentStatus? DeploymentStatus { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.EnabledState? EnabledState { get { throw null; } set { } }
        public string EndpointName { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.ForwardingProtocol? ForwardingProtocol { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.HttpsRedirect? HttpsRedirect { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain? LinkToDefaultDomain { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier OriginGroupId { get { throw null; } set { } }
        public string OriginPath { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PatternsToMatch { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.AfdProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> RuleSets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.AfdEndpointProtocol> SupportedProtocols { get { throw null; } }
    }
    public partial class AfdRouteResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AfdRouteResource() { }
        public virtual Azure.ResourceManager.Cdn.AfdRouteData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string endpointName, string routeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdRouteResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdRouteResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdRouteResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.AfdRoutePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdRouteResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.AfdRoutePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AfdRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.AfdRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.AfdRuleResource>, System.Collections.IEnumerable
    {
        protected AfdRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleName, Azure.ResourceManager.Cdn.AfdRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleName, Azure.ResourceManager.Cdn.AfdRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdRuleResource> Get(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.AfdRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.AfdRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdRuleResource>> GetAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.AfdRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.AfdRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.AfdRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.AfdRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AfdRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public AfdRuleData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.DeliveryRuleAction> Actions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition> Conditions { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.AfdDeploymentStatus? DeploymentStatus { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior? MatchProcessingBehavior { get { throw null; } set { } }
        public int? Order { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.AfdProvisioningState? ProvisioningState { get { throw null; } }
        public string RuleSetName { get { throw null; } }
    }
    public partial class AfdRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AfdRuleResource() { }
        public virtual Azure.ResourceManager.Cdn.AfdRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string ruleSetName, string ruleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.AfdRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.AfdRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AfdRuleSetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.AfdRuleSetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.AfdRuleSetResource>, System.Collections.IEnumerable
    {
        protected AfdRuleSetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdRuleSetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdRuleSetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdRuleSetResource> Get(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.AfdRuleSetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.AfdRuleSetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdRuleSetResource>> GetAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.AfdRuleSetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.AfdRuleSetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.AfdRuleSetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.AfdRuleSetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AfdRuleSetData : Azure.ResourceManager.Models.ResourceData
    {
        public AfdRuleSetData() { }
        public Azure.ResourceManager.Cdn.Models.AfdDeploymentStatus? DeploymentStatus { get { throw null; } }
        public string ProfileName { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.AfdProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class AfdRuleSetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AfdRuleSetResource() { }
        public virtual Azure.ResourceManager.Cdn.AfdRuleSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string ruleSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdRuleSetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdRuleResource> GetAfdRule(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdRuleResource>> GetAfdRuleAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Cdn.AfdRuleCollection GetAfdRules() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdRuleSetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.Models.CdnUsage> GetResourceUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.Models.CdnUsage> GetResourceUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdRuleSetResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdRuleSetResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AfdSecretCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.AfdSecretResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.AfdSecretResource>, System.Collections.IEnumerable
    {
        protected AfdSecretCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdSecretResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string secretName, Azure.ResourceManager.Cdn.AfdSecretData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdSecretResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string secretName, Azure.ResourceManager.Cdn.AfdSecretData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdSecretResource> Get(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.AfdSecretResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.AfdSecretResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdSecretResource>> GetAsync(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.AfdSecretResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.AfdSecretResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.AfdSecretResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.AfdSecretResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AfdSecretData : Azure.ResourceManager.Models.ResourceData
    {
        public AfdSecretData() { }
        public Azure.ResourceManager.Cdn.Models.AfdDeploymentStatus? DeploymentStatus { get { throw null; } }
        public string ProfileName { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.SecretProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.AfdProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class AfdSecretResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AfdSecretResource() { }
        public virtual Azure.ResourceManager.Cdn.AfdSecretData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string secretName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdSecretResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdSecretResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdSecretResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.AfdSecretData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdSecretResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.AfdSecretData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AfdSecurityPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.AfdSecurityPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.AfdSecurityPolicyResource>, System.Collections.IEnumerable
    {
        protected AfdSecurityPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdSecurityPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string securityPolicyName, Azure.ResourceManager.Cdn.AfdSecurityPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdSecurityPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string securityPolicyName, Azure.ResourceManager.Cdn.AfdSecurityPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string securityPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string securityPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdSecurityPolicyResource> Get(string securityPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.AfdSecurityPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.AfdSecurityPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdSecurityPolicyResource>> GetAsync(string securityPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.AfdSecurityPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.AfdSecurityPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.AfdSecurityPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.AfdSecurityPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AfdSecurityPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public AfdSecurityPolicyData() { }
        public Azure.ResourceManager.Cdn.Models.AfdDeploymentStatus? DeploymentStatus { get { throw null; } }
        public string ProfileName { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.SecurityPolicyProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.AfdProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class AfdSecurityPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AfdSecurityPolicyResource() { }
        public virtual Azure.ResourceManager.Cdn.AfdSecurityPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string securityPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdSecurityPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdSecurityPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdSecurityPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.AfdSecurityPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.AfdSecurityPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.AfdSecurityPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CdnCustomDomainCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.CdnCustomDomainResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.CdnCustomDomainResource>, System.Collections.IEnumerable
    {
        protected CdnCustomDomainCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnCustomDomainResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string customDomainName, Azure.ResourceManager.Cdn.Models.CdnCustomDomainCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnCustomDomainResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string customDomainName, Azure.ResourceManager.Cdn.Models.CdnCustomDomainCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnCustomDomainResource> Get(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.CdnCustomDomainResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.CdnCustomDomainResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnCustomDomainResource>> GetAsync(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.CdnCustomDomainResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.CdnCustomDomainResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.CdnCustomDomainResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.CdnCustomDomainResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CdnCustomDomainData : Azure.ResourceManager.Models.ResourceData
    {
        public CdnCustomDomainData() { }
        public Azure.ResourceManager.Cdn.Models.CustomDomainHttpsContent CustomDomainHttpsContent { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState? CustomHttpsAvailabilityState { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState? CustomHttpsProvisioningState { get { throw null; } }
        public string HostName { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.CustomDomainResourceState? ResourceState { get { throw null; } }
        public string ValidationData { get { throw null; } set { } }
    }
    public partial class CdnCustomDomainResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CdnCustomDomainResource() { }
        public virtual Azure.ResourceManager.Cdn.CdnCustomDomainData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string endpointName, string customDomainName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnCustomDomainResource> DisableCustomHttps(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnCustomDomainResource>> DisableCustomHttpsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnCustomDomainResource> EnableCustomHttps(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CustomDomainHttpsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnCustomDomainResource>> EnableCustomHttpsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CustomDomainHttpsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnCustomDomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnCustomDomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnCustomDomainResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CdnCustomDomainCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnCustomDomainResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CdnCustomDomainCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CdnEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.CdnEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.CdnEndpointResource>, System.Collections.IEnumerable
    {
        protected CdnEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.Cdn.CdnEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.Cdn.CdnEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnEndpointResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.CdnEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.CdnEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnEndpointResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.CdnEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.CdnEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.CdnEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.CdnEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CdnEndpointData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CdnEndpointData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<string> ContentTypesToCompress { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.CdnCustomDomainData> CustomDomains { get { throw null; } }
        public Azure.Core.ResourceIdentifier DefaultOriginGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.EndpointDeliveryPolicy DeliveryPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.GeoFilter> GeoFilters { get { throw null; } }
        public string HostName { get { throw null; } }
        public bool? IsCompressionEnabled { get { throw null; } set { } }
        public bool? IsHttpAllowed { get { throw null; } set { } }
        public bool? IsHttpsAllowed { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.OptimizationType? OptimizationType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.DeepCreatedOriginGroup> OriginGroups { get { throw null; } }
        public string OriginHostHeader { get { throw null; } set { } }
        public string OriginPath { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.DeepCreatedOrigin> Origins { get { throw null; } }
        public string ProbePath { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.EndpointProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.QueryStringCachingBehavior? QueryStringCachingBehavior { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.EndpointResourceState? ResourceState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.UriSigningKey> UriSigningKeys { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier WebApplicationFirewallPolicyLinkId { get { throw null; } set { } }
    }
    public partial class CdnEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CdnEndpointResource() { }
        public virtual Azure.ResourceManager.Cdn.CdnEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnEndpointResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnEndpointResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnCustomDomainResource> GetCdnCustomDomain(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnCustomDomainResource>> GetCdnCustomDomainAsync(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Cdn.CdnCustomDomainCollection GetCdnCustomDomains() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnOriginResource> GetCdnOrigin(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnOriginResource>> GetCdnOriginAsync(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnOriginGroupResource> GetCdnOriginGroup(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnOriginGroupResource>> GetCdnOriginGroupAsync(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Cdn.CdnOriginGroupCollection GetCdnOriginGroups() { throw null; }
        public virtual Azure.ResourceManager.Cdn.CdnOriginCollection GetCdnOrigins() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.Models.ResourceUsage> GetResourceUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.Models.ResourceUsage> GetResourceUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation LoadContent(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.LoadContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> LoadContentAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.LoadContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PurgeContent(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.PurgeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PurgeContentAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.PurgeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnEndpointResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnEndpointResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnEndpointResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnEndpointResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnEndpointResource> Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnEndpointResource>> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnEndpointResource> Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnEndpointResource>> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CdnEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CdnEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.ValidateCustomDomainResult> ValidateCustomDomain(Azure.ResourceManager.Cdn.Models.ValidateCustomDomainContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.ValidateCustomDomainResult>> ValidateCustomDomainAsync(Azure.ResourceManager.Cdn.Models.ValidateCustomDomainContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class CdnExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult> CheckCdnNameAvailability(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult>> CheckCdnNameAvailabilityAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult> CheckCdnNameAvailabilityWithSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult>> CheckCdnNameAvailabilityWithSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityResult> CheckEndpointNameAvailability(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityResult>> CheckEndpointNameAvailabilityAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Cdn.AfdCustomDomainResource GetAfdCustomDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.AfdEndpointResource GetAfdEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.AfdOriginGroupResource GetAfdOriginGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.AfdOriginResource GetAfdOriginResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.AfdRouteResource GetAfdRouteResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.AfdRuleResource GetAfdRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.AfdRuleSetResource GetAfdRuleSetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.AfdSecretResource GetAfdSecretResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.AfdSecurityPolicyResource GetAfdSecurityPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.CdnCustomDomainResource GetCdnCustomDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.CdnEndpointResource GetCdnEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.CdnOriginGroupResource GetCdnOriginGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.CdnOriginResource GetCdnOriginResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyCollection GetCdnWebApplicationFirewallPolicies(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> GetCdnWebApplicationFirewallPolicy(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>> GetCdnWebApplicationFirewallPolicyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource GetCdnWebApplicationFirewallPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Cdn.Models.EdgeNode> GetEdgeNodes(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Cdn.Models.EdgeNode> GetEdgeNodesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Cdn.Models.ManagedRuleSetDefinition> GetManagedRuleSets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Cdn.Models.ManagedRuleSetDefinition> GetManagedRuleSetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Cdn.ProfileResource> GetProfile(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.ProfileResource>> GetProfileAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Cdn.ProfileResource GetProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.ProfileCollection GetProfiles(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Cdn.ProfileResource> GetProfiles(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Cdn.ProfileResource> GetProfilesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Cdn.Models.ResourceUsage> GetResourceUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Cdn.Models.ResourceUsage> GetResourceUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Cdn.Models.ValidateProbeResult> ValidateProbe(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Cdn.Models.ValidateProbeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.ValidateProbeResult>> ValidateProbeAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Cdn.Models.ValidateProbeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CdnOriginCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.CdnOriginResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.CdnOriginResource>, System.Collections.IEnumerable
    {
        protected CdnOriginCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnOriginResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string originName, Azure.ResourceManager.Cdn.CdnOriginData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnOriginResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string originName, Azure.ResourceManager.Cdn.CdnOriginData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnOriginResource> Get(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.CdnOriginResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.CdnOriginResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnOriginResource>> GetAsync(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.CdnOriginResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.CdnOriginResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.CdnOriginResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.CdnOriginResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CdnOriginData : Azure.ResourceManager.Models.ResourceData
    {
        public CdnOriginData() { }
        public bool? Enabled { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
        public int? HttpPort { get { throw null; } set { } }
        public int? HttpsPort { get { throw null; } set { } }
        public string OriginHostHeader { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus? PrivateEndpointStatus { get { throw null; } }
        public string PrivateLinkAlias { get { throw null; } set { } }
        public string PrivateLinkApprovalMessage { get { throw null; } set { } }
        public string PrivateLinkLocation { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.OriginProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.OriginResourceState? ResourceState { get { throw null; } }
        public int? Weight { get { throw null; } set { } }
    }
    public partial class CdnOriginGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.CdnOriginGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.CdnOriginGroupResource>, System.Collections.IEnumerable
    {
        protected CdnOriginGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnOriginGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string originGroupName, Azure.ResourceManager.Cdn.CdnOriginGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnOriginGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string originGroupName, Azure.ResourceManager.Cdn.CdnOriginGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnOriginGroupResource> Get(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.CdnOriginGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.CdnOriginGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnOriginGroupResource>> GetAsync(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.CdnOriginGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.CdnOriginGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.CdnOriginGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.CdnOriginGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CdnOriginGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public CdnOriginGroupData() { }
        public Azure.ResourceManager.Cdn.Models.HealthProbeSettings HealthProbeSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Origins { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.OriginGroupResourceState? ResourceState { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.ResponseBasedOriginErrorDetectionSettings ResponseBasedOriginErrorDetectionSettings { get { throw null; } set { } }
        public int? TrafficRestorationTimeToHealedOrNewEndpointsInMinutes { get { throw null; } set { } }
    }
    public partial class CdnOriginGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CdnOriginGroupResource() { }
        public virtual Azure.ResourceManager.Cdn.CdnOriginGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string endpointName, string originGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnOriginGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnOriginGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnOriginGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CdnOriginGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnOriginGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CdnOriginGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CdnOriginResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CdnOriginResource() { }
        public virtual Azure.ResourceManager.Cdn.CdnOriginData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string endpointName, string originName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnOriginResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnOriginResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnOriginResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CdnOriginPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnOriginResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CdnOriginPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CdnWebApplicationFirewallPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>, System.Collections.IEnumerable
    {
        protected CdnWebApplicationFirewallPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> Get(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>> GetAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CdnWebApplicationFirewallPolicyData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CdnWebApplicationFirewallPolicyData(Azure.Core.AzureLocation location, Azure.ResourceManager.Cdn.Models.CdnSku sku) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.CustomRule> CustomRules { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> EndpointLinks { get { throw null; } }
        public Azure.ETag? Etag { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.ManagedRuleSet> ManagedRuleSets { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.PolicySettings PolicySettings { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.RateLimitRule> RateLimitRules { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.PolicyResourceState? ResourceState { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.CdnSkuName? SkuName { get { throw null; } set { } }
    }
    public partial class CdnWebApplicationFirewallPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CdnWebApplicationFirewallPolicyResource() { }
        public virtual Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string policyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CdnWebApplicationFirewallPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CdnWebApplicationFirewallPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.ProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.ProfileResource>, System.Collections.IEnumerable
    {
        protected ProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.ProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string profileName, Azure.ResourceManager.Cdn.ProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.ProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string profileName, Azure.ResourceManager.Cdn.ProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.ProfileResource> Get(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.ProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.ProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.ProfileResource>> GetAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.ProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.ProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.ProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.ProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProfileData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ProfileData(Azure.Core.AzureLocation location, Azure.ResourceManager.Cdn.Models.CdnSku sku) : base (default(Azure.Core.AzureLocation)) { }
        public System.Guid? FrontDoorId { get { throw null; } }
        public string Kind { get { throw null; } }
        public int? OriginResponseTimeoutSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.ProfileProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.ProfileResourceState? ResourceState { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.CdnSkuName? SkuName { get { throw null; } set { } }
    }
    public partial class ProfileResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProfileResource() { }
        public virtual Azure.ResourceManager.Cdn.ProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.ProfileResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.ProfileResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult> CheckAfdProfileHostNameAvailability(Azure.ResourceManager.Cdn.Models.HostNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult>> CheckAfdProfileHostNameAvailabilityAsync(Azure.ResourceManager.Cdn.Models.HostNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.SsoUri> GenerateSsoUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.SsoUri>> GenerateSsoUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.ProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdCustomDomainResource> GetAfdCustomDomain(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdCustomDomainResource>> GetAfdCustomDomainAsync(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Cdn.AfdCustomDomainCollection GetAfdCustomDomains() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdEndpointResource> GetAfdEndpoint(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdEndpointResource>> GetAfdEndpointAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Cdn.AfdEndpointCollection GetAfdEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdOriginGroupResource> GetAfdOriginGroup(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdOriginGroupResource>> GetAfdOriginGroupAsync(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Cdn.AfdOriginGroupCollection GetAfdOriginGroups() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.Models.CdnUsage> GetAfdProfileResourceUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.Models.CdnUsage> GetAfdProfileResourceUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdRuleSetResource> GetAfdRuleSet(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdRuleSetResource>> GetAfdRuleSetAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Cdn.AfdRuleSetCollection GetAfdRuleSets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdSecretResource> GetAfdSecret(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdSecretResource>> GetAfdSecretAsync(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Cdn.AfdSecretCollection GetAfdSecrets() { throw null; }
        public virtual Azure.ResourceManager.Cdn.AfdSecurityPolicyCollection GetAfdSecurityPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.AfdSecurityPolicyResource> GetAfdSecurityPolicy(string securityPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.AfdSecurityPolicyResource>> GetAfdSecurityPolicyAsync(string securityPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.ProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnEndpointResource> GetCdnEndpoint(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnEndpointResource>> GetCdnEndpointAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Cdn.CdnEndpointCollection GetCdnEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.ContinentsResponse> GetLogAnalyticsLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.ContinentsResponse>> GetLogAnalyticsLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.MetricsResponse> GetLogAnalyticsMetrics(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.LogMetric> metrics, System.DateTimeOffset dateTimeBegin, System.DateTimeOffset dateTimeEnd, Azure.ResourceManager.Cdn.Models.LogMetricsGranularity granularity, System.Collections.Generic.IEnumerable<string> customDomains, System.Collections.Generic.IEnumerable<string> protocols, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy> groupBy = null, System.Collections.Generic.IEnumerable<string> continents = null, System.Collections.Generic.IEnumerable<string> countryOrRegions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.MetricsResponse>> GetLogAnalyticsMetricsAsync(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.LogMetric> metrics, System.DateTimeOffset dateTimeBegin, System.DateTimeOffset dateTimeEnd, Azure.ResourceManager.Cdn.Models.LogMetricsGranularity granularity, System.Collections.Generic.IEnumerable<string> customDomains, System.Collections.Generic.IEnumerable<string> protocols, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy> groupBy = null, System.Collections.Generic.IEnumerable<string> continents = null, System.Collections.Generic.IEnumerable<string> countryOrRegions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.RankingsResponse> GetLogAnalyticsRankings(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.LogRanking> rankings, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.LogRankingMetric> metrics, int maxRanking, System.DateTimeOffset dateTimeBegin, System.DateTimeOffset dateTimeEnd, System.Collections.Generic.IEnumerable<string> customDomains = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.RankingsResponse>> GetLogAnalyticsRankingsAsync(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.LogRanking> rankings, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.LogRankingMetric> metrics, int maxRanking, System.DateTimeOffset dateTimeBegin, System.DateTimeOffset dateTimeEnd, System.Collections.Generic.IEnumerable<string> customDomains = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.ResourcesResponse> GetLogAnalyticsResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.ResourcesResponse>> GetLogAnalyticsResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.Models.ResourceUsage> GetResourceUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.Models.ResourceUsage> GetResourceUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.SupportedOptimizationTypesListResult> GetSupportedOptimizationTypes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.SupportedOptimizationTypesListResult>> GetSupportedOptimizationTypesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.WafMetricsResponse> GetWafLogAnalyticsMetrics(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafMetric> metrics, System.DateTimeOffset dateTimeBegin, System.DateTimeOffset dateTimeEnd, Azure.ResourceManager.Cdn.Models.WafGranularity granularity, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafAction> actions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafRankingGroupBy> groupBy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafRuleType> ruleTypes = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.WafMetricsResponse>> GetWafLogAnalyticsMetricsAsync(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafMetric> metrics, System.DateTimeOffset dateTimeBegin, System.DateTimeOffset dateTimeEnd, Azure.ResourceManager.Cdn.Models.WafGranularity granularity, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafAction> actions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafRankingGroupBy> groupBy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafRuleType> ruleTypes = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.WafRankingsResponse> GetWafLogAnalyticsRankings(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafMetric> metrics, System.DateTimeOffset dateTimeBegin, System.DateTimeOffset dateTimeEnd, int maxRanking, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafRankingType> rankings, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafAction> actions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafRuleType> ruleTypes = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.WafRankingsResponse>> GetWafLogAnalyticsRankingsAsync(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafMetric> metrics, System.DateTimeOffset dateTimeBegin, System.DateTimeOffset dateTimeEnd, int maxRanking, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafRankingType> rankings, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafAction> actions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafRuleType> ruleTypes = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.ProfileResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.ProfileResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.ProfileResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.ProfileResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.ProfileResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.ProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.ProfileResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.ProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Cdn.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.ActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ActionType Allow { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ActionType Block { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ActionType Log { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ActionType Redirect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ActionType left, Azure.ResourceManager.Cdn.Models.ActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ActionType left, Azure.ResourceManager.Cdn.Models.ActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ActivatedResourceReference
    {
        public ActivatedResourceReference() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public bool? IsActive { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AfdCertificateType : System.IEquatable<Azure.ResourceManager.Cdn.Models.AfdCertificateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AfdCertificateType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.AfdCertificateType AzureFirstPartyManagedCertificate { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.AfdCertificateType CustomerCertificate { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.AfdCertificateType ManagedCertificate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.AfdCertificateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.AfdCertificateType left, Azure.ResourceManager.Cdn.Models.AfdCertificateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.AfdCertificateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.AfdCertificateType left, Azure.ResourceManager.Cdn.Models.AfdCertificateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AfdCustomDomainHttpsContent
    {
        public AfdCustomDomainHttpsContent(Azure.ResourceManager.Cdn.Models.AfdCertificateType certificateType) { }
        public Azure.ResourceManager.Cdn.Models.AfdCertificateType CertificateType { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.AfdMinimumTlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SecretId { get { throw null; } set { } }
    }
    public partial class AfdCustomDomainPatch
    {
        public AfdCustomDomainPatch() { }
        public Azure.Core.ResourceIdentifier DnsZoneId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PreValidatedCustomDomainResourceId { get { throw null; } set { } }
        public string ProfileName { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.AfdCustomDomainHttpsContent TlsSettings { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AfdDeploymentStatus : System.IEquatable<Azure.ResourceManager.Cdn.Models.AfdDeploymentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AfdDeploymentStatus(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.AfdDeploymentStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.AfdDeploymentStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.AfdDeploymentStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.AfdDeploymentStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.AfdDeploymentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.AfdDeploymentStatus left, Azure.ResourceManager.Cdn.Models.AfdDeploymentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.AfdDeploymentStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.AfdDeploymentStatus left, Azure.ResourceManager.Cdn.Models.AfdDeploymentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AfdEndpointPatch
    {
        public AfdEndpointPatch() { }
        public Azure.ResourceManager.Cdn.Models.EnabledState? EnabledState { get { throw null; } set { } }
        public string ProfileName { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AfdEndpointProtocol : System.IEquatable<Azure.ResourceManager.Cdn.Models.AfdEndpointProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AfdEndpointProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.AfdEndpointProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.AfdEndpointProtocol Https { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.AfdEndpointProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.AfdEndpointProtocol left, Azure.ResourceManager.Cdn.Models.AfdEndpointProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.AfdEndpointProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.AfdEndpointProtocol left, Azure.ResourceManager.Cdn.Models.AfdEndpointProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum AfdMinimumTlsVersion
    {
        Tls1_0 = 0,
        Tls1_2 = 1,
    }
    public partial class AfdOriginGroupPatch
    {
        public AfdOriginGroupPatch() { }
        public Azure.ResourceManager.Cdn.Models.HealthProbeSettings HealthProbeSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.LoadBalancingSettings LoadBalancingSettings { get { throw null; } set { } }
        public string ProfileName { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.EnabledState? SessionAffinityState { get { throw null; } set { } }
        public int? TrafficRestorationTimeInMinutes { get { throw null; } set { } }
    }
    public partial class AfdOriginPatch
    {
        public AfdOriginPatch() { }
        public Azure.ResourceManager.Cdn.Models.EnabledState? EnabledState { get { throw null; } set { } }
        public bool? EnforceCertificateNameCheck { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
        public int? HttpPort { get { throw null; } set { } }
        public int? HttpsPort { get { throw null; } set { } }
        public string OriginGroupName { get { throw null; } }
        public string OriginHostHeader { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier OriginId { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.SharedPrivateLinkResourceProperties SharedPrivateLinkResource { get { throw null; } set { } }
        public int? Weight { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AfdProvisioningState : System.IEquatable<Azure.ResourceManager.Cdn.Models.AfdProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AfdProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.AfdProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.AfdProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.AfdProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.AfdProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.AfdProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.AfdProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.AfdProvisioningState left, Azure.ResourceManager.Cdn.Models.AfdProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.AfdProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.AfdProvisioningState left, Azure.ResourceManager.Cdn.Models.AfdProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AfdPurgeContent
    {
        public AfdPurgeContent(System.Collections.Generic.IEnumerable<string> contentPaths) { }
        public System.Collections.Generic.IList<string> ContentPaths { get { throw null; } }
        public System.Collections.Generic.IList<string> Domains { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AfdQueryStringCachingBehavior : System.IEquatable<Azure.ResourceManager.Cdn.Models.AfdQueryStringCachingBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AfdQueryStringCachingBehavior(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.AfdQueryStringCachingBehavior IgnoreQueryString { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.AfdQueryStringCachingBehavior IgnoreSpecifiedQueryStrings { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.AfdQueryStringCachingBehavior IncludeSpecifiedQueryStrings { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.AfdQueryStringCachingBehavior UseQueryString { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.AfdQueryStringCachingBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.AfdQueryStringCachingBehavior left, Azure.ResourceManager.Cdn.Models.AfdQueryStringCachingBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.AfdQueryStringCachingBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.AfdQueryStringCachingBehavior left, Azure.ResourceManager.Cdn.Models.AfdQueryStringCachingBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AfdRouteCacheConfiguration
    {
        public AfdRouteCacheConfiguration() { }
        public Azure.ResourceManager.Cdn.Models.RouteCacheCompressionSettings CompressionSettings { get { throw null; } set { } }
        public string QueryParameters { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.AfdQueryStringCachingBehavior? QueryStringCachingBehavior { get { throw null; } set { } }
    }
    public partial class AfdRoutePatch
    {
        public AfdRoutePatch() { }
        public Azure.ResourceManager.Cdn.Models.AfdRouteCacheConfiguration CacheConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.ActivatedResourceReference> CustomDomains { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.EnabledState? EnabledState { get { throw null; } set { } }
        public string EndpointName { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.ForwardingProtocol? ForwardingProtocol { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.HttpsRedirect? HttpsRedirect { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain? LinkToDefaultDomain { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier OriginGroupId { get { throw null; } set { } }
        public string OriginPath { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PatternsToMatch { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> RuleSets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.AfdEndpointProtocol> SupportedProtocols { get { throw null; } }
    }
    public partial class AfdRulePatch
    {
        public AfdRulePatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.DeliveryRuleAction> Actions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition> Conditions { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior? MatchProcessingBehavior { get { throw null; } set { } }
        public int? Order { get { throw null; } set { } }
        public string RuleSetName { get { throw null; } }
    }
    public partial class AfdSecurityPolicyPatch
    {
        public AfdSecurityPolicyPatch() { }
        public Azure.ResourceManager.Cdn.Models.SecurityPolicyProperties Properties { get { throw null; } set { } }
    }
    public partial class AzureFirstPartyManagedCertificateProperties : Azure.ResourceManager.Cdn.Models.SecretProperties
    {
        public AzureFirstPartyManagedCertificateProperties() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CacheBehaviorSetting : System.IEquatable<Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CacheBehaviorSetting(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting BypassCache { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting Override { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting SetIfMissing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting left, Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting left, Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CacheConfiguration
    {
        public CacheConfiguration() { }
        public Azure.ResourceManager.Cdn.Models.RuleCacheBehavior? CacheBehavior { get { throw null; } set { } }
        public System.TimeSpan? CacheDuration { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.RuleIsCompressionEnabled? IsCompressionEnabled { get { throw null; } set { } }
        public string QueryParameters { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.RuleQueryStringCachingBehavior? QueryStringCachingBehavior { get { throw null; } set { } }
    }
    public partial class CacheExpirationActionProperties
    {
        public CacheExpirationActionProperties(Azure.ResourceManager.Cdn.Models.CacheExpirationActionType actionType, Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting cacheBehavior, Azure.ResourceManager.Cdn.Models.CacheLevel cacheType) { }
        public Azure.ResourceManager.Cdn.Models.CacheExpirationActionType ActionType { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting CacheBehavior { get { throw null; } set { } }
        public System.TimeSpan? CacheDuration { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.CacheLevel CacheType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CacheExpirationActionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.CacheExpirationActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CacheExpirationActionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CacheExpirationActionType CacheExpirationAction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CacheExpirationActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CacheExpirationActionType left, Azure.ResourceManager.Cdn.Models.CacheExpirationActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CacheExpirationActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CacheExpirationActionType left, Azure.ResourceManager.Cdn.Models.CacheExpirationActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CacheKeyQueryStringActionProperties
    {
        public CacheKeyQueryStringActionProperties(Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionType actionType, Azure.ResourceManager.Cdn.Models.QueryStringBehavior queryStringBehavior) { }
        public Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionType ActionType { get { throw null; } set { } }
        public string QueryParameters { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.QueryStringBehavior QueryStringBehavior { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CacheKeyQueryStringActionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CacheKeyQueryStringActionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionType CacheKeyQueryStringBehaviorAction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionType left, Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionType left, Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CacheLevel : System.IEquatable<Azure.ResourceManager.Cdn.Models.CacheLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CacheLevel(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CacheLevel All { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CacheLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CacheLevel left, Azure.ResourceManager.Cdn.Models.CacheLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CacheLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CacheLevel left, Azure.ResourceManager.Cdn.Models.CacheLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CdnCertificateSource
    {
        public CdnCertificateSource(Azure.ResourceManager.Cdn.Models.CdnCertificateSourceType sourceType, Azure.ResourceManager.Cdn.Models.CdnManagedCertificateType certificateType) { }
        public Azure.ResourceManager.Cdn.Models.CdnManagedCertificateType CertificateType { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.CdnCertificateSourceType SourceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CdnCertificateSourceType : System.IEquatable<Azure.ResourceManager.Cdn.Models.CdnCertificateSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CdnCertificateSourceType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CdnCertificateSourceType CdnCertificateSource { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CdnCertificateSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CdnCertificateSourceType left, Azure.ResourceManager.Cdn.Models.CdnCertificateSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CdnCertificateSourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CdnCertificateSourceType left, Azure.ResourceManager.Cdn.Models.CdnCertificateSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CdnCustomDomainCreateOrUpdateContent
    {
        public CdnCustomDomainCreateOrUpdateContent() { }
        public string HostName { get { throw null; } set { } }
    }
    public partial class CdnEndpointPatch
    {
        public CdnEndpointPatch() { }
        public System.Collections.Generic.IList<string> ContentTypesToCompress { get { throw null; } }
        public Azure.Core.ResourceIdentifier DefaultOriginGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.EndpointDeliveryPolicy DeliveryPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.GeoFilter> GeoFilters { get { throw null; } }
        public bool? IsCompressionEnabled { get { throw null; } set { } }
        public bool? IsHttpAllowed { get { throw null; } set { } }
        public bool? IsHttpsAllowed { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.OptimizationType? OptimizationType { get { throw null; } set { } }
        public string OriginHostHeader { get { throw null; } set { } }
        public string OriginPath { get { throw null; } set { } }
        public string ProbePath { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.QueryStringCachingBehavior? QueryStringCachingBehavior { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.UriSigningKey> UriSigningKeys { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier WebApplicationFirewallPolicyLinkId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CdnManagedCertificateType : System.IEquatable<Azure.ResourceManager.Cdn.Models.CdnManagedCertificateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CdnManagedCertificateType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CdnManagedCertificateType Dedicated { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnManagedCertificateType Shared { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CdnManagedCertificateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CdnManagedCertificateType left, Azure.ResourceManager.Cdn.Models.CdnManagedCertificateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CdnManagedCertificateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CdnManagedCertificateType left, Azure.ResourceManager.Cdn.Models.CdnManagedCertificateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CdnManagedHttpsContent : Azure.ResourceManager.Cdn.Models.CustomDomainHttpsContent
    {
        public CdnManagedHttpsContent(Azure.ResourceManager.Cdn.Models.ProtocolType protocolType, Azure.ResourceManager.Cdn.Models.CdnCertificateSource certificateSourceParameters) : base (default(Azure.ResourceManager.Cdn.Models.ProtocolType)) { }
        public Azure.ResourceManager.Cdn.Models.CdnCertificateSource CertificateSourceParameters { get { throw null; } set { } }
    }
    public partial class CdnNameAvailabilityContent
    {
        public CdnNameAvailabilityContent(string name, Azure.ResourceManager.Cdn.Models.CdnResourceType resourceType) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.CdnResourceType ResourceType { get { throw null; } }
    }
    public partial class CdnNameAvailabilityResult
    {
        internal CdnNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class CdnOriginGroupPatch
    {
        public CdnOriginGroupPatch() { }
        public Azure.ResourceManager.Cdn.Models.HealthProbeSettings HealthProbeSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Origins { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.ResponseBasedOriginErrorDetectionSettings ResponseBasedOriginErrorDetectionSettings { get { throw null; } set { } }
        public int? TrafficRestorationTimeToHealedOrNewEndpointsInMinutes { get { throw null; } set { } }
    }
    public partial class CdnOriginPatch
    {
        public CdnOriginPatch() { }
        public bool? Enabled { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
        public int? HttpPort { get { throw null; } set { } }
        public int? HttpsPort { get { throw null; } set { } }
        public string OriginHostHeader { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public string PrivateLinkAlias { get { throw null; } set { } }
        public string PrivateLinkApprovalMessage { get { throw null; } set { } }
        public string PrivateLinkLocation { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkResourceId { get { throw null; } set { } }
        public int? Weight { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CdnResourceType : System.IEquatable<Azure.ResourceManager.Cdn.Models.CdnResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CdnResourceType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CdnResourceType MicrosoftCdnProfilesAfdEndpoints { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnResourceType MicrosoftCdnProfilesEndpoints { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CdnResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CdnResourceType left, Azure.ResourceManager.Cdn.Models.CdnResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CdnResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CdnResourceType left, Azure.ResourceManager.Cdn.Models.CdnResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CdnSku
    {
        public CdnSku() { }
        public Azure.ResourceManager.Cdn.Models.CdnSkuName? Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CdnSkuName : System.IEquatable<Azure.ResourceManager.Cdn.Models.CdnSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CdnSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName CustomVerizon { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName PremiumAzureFrontDoor { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName PremiumVerizon { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName Standard955BandWidthChinaCdn { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName StandardAkamai { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName StandardAvgBandWidthChinaCdn { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName StandardAzureFrontDoor { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName StandardChinaCdn { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName StandardMicrosoft { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName StandardPlus955BandWidthChinaCdn { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName StandardPlusAvgBandWidthChinaCdn { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName StandardPlusChinaCdn { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName StandardVerizon { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CdnSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CdnSkuName left, Azure.ResourceManager.Cdn.Models.CdnSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CdnSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CdnSkuName left, Azure.ResourceManager.Cdn.Models.CdnSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CdnUsage
    {
        internal CdnUsage() { }
        public long CurrentValue { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public long Limit { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.CdnUsageResourceName Name { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.UsageUnit Unit { get { throw null; } }
    }
    public partial class CdnUsageResourceName
    {
        internal CdnUsageResourceName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class CdnWebApplicationFirewallPolicyPatch
    {
        public CdnWebApplicationFirewallPolicyPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateDeleteAction : System.IEquatable<Azure.ResourceManager.Cdn.Models.CertificateDeleteAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateDeleteAction(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CertificateDeleteAction NoAction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CertificateDeleteAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CertificateDeleteAction left, Azure.ResourceManager.Cdn.Models.CertificateDeleteAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CertificateDeleteAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CertificateDeleteAction left, Azure.ResourceManager.Cdn.Models.CertificateDeleteAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateUpdateAction : System.IEquatable<Azure.ResourceManager.Cdn.Models.CertificateUpdateAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateUpdateAction(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CertificateUpdateAction NoAction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CertificateUpdateAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CertificateUpdateAction left, Azure.ResourceManager.Cdn.Models.CertificateUpdateAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CertificateUpdateAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CertificateUpdateAction left, Azure.ResourceManager.Cdn.Models.CertificateUpdateAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CidrIPAddress
    {
        public CidrIPAddress() { }
        public string BaseIPAddress { get { throw null; } set { } }
        public int? PrefixLength { get { throw null; } set { } }
    }
    public partial class ClientPortMatchCondition
    {
        public ClientPortMatchCondition(Azure.ResourceManager.Cdn.Models.ClientPortMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.ClientPortOperator @operator) { }
        public Azure.ResourceManager.Cdn.Models.ClientPortMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.ClientPortOperator Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClientPortMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.ClientPortMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClientPortMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ClientPortMatchConditionType ClientPortCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ClientPortMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ClientPortMatchConditionType left, Azure.ResourceManager.Cdn.Models.ClientPortMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ClientPortMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ClientPortMatchConditionType left, Azure.ResourceManager.Cdn.Models.ClientPortMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClientPortOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.ClientPortOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClientPortOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ClientPortOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ClientPortOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ClientPortOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ClientPortOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ClientPortOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ClientPortOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ClientPortOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ClientPortOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ClientPortOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ClientPortOperator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ClientPortOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ClientPortOperator left, Azure.ResourceManager.Cdn.Models.ClientPortOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ClientPortOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ClientPortOperator left, Azure.ResourceManager.Cdn.Models.ClientPortOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Components18OrqelSchemasWafmetricsresponsePropertiesSeriesItemsPropertiesDataItems
    {
        internal Components18OrqelSchemasWafmetricsresponsePropertiesSeriesItemsPropertiesDataItems() { }
        public System.DateTimeOffset? DateOn { get { throw null; } }
        public float? Value { get { throw null; } }
    }
    public partial class Components1Gs0LlpSchemasMetricsresponsePropertiesSeriesItemsPropertiesDataItems
    {
        internal Components1Gs0LlpSchemasMetricsresponsePropertiesSeriesItemsPropertiesDataItems() { }
        public System.DateTimeOffset? DateOn { get { throw null; } }
        public float? Value { get { throw null; } }
    }
    public partial class ComponentsKpo1PjSchemasWafrankingsresponsePropertiesDataItemsPropertiesMetricsItems
    {
        internal ComponentsKpo1PjSchemasWafrankingsresponsePropertiesDataItemsPropertiesMetricsItems() { }
        public string Metric { get { throw null; } }
        public double? Percentage { get { throw null; } }
        public long? Value { get { throw null; } }
    }
    public partial class ContinentsResponse
    {
        internal ContinentsResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.ContinentsResponseContinentsItem> Continents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.ContinentsResponseCountryOrRegionsItem> CountryOrRegions { get { throw null; } }
    }
    public partial class ContinentsResponseContinentsItem
    {
        internal ContinentsResponseContinentsItem() { }
        public string Id { get { throw null; } }
    }
    public partial class ContinentsResponseCountryOrRegionsItem
    {
        internal ContinentsResponseCountryOrRegionsItem() { }
        public string ContinentId { get { throw null; } }
        public string Id { get { throw null; } }
    }
    public partial class CookiesMatchCondition
    {
        public CookiesMatchCondition(Azure.ResourceManager.Cdn.Models.CookiesMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.CookiesOperator @operator) { }
        public Azure.ResourceManager.Cdn.Models.CookiesMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.CookiesOperator Operator { get { throw null; } set { } }
        public string Selector { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CookiesMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.CookiesMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CookiesMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CookiesMatchConditionType CookiesCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CookiesMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CookiesMatchConditionType left, Azure.ResourceManager.Cdn.Models.CookiesMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CookiesMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CookiesMatchConditionType left, Azure.ResourceManager.Cdn.Models.CookiesMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CookiesOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.CookiesOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CookiesOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CookiesOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CookiesOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CookiesOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CookiesOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CookiesOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CookiesOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CookiesOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CookiesOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CookiesOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CookiesOperator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CookiesOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CookiesOperator left, Azure.ResourceManager.Cdn.Models.CookiesOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CookiesOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CookiesOperator left, Azure.ResourceManager.Cdn.Models.CookiesOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomDomainHttpsContent
    {
        public CustomDomainHttpsContent(Azure.ResourceManager.Cdn.Models.ProtocolType protocolType) { }
        public Azure.ResourceManager.Cdn.Models.MinimumTlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.ProtocolType ProtocolType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomDomainResourceState : System.IEquatable<Azure.ResourceManager.Cdn.Models.CustomDomainResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomDomainResourceState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CustomDomainResourceState Active { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomDomainResourceState Creating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomDomainResourceState Deleting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CustomDomainResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CustomDomainResourceState left, Azure.ResourceManager.Cdn.Models.CustomDomainResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CustomDomainResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CustomDomainResourceState left, Azure.ResourceManager.Cdn.Models.CustomDomainResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomerCertificateProperties : Azure.ResourceManager.Cdn.Models.SecretProperties
    {
        public CustomerCertificateProperties(Azure.ResourceManager.Resources.Models.WritableSubResource secretSource) { }
        public string CertificateAuthority { get { throw null; } }
        public string ExpirationDate { get { throw null; } }
        public Azure.Core.ResourceIdentifier SecretSourceId { get { throw null; } set { } }
        public string SecretVersion { get { throw null; } set { } }
        public string Subject { get { throw null; } }
        public System.Collections.Generic.IList<string> SubjectAlternativeNames { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        public bool? UseLatestVersion { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomHttpsAvailabilityState : System.IEquatable<Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomHttpsAvailabilityState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState CertificateDeleted { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState CertificateDeployed { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState DeletingCertificate { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState DeployingCertificate { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState DomainControlValidationRequestApproved { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState DomainControlValidationRequestRejected { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState DomainControlValidationRequestTimedOut { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState IssuingCertificate { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState PendingDomainControlValidationREquestApproval { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState SubmittingDomainControlValidationRequest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState left, Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState left, Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomHttpsProvisioningState : System.IEquatable<Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomHttpsProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState Disabling { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState Enabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState Enabling { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState Failed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState left, Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState left, Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomRule
    {
        public CustomRule(string name, int priority, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.MatchCondition> matchConditions, Azure.ResourceManager.Cdn.Models.ActionType action) { }
        public Azure.ResourceManager.Cdn.Models.ActionType Action { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.CustomRuleEnabledState? EnabledState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.MatchCondition> MatchConditions { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public int Priority { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomRuleEnabledState : System.IEquatable<Azure.ResourceManager.Cdn.Models.CustomRuleEnabledState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomRuleEnabledState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CustomRuleEnabledState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomRuleEnabledState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CustomRuleEnabledState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CustomRuleEnabledState left, Azure.ResourceManager.Cdn.Models.CustomRuleEnabledState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CustomRuleEnabledState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CustomRuleEnabledState left, Azure.ResourceManager.Cdn.Models.CustomRuleEnabledState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeepCreatedOrigin
    {
        public DeepCreatedOrigin(string name) { }
        public bool? Enabled { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
        public int? HttpPort { get { throw null; } set { } }
        public int? HttpsPort { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string OriginHostHeader { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus? PrivateEndpointStatus { get { throw null; } }
        public string PrivateLinkAlias { get { throw null; } set { } }
        public string PrivateLinkApprovalMessage { get { throw null; } set { } }
        public string PrivateLinkLocation { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkResourceId { get { throw null; } set { } }
        public int? Weight { get { throw null; } set { } }
    }
    public partial class DeepCreatedOriginGroup
    {
        public DeepCreatedOriginGroup(string name) { }
        public Azure.ResourceManager.Cdn.Models.HealthProbeSettings HealthProbeSettings { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Origins { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.ResponseBasedOriginErrorDetectionSettings ResponseBasedOriginErrorDetectionSettings { get { throw null; } set { } }
        public int? TrafficRestorationTimeToHealedOrNewEndpointsInMinutes { get { throw null; } set { } }
    }
    public partial class DeliveryRule
    {
        public DeliveryRule(int order, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.DeliveryRuleAction> actions) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.DeliveryRuleAction> Actions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition> Conditions { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public int Order { get { throw null; } set { } }
    }
    public partial class DeliveryRuleAction
    {
        public DeliveryRuleAction() { }
    }
    public partial class DeliveryRuleCacheExpirationAction : Azure.ResourceManager.Cdn.Models.DeliveryRuleAction
    {
        public DeliveryRuleCacheExpirationAction(Azure.ResourceManager.Cdn.Models.CacheExpirationActionProperties properties) { }
        public Azure.ResourceManager.Cdn.Models.CacheExpirationActionProperties Properties { get { throw null; } set { } }
    }
    public partial class DeliveryRuleCacheKeyQueryStringAction : Azure.ResourceManager.Cdn.Models.DeliveryRuleAction
    {
        public DeliveryRuleCacheKeyQueryStringAction(Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionProperties properties) { }
        public Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionProperties Properties { get { throw null; } set { } }
    }
    public partial class DeliveryRuleClientPortCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition
    {
        public DeliveryRuleClientPortCondition(Azure.ResourceManager.Cdn.Models.ClientPortMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.ClientPortMatchCondition Properties { get { throw null; } set { } }
    }
    public partial class DeliveryRuleCondition
    {
        public DeliveryRuleCondition() { }
    }
    public partial class DeliveryRuleCookiesCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition
    {
        public DeliveryRuleCookiesCondition(Azure.ResourceManager.Cdn.Models.CookiesMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.CookiesMatchCondition Properties { get { throw null; } set { } }
    }
    public partial class DeliveryRuleHostNameCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition
    {
        public DeliveryRuleHostNameCondition(Azure.ResourceManager.Cdn.Models.HostNameMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.HostNameMatchCondition Properties { get { throw null; } set { } }
    }
    public partial class DeliveryRuleHttpVersionCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition
    {
        public DeliveryRuleHttpVersionCondition(Azure.ResourceManager.Cdn.Models.HttpVersionMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.HttpVersionMatchCondition Properties { get { throw null; } set { } }
    }
    public partial class DeliveryRuleIsDeviceCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition
    {
        public DeliveryRuleIsDeviceCondition(Azure.ResourceManager.Cdn.Models.IsDeviceMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.IsDeviceMatchCondition Properties { get { throw null; } set { } }
    }
    public partial class DeliveryRulePostArgsCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition
    {
        public DeliveryRulePostArgsCondition(Azure.ResourceManager.Cdn.Models.PostArgsMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.PostArgsMatchCondition Properties { get { throw null; } set { } }
    }
    public partial class DeliveryRuleQueryStringCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition
    {
        public DeliveryRuleQueryStringCondition(Azure.ResourceManager.Cdn.Models.QueryStringMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.QueryStringMatchCondition Properties { get { throw null; } set { } }
    }
    public partial class DeliveryRuleRemoteAddressCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition
    {
        public DeliveryRuleRemoteAddressCondition(Azure.ResourceManager.Cdn.Models.RemoteAddressMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.RemoteAddressMatchCondition Properties { get { throw null; } set { } }
    }
    public partial class DeliveryRuleRequestBodyCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition
    {
        public DeliveryRuleRequestBodyCondition(Azure.ResourceManager.Cdn.Models.RequestBodyMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.RequestBodyMatchCondition Properties { get { throw null; } set { } }
    }
    public partial class DeliveryRuleRequestHeaderAction : Azure.ResourceManager.Cdn.Models.DeliveryRuleAction
    {
        public DeliveryRuleRequestHeaderAction(Azure.ResourceManager.Cdn.Models.HeaderActionProperties properties) { }
        public Azure.ResourceManager.Cdn.Models.HeaderActionProperties Properties { get { throw null; } set { } }
    }
    public partial class DeliveryRuleRequestHeaderCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition
    {
        public DeliveryRuleRequestHeaderCondition(Azure.ResourceManager.Cdn.Models.RequestHeaderMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.RequestHeaderMatchCondition Properties { get { throw null; } set { } }
    }
    public partial class DeliveryRuleRequestMethodCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition
    {
        public DeliveryRuleRequestMethodCondition(Azure.ResourceManager.Cdn.Models.RequestMethodMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.RequestMethodMatchCondition Properties { get { throw null; } set { } }
    }
    public partial class DeliveryRuleRequestSchemeCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition
    {
        public DeliveryRuleRequestSchemeCondition(Azure.ResourceManager.Cdn.Models.RequestSchemeMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.RequestSchemeMatchCondition Properties { get { throw null; } set { } }
    }
    public partial class DeliveryRuleRequestUriCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition
    {
        public DeliveryRuleRequestUriCondition(Azure.ResourceManager.Cdn.Models.RequestUriMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.RequestUriMatchCondition Properties { get { throw null; } set { } }
    }
    public partial class DeliveryRuleResponseHeaderAction : Azure.ResourceManager.Cdn.Models.DeliveryRuleAction
    {
        public DeliveryRuleResponseHeaderAction(Azure.ResourceManager.Cdn.Models.HeaderActionProperties properties) { }
        public Azure.ResourceManager.Cdn.Models.HeaderActionProperties Properties { get { throw null; } set { } }
    }
    public partial class DeliveryRuleRouteConfigurationOverrideAction : Azure.ResourceManager.Cdn.Models.DeliveryRuleAction
    {
        public DeliveryRuleRouteConfigurationOverrideAction(Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionProperties properties) { }
        public Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionProperties Properties { get { throw null; } set { } }
    }
    public partial class DeliveryRuleServerPortCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition
    {
        public DeliveryRuleServerPortCondition(Azure.ResourceManager.Cdn.Models.ServerPortMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.ServerPortMatchCondition Properties { get { throw null; } set { } }
    }
    public partial class DeliveryRuleSocketAddressCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition
    {
        public DeliveryRuleSocketAddressCondition(Azure.ResourceManager.Cdn.Models.SocketAddressMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.SocketAddressMatchCondition Properties { get { throw null; } set { } }
    }
    public partial class DeliveryRuleSslProtocolCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition
    {
        public DeliveryRuleSslProtocolCondition(Azure.ResourceManager.Cdn.Models.SslProtocolMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.SslProtocolMatchCondition Properties { get { throw null; } set { } }
    }
    public partial class DeliveryRuleUriFileExtensionCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition
    {
        public DeliveryRuleUriFileExtensionCondition(Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchCondition Properties { get { throw null; } set { } }
    }
    public partial class DeliveryRuleUriFileNameCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition
    {
        public DeliveryRuleUriFileNameCondition(Azure.ResourceManager.Cdn.Models.UriFileNameMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.UriFileNameMatchCondition Properties { get { throw null; } set { } }
    }
    public partial class DeliveryRuleUriPathCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition
    {
        public DeliveryRuleUriPathCondition(Azure.ResourceManager.Cdn.Models.UriPathMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.UriPathMatchCondition Properties { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DestinationProtocol : System.IEquatable<Azure.ResourceManager.Cdn.Models.DestinationProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DestinationProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.DestinationProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DestinationProtocol Https { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DestinationProtocol MatchRequest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.DestinationProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.DestinationProtocol left, Azure.ResourceManager.Cdn.Models.DestinationProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.DestinationProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.DestinationProtocol left, Azure.ResourceManager.Cdn.Models.DestinationProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainNameLabelScope : System.IEquatable<Azure.ResourceManager.Cdn.Models.DomainNameLabelScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainNameLabelScope(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.DomainNameLabelScope NoReuse { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DomainNameLabelScope ResourceGroupReuse { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DomainNameLabelScope SubscriptionReuse { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DomainNameLabelScope TenantReuse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.DomainNameLabelScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.DomainNameLabelScope left, Azure.ResourceManager.Cdn.Models.DomainNameLabelScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.DomainNameLabelScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.DomainNameLabelScope left, Azure.ResourceManager.Cdn.Models.DomainNameLabelScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DomainValidationProperties
    {
        internal DomainValidationProperties() { }
        public string ExpirationDate { get { throw null; } }
        public string ValidationToken { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainValidationState : System.IEquatable<Azure.ResourceManager.Cdn.Models.DomainValidationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainValidationState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.DomainValidationState Approved { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DomainValidationState InternalError { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DomainValidationState Pending { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DomainValidationState PendingRevalidation { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DomainValidationState RefreshingValidationToken { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DomainValidationState Rejected { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DomainValidationState Submitting { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DomainValidationState TimedOut { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DomainValidationState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.DomainValidationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.DomainValidationState left, Azure.ResourceManager.Cdn.Models.DomainValidationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.DomainValidationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.DomainValidationState left, Azure.ResourceManager.Cdn.Models.DomainValidationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeNode : Azure.ResourceManager.Models.ResourceData
    {
        public EdgeNode() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.IPAddressGroup> IPAddressGroups { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnabledState : System.IEquatable<Azure.ResourceManager.Cdn.Models.EnabledState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnabledState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.EnabledState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.EnabledState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.EnabledState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.EnabledState left, Azure.ResourceManager.Cdn.Models.EnabledState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.EnabledState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.EnabledState left, Azure.ResourceManager.Cdn.Models.EnabledState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EndpointDeliveryPolicy
    {
        public EndpointDeliveryPolicy(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.DeliveryRule> rules) { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.DeliveryRule> Rules { get { throw null; } }
    }
    public partial class EndpointNameAvailabilityContent
    {
        public EndpointNameAvailabilityContent(string name, Azure.ResourceManager.Cdn.Models.CdnResourceType resourceType) { }
        public Azure.ResourceManager.Cdn.Models.DomainNameLabelScope? AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.CdnResourceType ResourceType { get { throw null; } }
    }
    public partial class EndpointNameAvailabilityResult
    {
        internal EndpointNameAvailabilityResult() { }
        public string AvailableHostname { get { throw null; } }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointProvisioningState : System.IEquatable<Azure.ResourceManager.Cdn.Models.EndpointProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.EndpointProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.EndpointProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.EndpointProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.EndpointProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.EndpointProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.EndpointProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.EndpointProvisioningState left, Azure.ResourceManager.Cdn.Models.EndpointProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.EndpointProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.EndpointProvisioningState left, Azure.ResourceManager.Cdn.Models.EndpointProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointResourceState : System.IEquatable<Azure.ResourceManager.Cdn.Models.EndpointResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointResourceState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.EndpointResourceState Creating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.EndpointResourceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.EndpointResourceState Running { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.EndpointResourceState Starting { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.EndpointResourceState Stopped { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.EndpointResourceState Stopping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.EndpointResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.EndpointResourceState left, Azure.ResourceManager.Cdn.Models.EndpointResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.EndpointResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.EndpointResourceState left, Azure.ResourceManager.Cdn.Models.EndpointResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ForwardingProtocol : System.IEquatable<Azure.ResourceManager.Cdn.Models.ForwardingProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ForwardingProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ForwardingProtocol HttpOnly { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ForwardingProtocol HttpsOnly { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ForwardingProtocol MatchRequest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ForwardingProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ForwardingProtocol left, Azure.ResourceManager.Cdn.Models.ForwardingProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ForwardingProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ForwardingProtocol left, Azure.ResourceManager.Cdn.Models.ForwardingProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GeoFilter
    {
        public GeoFilter(string relativePath, Azure.ResourceManager.Cdn.Models.GeoFilterActions action, System.Collections.Generic.IEnumerable<string> countryCodes) { }
        public Azure.ResourceManager.Cdn.Models.GeoFilterActions Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> CountryCodes { get { throw null; } }
        public string RelativePath { get { throw null; } set { } }
    }
    public enum GeoFilterActions
    {
        Block = 0,
        Allow = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HeaderAction : System.IEquatable<Azure.ResourceManager.Cdn.Models.HeaderAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HeaderAction(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.HeaderAction Append { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.HeaderAction Delete { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.HeaderAction Overwrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.HeaderAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.HeaderAction left, Azure.ResourceManager.Cdn.Models.HeaderAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.HeaderAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.HeaderAction left, Azure.ResourceManager.Cdn.Models.HeaderAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HeaderActionProperties
    {
        public HeaderActionProperties(Azure.ResourceManager.Cdn.Models.HeaderActionType actionType, Azure.ResourceManager.Cdn.Models.HeaderAction headerAction, string headerName) { }
        public Azure.ResourceManager.Cdn.Models.HeaderActionType ActionType { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.HeaderAction HeaderAction { get { throw null; } set { } }
        public string HeaderName { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HeaderActionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.HeaderActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HeaderActionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.HeaderActionType HeaderAction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.HeaderActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.HeaderActionType left, Azure.ResourceManager.Cdn.Models.HeaderActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.HeaderActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.HeaderActionType left, Azure.ResourceManager.Cdn.Models.HeaderActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum HealthProbeRequestType
    {
        NotSet = 0,
        Get = 1,
        Head = 2,
    }
    public partial class HealthProbeSettings
    {
        public HealthProbeSettings() { }
        public int? ProbeIntervalInSeconds { get { throw null; } set { } }
        public string ProbePath { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.ProbeProtocol? ProbeProtocol { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.HealthProbeRequestType? ProbeRequestType { get { throw null; } set { } }
    }
    public partial class HostNameAvailabilityContent
    {
        public HostNameAvailabilityContent(string hostName) { }
        public string HostName { get { throw null; } }
    }
    public partial class HostNameMatchCondition
    {
        public HostNameMatchCondition(Azure.ResourceManager.Cdn.Models.HostNameMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.HostNameOperator @operator) { }
        public Azure.ResourceManager.Cdn.Models.HostNameMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.HostNameOperator Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HostNameMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.HostNameMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostNameMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.HostNameMatchConditionType HostNameCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.HostNameMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.HostNameMatchConditionType left, Azure.ResourceManager.Cdn.Models.HostNameMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.HostNameMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.HostNameMatchConditionType left, Azure.ResourceManager.Cdn.Models.HostNameMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HostNameOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.HostNameOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostNameOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.HostNameOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.HostNameOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.HostNameOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.HostNameOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.HostNameOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.HostNameOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.HostNameOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.HostNameOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.HostNameOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.HostNameOperator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.HostNameOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.HostNameOperator left, Azure.ResourceManager.Cdn.Models.HostNameOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.HostNameOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.HostNameOperator left, Azure.ResourceManager.Cdn.Models.HostNameOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HttpErrorRange
    {
        public HttpErrorRange() { }
        public int? Begin { get { throw null; } set { } }
        public int? End { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HttpsRedirect : System.IEquatable<Azure.ResourceManager.Cdn.Models.HttpsRedirect>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HttpsRedirect(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.HttpsRedirect Disabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.HttpsRedirect Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.HttpsRedirect other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.HttpsRedirect left, Azure.ResourceManager.Cdn.Models.HttpsRedirect right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.HttpsRedirect (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.HttpsRedirect left, Azure.ResourceManager.Cdn.Models.HttpsRedirect right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HttpVersionMatchCondition
    {
        public HttpVersionMatchCondition(Azure.ResourceManager.Cdn.Models.HttpVersionMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.HttpVersionOperator @operator) { }
        public Azure.ResourceManager.Cdn.Models.HttpVersionMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.HttpVersionOperator Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HttpVersionMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.HttpVersionMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HttpVersionMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.HttpVersionMatchConditionType HttpVersionCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.HttpVersionMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.HttpVersionMatchConditionType left, Azure.ResourceManager.Cdn.Models.HttpVersionMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.HttpVersionMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.HttpVersionMatchConditionType left, Azure.ResourceManager.Cdn.Models.HttpVersionMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HttpVersionOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.HttpVersionOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HttpVersionOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.HttpVersionOperator Equal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.HttpVersionOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.HttpVersionOperator left, Azure.ResourceManager.Cdn.Models.HttpVersionOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.HttpVersionOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.HttpVersionOperator left, Azure.ResourceManager.Cdn.Models.HttpVersionOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPAddressGroup
    {
        public IPAddressGroup() { }
        public string DeliveryRegion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.CidrIPAddress> IPv4Addresses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.CidrIPAddress> IPv6Addresses { get { throw null; } }
    }
    public partial class IsDeviceMatchCondition
    {
        public IsDeviceMatchCondition(Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.IsDeviceOperator @operator) { }
        public Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionMatchValue> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.IsDeviceOperator Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsDeviceMatchConditionMatchValue : System.IEquatable<Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionMatchValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsDeviceMatchConditionMatchValue(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionMatchValue Desktop { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionMatchValue Mobile { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionMatchValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionMatchValue left, Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionMatchValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionMatchValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionMatchValue left, Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionMatchValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsDeviceMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsDeviceMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionType IsDeviceCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionType left, Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionType left, Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsDeviceOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.IsDeviceOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsDeviceOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.IsDeviceOperator Equal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.IsDeviceOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.IsDeviceOperator left, Azure.ResourceManager.Cdn.Models.IsDeviceOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.IsDeviceOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.IsDeviceOperator left, Azure.ResourceManager.Cdn.Models.IsDeviceOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultCertificateSource
    {
        public KeyVaultCertificateSource(Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSourceType sourceType, string subscriptionId, string resourceGroupName, string vaultName, string secretName, Azure.ResourceManager.Cdn.Models.CertificateUpdateAction updateRule, Azure.ResourceManager.Cdn.Models.CertificateDeleteAction deleteRule) { }
        public Azure.ResourceManager.Cdn.Models.CertificateDeleteAction DeleteRule { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } set { } }
        public string SecretName { get { throw null; } set { } }
        public string SecretVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSourceType SourceType { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.CertificateUpdateAction UpdateRule { get { throw null; } set { } }
        public string VaultName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultCertificateSourceType : System.IEquatable<Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultCertificateSourceType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSourceType KeyVaultCertificateSource { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSourceType left, Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSourceType left, Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultSigningKey
    {
        public KeyVaultSigningKey(Azure.ResourceManager.Cdn.Models.KeyVaultSigningKeyType keyType, string subscriptionId, string resourceGroupName, string vaultName, string secretName, string secretVersion) { }
        public Azure.ResourceManager.Cdn.Models.KeyVaultSigningKeyType KeyType { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } set { } }
        public string SecretName { get { throw null; } set { } }
        public string SecretVersion { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public string VaultName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultSigningKeyType : System.IEquatable<Azure.ResourceManager.Cdn.Models.KeyVaultSigningKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultSigningKeyType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.KeyVaultSigningKeyType KeyVaultSigningKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.KeyVaultSigningKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.KeyVaultSigningKeyType left, Azure.ResourceManager.Cdn.Models.KeyVaultSigningKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.KeyVaultSigningKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.KeyVaultSigningKeyType left, Azure.ResourceManager.Cdn.Models.KeyVaultSigningKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkToDefaultDomain : System.IEquatable<Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkToDefaultDomain(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain Disabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain left, Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain left, Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LoadBalancingSettings
    {
        public LoadBalancingSettings() { }
        public int? AdditionalLatencyInMilliseconds { get { throw null; } set { } }
        public int? SampleSize { get { throw null; } set { } }
        public int? SuccessfulSamplesRequired { get { throw null; } set { } }
    }
    public partial class LoadContent
    {
        public LoadContent(System.Collections.Generic.IEnumerable<string> contentPaths) { }
        public System.Collections.Generic.IList<string> ContentPaths { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogMetric : System.IEquatable<Azure.ResourceManager.Cdn.Models.LogMetric>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogMetric(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.LogMetric ClientRequestBandwidth { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogMetric ClientRequestCount { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogMetric ClientRequestTraffic { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogMetric OriginRequestBandwidth { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogMetric OriginRequestTraffic { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogMetric TotalLatency { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.LogMetric other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.LogMetric left, Azure.ResourceManager.Cdn.Models.LogMetric right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.LogMetric (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.LogMetric left, Azure.ResourceManager.Cdn.Models.LogMetric right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogMetricsGranularity : System.IEquatable<Azure.ResourceManager.Cdn.Models.LogMetricsGranularity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogMetricsGranularity(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.LogMetricsGranularity P1D { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogMetricsGranularity PT1H { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogMetricsGranularity PT5M { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.LogMetricsGranularity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.LogMetricsGranularity left, Azure.ResourceManager.Cdn.Models.LogMetricsGranularity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.LogMetricsGranularity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.LogMetricsGranularity left, Azure.ResourceManager.Cdn.Models.LogMetricsGranularity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogMetricsGroupBy : System.IEquatable<Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogMetricsGroupBy(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy CacheStatus { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy CountryOrRegion { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy CustomDomain { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy HttpStatusCode { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy Protocol { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy left, Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy left, Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogRanking : System.IEquatable<Azure.ResourceManager.Cdn.Models.LogRanking>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogRanking(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.LogRanking Browser { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogRanking CountryOrRegion { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogRanking Referrer { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogRanking Uri { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogRanking UserAgent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.LogRanking other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.LogRanking left, Azure.ResourceManager.Cdn.Models.LogRanking right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.LogRanking (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.LogRanking left, Azure.ResourceManager.Cdn.Models.LogRanking right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogRankingMetric : System.IEquatable<Azure.ResourceManager.Cdn.Models.LogRankingMetric>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogRankingMetric(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.LogRankingMetric ClientRequestCount { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogRankingMetric ClientRequestTraffic { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogRankingMetric ErrorCount { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogRankingMetric HitCount { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogRankingMetric MissCount { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogRankingMetric UserErrorCount { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.LogRankingMetric other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.LogRankingMetric left, Azure.ResourceManager.Cdn.Models.LogRankingMetric right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.LogRankingMetric (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.LogRankingMetric left, Azure.ResourceManager.Cdn.Models.LogRankingMetric right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedCertificateProperties : Azure.ResourceManager.Cdn.Models.SecretProperties
    {
        public ManagedCertificateProperties() { }
        public string ExpirationDate { get { throw null; } }
        public string Subject { get { throw null; } }
    }
    public partial class ManagedRuleDefinition
    {
        internal ManagedRuleDefinition() { }
        public string Description { get { throw null; } }
        public string RuleId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedRuleEnabledState : System.IEquatable<Azure.ResourceManager.Cdn.Models.ManagedRuleEnabledState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedRuleEnabledState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ManagedRuleEnabledState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ManagedRuleEnabledState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ManagedRuleEnabledState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ManagedRuleEnabledState left, Azure.ResourceManager.Cdn.Models.ManagedRuleEnabledState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ManagedRuleEnabledState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ManagedRuleEnabledState left, Azure.ResourceManager.Cdn.Models.ManagedRuleEnabledState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedRuleGroupDefinition
    {
        internal ManagedRuleGroupDefinition() { }
        public string Description { get { throw null; } }
        public string RuleGroupName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.ManagedRuleDefinition> Rules { get { throw null; } }
    }
    public partial class ManagedRuleGroupOverride
    {
        public ManagedRuleGroupOverride(string ruleGroupName) { }
        public string RuleGroupName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.ManagedRuleOverride> Rules { get { throw null; } }
    }
    public partial class ManagedRuleOverride
    {
        public ManagedRuleOverride(string ruleId) { }
        public Azure.ResourceManager.Cdn.Models.ActionType? Action { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.ManagedRuleEnabledState? EnabledState { get { throw null; } set { } }
        public string RuleId { get { throw null; } set { } }
    }
    public partial class ManagedRuleSet
    {
        public ManagedRuleSet(string ruleSetType, string ruleSetVersion) { }
        public int? AnomalyScore { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.ManagedRuleGroupOverride> RuleGroupOverrides { get { throw null; } }
        public string RuleSetType { get { throw null; } set { } }
        public string RuleSetVersion { get { throw null; } set { } }
    }
    public partial class ManagedRuleSetDefinition : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedRuleSetDefinition() { }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.ManagedRuleGroupDefinition> RuleGroups { get { throw null; } }
        public string RuleSetType { get { throw null; } }
        public string RuleSetVersion { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.CdnSkuName? SkuName { get { throw null; } set { } }
    }
    public partial class MatchCondition
    {
        public MatchCondition(Azure.ResourceManager.Cdn.Models.WafMatchVariable matchVariable, Azure.ResourceManager.Cdn.Models.MatchOperator @operator, System.Collections.Generic.IEnumerable<string> matchValue) { }
        public System.Collections.Generic.IList<string> MatchValue { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.WafMatchVariable MatchVariable { get { throw null; } set { } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.MatchOperator Operator { get { throw null; } set { } }
        public string Selector { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.TransformType> Transforms { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MatchOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.MatchOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MatchOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.MatchOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MatchOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MatchOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MatchOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MatchOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MatchOperator GeoMatch { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MatchOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MatchOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MatchOperator IPMatch { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MatchOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MatchOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MatchOperator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.MatchOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.MatchOperator left, Azure.ResourceManager.Cdn.Models.MatchOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.MatchOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.MatchOperator left, Azure.ResourceManager.Cdn.Models.MatchOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MatchProcessingBehavior : System.IEquatable<Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MatchProcessingBehavior(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior Continue { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior Stop { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior left, Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior left, Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetricsResponse
    {
        internal MetricsResponse() { }
        public System.DateTimeOffset? DateTimeBegin { get { throw null; } }
        public System.DateTimeOffset? DateTimeEnd { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.MetricsResponseGranularity? Granularity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItem> Series { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricsResponseGranularity : System.IEquatable<Azure.ResourceManager.Cdn.Models.MetricsResponseGranularity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricsResponseGranularity(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.MetricsResponseGranularity P1D { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MetricsResponseGranularity PT1H { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MetricsResponseGranularity PT5M { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.MetricsResponseGranularity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.MetricsResponseGranularity left, Azure.ResourceManager.Cdn.Models.MetricsResponseGranularity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.MetricsResponseGranularity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.MetricsResponseGranularity left, Azure.ResourceManager.Cdn.Models.MetricsResponseGranularity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetricsResponseSeriesItem
    {
        internal MetricsResponseSeriesItem() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.Components1Gs0LlpSchemasMetricsresponsePropertiesSeriesItemsPropertiesDataItems> Data { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesPropertiesItemsItem> Groups { get { throw null; } }
        public string Metric { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit? Unit { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricsResponseSeriesItemUnit : System.IEquatable<Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricsResponseSeriesItemUnit(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit BitsPerSecond { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit Bytes { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit Count { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit MilliSeconds { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit left, Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit left, Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetricsResponseSeriesPropertiesItemsItem
    {
        internal MetricsResponseSeriesPropertiesItemsItem() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public enum MinimumTlsVersion
    {
        None = 0,
        Tls1_0 = 1,
        Tls1_2 = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OptimizationType : System.IEquatable<Azure.ResourceManager.Cdn.Models.OptimizationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OptimizationType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.OptimizationType DynamicSiteAcceleration { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OptimizationType GeneralMediaStreaming { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OptimizationType GeneralWebDelivery { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OptimizationType LargeFileDownload { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OptimizationType VideoOnDemandMediaStreaming { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.OptimizationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.OptimizationType left, Azure.ResourceManager.Cdn.Models.OptimizationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.OptimizationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.OptimizationType left, Azure.ResourceManager.Cdn.Models.OptimizationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OriginGroupOverride
    {
        public OriginGroupOverride() { }
        public Azure.ResourceManager.Cdn.Models.ForwardingProtocol? ForwardingProtocol { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier OriginGroupId { get { throw null; } set { } }
    }
    public partial class OriginGroupOverrideAction : Azure.ResourceManager.Cdn.Models.DeliveryRuleAction
    {
        public OriginGroupOverrideAction(Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionProperties properties) { }
        public Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionProperties Properties { get { throw null; } set { } }
    }
    public partial class OriginGroupOverrideActionProperties
    {
        public OriginGroupOverrideActionProperties(Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionType actionType, Azure.ResourceManager.Resources.Models.WritableSubResource originGroup) { }
        public Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionType ActionType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier OriginGroupId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OriginGroupOverrideActionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OriginGroupOverrideActionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionType OriginGroupOverrideAction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionType left, Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionType left, Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OriginGroupProvisioningState : System.IEquatable<Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OriginGroupProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState left, Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState left, Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OriginGroupResourceState : System.IEquatable<Azure.ResourceManager.Cdn.Models.OriginGroupResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OriginGroupResourceState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.OriginGroupResourceState Active { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginGroupResourceState Creating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginGroupResourceState Deleting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.OriginGroupResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.OriginGroupResourceState left, Azure.ResourceManager.Cdn.Models.OriginGroupResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.OriginGroupResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.OriginGroupResourceState left, Azure.ResourceManager.Cdn.Models.OriginGroupResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OriginProvisioningState : System.IEquatable<Azure.ResourceManager.Cdn.Models.OriginProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OriginProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.OriginProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.OriginProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.OriginProvisioningState left, Azure.ResourceManager.Cdn.Models.OriginProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.OriginProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.OriginProvisioningState left, Azure.ResourceManager.Cdn.Models.OriginProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OriginResourceState : System.IEquatable<Azure.ResourceManager.Cdn.Models.OriginResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OriginResourceState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.OriginResourceState Active { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginResourceState Creating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginResourceState Deleting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.OriginResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.OriginResourceState left, Azure.ResourceManager.Cdn.Models.OriginResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.OriginResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.OriginResourceState left, Azure.ResourceManager.Cdn.Models.OriginResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ParamIndicator : System.IEquatable<Azure.ResourceManager.Cdn.Models.ParamIndicator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParamIndicator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ParamIndicator Expires { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ParamIndicator KeyId { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ParamIndicator Signature { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ParamIndicator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ParamIndicator left, Azure.ResourceManager.Cdn.Models.ParamIndicator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ParamIndicator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ParamIndicator left, Azure.ResourceManager.Cdn.Models.ParamIndicator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyEnabledState : System.IEquatable<Azure.ResourceManager.Cdn.Models.PolicyEnabledState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyEnabledState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.PolicyEnabledState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PolicyEnabledState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.PolicyEnabledState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.PolicyEnabledState left, Azure.ResourceManager.Cdn.Models.PolicyEnabledState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.PolicyEnabledState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.PolicyEnabledState left, Azure.ResourceManager.Cdn.Models.PolicyEnabledState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyMode : System.IEquatable<Azure.ResourceManager.Cdn.Models.PolicyMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyMode(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.PolicyMode Detection { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PolicyMode Prevention { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.PolicyMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.PolicyMode left, Azure.ResourceManager.Cdn.Models.PolicyMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.PolicyMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.PolicyMode left, Azure.ResourceManager.Cdn.Models.PolicyMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyResourceState : System.IEquatable<Azure.ResourceManager.Cdn.Models.PolicyResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyResourceState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.PolicyResourceState Creating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PolicyResourceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PolicyResourceState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PolicyResourceState Disabling { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PolicyResourceState Enabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PolicyResourceState Enabling { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.PolicyResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.PolicyResourceState left, Azure.ResourceManager.Cdn.Models.PolicyResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.PolicyResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.PolicyResourceState left, Azure.ResourceManager.Cdn.Models.PolicyResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicySettings
    {
        public PolicySettings() { }
        public string DefaultCustomBlockResponseBody { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode? DefaultCustomBlockResponseStatusCode { get { throw null; } set { } }
        public System.Uri DefaultRedirectUri { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.PolicyEnabledState? EnabledState { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.PolicyMode? Mode { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicySettingsDefaultCustomBlockResponseStatusCode : System.IEquatable<Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode>
    {
        private readonly int _dummyPrimitive;
        public PolicySettingsDefaultCustomBlockResponseStatusCode(int value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode FourHundredFive { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode FourHundredSix { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode FourHundredThree { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode FourHundredTwentyNine { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode TwoHundred { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode left, Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode (int value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode left, Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostArgsMatchCondition
    {
        public PostArgsMatchCondition(Azure.ResourceManager.Cdn.Models.PostArgsMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.PostArgsOperator @operator) { }
        public Azure.ResourceManager.Cdn.Models.PostArgsMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.PostArgsOperator Operator { get { throw null; } set { } }
        public string Selector { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostArgsMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.PostArgsMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostArgsMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.PostArgsMatchConditionType PostArgsCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.PostArgsMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.PostArgsMatchConditionType left, Azure.ResourceManager.Cdn.Models.PostArgsMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.PostArgsMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.PostArgsMatchConditionType left, Azure.ResourceManager.Cdn.Models.PostArgsMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostArgsOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.PostArgsOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostArgsOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.PostArgsOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PostArgsOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PostArgsOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PostArgsOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PostArgsOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PostArgsOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PostArgsOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PostArgsOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PostArgsOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PostArgsOperator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.PostArgsOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.PostArgsOperator left, Azure.ResourceManager.Cdn.Models.PostArgsOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.PostArgsOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.PostArgsOperator left, Azure.ResourceManager.Cdn.Models.PostArgsOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PreTransformCategory : System.IEquatable<Azure.ResourceManager.Cdn.Models.PreTransformCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PreTransformCategory(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.PreTransformCategory Lowercase { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PreTransformCategory RemoveNulls { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PreTransformCategory Trim { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PreTransformCategory Uppercase { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PreTransformCategory UriDecode { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PreTransformCategory UriEncode { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.PreTransformCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.PreTransformCategory left, Azure.ResourceManager.Cdn.Models.PreTransformCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.PreTransformCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.PreTransformCategory left, Azure.ResourceManager.Cdn.Models.PreTransformCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointStatus : System.IEquatable<Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointStatus(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus Rejected { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus left, Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus left, Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ProbeProtocol
    {
        NotSet = 0,
        Http = 1,
        Https = 2,
    }
    public partial class ProfilePatch
    {
        public ProfilePatch() { }
        public int? OriginResponseTimeoutSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProfileProvisioningState : System.IEquatable<Azure.ResourceManager.Cdn.Models.ProfileProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProfileProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ProfileProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ProfileProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ProfileProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ProfileProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ProfileProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ProfileProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ProfileProvisioningState left, Azure.ResourceManager.Cdn.Models.ProfileProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ProfileProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ProfileProvisioningState left, Azure.ResourceManager.Cdn.Models.ProfileProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProfileResourceState : System.IEquatable<Azure.ResourceManager.Cdn.Models.ProfileResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProfileResourceState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ProfileResourceState Active { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ProfileResourceState Creating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ProfileResourceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ProfileResourceState Disabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ProfileResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ProfileResourceState left, Azure.ResourceManager.Cdn.Models.ProfileResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ProfileResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ProfileResourceState left, Azure.ResourceManager.Cdn.Models.ProfileResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProtocolType : System.IEquatable<Azure.ResourceManager.Cdn.Models.ProtocolType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProtocolType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ProtocolType IPBased { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ProtocolType ServerNameIndication { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ProtocolType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ProtocolType left, Azure.ResourceManager.Cdn.Models.ProtocolType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ProtocolType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ProtocolType left, Azure.ResourceManager.Cdn.Models.ProtocolType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Cdn.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ProvisioningState left, Azure.ResourceManager.Cdn.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ProvisioningState left, Azure.ResourceManager.Cdn.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PurgeContent
    {
        public PurgeContent(System.Collections.Generic.IEnumerable<string> contentPaths) { }
        public System.Collections.Generic.IList<string> ContentPaths { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueryStringBehavior : System.IEquatable<Azure.ResourceManager.Cdn.Models.QueryStringBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueryStringBehavior(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.QueryStringBehavior Exclude { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.QueryStringBehavior ExcludeAll { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.QueryStringBehavior Include { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.QueryStringBehavior IncludeAll { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.QueryStringBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.QueryStringBehavior left, Azure.ResourceManager.Cdn.Models.QueryStringBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.QueryStringBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.QueryStringBehavior left, Azure.ResourceManager.Cdn.Models.QueryStringBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum QueryStringCachingBehavior
    {
        NotSet = 0,
        IgnoreQueryString = 1,
        BypassCaching = 2,
        UseQueryString = 3,
    }
    public partial class QueryStringMatchCondition
    {
        public QueryStringMatchCondition(Azure.ResourceManager.Cdn.Models.QueryStringMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.QueryStringOperator @operator) { }
        public Azure.ResourceManager.Cdn.Models.QueryStringMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.QueryStringOperator Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueryStringMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.QueryStringMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueryStringMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.QueryStringMatchConditionType QueryStringCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.QueryStringMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.QueryStringMatchConditionType left, Azure.ResourceManager.Cdn.Models.QueryStringMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.QueryStringMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.QueryStringMatchConditionType left, Azure.ResourceManager.Cdn.Models.QueryStringMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueryStringOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.QueryStringOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueryStringOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.QueryStringOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.QueryStringOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.QueryStringOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.QueryStringOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.QueryStringOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.QueryStringOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.QueryStringOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.QueryStringOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.QueryStringOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.QueryStringOperator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.QueryStringOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.QueryStringOperator left, Azure.ResourceManager.Cdn.Models.QueryStringOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.QueryStringOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.QueryStringOperator left, Azure.ResourceManager.Cdn.Models.QueryStringOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RankingsResponse
    {
        internal RankingsResponse() { }
        public System.DateTimeOffset? DateTimeBegin { get { throw null; } }
        public System.DateTimeOffset? DateTimeEnd { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesItem> Tables { get { throw null; } }
    }
    public partial class RankingsResponseTablesItem
    {
        internal RankingsResponseTablesItem() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsItem> Data { get { throw null; } }
        public string Ranking { get { throw null; } }
    }
    public partial class RankingsResponseTablesPropertiesItemsItem
    {
        internal RankingsResponseTablesPropertiesItemsItem() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsMetricsItem> Metrics { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class RankingsResponseTablesPropertiesItemsMetricsItem
    {
        internal RankingsResponseTablesPropertiesItemsMetricsItem() { }
        public string Metric { get { throw null; } }
        public float? Percentage { get { throw null; } }
        public long? Value { get { throw null; } }
    }
    public partial class RateLimitRule : Azure.ResourceManager.Cdn.Models.CustomRule
    {
        public RateLimitRule(string name, int priority, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.MatchCondition> matchConditions, Azure.ResourceManager.Cdn.Models.ActionType action, int rateLimitThreshold, int rateLimitDurationInMinutes) : base (default(string), default(int), default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.MatchCondition>), default(Azure.ResourceManager.Cdn.Models.ActionType)) { }
        public int RateLimitDurationInMinutes { get { throw null; } set { } }
        public int RateLimitThreshold { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedirectType : System.IEquatable<Azure.ResourceManager.Cdn.Models.RedirectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedirectType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RedirectType Found { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RedirectType Moved { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RedirectType PermanentRedirect { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RedirectType TemporaryRedirect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RedirectType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RedirectType left, Azure.ResourceManager.Cdn.Models.RedirectType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RedirectType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RedirectType left, Azure.ResourceManager.Cdn.Models.RedirectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RemoteAddressMatchCondition
    {
        public RemoteAddressMatchCondition(Azure.ResourceManager.Cdn.Models.RemoteAddressMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.RemoteAddressOperator @operator) { }
        public Azure.ResourceManager.Cdn.Models.RemoteAddressMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.RemoteAddressOperator Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RemoteAddressMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.RemoteAddressMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RemoteAddressMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RemoteAddressMatchConditionType RemoteAddressCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RemoteAddressMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RemoteAddressMatchConditionType left, Azure.ResourceManager.Cdn.Models.RemoteAddressMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RemoteAddressMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RemoteAddressMatchConditionType left, Azure.ResourceManager.Cdn.Models.RemoteAddressMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RemoteAddressOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.RemoteAddressOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RemoteAddressOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RemoteAddressOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RemoteAddressOperator GeoMatch { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RemoteAddressOperator IPMatch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RemoteAddressOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RemoteAddressOperator left, Azure.ResourceManager.Cdn.Models.RemoteAddressOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RemoteAddressOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RemoteAddressOperator left, Azure.ResourceManager.Cdn.Models.RemoteAddressOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RequestBodyMatchCondition
    {
        public RequestBodyMatchCondition(Azure.ResourceManager.Cdn.Models.RequestBodyMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.RequestBodyOperator @operator) { }
        public Azure.ResourceManager.Cdn.Models.RequestBodyMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.RequestBodyOperator Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestBodyMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.RequestBodyMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestBodyMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RequestBodyMatchConditionType RequestBodyCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RequestBodyMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RequestBodyMatchConditionType left, Azure.ResourceManager.Cdn.Models.RequestBodyMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RequestBodyMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RequestBodyMatchConditionType left, Azure.ResourceManager.Cdn.Models.RequestBodyMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestBodyOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.RequestBodyOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestBodyOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RequestBodyOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestBodyOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestBodyOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestBodyOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestBodyOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestBodyOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestBodyOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestBodyOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestBodyOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestBodyOperator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RequestBodyOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RequestBodyOperator left, Azure.ResourceManager.Cdn.Models.RequestBodyOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RequestBodyOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RequestBodyOperator left, Azure.ResourceManager.Cdn.Models.RequestBodyOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RequestHeaderMatchCondition
    {
        public RequestHeaderMatchCondition(Azure.ResourceManager.Cdn.Models.RequestHeaderMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.RequestHeaderOperator @operator) { }
        public Azure.ResourceManager.Cdn.Models.RequestHeaderMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.RequestHeaderOperator Operator { get { throw null; } set { } }
        public string Selector { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestHeaderMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.RequestHeaderMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestHeaderMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RequestHeaderMatchConditionType RequestHeaderCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RequestHeaderMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RequestHeaderMatchConditionType left, Azure.ResourceManager.Cdn.Models.RequestHeaderMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RequestHeaderMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RequestHeaderMatchConditionType left, Azure.ResourceManager.Cdn.Models.RequestHeaderMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestHeaderOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.RequestHeaderOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestHeaderOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RequestHeaderOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestHeaderOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestHeaderOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestHeaderOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestHeaderOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestHeaderOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestHeaderOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestHeaderOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestHeaderOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestHeaderOperator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RequestHeaderOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RequestHeaderOperator left, Azure.ResourceManager.Cdn.Models.RequestHeaderOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RequestHeaderOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RequestHeaderOperator left, Azure.ResourceManager.Cdn.Models.RequestHeaderOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RequestMethodMatchCondition
    {
        public RequestMethodMatchCondition(Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.RequestMethodOperator @operator) { }
        public Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.RequestMethodOperator Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestMethodMatchConditionMatchValue : System.IEquatable<Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestMethodMatchConditionMatchValue(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue Delete { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue Get { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue Head { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue Options { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue Post { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue Put { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue Trace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue left, Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue left, Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestMethodMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestMethodMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionType RequestMethodCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionType left, Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionType left, Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestMethodOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.RequestMethodOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestMethodOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RequestMethodOperator Equal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RequestMethodOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RequestMethodOperator left, Azure.ResourceManager.Cdn.Models.RequestMethodOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RequestMethodOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RequestMethodOperator left, Azure.ResourceManager.Cdn.Models.RequestMethodOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RequestSchemeMatchCondition
    {
        public RequestSchemeMatchCondition(Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.RequestSchemeOperator @operator) { }
        public Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionMatchValue> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.RequestSchemeOperator Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestSchemeMatchConditionMatchValue : System.IEquatable<Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionMatchValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestSchemeMatchConditionMatchValue(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionMatchValue Http { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionMatchValue Https { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionMatchValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionMatchValue left, Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionMatchValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionMatchValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionMatchValue left, Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionMatchValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestSchemeMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestSchemeMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionType RequestSchemeCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionType left, Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionType left, Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestSchemeOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.RequestSchemeOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestSchemeOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RequestSchemeOperator Equal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RequestSchemeOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RequestSchemeOperator left, Azure.ResourceManager.Cdn.Models.RequestSchemeOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RequestSchemeOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RequestSchemeOperator left, Azure.ResourceManager.Cdn.Models.RequestSchemeOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RequestUriMatchCondition
    {
        public RequestUriMatchCondition(Azure.ResourceManager.Cdn.Models.RequestUriMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.RequestUriOperator @operator) { }
        public Azure.ResourceManager.Cdn.Models.RequestUriMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.RequestUriOperator Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestUriMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.RequestUriMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestUriMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RequestUriMatchConditionType RequestUriCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RequestUriMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RequestUriMatchConditionType left, Azure.ResourceManager.Cdn.Models.RequestUriMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RequestUriMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RequestUriMatchConditionType left, Azure.ResourceManager.Cdn.Models.RequestUriMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestUriOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.RequestUriOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestUriOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RequestUriOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestUriOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestUriOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestUriOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestUriOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestUriOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestUriOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestUriOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestUriOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestUriOperator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RequestUriOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RequestUriOperator left, Azure.ResourceManager.Cdn.Models.RequestUriOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RequestUriOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RequestUriOperator left, Azure.ResourceManager.Cdn.Models.RequestUriOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourcesResponse
    {
        internal ResourcesResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.ResourcesResponseCustomDomainsItem> CustomDomains { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsItem> Endpoints { get { throw null; } }
    }
    public partial class ResourcesResponseCustomDomainsItem
    {
        internal ResourcesResponseCustomDomainsItem() { }
        public string EndpointId { get { throw null; } }
        public bool? History { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class ResourcesResponseEndpointsItem
    {
        internal ResourcesResponseEndpointsItem() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsPropertiesItemsItem> CustomDomains { get { throw null; } }
        public bool? History { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class ResourcesResponseEndpointsPropertiesItemsItem
    {
        internal ResourcesResponseEndpointsPropertiesItemsItem() { }
        public string EndpointId { get { throw null; } }
        public bool? History { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class ResourceUsage
    {
        internal ResourceUsage() { }
        public int? CurrentValue { get { throw null; } }
        public int? Limit { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.ResourceUsageUnit? Unit { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceUsageUnit : System.IEquatable<Azure.ResourceManager.Cdn.Models.ResourceUsageUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceUsageUnit(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ResourceUsageUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ResourceUsageUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ResourceUsageUnit left, Azure.ResourceManager.Cdn.Models.ResourceUsageUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ResourceUsageUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ResourceUsageUnit left, Azure.ResourceManager.Cdn.Models.ResourceUsageUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ResponseBasedDetectedErrorTypes
    {
        None = 0,
        TcpErrorsOnly = 1,
        TcpAndHttpErrors = 2,
    }
    public partial class ResponseBasedOriginErrorDetectionSettings
    {
        public ResponseBasedOriginErrorDetectionSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.HttpErrorRange> HttpErrorRanges { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.ResponseBasedDetectedErrorTypes? ResponseBasedDetectedErrorTypes { get { throw null; } set { } }
        public int? ResponseBasedFailoverThresholdPercentage { get { throw null; } set { } }
    }
    public partial class RouteCacheCompressionSettings
    {
        public RouteCacheCompressionSettings() { }
        public System.Collections.Generic.IList<string> ContentTypesToCompress { get { throw null; } }
        public bool? IsCompressionEnabled { get { throw null; } set { } }
    }
    public partial class RouteConfigurationOverrideActionProperties
    {
        public RouteConfigurationOverrideActionProperties(Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionType actionType) { }
        public Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionType ActionType { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.CacheConfiguration CacheConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.OriginGroupOverride OriginGroupOverride { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RouteConfigurationOverrideActionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RouteConfigurationOverrideActionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionType RouteConfigurationOverrideAction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionType left, Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionType left, Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RuleCacheBehavior : System.IEquatable<Azure.ResourceManager.Cdn.Models.RuleCacheBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RuleCacheBehavior(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RuleCacheBehavior HonorOrigin { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RuleCacheBehavior OverrideAlways { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RuleCacheBehavior OverrideIfOriginMissing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RuleCacheBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RuleCacheBehavior left, Azure.ResourceManager.Cdn.Models.RuleCacheBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RuleCacheBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RuleCacheBehavior left, Azure.ResourceManager.Cdn.Models.RuleCacheBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RuleIsCompressionEnabled : System.IEquatable<Azure.ResourceManager.Cdn.Models.RuleIsCompressionEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RuleIsCompressionEnabled(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RuleIsCompressionEnabled Disabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RuleIsCompressionEnabled Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RuleIsCompressionEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RuleIsCompressionEnabled left, Azure.ResourceManager.Cdn.Models.RuleIsCompressionEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RuleIsCompressionEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RuleIsCompressionEnabled left, Azure.ResourceManager.Cdn.Models.RuleIsCompressionEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RuleQueryStringCachingBehavior : System.IEquatable<Azure.ResourceManager.Cdn.Models.RuleQueryStringCachingBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RuleQueryStringCachingBehavior(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RuleQueryStringCachingBehavior IgnoreQueryString { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RuleQueryStringCachingBehavior IgnoreSpecifiedQueryStrings { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RuleQueryStringCachingBehavior IncludeSpecifiedQueryStrings { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RuleQueryStringCachingBehavior UseQueryString { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RuleQueryStringCachingBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RuleQueryStringCachingBehavior left, Azure.ResourceManager.Cdn.Models.RuleQueryStringCachingBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RuleQueryStringCachingBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RuleQueryStringCachingBehavior left, Azure.ResourceManager.Cdn.Models.RuleQueryStringCachingBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecretProperties
    {
        public SecretProperties() { }
    }
    public partial class SecurityPolicyProperties
    {
        public SecurityPolicyProperties() { }
    }
    public partial class SecurityPolicyWebApplicationFirewall : Azure.ResourceManager.Cdn.Models.SecurityPolicyProperties
    {
        public SecurityPolicyWebApplicationFirewall() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.SecurityPolicyWebApplicationFirewallAssociation> Associations { get { throw null; } }
        public Azure.Core.ResourceIdentifier WafPolicyId { get { throw null; } set { } }
    }
    public partial class SecurityPolicyWebApplicationFirewallAssociation
    {
        public SecurityPolicyWebApplicationFirewallAssociation() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.ActivatedResourceReference> Domains { get { throw null; } }
        public System.Collections.Generic.IList<string> PatternsToMatch { get { throw null; } }
    }
    public partial class ServerPortMatchCondition
    {
        public ServerPortMatchCondition(Azure.ResourceManager.Cdn.Models.ServerPortMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.ServerPortOperator @operator) { }
        public Azure.ResourceManager.Cdn.Models.ServerPortMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.ServerPortOperator Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerPortMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.ServerPortMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerPortMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ServerPortMatchConditionType ServerPortCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ServerPortMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ServerPortMatchConditionType left, Azure.ResourceManager.Cdn.Models.ServerPortMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ServerPortMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ServerPortMatchConditionType left, Azure.ResourceManager.Cdn.Models.ServerPortMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerPortOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.ServerPortOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerPortOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ServerPortOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ServerPortOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ServerPortOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ServerPortOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ServerPortOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ServerPortOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ServerPortOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ServerPortOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ServerPortOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ServerPortOperator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ServerPortOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ServerPortOperator left, Azure.ResourceManager.Cdn.Models.ServerPortOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ServerPortOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ServerPortOperator left, Azure.ResourceManager.Cdn.Models.ServerPortOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SharedPrivateLinkResourceProperties
    {
        public SharedPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkId { get { throw null; } set { } }
        public string PrivateLinkLocation { get { throw null; } set { } }
        public string RequestMessage { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.SharedPrivateLinkResourceStatus? Status { get { throw null; } set { } }
    }
    public enum SharedPrivateLinkResourceStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
        Timeout = 4,
    }
    public partial class SocketAddressMatchCondition
    {
        public SocketAddressMatchCondition(Azure.ResourceManager.Cdn.Models.SocketAddressMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.SocketAddressOperator @operator) { }
        public Azure.ResourceManager.Cdn.Models.SocketAddressMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.SocketAddressOperator Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SocketAddressMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.SocketAddressMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SocketAddressMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.SocketAddressMatchConditionType SocketAddressCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.SocketAddressMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.SocketAddressMatchConditionType left, Azure.ResourceManager.Cdn.Models.SocketAddressMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.SocketAddressMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.SocketAddressMatchConditionType left, Azure.ResourceManager.Cdn.Models.SocketAddressMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SocketAddressOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.SocketAddressOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SocketAddressOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.SocketAddressOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.SocketAddressOperator IPMatch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.SocketAddressOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.SocketAddressOperator left, Azure.ResourceManager.Cdn.Models.SocketAddressOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.SocketAddressOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.SocketAddressOperator left, Azure.ResourceManager.Cdn.Models.SocketAddressOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SslProtocol : System.IEquatable<Azure.ResourceManager.Cdn.Models.SslProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SslProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.SslProtocol Tls1_0 { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.SslProtocol Tls1_1 { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.SslProtocol Tls1_2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.SslProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.SslProtocol left, Azure.ResourceManager.Cdn.Models.SslProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.SslProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.SslProtocol left, Azure.ResourceManager.Cdn.Models.SslProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SslProtocolMatchCondition
    {
        public SslProtocolMatchCondition(Azure.ResourceManager.Cdn.Models.SslProtocolMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.SslProtocolOperator @operator) { }
        public Azure.ResourceManager.Cdn.Models.SslProtocolMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.SslProtocol> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.SslProtocolOperator Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SslProtocolMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.SslProtocolMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SslProtocolMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.SslProtocolMatchConditionType SslProtocolCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.SslProtocolMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.SslProtocolMatchConditionType left, Azure.ResourceManager.Cdn.Models.SslProtocolMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.SslProtocolMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.SslProtocolMatchConditionType left, Azure.ResourceManager.Cdn.Models.SslProtocolMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SslProtocolOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.SslProtocolOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SslProtocolOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.SslProtocolOperator Equal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.SslProtocolOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.SslProtocolOperator left, Azure.ResourceManager.Cdn.Models.SslProtocolOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.SslProtocolOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.SslProtocolOperator left, Azure.ResourceManager.Cdn.Models.SslProtocolOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SsoUri
    {
        internal SsoUri() { }
        public System.Uri AvailableSsoUri { get { throw null; } }
    }
    public partial class SupportedOptimizationTypesListResult
    {
        internal SupportedOptimizationTypesListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.OptimizationType> SupportedOptimizationTypes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TransformType : System.IEquatable<Azure.ResourceManager.Cdn.Models.TransformType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TransformType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.TransformType Lowercase { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.TransformType RemoveNulls { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.TransformType Trim { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.TransformType Uppercase { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.TransformType UriDecode { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.TransformType UriEncode { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.TransformType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.TransformType left, Azure.ResourceManager.Cdn.Models.TransformType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.TransformType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.TransformType left, Azure.ResourceManager.Cdn.Models.TransformType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UriFileExtensionMatchCondition
    {
        public UriFileExtensionMatchCondition(Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator @operator) { }
        public Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UriFileExtensionMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UriFileExtensionMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchConditionType UriFileExtensionMatchCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchConditionType left, Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchConditionType left, Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UriFileExtensionOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UriFileExtensionOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator left, Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator left, Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UriFileNameMatchCondition
    {
        public UriFileNameMatchCondition(Azure.ResourceManager.Cdn.Models.UriFileNameMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.UriFileNameOperator @operator) { }
        public Azure.ResourceManager.Cdn.Models.UriFileNameMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.UriFileNameOperator Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UriFileNameMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.UriFileNameMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UriFileNameMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.UriFileNameMatchConditionType UriFilenameCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.UriFileNameMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.UriFileNameMatchConditionType left, Azure.ResourceManager.Cdn.Models.UriFileNameMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.UriFileNameMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.UriFileNameMatchConditionType left, Azure.ResourceManager.Cdn.Models.UriFileNameMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UriFileNameOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.UriFileNameOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UriFileNameOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.UriFileNameOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileNameOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileNameOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileNameOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileNameOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileNameOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileNameOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileNameOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileNameOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileNameOperator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.UriFileNameOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.UriFileNameOperator left, Azure.ResourceManager.Cdn.Models.UriFileNameOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.UriFileNameOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.UriFileNameOperator left, Azure.ResourceManager.Cdn.Models.UriFileNameOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UriPathMatchCondition
    {
        public UriPathMatchCondition(Azure.ResourceManager.Cdn.Models.UriPathMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.UriPathOperator @operator) { }
        public Azure.ResourceManager.Cdn.Models.UriPathMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.UriPathOperator Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UriPathMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.UriPathMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UriPathMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.UriPathMatchConditionType UriPathMatchCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.UriPathMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.UriPathMatchConditionType left, Azure.ResourceManager.Cdn.Models.UriPathMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.UriPathMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.UriPathMatchConditionType left, Azure.ResourceManager.Cdn.Models.UriPathMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UriPathOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.UriPathOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UriPathOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.UriPathOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriPathOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriPathOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriPathOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriPathOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriPathOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriPathOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriPathOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriPathOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriPathOperator RegEx { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriPathOperator Wildcard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.UriPathOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.UriPathOperator left, Azure.ResourceManager.Cdn.Models.UriPathOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.UriPathOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.UriPathOperator left, Azure.ResourceManager.Cdn.Models.UriPathOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UriRedirectAction : Azure.ResourceManager.Cdn.Models.DeliveryRuleAction
    {
        public UriRedirectAction(Azure.ResourceManager.Cdn.Models.UriRedirectActionProperties properties) { }
        public Azure.ResourceManager.Cdn.Models.UriRedirectActionProperties Properties { get { throw null; } set { } }
    }
    public partial class UriRedirectActionProperties
    {
        public UriRedirectActionProperties(Azure.ResourceManager.Cdn.Models.UriRedirectActionType actionType, Azure.ResourceManager.Cdn.Models.RedirectType redirectType) { }
        public Azure.ResourceManager.Cdn.Models.UriRedirectActionType ActionType { get { throw null; } set { } }
        public string CustomFragment { get { throw null; } set { } }
        public string CustomHostname { get { throw null; } set { } }
        public string CustomPath { get { throw null; } set { } }
        public string CustomQueryString { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.DestinationProtocol? DestinationProtocol { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.RedirectType RedirectType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UriRedirectActionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.UriRedirectActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UriRedirectActionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.UriRedirectActionType UriRedirectAction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.UriRedirectActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.UriRedirectActionType left, Azure.ResourceManager.Cdn.Models.UriRedirectActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.UriRedirectActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.UriRedirectActionType left, Azure.ResourceManager.Cdn.Models.UriRedirectActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UriRewriteAction : Azure.ResourceManager.Cdn.Models.DeliveryRuleAction
    {
        public UriRewriteAction(Azure.ResourceManager.Cdn.Models.UriRewriteActionProperties properties) { }
        public Azure.ResourceManager.Cdn.Models.UriRewriteActionProperties Properties { get { throw null; } set { } }
    }
    public partial class UriRewriteActionProperties
    {
        public UriRewriteActionProperties(Azure.ResourceManager.Cdn.Models.UriRewriteActionType actionType, string sourcePattern, string destination) { }
        public Azure.ResourceManager.Cdn.Models.UriRewriteActionType ActionType { get { throw null; } set { } }
        public string Destination { get { throw null; } set { } }
        public bool? PreserveUnmatchedPath { get { throw null; } set { } }
        public string SourcePattern { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UriRewriteActionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.UriRewriteActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UriRewriteActionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.UriRewriteActionType UriRewriteAction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.UriRewriteActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.UriRewriteActionType left, Azure.ResourceManager.Cdn.Models.UriRewriteActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.UriRewriteActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.UriRewriteActionType left, Azure.ResourceManager.Cdn.Models.UriRewriteActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UriSigningAction : Azure.ResourceManager.Cdn.Models.DeliveryRuleAction
    {
        public UriSigningAction(Azure.ResourceManager.Cdn.Models.UriSigningActionProperties properties) { }
        public Azure.ResourceManager.Cdn.Models.UriSigningActionProperties Properties { get { throw null; } set { } }
    }
    public partial class UriSigningActionProperties
    {
        public UriSigningActionProperties(Azure.ResourceManager.Cdn.Models.UriSigningActionType actionType) { }
        public Azure.ResourceManager.Cdn.Models.UriSigningActionType ActionType { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.UriSigningAlgorithm? Algorithm { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.UriSigningParamIdentifier> ParameterNameOverride { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UriSigningActionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.UriSigningActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UriSigningActionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.UriSigningActionType UriSigningAction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.UriSigningActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.UriSigningActionType left, Azure.ResourceManager.Cdn.Models.UriSigningActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.UriSigningActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.UriSigningActionType left, Azure.ResourceManager.Cdn.Models.UriSigningActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UriSigningAlgorithm : System.IEquatable<Azure.ResourceManager.Cdn.Models.UriSigningAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UriSigningAlgorithm(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.UriSigningAlgorithm Sha256 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.UriSigningAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.UriSigningAlgorithm left, Azure.ResourceManager.Cdn.Models.UriSigningAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.UriSigningAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.UriSigningAlgorithm left, Azure.ResourceManager.Cdn.Models.UriSigningAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UriSigningKey
    {
        public UriSigningKey(string keyId, Azure.ResourceManager.Cdn.Models.KeyVaultSigningKey keySourceParameters) { }
        public string KeyId { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.KeyVaultSigningKey KeySourceParameters { get { throw null; } set { } }
    }
    public partial class UriSigningKeyProperties : Azure.ResourceManager.Cdn.Models.SecretProperties
    {
        public UriSigningKeyProperties(string keyId, Azure.ResourceManager.Resources.Models.WritableSubResource secretSource) { }
        public string KeyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SecretSourceId { get { throw null; } set { } }
        public string SecretVersion { get { throw null; } set { } }
    }
    public partial class UriSigningParamIdentifier
    {
        public UriSigningParamIdentifier(Azure.ResourceManager.Cdn.Models.ParamIndicator paramIndicator, string paramName) { }
        public Azure.ResourceManager.Cdn.Models.ParamIndicator ParamIndicator { get { throw null; } set { } }
        public string ParamName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsageUnit : System.IEquatable<Azure.ResourceManager.Cdn.Models.UsageUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsageUnit(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.UsageUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.UsageUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.UsageUnit left, Azure.ResourceManager.Cdn.Models.UsageUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.UsageUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.UsageUnit left, Azure.ResourceManager.Cdn.Models.UsageUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserManagedHttpsContent : Azure.ResourceManager.Cdn.Models.CustomDomainHttpsContent
    {
        public UserManagedHttpsContent(Azure.ResourceManager.Cdn.Models.ProtocolType protocolType, Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSource certificateSourceParameters) : base (default(Azure.ResourceManager.Cdn.Models.ProtocolType)) { }
        public Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSource CertificateSourceParameters { get { throw null; } set { } }
    }
    public partial class ValidateCustomDomainContent
    {
        public ValidateCustomDomainContent(string hostName) { }
        public string HostName { get { throw null; } }
    }
    public partial class ValidateCustomDomainResult
    {
        internal ValidateCustomDomainResult() { }
        public bool? IsCustomDomainValid { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class ValidateProbeContent
    {
        public ValidateProbeContent(System.Uri probeUri) { }
        public System.Uri ProbeUri { get { throw null; } }
    }
    public partial class ValidateProbeResult
    {
        internal ValidateProbeResult() { }
        public string ErrorCode { get { throw null; } }
        public bool? IsValid { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WafAction : System.IEquatable<Azure.ResourceManager.Cdn.Models.WafAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WafAction(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.WafAction Allow { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafAction Block { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafAction Log { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafAction Redirect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.WafAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.WafAction left, Azure.ResourceManager.Cdn.Models.WafAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.WafAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.WafAction left, Azure.ResourceManager.Cdn.Models.WafAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WafGranularity : System.IEquatable<Azure.ResourceManager.Cdn.Models.WafGranularity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WafGranularity(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.WafGranularity P1D { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafGranularity PT1H { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafGranularity PT5M { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.WafGranularity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.WafGranularity left, Azure.ResourceManager.Cdn.Models.WafGranularity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.WafGranularity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.WafGranularity left, Azure.ResourceManager.Cdn.Models.WafGranularity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WafMatchVariable : System.IEquatable<Azure.ResourceManager.Cdn.Models.WafMatchVariable>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WafMatchVariable(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.WafMatchVariable Cookies { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafMatchVariable PostArgs { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafMatchVariable QueryString { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafMatchVariable RemoteAddr { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafMatchVariable RequestBody { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafMatchVariable RequestHeader { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafMatchVariable RequestMethod { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafMatchVariable RequestUri { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafMatchVariable SocketAddr { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.WafMatchVariable other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.WafMatchVariable left, Azure.ResourceManager.Cdn.Models.WafMatchVariable right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.WafMatchVariable (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.WafMatchVariable left, Azure.ResourceManager.Cdn.Models.WafMatchVariable right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WafMetric : System.IEquatable<Azure.ResourceManager.Cdn.Models.WafMetric>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WafMetric(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.WafMetric ClientRequestCount { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.WafMetric other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.WafMetric left, Azure.ResourceManager.Cdn.Models.WafMetric right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.WafMetric (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.WafMetric left, Azure.ResourceManager.Cdn.Models.WafMetric right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WafMetricsResponse
    {
        internal WafMetricsResponse() { }
        public System.DateTimeOffset? DateTimeBegin { get { throw null; } }
        public System.DateTimeOffset? DateTimeEnd { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.WafMetricsResponseGranularity? Granularity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItem> Series { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WafMetricsResponseGranularity : System.IEquatable<Azure.ResourceManager.Cdn.Models.WafMetricsResponseGranularity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WafMetricsResponseGranularity(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.WafMetricsResponseGranularity P1D { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafMetricsResponseGranularity PT1H { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafMetricsResponseGranularity PT5M { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.WafMetricsResponseGranularity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.WafMetricsResponseGranularity left, Azure.ResourceManager.Cdn.Models.WafMetricsResponseGranularity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.WafMetricsResponseGranularity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.WafMetricsResponseGranularity left, Azure.ResourceManager.Cdn.Models.WafMetricsResponseGranularity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WafMetricsResponseSeriesItem
    {
        internal WafMetricsResponseSeriesItem() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.Components18OrqelSchemasWafmetricsresponsePropertiesSeriesItemsPropertiesDataItems> Data { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesPropertiesItemsItem> Groups { get { throw null; } }
        public string Metric { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItemUnit? Unit { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WafMetricsResponseSeriesItemUnit : System.IEquatable<Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItemUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WafMetricsResponseSeriesItemUnit(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItemUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItemUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItemUnit left, Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItemUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItemUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItemUnit left, Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItemUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WafMetricsResponseSeriesPropertiesItemsItem
    {
        internal WafMetricsResponseSeriesPropertiesItemsItem() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WafRankingGroupBy : System.IEquatable<Azure.ResourceManager.Cdn.Models.WafRankingGroupBy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WafRankingGroupBy(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.WafRankingGroupBy CustomDomain { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafRankingGroupBy HttpStatusCode { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.WafRankingGroupBy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.WafRankingGroupBy left, Azure.ResourceManager.Cdn.Models.WafRankingGroupBy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.WafRankingGroupBy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.WafRankingGroupBy left, Azure.ResourceManager.Cdn.Models.WafRankingGroupBy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WafRankingsResponse
    {
        internal WafRankingsResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.WafRankingsResponseDataItem> Data { get { throw null; } }
        public System.DateTimeOffset? DateTimeBegin { get { throw null; } }
        public System.DateTimeOffset? DateTimeEnd { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Groups { get { throw null; } }
    }
    public partial class WafRankingsResponseDataItem
    {
        internal WafRankingsResponseDataItem() { }
        public System.Collections.Generic.IReadOnlyList<string> GroupValues { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.ComponentsKpo1PjSchemasWafrankingsresponsePropertiesDataItemsPropertiesMetricsItems> Metrics { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WafRankingType : System.IEquatable<Azure.ResourceManager.Cdn.Models.WafRankingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WafRankingType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.WafRankingType Action { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafRankingType ClientIP { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafRankingType CountryOrRegion { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafRankingType RuleGroup { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafRankingType RuleId { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafRankingType RuleType { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafRankingType Uri { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafRankingType UserAgent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.WafRankingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.WafRankingType left, Azure.ResourceManager.Cdn.Models.WafRankingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.WafRankingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.WafRankingType left, Azure.ResourceManager.Cdn.Models.WafRankingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WafRuleType : System.IEquatable<Azure.ResourceManager.Cdn.Models.WafRuleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WafRuleType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.WafRuleType Bot { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafRuleType Custom { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafRuleType Managed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.WafRuleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.WafRuleType left, Azure.ResourceManager.Cdn.Models.WafRuleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.WafRuleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.WafRuleType left, Azure.ResourceManager.Cdn.Models.WafRuleType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
