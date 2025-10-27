namespace Azure.Provisioning.Dns
{
    public partial class DelegationSignerInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DelegationSignerInfo() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsAaaaRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsAaaaRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> IfMatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IfNoneMatch { get { throw null; } set { } }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsARecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsARecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> IfMatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IfNoneMatch { get { throw null; } set { } }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsCaaRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsCaaRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> IfMatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IfNoneMatch { get { throw null; } set { } }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsCnameRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsCnameRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> IfMatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IfNoneMatch { get { throw null; } set { } }
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
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> IfMatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IfNoneMatch { get { throw null; } set { } }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsMXRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsMXRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> IfMatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IfNoneMatch { get { throw null; } set { } }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsNaptrRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsNaptrRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> IfMatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IfNoneMatch { get { throw null; } set { } }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsNSRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsNSRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> IfMatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IfNoneMatch { get { throw null; } set { } }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsPtrRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsPtrRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> IfMatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IfNoneMatch { get { throw null; } set { } }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnssecConfig : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnssecConfig(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> IfMatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IfNoneMatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Dns.DnsZone? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Dns.DnssecConfig FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_04_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_05_01;
        }
    }
    public partial class DnsSigningKey : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DnsSigningKey() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsSoaRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsSoaRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> IfMatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IfNoneMatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Dns.DnsZone? Parent { get { throw null; } set { } }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsSrvRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsSrvRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> IfMatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IfNoneMatch { get { throw null; } set { } }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsTlsaRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsTlsaRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> IfMatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IfNoneMatch { get { throw null; } set { } }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsTxtRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsTxtRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> IfMatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IfNoneMatch { get { throw null; } set { } }
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
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DnsZone : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DnsZone(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> IfMatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IfNoneMatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
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
        protected override void DefineProvisionableProperties() { }
    }
}
