namespace Azure.Provisioning.TrafficManager
{
    public enum AllowedEndpointRecordType
    {
        DomainName = 0,
        IPv4Address = 1,
        IPv6Address = 2,
        Any = 3,
    }
    public partial class AzureEndpointTrafficManagerEndpoint : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AzureEndpointTrafficManagerEndpoint(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.TrafficManager.TrafficManagerEndpointAlwaysServeStatus> AlwaysServe { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.TrafficManager.TrafficManagerEndpointCustomHeaderInfo> CustomHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EndpointLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.TrafficManager.TrafficManagerEndpointMonitorStatus> EndpointMonitorStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.TrafficManager.TrafficManagerEndpointStatus> EndpointStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> GeoMapping { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> MinChildEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MinChildEndpointsIPv4 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MinChildEndpointsIPv6 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.TrafficManager.TrafficManagerProfile Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.TrafficManager.TrafficManagerEndpointSubnetInfo> Subnets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Target { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TargetResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> Weight { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.TrafficManager.AzureEndpointTrafficManagerEndpoint FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_04_01;
        }
    }
    public partial class ExpectedStatusCodeRangeInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExpectedStatusCodeRangeInfo() { }
        public Azure.Provisioning.BicepValue<int> Max { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Min { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExternalEndpointTrafficManagerEndpoint : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ExternalEndpointTrafficManagerEndpoint(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.TrafficManager.TrafficManagerEndpointAlwaysServeStatus> AlwaysServe { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.TrafficManager.TrafficManagerEndpointCustomHeaderInfo> CustomHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EndpointLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.TrafficManager.TrafficManagerEndpointMonitorStatus> EndpointMonitorStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.TrafficManager.TrafficManagerEndpointStatus> EndpointStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> GeoMapping { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> MinChildEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MinChildEndpointsIPv4 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MinChildEndpointsIPv6 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.TrafficManager.TrafficManagerProfile Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.TrafficManager.TrafficManagerEndpointSubnetInfo> Subnets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Target { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TargetResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> Weight { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.TrafficManager.ExternalEndpointTrafficManagerEndpoint FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_04_01;
        }
    }
    public partial class NestedEndpointTrafficManagerEndpoint : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NestedEndpointTrafficManagerEndpoint(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.TrafficManager.TrafficManagerEndpointAlwaysServeStatus> AlwaysServe { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.TrafficManager.TrafficManagerEndpointCustomHeaderInfo> CustomHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EndpointLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.TrafficManager.TrafficManagerEndpointMonitorStatus> EndpointMonitorStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.TrafficManager.TrafficManagerEndpointStatus> EndpointStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> GeoMapping { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> MinChildEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MinChildEndpointsIPv4 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MinChildEndpointsIPv6 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.TrafficManager.TrafficManagerProfile Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.TrafficManager.TrafficManagerEndpointSubnetInfo> Subnets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Target { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TargetResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> Weight { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.TrafficManager.NestedEndpointTrafficManagerEndpoint FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_04_01;
        }
    }
    public partial class TrafficManagerDnsConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TrafficManagerDnsConfig() { }
        public Azure.Provisioning.BicepValue<string> Fqdn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RelativeName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> Ttl { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum TrafficManagerEndpointAlwaysServeStatus
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class TrafficManagerEndpointCustomHeaderInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TrafficManagerEndpointCustomHeaderInfo() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum TrafficManagerEndpointMonitorStatus
    {
        CheckingEndpoint = 0,
        Online = 1,
        Degraded = 2,
        Disabled = 3,
        Inactive = 4,
        Stopped = 5,
        Unmonitored = 6,
    }
    public enum TrafficManagerEndpointStatus
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class TrafficManagerEndpointSubnetInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TrafficManagerEndpointSubnetInfo() { }
        public Azure.Provisioning.BicepValue<System.Net.IPAddress> First { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Net.IPAddress> Last { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Scope { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TrafficManagerGeographicHierarchy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public TrafficManagerGeographicHierarchy(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.TrafficManager.TrafficManagerRegion GeographicHierarchy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.TrafficManager.TrafficManagerGeographicHierarchy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_04_01;
        }
    }
    public partial class TrafficManagerHeatMap : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public TrafficManagerHeatMap(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.TrafficManager.TrafficManagerHeatMapEndpoint> Endpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.TrafficManager.TrafficManagerProfile Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.TrafficManager.TrafficManagerHeatMapTrafficFlow> TrafficFlows { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.TrafficManager.TrafficManagerHeatMap FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_04_01;
        }
    }
    public partial class TrafficManagerHeatMapEndpoint : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TrafficManagerHeatMapEndpoint() { }
        public Azure.Provisioning.BicepValue<int> EndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TrafficManagerHeatMapQueryExperience : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TrafficManagerHeatMapQueryExperience() { }
        public Azure.Provisioning.BicepValue<int> EndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> Latency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> QueryCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TrafficManagerHeatMapTrafficFlow : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TrafficManagerHeatMapTrafficFlow() { }
        public Azure.Provisioning.BicepValue<double> Latitude { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> Longitude { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.TrafficManager.TrafficManagerHeatMapQueryExperience> QueryExperiences { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Net.IPAddress> SourceIP { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TrafficManagerMonitorConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TrafficManagerMonitorConfig() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.TrafficManager.TrafficManagerMonitorConfigCustomHeaderInfo> CustomHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.TrafficManager.ExpectedStatusCodeRangeInfo> ExpectedStatusCodeRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> IntervalInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.TrafficManager.TrafficManagerProfileMonitorStatus> ProfileMonitorStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.TrafficManager.TrafficManagerMonitorProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> TimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> ToleratedNumberOfFailures { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TrafficManagerMonitorConfigCustomHeaderInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TrafficManagerMonitorConfigCustomHeaderInfo() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum TrafficManagerMonitorProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="HTTP")]
        Http = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HTTPS")]
        Https = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TCP")]
        Tcp = 2,
    }
    public partial class TrafficManagerProfile : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public TrafficManagerProfile(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.TrafficManager.AllowedEndpointRecordType> AllowedEndpointRecordTypes { get { throw null; } set { } }
        public Azure.Provisioning.TrafficManager.TrafficManagerDnsConfig DnsConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.TrafficManager.AzureEndpointTrafficManagerEndpoint> Endpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MaxReturn { get { throw null; } set { } }
        public Azure.Provisioning.TrafficManager.TrafficManagerMonitorConfig MonitorConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.TrafficManager.TrafficManagerProfileStatus> ProfileStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.TrafficManager.TrafficRoutingMethod> TrafficRoutingMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.TrafficManager.TrafficViewEnrollmentStatus> TrafficViewEnrollmentStatus { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.TrafficManager.TrafficManagerProfile FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_04_01;
        }
    }
    public enum TrafficManagerProfileMonitorStatus
    {
        CheckingEndpoints = 0,
        Online = 1,
        Degraded = 2,
        Disabled = 3,
        Inactive = 4,
    }
    public enum TrafficManagerProfileStatus
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class TrafficManagerRegion : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TrafficManagerRegion() { }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.TrafficManager.TrafficManagerRegion> Regions { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TrafficManagerUserMetrics : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public TrafficManagerUserMetrics(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.TrafficManager.TrafficManagerUserMetrics FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_04_01;
        }
    }
    public enum TrafficRoutingMethod
    {
        Performance = 0,
        Priority = 1,
        Weighted = 2,
        Geographic = 3,
        MultiValue = 4,
        Subnet = 5,
    }
    public enum TrafficViewEnrollmentStatus
    {
        Enabled = 0,
        Disabled = 1,
    }
}
