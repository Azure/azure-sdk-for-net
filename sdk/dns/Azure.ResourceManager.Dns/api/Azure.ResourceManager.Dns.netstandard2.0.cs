namespace Azure.ResourceManager.Dns
{
    public partial class DnsManagementClient
    {
        protected DnsManagementClient() { }
        public DnsManagementClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.Dns.DnsManagementClientOptions options = null) { }
        public DnsManagementClient(string subscriptionId, System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.Dns.DnsManagementClientOptions options = null) { }
        public virtual Azure.ResourceManager.Dns.DnsResourceReferenceOperations DnsResourceReference { get { throw null; } }
        public virtual Azure.ResourceManager.Dns.RecordSetsOperations RecordSets { get { throw null; } }
        public virtual Azure.ResourceManager.Dns.ZonesOperations Zones { get { throw null; } }
    }
    public partial class DnsManagementClientOptions : Azure.Core.ClientOptions
    {
        public DnsManagementClientOptions() { }
    }
    public partial class DnsResourceReferenceOperations
    {
        protected DnsResourceReferenceOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Dns.Models.DnsResourceReferenceResult> GetByTargetResources(Azure.ResourceManager.Dns.Models.DnsResourceReferenceRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.Models.DnsResourceReferenceResult>> GetByTargetResourcesAsync(Azure.ResourceManager.Dns.Models.DnsResourceReferenceRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecordSetsOperations
    {
        protected RecordSetsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Dns.Models.RecordSet> CreateOrUpdate(string resourceGroupName, string zoneName, string relativeRecordSetName, Azure.ResourceManager.Dns.Models.RecordType recordType, Azure.ResourceManager.Dns.Models.RecordSet parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.Models.RecordSet>> CreateOrUpdateAsync(string resourceGroupName, string zoneName, string relativeRecordSetName, Azure.ResourceManager.Dns.Models.RecordType recordType, Azure.ResourceManager.Dns.Models.RecordSet parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string zoneName, string relativeRecordSetName, Azure.ResourceManager.Dns.Models.RecordType recordType, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string zoneName, string relativeRecordSetName, Azure.ResourceManager.Dns.Models.RecordType recordType, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.Models.RecordSet> Get(string resourceGroupName, string zoneName, string relativeRecordSetName, Azure.ResourceManager.Dns.Models.RecordType recordType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.Models.RecordSet>> GetAsync(string resourceGroupName, string zoneName, string relativeRecordSetName, Azure.ResourceManager.Dns.Models.RecordType recordType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.Models.RecordSet> ListAllByDnsZone(string resourceGroupName, string zoneName, int? top = default(int?), string recordSetNameSuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.Models.RecordSet> ListAllByDnsZoneAsync(string resourceGroupName, string zoneName, int? top = default(int?), string recordSetNameSuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.Models.RecordSet> ListByDnsZone(string resourceGroupName, string zoneName, int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.Models.RecordSet> ListByDnsZoneAsync(string resourceGroupName, string zoneName, int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.Models.RecordSet> ListByType(string resourceGroupName, string zoneName, Azure.ResourceManager.Dns.Models.RecordType recordType, int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.Models.RecordSet> ListByTypeAsync(string resourceGroupName, string zoneName, Azure.ResourceManager.Dns.Models.RecordType recordType, int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.Models.RecordSet> Update(string resourceGroupName, string zoneName, string relativeRecordSetName, Azure.ResourceManager.Dns.Models.RecordType recordType, Azure.ResourceManager.Dns.Models.RecordSet parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.Models.RecordSet>> UpdateAsync(string resourceGroupName, string zoneName, string relativeRecordSetName, Azure.ResourceManager.Dns.Models.RecordType recordType, Azure.ResourceManager.Dns.Models.RecordSet parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ZonesDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected ZonesDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ZonesOperations
    {
        protected ZonesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Dns.Models.Zone> CreateOrUpdate(string resourceGroupName, string zoneName, Azure.ResourceManager.Dns.Models.Zone parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.Models.Zone>> CreateOrUpdateAsync(string resourceGroupName, string zoneName, Azure.ResourceManager.Dns.Models.Zone parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.Models.Zone> Get(string resourceGroupName, string zoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.Models.Zone>> GetAsync(string resourceGroupName, string zoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.Models.Zone> List(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.Models.Zone> ListAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.Models.Zone> ListByResourceGroup(string resourceGroupName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.Models.Zone> ListByResourceGroupAsync(string resourceGroupName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dns.ZonesDeleteOperation StartDelete(string resourceGroupName, string zoneName, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Dns.ZonesDeleteOperation> StartDeleteAsync(string resourceGroupName, string zoneName, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.Models.Zone> Update(string resourceGroupName, string zoneName, Azure.ResourceManager.Dns.Models.ZoneUpdate parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.Models.Zone>> UpdateAsync(string resourceGroupName, string zoneName, Azure.ResourceManager.Dns.Models.ZoneUpdate parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Dns.Models
{
    public partial class AaaaRecord
    {
        public AaaaRecord() { }
        public string Ipv6Address { get { throw null; } set { } }
    }
    public partial class ARecord
    {
        public ARecord() { }
        public string Ipv4Address { get { throw null; } set { } }
    }
    public partial class CaaRecord
    {
        public CaaRecord() { }
        public int? Flags { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class CnameRecord
    {
        public CnameRecord() { }
        public string Cname { get { throw null; } set { } }
    }
    public partial class DnsResourceReference
    {
        internal DnsResourceReference() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Dns.Models.SubResource> DnsResources { get { throw null; } }
        public Azure.ResourceManager.Dns.Models.SubResource TargetResource { get { throw null; } }
    }
    public partial class DnsResourceReferenceRequest
    {
        public DnsResourceReferenceRequest() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.SubResource> TargetResources { get { throw null; } }
    }
    public partial class DnsResourceReferenceResult
    {
        internal DnsResourceReferenceResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Dns.Models.DnsResourceReference> DnsResourceReferences { get { throw null; } }
    }
    public partial class MxRecord
    {
        public MxRecord() { }
        public string Exchange { get { throw null; } set { } }
        public int? Preference { get { throw null; } set { } }
    }
    public partial class NsRecord
    {
        public NsRecord() { }
        public string Nsdname { get { throw null; } set { } }
    }
    public partial class PtrRecord
    {
        public PtrRecord() { }
        public string Ptrdname { get { throw null; } set { } }
    }
    public partial class RecordSet
    {
        public RecordSet() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.AaaaRecord> AaaaRecords { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.ARecord> ARecords { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.CaaRecord> CaaRecords { get { throw null; } }
        public Azure.ResourceManager.Dns.Models.CnameRecord CnameRecord { get { throw null; } set { } }
        public string Etag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.MxRecord> MxRecords { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.NsRecord> NsRecords { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.PtrRecord> PtrRecords { get { throw null; } }
        public Azure.ResourceManager.Dns.Models.SoaRecord SoaRecord { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.SrvRecord> SrvRecords { get { throw null; } }
        public Azure.ResourceManager.Dns.Models.SubResource TargetResource { get { throw null; } set { } }
        public long? TTL { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.TxtRecord> TxtRecords { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public enum RecordType
    {
        A = 0,
        Aaaa = 1,
        CAA = 2,
        Cname = 3,
        MX = 4,
        NS = 5,
        PTR = 6,
        SOA = 7,
        SRV = 8,
        TXT = 9,
    }
    public partial class Resource
    {
        public Resource(string location) { }
        public string Id { get { throw null; } }
        public string Location { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class SoaRecord
    {
        public SoaRecord() { }
        public string Email { get { throw null; } set { } }
        public long? ExpireTime { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        public long? MinimumTtl { get { throw null; } set { } }
        public long? RefreshTime { get { throw null; } set { } }
        public long? RetryTime { get { throw null; } set { } }
        public long? SerialNumber { get { throw null; } set { } }
    }
    public partial class SrvRecord
    {
        public SrvRecord() { }
        public int? Port { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        public int? Weight { get { throw null; } set { } }
    }
    public partial class SubResource
    {
        public SubResource() { }
        public string Id { get { throw null; } set { } }
    }
    public partial class TxtRecord
    {
        public TxtRecord() { }
        public System.Collections.Generic.IList<string> Value { get { throw null; } }
    }
    public partial class Zone : Azure.ResourceManager.Dns.Models.Resource
    {
        public Zone(string location) : base (default(string)) { }
        public string Etag { get { throw null; } set { } }
        public long? MaxNumberOfRecordSets { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NameServers { get { throw null; } }
        public long? NumberOfRecordSets { get { throw null; } }
        [System.ObsoleteAttribute("Private DNS is not allowed in this API anymore, use the privatedns API")]
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.SubResource> RegistrationVirtualNetworks { get { throw null; } }
        [System.ObsoleteAttribute("Private DNS is not allowed in this API anymore, use the privatedns API")]
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.SubResource> ResolutionVirtualNetworks { get { throw null; } }
        [System.ObsoleteAttribute("Private DNS is not allowed in this API anymore, use the privatedns API")]
        public Azure.ResourceManager.Dns.Models.ZoneType? ZoneType { get { throw null; } }
    }
    [System.ObsoleteAttribute("Enum is no longer support since privat dns is no longer supported (public only); please use the privatedns API")]
    public enum ZoneType
    {
        Public = 0,
        Private = 1,
    }
    public partial class ZoneUpdate
    {
        public ZoneUpdate() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
}
