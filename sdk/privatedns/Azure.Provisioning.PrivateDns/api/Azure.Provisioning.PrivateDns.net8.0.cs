namespace Azure.Provisioning.PrivateDns
{
    public partial class PrivateDnsAaaaRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PrivateDnsAaaaRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.PrivateDns.PrivateDnsZone? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.PrivateDns.PrivateDnsAaaaRecordInfo> PrivateDnsAaaaRecords { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> TtlInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PrivateDns.PrivateDnsAaaaRecord FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_09_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_06_01;
            public static readonly string V2024_06_01;
        }
    }
    public partial class PrivateDnsAaaaRecordInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateDnsAaaaRecordInfo() { }
        public Azure.Provisioning.BicepValue<System.Net.IPAddress> IPv6Address { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PrivateDnsARecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PrivateDnsARecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.PrivateDns.PrivateDnsZone? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.PrivateDns.PrivateDnsARecordInfo> PrivateDnsARecords { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> TtlInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PrivateDns.PrivateDnsARecord FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_09_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_06_01;
            public static readonly string V2024_06_01;
        }
    }
    public partial class PrivateDnsARecordInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateDnsARecordInfo() { }
        public Azure.Provisioning.BicepValue<System.Net.IPAddress> IPv4Address { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PrivateDnsCnameRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PrivateDnsCnameRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Cname { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.PrivateDns.PrivateDnsZone? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> TtlInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PrivateDns.PrivateDnsCnameRecord FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_09_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_06_01;
            public static readonly string V2024_06_01;
        }
    }
    public partial class PrivateDnsMXRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PrivateDnsMXRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.PrivateDns.PrivateDnsZone? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.PrivateDns.PrivateDnsMXRecordInfo> PrivateDnsMXRecords { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> TtlInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PrivateDns.PrivateDnsMXRecord FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_09_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_06_01;
            public static readonly string V2024_06_01;
        }
    }
    public partial class PrivateDnsMXRecordInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateDnsMXRecordInfo() { }
        public Azure.Provisioning.BicepValue<string> Exchange { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Preference { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PrivateDnsProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Failed = 4,
        Canceled = 5,
    }
    public partial class PrivateDnsPtrRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PrivateDnsPtrRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.PrivateDns.PrivateDnsZone? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.PrivateDns.PrivateDnsPtrRecordInfo> PrivateDnsPtrRecords { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> TtlInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PrivateDns.PrivateDnsPtrRecord FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_09_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_06_01;
            public static readonly string V2024_06_01;
        }
    }
    public partial class PrivateDnsPtrRecordInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateDnsPtrRecordInfo() { }
        public Azure.Provisioning.BicepValue<string> PtrDomainName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PrivateDnsResolutionPolicy
    {
        Default = 0,
        NxDomainRedirect = 1,
    }
    public partial class PrivateDnsSoaRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PrivateDnsSoaRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.PrivateDns.PrivateDnsZone? Parent { get { throw null; } set { } }
        public Azure.Provisioning.PrivateDns.PrivateDnsSoaRecordInfo PrivateDnsSoaRecordInfo { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> TtlInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PrivateDns.PrivateDnsSoaRecord FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_09_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_06_01;
            public static readonly string V2024_06_01;
        }
    }
    public partial class PrivateDnsSoaRecordInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateDnsSoaRecordInfo() { }
        public Azure.Provisioning.BicepValue<string> Email { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> ExpireTimeInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MinimumTtlInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> RefreshTimeInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> RetryTimeInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> SerialNumber { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PrivateDnsSrvRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PrivateDnsSrvRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.PrivateDns.PrivateDnsZone? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.PrivateDns.PrivateDnsSrvRecordInfo> PrivateDnsSrvRecords { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> TtlInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PrivateDns.PrivateDnsSrvRecord FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_09_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_06_01;
            public static readonly string V2024_06_01;
        }
    }
    public partial class PrivateDnsSrvRecordInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateDnsSrvRecordInfo() { }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Target { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Weight { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PrivateDnsTxtRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PrivateDnsTxtRecord(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.PrivateDns.PrivateDnsZone? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.PrivateDns.PrivateDnsTxtRecordInfo> PrivateDnsTxtRecords { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> TtlInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PrivateDns.PrivateDnsTxtRecord FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_09_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_06_01;
            public static readonly string V2024_06_01;
        }
    }
    public partial class PrivateDnsTxtRecordInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateDnsTxtRecordInfo() { }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PrivateDnsZone : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PrivateDnsZone(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InternalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MaxNumberOfRecords { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> MaxNumberOfVirtualNetworkLinks { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> MaxNumberOfVirtualNetworkLinksWithRegistration { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> NumberOfRecords { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> NumberOfVirtualNetworkLinks { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> NumberOfVirtualNetworkLinksWithRegistration { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PrivateDns.PrivateDnsProvisioningState> PrivateDnsProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PrivateDns.PrivateDnsZone FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_09_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_06_01;
            public static readonly string V2024_06_01;
        }
    }
    public partial class VirtualNetworkLink : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualNetworkLink(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.PrivateDns.PrivateDnsZone? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PrivateDns.PrivateDnsProvisioningState> PrivateDnsProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PrivateDns.PrivateDnsResolutionPolicy> PrivateDnsResolutionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RegistrationEnabled { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualNetworkId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PrivateDns.VirtualNetworkLinkState> VirtualNetworkLinkState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PrivateDns.VirtualNetworkLink FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_09_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_06_01;
            public static readonly string V2024_06_01;
        }
    }
    public enum VirtualNetworkLinkState
    {
        InProgress = 0,
        Completed = 1,
    }
}
