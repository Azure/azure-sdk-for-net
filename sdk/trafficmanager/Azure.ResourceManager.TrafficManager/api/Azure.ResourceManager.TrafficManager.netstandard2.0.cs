namespace Azure.ResourceManager.TrafficManager
{
    public partial class EndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.TrafficManager.EndpointData>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrafficManager.EndpointData>, System.Collections.IEnumerable
    {
        protected EndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.EndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointType, string endpointName, Azure.ResourceManager.TrafficManager.EndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.EndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointType, string endpointName, Azure.ResourceManager.TrafficManager.EndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.EndpointResource> Get(string endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.TrafficManager.EndpointData> GetAll() { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.TrafficManager.EndpointData> GetAllAsync() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.EndpointResource>> GetAsync(string endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.TrafficManager.EndpointData> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.TrafficManager.EndpointData>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.TrafficManager.EndpointData> System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrafficManager.EndpointData>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EndpointData : Azure.ResourceManager.TrafficManager.Models.ProxyResource
    {
        public EndpointData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.EndpointPropertiesCustomHeadersItem> CustomHeaders { get { throw null; } }
        public string EndpointLocation { get { throw null; } set { } }
        public Azure.ResourceManager.TrafficManager.Models.EndpointMonitorStatus? EndpointMonitorStatus { get { throw null; } set { } }
        public Azure.ResourceManager.TrafficManager.Models.EndpointStatus? EndpointStatus { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> GeoMapping { get { throw null; } }
        public long? MinChildEndpoints { get { throw null; } set { } }
        public long? MinChildEndpointsIPv4 { get { throw null; } set { } }
        public long? MinChildEndpointsIPv6 { get { throw null; } set { } }
        public long? Priority { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.EndpointPropertiesSubnetsItem> Subnets { get { throw null; } }
        public string Target { get { throw null; } set { } }
        public string TargetResourceId { get { throw null; } set { } }
        public long? Weight { get { throw null; } set { } }
    }
    public partial class EndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EndpointResource() { }
        public virtual Azure.ResourceManager.TrafficManager.EndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string endpointType, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.EndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.EndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.EndpointResource> Update(Azure.ResourceManager.TrafficManager.EndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.EndpointResource>> UpdateAsync(Azure.ResourceManager.TrafficManager.EndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HeatMapModelCollection : Azure.ResourceManager.ArmCollection
    {
        protected HeatMapModelCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.TrafficManager.Models.HeatMapType heatMapType, System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.TrafficManager.Models.HeatMapType heatMapType, System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.HeatMapModelResource> Get(Azure.ResourceManager.TrafficManager.Models.HeatMapType heatMapType, System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.HeatMapModelResource>> GetAsync(Azure.ResourceManager.TrafficManager.Models.HeatMapType heatMapType, System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HeatMapModelData : Azure.ResourceManager.TrafficManager.Models.ProxyResource
    {
        public HeatMapModelData() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.HeatMapEndpoint> Endpoints { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.TrafficFlow> TrafficFlows { get { throw null; } }
    }
    public partial class HeatMapModelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HeatMapModelResource() { }
        public virtual Azure.ResourceManager.TrafficManager.HeatMapModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, Azure.ResourceManager.TrafficManager.Models.HeatMapType heatMapType) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.HeatMapModelResource> Get(System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.HeatMapModelResource>> GetAsync(System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.TrafficManager.ProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrafficManager.ProfileResource>, System.Collections.IEnumerable
    {
        protected ProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.ProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string profileName, Azure.ResourceManager.TrafficManager.ProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.ProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string profileName, Azure.ResourceManager.TrafficManager.ProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.ProfileResource> Get(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.TrafficManager.ProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.TrafficManager.ProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.ProfileResource>> GetAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.TrafficManager.ProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.TrafficManager.ProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.TrafficManager.ProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrafficManager.ProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProfileData : Azure.ResourceManager.TrafficManager.Models.TrackedResource
    {
        public ProfileData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType> AllowedEndpointRecordTypes { get { throw null; } }
        public Azure.ResourceManager.TrafficManager.Models.DnsConfig DnsConfig { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.EndpointData> Endpoints { get { throw null; } }
        public long? MaxReturn { get { throw null; } set { } }
        public Azure.ResourceManager.TrafficManager.Models.MonitorConfig MonitorConfig { get { throw null; } set { } }
        public Azure.ResourceManager.TrafficManager.Models.ProfileStatus? ProfileStatus { get { throw null; } set { } }
        public Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod? TrafficRoutingMethod { get { throw null; } set { } }
        public Azure.ResourceManager.TrafficManager.Models.TrafficViewEnrollmentStatus? TrafficViewEnrollmentStatus { get { throw null; } set { } }
    }
    public partial class ProfileResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProfileResource() { }
        public virtual Azure.ResourceManager.TrafficManager.ProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.ProfileResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.ProfileResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.ProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.ProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.EndpointResource> GetEndpoint(string endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.EndpointResource>> GetEndpointAsync(string endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.TrafficManager.EndpointCollection GetEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.HeatMapModelResource> GetHeatMapModel(Azure.ResourceManager.TrafficManager.Models.HeatMapType heatMapType, System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.HeatMapModelResource>> GetHeatMapModelAsync(Azure.ResourceManager.TrafficManager.Models.HeatMapType heatMapType, System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.TrafficManager.HeatMapModelCollection GetHeatMapModels() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.ProfileResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.ProfileResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.ProfileResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.ProfileResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.ProfileResource> Update(Azure.ResourceManager.TrafficManager.ProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.ProfileResource>> UpdateAsync(Azure.ResourceManager.TrafficManager.ProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class TrafficManagerExtensions
    {
        public static Azure.Response<Azure.ResourceManager.TrafficManager.Models.TrafficManagerNameAvailability> CheckTrafficManagerRelativeDnsNameAvailabilityProfile(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.TrafficManager.Models.CheckTrafficManagerRelativeDnsNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.Models.TrafficManagerNameAvailability>> CheckTrafficManagerRelativeDnsNameAvailabilityProfileAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.TrafficManager.Models.CheckTrafficManagerRelativeDnsNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.TrafficManager.EndpointResource GetEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.TrafficManager.HeatMapModelResource GetHeatMapModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.TrafficManager.ProfileResource> GetProfile(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.ProfileResource>> GetProfileAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.TrafficManager.ProfileResource GetProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.TrafficManager.ProfileCollection GetProfiles(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.TrafficManager.ProfileResource> GetProfiles(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.TrafficManager.ProfileResource> GetProfilesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyResource GetTrafficManagerGeographicHierarchy(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyResource GetTrafficManagerGeographicHierarchyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.TrafficManager.UserMetricsModelResource GetUserMetricsModel(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.TrafficManager.UserMetricsModelResource GetUserMetricsModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class TrafficManagerGeographicHierarchyData : Azure.ResourceManager.TrafficManager.Models.ProxyResource
    {
        public TrafficManagerGeographicHierarchyData() { }
        public Azure.ResourceManager.TrafficManager.Models.Region GeographicHierarchy { get { throw null; } set { } }
    }
    public partial class TrafficManagerGeographicHierarchyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TrafficManagerGeographicHierarchyResource() { }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UserMetricsModelData : Azure.ResourceManager.TrafficManager.Models.ProxyResource
    {
        public UserMetricsModelData() { }
        public string Key { get { throw null; } set { } }
    }
    public partial class UserMetricsModelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UserMetricsModelResource() { }
        public virtual Azure.ResourceManager.TrafficManager.UserMetricsModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.UserMetricsModelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.UserMetricsModelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.UserMetricsModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.UserMetricsModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.TrafficManager.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AllowedEndpointRecordType : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AllowedEndpointRecordType(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType Any { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType DomainName { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType IPv4Address { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType IPv6Address { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType left, Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType left, Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CheckTrafficManagerRelativeDnsNameAvailabilityContent
    {
        public CheckTrafficManagerRelativeDnsNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class DnsConfig
    {
        public DnsConfig() { }
        public string Fqdn { get { throw null; } }
        public string RelativeName { get { throw null; } set { } }
        public long? Ttl { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointMonitorStatus : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.EndpointMonitorStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointMonitorStatus(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.EndpointMonitorStatus CheckingEndpoint { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.EndpointMonitorStatus Degraded { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.EndpointMonitorStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.EndpointMonitorStatus Inactive { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.EndpointMonitorStatus Online { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.EndpointMonitorStatus Stopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.EndpointMonitorStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.EndpointMonitorStatus left, Azure.ResourceManager.TrafficManager.Models.EndpointMonitorStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.EndpointMonitorStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.EndpointMonitorStatus left, Azure.ResourceManager.TrafficManager.Models.EndpointMonitorStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EndpointPropertiesCustomHeadersItem
    {
        public EndpointPropertiesCustomHeadersItem() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class EndpointPropertiesSubnetsItem
    {
        public EndpointPropertiesSubnetsItem() { }
        public string First { get { throw null; } set { } }
        public string Last { get { throw null; } set { } }
        public int? Scope { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointStatus : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.EndpointStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointStatus(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.EndpointStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.EndpointStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.EndpointStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.EndpointStatus left, Azure.ResourceManager.TrafficManager.Models.EndpointStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.EndpointStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.EndpointStatus left, Azure.ResourceManager.TrafficManager.Models.EndpointStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HeatMapEndpoint
    {
        public HeatMapEndpoint() { }
        public int? EndpointId { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HeatMapType : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.HeatMapType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HeatMapType(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.HeatMapType Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.HeatMapType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.HeatMapType left, Azure.ResourceManager.TrafficManager.Models.HeatMapType right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.HeatMapType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.HeatMapType left, Azure.ResourceManager.TrafficManager.Models.HeatMapType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitorConfig
    {
        public MonitorConfig() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.MonitorConfigCustomHeadersItem> CustomHeaders { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.MonitorConfigExpectedStatusCodeRangesItem> ExpectedStatusCodeRanges { get { throw null; } }
        public long? IntervalInSeconds { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public long? Port { get { throw null; } set { } }
        public Azure.ResourceManager.TrafficManager.Models.ProfileMonitorStatus? ProfileMonitorStatus { get { throw null; } set { } }
        public Azure.ResourceManager.TrafficManager.Models.MonitorProtocol? Protocol { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public long? ToleratedNumberOfFailures { get { throw null; } set { } }
    }
    public partial class MonitorConfigCustomHeadersItem
    {
        public MonitorConfigCustomHeadersItem() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class MonitorConfigExpectedStatusCodeRangesItem
    {
        public MonitorConfigExpectedStatusCodeRangesItem() { }
        public int? Max { get { throw null; } set { } }
        public int? Min { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorProtocol : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.MonitorProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorProtocol(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.MonitorProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.MonitorProtocol Https { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.MonitorProtocol TCP { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.MonitorProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.MonitorProtocol left, Azure.ResourceManager.TrafficManager.Models.MonitorProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.MonitorProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.MonitorProtocol left, Azure.ResourceManager.TrafficManager.Models.MonitorProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProfileMonitorStatus : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.ProfileMonitorStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProfileMonitorStatus(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.ProfileMonitorStatus CheckingEndpoints { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.ProfileMonitorStatus Degraded { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.ProfileMonitorStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.ProfileMonitorStatus Inactive { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.ProfileMonitorStatus Online { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.ProfileMonitorStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.ProfileMonitorStatus left, Azure.ResourceManager.TrafficManager.Models.ProfileMonitorStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.ProfileMonitorStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.ProfileMonitorStatus left, Azure.ResourceManager.TrafficManager.Models.ProfileMonitorStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProfileStatus : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.ProfileStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProfileStatus(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.ProfileStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.ProfileStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.ProfileStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.ProfileStatus left, Azure.ResourceManager.TrafficManager.Models.ProfileStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.ProfileStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.ProfileStatus left, Azure.ResourceManager.TrafficManager.Models.ProfileStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProxyResource : Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData
    {
        public ProxyResource() { }
    }
    public partial class QueryExperience
    {
        public QueryExperience(int endpointId, int queryCount) { }
        public int EndpointId { get { throw null; } set { } }
        public double? Latency { get { throw null; } set { } }
        public int QueryCount { get { throw null; } set { } }
    }
    public partial class Region
    {
        public Region() { }
        public string Code { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.Region> Regions { get { throw null; } }
    }
    public partial class TrackedResource : Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData
    {
        public TrackedResource() { }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class TrafficFlow
    {
        public TrafficFlow() { }
        public double? Latitude { get { throw null; } set { } }
        public double? Longitude { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.QueryExperience> QueryExperiences { get { throw null; } }
        public string SourceIP { get { throw null; } set { } }
    }
    public partial class TrafficManagerNameAvailability
    {
        internal TrafficManagerNameAvailability() { }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class TrafficManagerResourceData
    {
        public TrafficManagerResourceData() { }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficRoutingMethod : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficRoutingMethod(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod Geographic { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod MultiValue { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod Performance { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod Priority { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod Subnet { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod Weighted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod left, Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod left, Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficViewEnrollmentStatus : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.TrafficViewEnrollmentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficViewEnrollmentStatus(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficViewEnrollmentStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficViewEnrollmentStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.TrafficViewEnrollmentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.TrafficViewEnrollmentStatus left, Azure.ResourceManager.TrafficManager.Models.TrafficViewEnrollmentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficViewEnrollmentStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.TrafficViewEnrollmentStatus left, Azure.ResourceManager.TrafficManager.Models.TrafficViewEnrollmentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
