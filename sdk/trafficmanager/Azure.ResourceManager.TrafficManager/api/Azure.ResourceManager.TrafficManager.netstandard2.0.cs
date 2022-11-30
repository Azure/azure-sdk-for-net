namespace Azure.ResourceManager.TrafficManager
{
    public partial class TrafficManagerEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>, System.Collections.IEnumerable
    {
        protected TrafficManagerEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointType, string endpointName, Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointType, string endpointName, Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource> Get(string endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData> GetAll() { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData> GetAllAsync() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource>> GetAsync(string endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData> System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TrafficManagerEndpointData : Azure.ResourceManager.TrafficManager.Models.TrafficManagerProxyResourceData
    {
        public TrafficManagerEndpointData() { }
        public Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointAlwaysServeStatus? AlwaysServe { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointCustomHeaderInfo> CustomHeaders { get { throw null; } }
        public string EndpointLocation { get { throw null; } set { } }
        public Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus? EndpointMonitorStatus { get { throw null; } set { } }
        public Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointStatus? EndpointStatus { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> GeoMapping { get { throw null; } }
        public long? MinChildEndpoints { get { throw null; } set { } }
        public long? MinChildEndpointsIPv4 { get { throw null; } set { } }
        public long? MinChildEndpointsIPv6 { get { throw null; } set { } }
        public long? Priority { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointSubnetInfo> Subnets { get { throw null; } }
        public string Target { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public long? Weight { get { throw null; } set { } }
    }
    public partial class TrafficManagerEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TrafficManagerEndpointResource() { }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string endpointType, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource> Update(Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource>> UpdateAsync(Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class TrafficManagerExtensions
    {
        public static Azure.Response<Azure.ResourceManager.TrafficManager.Models.TrafficManagerNameAvailabilityResult> CheckTrafficManagerRelativeDnsNameAvailability(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.TrafficManager.Models.TrafficManagerRelativeDnsNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.Models.TrafficManagerNameAvailabilityResult>> CheckTrafficManagerRelativeDnsNameAvailabilityAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.TrafficManager.Models.TrafficManagerRelativeDnsNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource GetTrafficManagerEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyResource GetTrafficManagerGeographicHierarchy(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.TrafficManager.TrafficManagerGeographicHierarchyResource GetTrafficManagerGeographicHierarchyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapResource GetTrafficManagerHeatMapResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> GetTrafficManagerProfile(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>> GetTrafficManagerProfileAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource GetTrafficManagerProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.TrafficManager.TrafficManagerProfileCollection GetTrafficManagerProfiles(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> GetTrafficManagerProfiles(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> GetTrafficManagerProfilesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource GetTrafficManagerUserMetrics(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource GetTrafficManagerUserMetricsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class TrafficManagerGeographicHierarchyData : Azure.ResourceManager.TrafficManager.Models.TrafficManagerProxyResourceData
    {
        public TrafficManagerGeographicHierarchyData() { }
        public Azure.ResourceManager.TrafficManager.Models.TrafficManagerRegion GeographicHierarchy { get { throw null; } set { } }
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
    public partial class TrafficManagerHeatMapCollection : Azure.ResourceManager.ArmCollection
    {
        protected TrafficManagerHeatMapCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType heatMapType, System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType heatMapType, System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapResource> Get(Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType heatMapType, System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapResource>> GetAsync(Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType heatMapType, System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TrafficManagerHeatMapData : Azure.ResourceManager.TrafficManager.Models.TrafficManagerProxyResourceData
    {
        public TrafficManagerHeatMapData() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapEndpoint> Endpoints { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapTrafficFlow> TrafficFlows { get { throw null; } }
    }
    public partial class TrafficManagerHeatMapResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TrafficManagerHeatMapResource() { }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType heatMapType) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapResource> Get(System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapResource>> GetAsync(System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TrafficManagerProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>, System.Collections.IEnumerable
    {
        protected TrafficManagerProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string profileName, Azure.ResourceManager.TrafficManager.TrafficManagerProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string profileName, Azure.ResourceManager.TrafficManager.TrafficManagerProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> Get(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>> GetAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TrafficManagerProfileData : Azure.ResourceManager.TrafficManager.Models.TrafficManagerTrackedResourceData
    {
        public TrafficManagerProfileData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.AllowedEndpointRecordType> AllowedEndpointRecordTypes { get { throw null; } }
        public Azure.ResourceManager.TrafficManager.Models.TrafficManagerDnsConfig DnsConfig { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointData> Endpoints { get { throw null; } }
        public long? MaxReturn { get { throw null; } set { } }
        public Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfig MonitorConfig { get { throw null; } set { } }
        public Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileStatus? ProfileStatus { get { throw null; } set { } }
        public Azure.ResourceManager.TrafficManager.Models.TrafficRoutingMethod? TrafficRoutingMethod { get { throw null; } set { } }
        public Azure.ResourceManager.TrafficManager.Models.TrafficViewEnrollmentStatus? TrafficViewEnrollmentStatus { get { throw null; } set { } }
    }
    public partial class TrafficManagerProfileResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TrafficManagerProfileResource() { }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource> GetTrafficManagerEndpoint(string endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerEndpointResource>> GetTrafficManagerEndpointAsync(string endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerEndpointCollection GetTrafficManagerEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapResource> GetTrafficManagerHeatMap(Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType heatMapType, System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapResource>> GetTrafficManagerHeatMapAsync(Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType heatMapType, System.Collections.Generic.IEnumerable<double> topLeft = null, System.Collections.Generic.IEnumerable<double> botRight = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerHeatMapCollection GetTrafficManagerHeatMaps() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource> Update(Azure.ResourceManager.TrafficManager.TrafficManagerProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerProfileResource>> UpdateAsync(Azure.ResourceManager.TrafficManager.TrafficManagerProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TrafficManagerUserMetricData : Azure.ResourceManager.TrafficManager.Models.TrafficManagerProxyResourceData
    {
        public TrafficManagerUserMetricData() { }
        public string Key { get { throw null; } set { } }
    }
    public partial class TrafficManagerUserMetricsResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TrafficManagerUserMetricsResource() { }
        public virtual Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource> CreateOrUpdate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrafficManager.TrafficManagerUserMetricsResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ExpectedStatusCodeRangeInfo
    {
        public ExpectedStatusCodeRangeInfo() { }
        public int? Max { get { throw null; } set { } }
        public int? Min { get { throw null; } set { } }
    }
    public partial class TrafficManagerDnsConfig
    {
        public TrafficManagerDnsConfig() { }
        public string Fqdn { get { throw null; } }
        public string RelativeName { get { throw null; } set { } }
        public long? Ttl { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficManagerEndpointAlwaysServeStatus : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointAlwaysServeStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficManagerEndpointAlwaysServeStatus(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointAlwaysServeStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointAlwaysServeStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointAlwaysServeStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointAlwaysServeStatus left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointAlwaysServeStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointAlwaysServeStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointAlwaysServeStatus left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointAlwaysServeStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrafficManagerEndpointCustomHeaderInfo
    {
        public TrafficManagerEndpointCustomHeaderInfo() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficManagerEndpointMonitorStatus : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficManagerEndpointMonitorStatus(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus CheckingEndpoint { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus Degraded { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus Inactive { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus Online { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus Stopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointMonitorStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficManagerEndpointStatus : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficManagerEndpointStatus(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointStatus left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointStatus left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerEndpointStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrafficManagerEndpointSubnetInfo
    {
        public TrafficManagerEndpointSubnetInfo() { }
        public System.Net.IPAddress First { get { throw null; } set { } }
        public System.Net.IPAddress Last { get { throw null; } set { } }
        public int? Scope { get { throw null; } set { } }
    }
    public partial class TrafficManagerHeatMapEndpoint
    {
        public TrafficManagerHeatMapEndpoint() { }
        public int? EndpointId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public partial class TrafficManagerHeatMapQueryExperience
    {
        public TrafficManagerHeatMapQueryExperience(int endpointId, int queryCount) { }
        public int EndpointId { get { throw null; } set { } }
        public double? Latency { get { throw null; } set { } }
        public int QueryCount { get { throw null; } set { } }
    }
    public partial class TrafficManagerHeatMapTrafficFlow
    {
        public TrafficManagerHeatMapTrafficFlow() { }
        public double? Latitude { get { throw null; } set { } }
        public double? Longitude { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapQueryExperience> QueryExperiences { get { throw null; } }
        public System.Net.IPAddress SourceIP { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficManagerHeatMapType : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficManagerHeatMapType(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerHeatMapType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrafficManagerMonitorConfig
    {
        public TrafficManagerMonitorConfig() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorConfigCustomHeaderInfo> CustomHeaders { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.ExpectedStatusCodeRangeInfo> ExpectedStatusCodeRanges { get { throw null; } }
        public long? IntervalInSeconds { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public long? Port { get { throw null; } set { } }
        public Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus? ProfileMonitorStatus { get { throw null; } set { } }
        public Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol? Protocol { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public long? ToleratedNumberOfFailures { get { throw null; } set { } }
    }
    public partial class TrafficManagerMonitorConfigCustomHeaderInfo
    {
        public TrafficManagerMonitorConfigCustomHeaderInfo() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficManagerMonitorProtocol : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficManagerMonitorProtocol(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol Https { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol Tcp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerMonitorProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrafficManagerNameAvailabilityResult
    {
        internal TrafficManagerNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public string UnavailableReason { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficManagerProfileMonitorStatus : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficManagerProfileMonitorStatus(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus CheckingEndpoints { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus Degraded { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus Inactive { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus Online { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileMonitorStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficManagerProfileStatus : System.IEquatable<Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficManagerProfileStatus(string value) { throw null; }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileStatus left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileStatus left, Azure.ResourceManager.TrafficManager.Models.TrafficManagerProfileStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrafficManagerProxyResourceData : Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData
    {
        public TrafficManagerProxyResourceData() { }
    }
    public partial class TrafficManagerRegion
    {
        public TrafficManagerRegion() { }
        public string Code { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TrafficManager.Models.TrafficManagerRegion> Regions { get { throw null; } }
    }
    public partial class TrafficManagerRelativeDnsNameAvailabilityContent
    {
        public TrafficManagerRelativeDnsNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
    }
    public partial class TrafficManagerResourceData
    {
        public TrafficManagerResourceData() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
    }
    public partial class TrafficManagerTrackedResourceData : Azure.ResourceManager.TrafficManager.Models.TrafficManagerResourceData
    {
        public TrafficManagerTrackedResourceData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
