namespace Azure.Provisioning.Dns
{
    public partial class DnsAaaaRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsAaaaRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Dns.DnsAaaaRecordInfo> DnsAaaaRecords { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Dns.DnsZone? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Dns.DnsAaaaRecord FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_04_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_05_01;
        }
    }
    public partial class DnsAaaaRecordInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DnsAaaaRecordInfo() { }
        public Azure.Provisioning.BicepValue<System.Net.IPAddress> Ipv6Addresses { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsARecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsARecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Dns.DnsARecordInfo> DnsARecords { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Dns.DnsZone? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Dns.DnsARecord FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_04_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_05_01;
        }
    }
    public partial class DnsARecordInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DnsARecordInfo() { }
        public Azure.Provisioning.BicepValue<System.Net.IPAddress> Ipv4Addresses { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsCaaRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsCaaRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Dns.DnsCaaRecordInfo> DnsCaaRecords { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Dns.DnsZone? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Dns.DnsCaaRecord FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_05_01;
        }
    }
    public partial class DnsCaaRecordInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DnsCaaRecordInfo() { }
        public Azure.Provisioning.BicepValue<int> Flags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsCnameRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsCnameRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Cname { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Dns.DnsZone? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Dns.DnsCnameRecord FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_04_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_05_01;
        }
    }
    public partial class DnsDSRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsDSRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Dns.DnsDSRecordInfo> DnsDsRecords { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Dns.DnsZone? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Dns.DnsDSRecord FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_04_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_05_01;
        }
    }
    public partial class DnsDSRecordInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DnsDSRecordInfo() { }
        public Azure.Provisioning.BicepValue<int> Algorithm { get { throw null; } set { } }
        public Azure.Provisioning.Dns.DSRecordDigest Digest { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> KeyTag { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsMXRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsMXRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Dns.DnsMXRecordInfo> DnsMxRecords { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Dns.DnsZone? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Dns.DnsMXRecord FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_04_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_05_01;
        }
    }
    public partial class DnsMXRecordInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DnsMXRecordInfo() { }
        public Azure.Provisioning.BicepValue<string> Exchange { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Preference { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsNaptrRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsNaptrRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Dns.DnsNaptrRecordInfo> DnsNaptrRecords { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Dns.DnsZone? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Dns.DnsNaptrRecord FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_04_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_05_01;
        }
    }
    public partial class DnsNaptrRecordInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DnsNaptrRecordInfo() { }
        public Azure.Provisioning.BicepValue<string> Flags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Order { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Preference { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Regexp { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Replacement { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Services { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsNSRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsNSRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Dns.DnsNSRecordInfo> DnsNSRecords { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Dns.DnsZone? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Dns.DnsNSRecord FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_04_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_05_01;
        }
    }
    public partial class DnsNSRecordInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DnsNSRecordInfo() { }
        public Azure.Provisioning.BicepValue<string> DnsNSDomainName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsPtrRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsPtrRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Dns.DnsPtrRecordInfo> DnsPtrRecords { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Dns.DnsZone? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Dns.DnsPtrRecord FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_04_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_05_01;
        }
    }
    public partial class DnsPtrRecordInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DnsPtrRecordInfo() { }
        public Azure.Provisioning.BicepValue<string> DnsPtrDomainName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsSoaRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsSoaRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Dns.DnsZone? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Dns.DnsSoaRecordInfo SoaRecord { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Dns.DnsSoaRecord FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_04_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_05_01;
        }
    }
    public partial class DnsSoaRecordInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DnsSoaRecordInfo() { }
        public Azure.Provisioning.BicepValue<string> Email { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> ExpireTimeInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MinimumTtlInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> RefreshTimeInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> RetryTimeInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> SerialNumber { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsSrvRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsSrvRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Dns.DnsSrvRecordInfo> DnsSrvRecords { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Dns.DnsZone? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Dns.DnsSrvRecord FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_04_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_05_01;
        }
    }
    public partial class DnsSrvRecordInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DnsSrvRecordInfo() { }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Target { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Weight { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsTlsaRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsTlsaRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Dns.DnsTlsaRecordInfo> DnsTlsaRecords { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Dns.DnsZone? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Dns.DnsTlsaRecord FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_04_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_05_01;
        }
    }
    public partial class DnsTlsaRecordInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DnsTlsaRecordInfo() { }
        public Azure.Provisioning.BicepValue<string> CertAssociationData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MatchingType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Selector { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Usage { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsTxtRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsTxtRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Dns.DnsTxtRecordInfo> DnsTxtRecords { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Dns.DnsZone? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Dns.DnsTxtRecord FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_04_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_05_01;
        }
    }
    public partial class DnsTxtRecordInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DnsTxtRecordInfo() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsZone : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsZone(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> RegistrationVirtualNetworks { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> ResolutionVirtualNetworks { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Dns.DnsZoneType> ZoneType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Dns.DnsZone FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_04_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_05_01;
        }
    }
    public enum DnsZoneType
    {
        Public = 0,
        Private = 1,
    }
    public partial class DSRecordDigest : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DSRecordDigest() { }
        public Azure.Provisioning.BicepValue<int> AlgorithmType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
