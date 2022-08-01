namespace Azure.ResourceManager.Dns
{
    public partial class AaaaRecordSetData : Azure.ResourceManager.Models.ResourceData
    {
        public AaaaRecordSetData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.DnsAaaaRecord> AaaaRecords { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public long? TtlInSeconds { get { throw null; } set { } }
    }
    public partial class ARecordSetData : Azure.ResourceManager.Models.ResourceData
    {
        public ARecordSetData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.DnsARecord> ARecords { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public long? TtlInSeconds { get { throw null; } set { } }
    }
    public partial class CaaRecordSetData : Azure.ResourceManager.Models.ResourceData
    {
        public CaaRecordSetData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.DnsCaaRecord> CaaRecords { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public long? TtlInSeconds { get { throw null; } set { } }
    }
    public partial class CnameRecordSetData : Azure.ResourceManager.Models.ResourceData
    {
        public CnameRecordSetData() { }
        public string Cname { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public long? TtlInSeconds { get { throw null; } set { } }
    }
    public static partial class DnsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Dns.Models.DnsResourceReferenceResult> GetByTargetResourcesDnsResourceReference(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Dns.Models.DnsResourceReferenceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.Models.DnsResourceReferenceResult>> GetByTargetResourcesDnsResourceReferenceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Dns.Models.DnsResourceReferenceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Dns.DnsZoneResource> GetDnsZone(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string zoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.DnsZoneResource>> GetDnsZoneAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string zoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Dns.DnsZoneResource GetDnsZoneResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.DnsZoneCollection GetDnsZones(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Dns.DnsZoneResource> GetDnsZonesByDnszone(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Dns.DnsZoneResource> GetDnsZonesByDnszoneAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Dns.RecordSetAaaaResource GetRecordSetAaaaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.RecordSetAResource GetRecordSetAResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.RecordSetCaaResource GetRecordSetCaaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.RecordSetCnameResource GetRecordSetCnameResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.RecordSetMXResource GetRecordSetMXResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.RecordSetNSResource GetRecordSetNSResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.RecordSetPtrResource GetRecordSetPtrResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.RecordSetSoaResource GetRecordSetSoaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.RecordSetSrvResource GetRecordSetSrvResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.RecordSetTxtResource GetRecordSetTxtResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DnsZoneCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.DnsZoneResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.DnsZoneResource>, System.Collections.IEnumerable
    {
        protected DnsZoneCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.DnsZoneResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string zoneName, Azure.ResourceManager.Dns.DnsZoneData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.DnsZoneResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string zoneName, Azure.ResourceManager.Dns.DnsZoneData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string zoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string zoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.DnsZoneResource> Get(string zoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.DnsZoneResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.DnsZoneResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.DnsZoneResource>> GetAsync(string zoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.DnsZoneResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.DnsZoneResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.DnsZoneResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.DnsZoneResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DnsZoneData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DnsZoneData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public long? MaxNumberOfRecordSets { get { throw null; } }
        public long? MaxNumberOfRecordsPerRecordSet { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NameServers { get { throw null; } }
        public long? NumberOfRecordSets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> RegistrationVirtualNetworks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ResolutionVirtualNetworks { get { throw null; } }
        public Azure.ResourceManager.Dns.Models.DnsZoneType? ZoneType { get { throw null; } set { } }
    }
    public partial class DnsZoneResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DnsZoneResource() { }
        public virtual Azure.ResourceManager.Dns.DnsZoneData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Dns.DnsZoneResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.DnsZoneResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.DnsZoneResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetAResource> GetAllRecordSets(int? top = default(int?), string recordSetNameSuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetAResource> GetAllRecordSetsAsync(int? top = default(int?), string recordSetNameSuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.DnsZoneResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetAResource> GetRecordSetA(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetAaaaResource> GetRecordSetAaaa(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetAaaaResource>> GetRecordSetAaaaAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dns.RecordSetAaaaCollection GetRecordSetAaaas() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetAResource>> GetRecordSetAAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dns.RecordSetACollection GetRecordSetACollection() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetCaaResource> GetRecordSetCaa(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetCaaResource>> GetRecordSetCaaAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dns.RecordSetCaaCollection GetRecordSetCaas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetCnameResource> GetRecordSetCname(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetCnameResource>> GetRecordSetCnameAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dns.RecordSetCnameCollection GetRecordSetCnames() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetMXResource> GetRecordSetMX(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetMXResource>> GetRecordSetMXAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dns.RecordSetMXCollection GetRecordSetMXes() { throw null; }
        public virtual Azure.ResourceManager.Dns.RecordSetNSCollection GetRecordSetNS() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetNSResource> GetRecordSetNS(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetNSResource>> GetRecordSetNSAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetPtrResource> GetRecordSetPtr(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetPtrResource>> GetRecordSetPtrAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dns.RecordSetPtrCollection GetRecordSetPtrs() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetAResource> GetRecordSets(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetAResource> GetRecordSetsAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetSoaResource> GetRecordSetSoa(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetSoaResource>> GetRecordSetSoaAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dns.RecordSetSoaCollection GetRecordSetSoas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetSrvResource> GetRecordSetSrv(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetSrvResource>> GetRecordSetSrvAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dns.RecordSetSrvCollection GetRecordSetSrvs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetTxtResource> GetRecordSetTxt(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetTxtResource>> GetRecordSetTxtAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dns.RecordSetTxtCollection GetRecordSetTxts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.DnsZoneResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.DnsZoneResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.DnsZoneResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.DnsZoneResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MXRecordSetData : Azure.ResourceManager.Models.ResourceData
    {
        public MXRecordSetData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.DnsMXRecord> MXRecords { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public long? TtlInSeconds { get { throw null; } set { } }
    }
    public partial class NSRecordSetData : Azure.ResourceManager.Models.ResourceData
    {
        public NSRecordSetData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.DnsNSRecord> NSRecords { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public long? TtlInSeconds { get { throw null; } set { } }
    }
    public partial class PtrRecordSetData : Azure.ResourceManager.Models.ResourceData
    {
        public PtrRecordSetData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.DnsPtrRecord> PtrRecords { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public long? TtlInSeconds { get { throw null; } set { } }
    }
    public partial class RecordSetAaaaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetAaaaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetAaaaResource>, System.Collections.IEnumerable
    {
        protected RecordSetAaaaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.RecordSetAaaaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.AaaaRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.RecordSetAaaaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.AaaaRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetAaaaResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetAaaaResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetAaaaResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetAaaaResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.RecordSetAaaaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetAaaaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.RecordSetAaaaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetAaaaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecordSetAaaaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecordSetAaaaResource() { }
        public virtual Azure.ResourceManager.Dns.AaaaRecordSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetAaaaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetAaaaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetAaaaResource> Update(Azure.ResourceManager.Dns.AaaaRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetAaaaResource>> UpdateAsync(Azure.ResourceManager.Dns.AaaaRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecordSetACollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetAResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetAResource>, System.Collections.IEnumerable
    {
        protected RecordSetACollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.RecordSetAResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.ARecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.RecordSetAResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.ARecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetAResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetAResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetAResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetAResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.RecordSetAResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetAResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.RecordSetAResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetAResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecordSetAResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecordSetAResource() { }
        public virtual Azure.ResourceManager.Dns.ARecordSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetAResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetAResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetAResource> Update(Azure.ResourceManager.Dns.ARecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetAResource>> UpdateAsync(Azure.ResourceManager.Dns.ARecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecordSetCaaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetCaaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetCaaResource>, System.Collections.IEnumerable
    {
        protected RecordSetCaaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.RecordSetCaaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.CaaRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.RecordSetCaaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.CaaRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetCaaResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetCaaResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetCaaResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetCaaResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.RecordSetCaaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetCaaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.RecordSetCaaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetCaaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecordSetCaaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecordSetCaaResource() { }
        public virtual Azure.ResourceManager.Dns.CaaRecordSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetCaaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetCaaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetCaaResource> Update(Azure.ResourceManager.Dns.CaaRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetCaaResource>> UpdateAsync(Azure.ResourceManager.Dns.CaaRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecordSetCnameCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetCnameResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetCnameResource>, System.Collections.IEnumerable
    {
        protected RecordSetCnameCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.RecordSetCnameResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.CnameRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.RecordSetCnameResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.CnameRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetCnameResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetCnameResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetCnameResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetCnameResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.RecordSetCnameResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetCnameResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.RecordSetCnameResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetCnameResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecordSetCnameResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecordSetCnameResource() { }
        public virtual Azure.ResourceManager.Dns.CnameRecordSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetCnameResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetCnameResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetCnameResource> Update(Azure.ResourceManager.Dns.CnameRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetCnameResource>> UpdateAsync(Azure.ResourceManager.Dns.CnameRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecordSetData : Azure.ResourceManager.Models.ResourceData
    {
        public RecordSetData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.DnsAaaaRecord> AaaaRecords { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.DnsARecord> ARecords { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.DnsCaaRecord> CaaRecords { get { throw null; } }
        public string Cname { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.DnsMXRecord> MXRecords { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.DnsNSRecord> NSRecords { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.DnsPtrRecord> PtrRecords { get { throw null; } }
        public Azure.ResourceManager.Dns.Models.DnsSoaRecord SoaRecord { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.DnsSrvRecord> SrvRecords { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public long? TtlInSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.DnsTxtRecord> TxtRecords { get { throw null; } }
    }
    public partial class RecordSetMXCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetMXResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetMXResource>, System.Collections.IEnumerable
    {
        protected RecordSetMXCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.RecordSetMXResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.MXRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.RecordSetMXResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.MXRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetMXResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetMXResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetMXResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetMXResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.RecordSetMXResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetMXResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.RecordSetMXResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetMXResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecordSetMXResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecordSetMXResource() { }
        public virtual Azure.ResourceManager.Dns.MXRecordSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetMXResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetMXResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetMXResource> Update(Azure.ResourceManager.Dns.MXRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetMXResource>> UpdateAsync(Azure.ResourceManager.Dns.MXRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecordSetNSCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetNSResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetNSResource>, System.Collections.IEnumerable
    {
        protected RecordSetNSCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.RecordSetNSResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.NSRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.RecordSetNSResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.NSRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetNSResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetNSResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetNSResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetNSResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.RecordSetNSResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetNSResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.RecordSetNSResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetNSResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecordSetNSResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecordSetNSResource() { }
        public virtual Azure.ResourceManager.Dns.NSRecordSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetNSResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetNSResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetNSResource> Update(Azure.ResourceManager.Dns.NSRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetNSResource>> UpdateAsync(Azure.ResourceManager.Dns.NSRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecordSetPtrCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetPtrResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetPtrResource>, System.Collections.IEnumerable
    {
        protected RecordSetPtrCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.RecordSetPtrResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.PtrRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.RecordSetPtrResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.PtrRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetPtrResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetPtrResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetPtrResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetPtrResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.RecordSetPtrResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetPtrResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.RecordSetPtrResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetPtrResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecordSetPtrResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecordSetPtrResource() { }
        public virtual Azure.ResourceManager.Dns.PtrRecordSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetPtrResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetPtrResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetPtrResource> Update(Azure.ResourceManager.Dns.PtrRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetPtrResource>> UpdateAsync(Azure.ResourceManager.Dns.PtrRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecordSetSoaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetSoaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetSoaResource>, System.Collections.IEnumerable
    {
        protected RecordSetSoaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.RecordSetSoaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.SoaRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.RecordSetSoaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.SoaRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetSoaResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetSoaResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetSoaResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetSoaResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.RecordSetSoaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetSoaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.RecordSetSoaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetSoaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecordSetSoaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecordSetSoaResource() { }
        public virtual Azure.ResourceManager.Dns.SoaRecordSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetSoaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetSoaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetSoaResource> Update(Azure.ResourceManager.Dns.SoaRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetSoaResource>> UpdateAsync(Azure.ResourceManager.Dns.SoaRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecordSetSrvCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetSrvResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetSrvResource>, System.Collections.IEnumerable
    {
        protected RecordSetSrvCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.RecordSetSrvResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.SrvRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.RecordSetSrvResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.SrvRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetSrvResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetSrvResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetSrvResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetSrvResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.RecordSetSrvResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetSrvResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.RecordSetSrvResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetSrvResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecordSetSrvResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecordSetSrvResource() { }
        public virtual Azure.ResourceManager.Dns.SrvRecordSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetSrvResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetSrvResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetSrvResource> Update(Azure.ResourceManager.Dns.SrvRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetSrvResource>> UpdateAsync(Azure.ResourceManager.Dns.SrvRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecordSetTxtCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetTxtResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetTxtResource>, System.Collections.IEnumerable
    {
        protected RecordSetTxtCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.RecordSetTxtResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.TxtRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.RecordSetTxtResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.TxtRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetTxtResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetTxtResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetTxtResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetTxtResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.RecordSetTxtResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetTxtResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.RecordSetTxtResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetTxtResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecordSetTxtResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecordSetTxtResource() { }
        public virtual Azure.ResourceManager.Dns.TxtRecordSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetTxtResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetTxtResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetTxtResource> Update(Azure.ResourceManager.Dns.TxtRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetTxtResource>> UpdateAsync(Azure.ResourceManager.Dns.TxtRecordSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SoaRecordSetData : Azure.ResourceManager.Models.ResourceData
    {
        public SoaRecordSetData() { }
        public string Etag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Dns.Models.DnsSoaRecord SoaRecord { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public long? TtlInSeconds { get { throw null; } set { } }
    }
    public partial class SrvRecordSetData : Azure.ResourceManager.Models.ResourceData
    {
        public SrvRecordSetData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.DnsSrvRecord> SrvRecords { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public long? TtlInSeconds { get { throw null; } set { } }
    }
    public partial class TxtRecordSetData : Azure.ResourceManager.Models.ResourceData
    {
        public TxtRecordSetData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public long? TtlInSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.DnsTxtRecord> TxtRecords { get { throw null; } }
    }
}
namespace Azure.ResourceManager.Dns.Models
{
    public partial class DnsAaaaRecord
    {
        public DnsAaaaRecord() { }
        public System.Net.IPAddress IPv6Address { get { throw null; } set { } }
    }
    public partial class DnsARecord
    {
        public DnsARecord() { }
        public System.Net.IPAddress IPv4Address { get { throw null; } set { } }
    }
    public partial class DnsCaaRecord
    {
        public DnsCaaRecord() { }
        public int? Flags { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class DnsMXRecord
    {
        public DnsMXRecord() { }
        public string Exchange { get { throw null; } set { } }
        public int? Preference { get { throw null; } set { } }
    }
    public partial class DnsNSRecord
    {
        public DnsNSRecord() { }
        public string DnsNsDomainName { get { throw null; } set { } }
    }
    public partial class DnsPtrRecord
    {
        public DnsPtrRecord() { }
        public string DnsPtrDomainName { get { throw null; } set { } }
    }
    public partial class DnsResourceReference
    {
        internal DnsResourceReference() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WritableSubResource> DnsResources { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } }
    }
    public partial class DnsResourceReferenceContent
    {
        public DnsResourceReferenceContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> TargetResources { get { throw null; } }
    }
    public partial class DnsResourceReferenceResult
    {
        internal DnsResourceReferenceResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Dns.Models.DnsResourceReference> DnsResourceReferences { get { throw null; } }
    }
    public partial class DnsSoaRecord
    {
        public DnsSoaRecord() { }
        public string Email { get { throw null; } set { } }
        public long? ExpireTimeInSeconds { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        public long? MinimumTtlInSeconds { get { throw null; } set { } }
        public long? RefreshTimeInSeconds { get { throw null; } set { } }
        public long? RetryTimeInSeconds { get { throw null; } set { } }
        public long? SerialNumber { get { throw null; } set { } }
    }
    public partial class DnsSrvRecord
    {
        public DnsSrvRecord() { }
        public int? Port { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        public int? Weight { get { throw null; } set { } }
    }
    public partial class DnsTxtRecord
    {
        public DnsTxtRecord() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class DnsZonePatch
    {
        public DnsZonePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public enum DnsZoneType
    {
        Public = 0,
        Private = 1,
    }
}
