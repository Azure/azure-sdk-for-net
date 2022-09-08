namespace Azure.ResourceManager.Dns
{
    public partial class AaaaRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.AaaaRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.AaaaRecordResource>, System.Collections.IEnumerable
    {
        protected AaaaRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.AaaaRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.AaaaRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.AaaaRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.AaaaRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.AaaaRecordResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.AaaaRecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.AaaaRecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.AaaaRecordResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.AaaaRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.AaaaRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.AaaaRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.AaaaRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AaaaRecordData : Azure.ResourceManager.Models.ResourceData
    {
        public AaaaRecordData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.AaaaRecordInfo> AaaaRecords { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public long? TtlInSeconds { get { throw null; } set { } }
    }
    public partial class AaaaRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AaaaRecordResource() { }
        public virtual Azure.ResourceManager.Dns.AaaaRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.AaaaRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.AaaaRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.AaaaRecordResource> Update(Azure.ResourceManager.Dns.AaaaRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.AaaaRecordResource>> UpdateAsync(Azure.ResourceManager.Dns.AaaaRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ARecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.ARecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.ARecordResource>, System.Collections.IEnumerable
    {
        protected ARecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.ARecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.ARecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.ARecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.ARecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.ARecordResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.ARecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.ARecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.ARecordResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.ARecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.ARecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.ARecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.ARecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ARecordData : Azure.ResourceManager.Models.ResourceData
    {
        public ARecordData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.ARecordInfo> ARecords { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public long? TtlInSeconds { get { throw null; } set { } }
    }
    public partial class ARecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ARecordResource() { }
        public virtual Azure.ResourceManager.Dns.ARecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.ARecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.ARecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.ARecordResource> Update(Azure.ResourceManager.Dns.ARecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.ARecordResource>> UpdateAsync(Azure.ResourceManager.Dns.ARecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CaaRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.CaaRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.CaaRecordResource>, System.Collections.IEnumerable
    {
        protected CaaRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.CaaRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.CaaRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.CaaRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.CaaRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.CaaRecordResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.CaaRecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.CaaRecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.CaaRecordResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.CaaRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.CaaRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.CaaRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.CaaRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CaaRecordData : Azure.ResourceManager.Models.ResourceData
    {
        public CaaRecordData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.CaaRecordInfo> CaaRecords { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public long? TtlInSeconds { get { throw null; } set { } }
    }
    public partial class CaaRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CaaRecordResource() { }
        public virtual Azure.ResourceManager.Dns.CaaRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.CaaRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.CaaRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.CaaRecordResource> Update(Azure.ResourceManager.Dns.CaaRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.CaaRecordResource>> UpdateAsync(Azure.ResourceManager.Dns.CaaRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CnameRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.CnameRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.CnameRecordResource>, System.Collections.IEnumerable
    {
        protected CnameRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.CnameRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.CnameRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.CnameRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.CnameRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.CnameRecordResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.CnameRecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.CnameRecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.CnameRecordResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.CnameRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.CnameRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.CnameRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.CnameRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CnameRecordData : Azure.ResourceManager.Models.ResourceData
    {
        public CnameRecordData() { }
        public string Cname { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public long? TtlInSeconds { get { throw null; } set { } }
    }
    public partial class CnameRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CnameRecordResource() { }
        public virtual Azure.ResourceManager.Dns.CnameRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.CnameRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.CnameRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.CnameRecordResource> Update(Azure.ResourceManager.Dns.CnameRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.CnameRecordResource>> UpdateAsync(Azure.ResourceManager.Dns.CnameRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DnsExtensions
    {
        public static Azure.ResourceManager.Dns.AaaaRecordResource GetAaaaRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.ARecordResource GetARecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Dns.Models.DnsResourceReferenceResult> GetByTargetResourcesDnsResourceReference(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Dns.Models.DnsResourceReferenceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.Models.DnsResourceReferenceResult>> GetByTargetResourcesDnsResourceReferenceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Dns.Models.DnsResourceReferenceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Dns.CaaRecordResource GetCaaRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.CnameRecordResource GetCnameRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Dns.DnsZoneResource> GetDnsZone(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string zoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.DnsZoneResource>> GetDnsZoneAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string zoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Dns.DnsZoneResource GetDnsZoneResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.DnsZoneCollection GetDnsZones(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Dns.DnsZoneResource> GetDnsZonesByDnszone(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Dns.DnsZoneResource> GetDnsZonesByDnszoneAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Dns.MXRecordResource GetMXRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.NSRecordResource GetNSRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.PtrRecordResource GetPtrRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.SoaRecordResource GetSoaRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.SrvRecordResource GetSrvRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.TxtRecordResource GetTxtRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Dns.AaaaRecordResource> GetAaaaRecord(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.AaaaRecordResource>> GetAaaaRecordAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dns.AaaaRecordCollection GetAaaaRecords() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetData> GetAllRecordSets(int? top = default(int?), string recordSetNameSuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetData> GetAllRecordSetsAsync(int? top = default(int?), string recordSetNameSuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.ARecordResource> GetARecord(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.ARecordResource>> GetARecordAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dns.ARecordCollection GetARecords() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.DnsZoneResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.CaaRecordResource> GetCaaRecord(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.CaaRecordResource>> GetCaaRecordAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dns.CaaRecordCollection GetCaaRecords() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.CnameRecordResource> GetCnameRecord(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.CnameRecordResource>> GetCnameRecordAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dns.CnameRecordCollection GetCnameRecords() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.MXRecordResource> GetMXRecord(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.MXRecordResource>> GetMXRecordAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dns.MXRecordCollection GetMXRecords() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.NSRecordResource> GetNSRecord(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.NSRecordResource>> GetNSRecordAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dns.NSRecordCollection GetNSRecords() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.PtrRecordResource> GetPtrRecord(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.PtrRecordResource>> GetPtrRecordAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dns.PtrRecordCollection GetPtrRecords() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetData> GetRecordSets(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetData> GetRecordSetsAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.SoaRecordResource> GetSoaRecord(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.SoaRecordResource>> GetSoaRecordAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dns.SoaRecordCollection GetSoaRecords() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.SrvRecordResource> GetSrvRecord(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.SrvRecordResource>> GetSrvRecordAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dns.SrvRecordCollection GetSrvRecords() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.TxtRecordResource> GetTxtRecord(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.TxtRecordResource>> GetTxtRecordAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dns.TxtRecordCollection GetTxtRecords() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.DnsZoneResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.DnsZoneResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.DnsZoneResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.DnsZoneResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.DnsZoneResource> Update(Azure.ResourceManager.Dns.Models.DnsZonePatch patch, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.DnsZoneResource>> UpdateAsync(Azure.ResourceManager.Dns.Models.DnsZonePatch patch, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MXRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.MXRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.MXRecordResource>, System.Collections.IEnumerable
    {
        protected MXRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.MXRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.MXRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.MXRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.MXRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.MXRecordResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.MXRecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.MXRecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.MXRecordResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.MXRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.MXRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.MXRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.MXRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MXRecordData : Azure.ResourceManager.Models.ResourceData
    {
        public MXRecordData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.MXRecordInfo> MXRecords { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public long? TtlInSeconds { get { throw null; } set { } }
    }
    public partial class MXRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MXRecordResource() { }
        public virtual Azure.ResourceManager.Dns.MXRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.MXRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.MXRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.MXRecordResource> Update(Azure.ResourceManager.Dns.MXRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.MXRecordResource>> UpdateAsync(Azure.ResourceManager.Dns.MXRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NSRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.NSRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.NSRecordResource>, System.Collections.IEnumerable
    {
        protected NSRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.NSRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.NSRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.NSRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.NSRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.NSRecordResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.NSRecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.NSRecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.NSRecordResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.NSRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.NSRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.NSRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.NSRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NSRecordData : Azure.ResourceManager.Models.ResourceData
    {
        public NSRecordData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.NSRecordInfo> NSRecords { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public long? TtlInSeconds { get { throw null; } set { } }
    }
    public partial class NSRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NSRecordResource() { }
        public virtual Azure.ResourceManager.Dns.NSRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.NSRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.NSRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.NSRecordResource> Update(Azure.ResourceManager.Dns.NSRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.NSRecordResource>> UpdateAsync(Azure.ResourceManager.Dns.NSRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PtrRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.PtrRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.PtrRecordResource>, System.Collections.IEnumerable
    {
        protected PtrRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.PtrRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.PtrRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.PtrRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.PtrRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.PtrRecordResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.PtrRecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.PtrRecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.PtrRecordResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.PtrRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.PtrRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.PtrRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.PtrRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PtrRecordData : Azure.ResourceManager.Models.ResourceData
    {
        public PtrRecordData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.PtrRecordInfo> PtrRecords { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public long? TtlInSeconds { get { throw null; } set { } }
    }
    public partial class PtrRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PtrRecordResource() { }
        public virtual Azure.ResourceManager.Dns.PtrRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.PtrRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.PtrRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.PtrRecordResource> Update(Azure.ResourceManager.Dns.PtrRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.PtrRecordResource>> UpdateAsync(Azure.ResourceManager.Dns.PtrRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecordSetData : Azure.ResourceManager.Models.ResourceData
    {
        public RecordSetData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.AaaaRecordInfo> AaaaRecords { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.ARecordInfo> ARecords { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.CaaRecordInfo> CaaRecords { get { throw null; } }
        public string Cname { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.MXRecordInfo> MXRecords { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.NSRecordInfo> NSRecords { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.PtrRecordInfo> PtrRecords { get { throw null; } }
        public Azure.ResourceManager.Dns.Models.SoaRecordInfo SoaRecordInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.SrvRecordInfo> SrvRecords { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public long? TtlInSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.TxtRecordInfo> TxtRecords { get { throw null; } }
    }
    public partial class SoaRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.SoaRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.SoaRecordResource>, System.Collections.IEnumerable
    {
        protected SoaRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.SoaRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.SoaRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.SoaRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.SoaRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.SoaRecordResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.SoaRecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.SoaRecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.SoaRecordResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.SoaRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.SoaRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.SoaRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.SoaRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SoaRecordData : Azure.ResourceManager.Models.ResourceData
    {
        public SoaRecordData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Dns.Models.SoaRecordInfo SoaRecord { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public long? TtlInSeconds { get { throw null; } set { } }
    }
    public partial class SoaRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SoaRecordResource() { }
        public virtual Azure.ResourceManager.Dns.SoaRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.SoaRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.SoaRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.SoaRecordResource> Update(Azure.ResourceManager.Dns.SoaRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.SoaRecordResource>> UpdateAsync(Azure.ResourceManager.Dns.SoaRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SrvRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.SrvRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.SrvRecordResource>, System.Collections.IEnumerable
    {
        protected SrvRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.SrvRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.SrvRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.SrvRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.SrvRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.SrvRecordResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.SrvRecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.SrvRecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.SrvRecordResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.SrvRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.SrvRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.SrvRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.SrvRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SrvRecordData : Azure.ResourceManager.Models.ResourceData
    {
        public SrvRecordData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.SrvRecordInfo> SrvRecords { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public long? TtlInSeconds { get { throw null; } set { } }
    }
    public partial class SrvRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SrvRecordResource() { }
        public virtual Azure.ResourceManager.Dns.SrvRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.SrvRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.SrvRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.SrvRecordResource> Update(Azure.ResourceManager.Dns.SrvRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.SrvRecordResource>> UpdateAsync(Azure.ResourceManager.Dns.SrvRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TxtRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.TxtRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.TxtRecordResource>, System.Collections.IEnumerable
    {
        protected TxtRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.TxtRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.TxtRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dns.TxtRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.Dns.TxtRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.TxtRecordResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.TxtRecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.TxtRecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.TxtRecordResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.TxtRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.TxtRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.TxtRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.TxtRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TxtRecordData : Azure.ResourceManager.Models.ResourceData
    {
        public TxtRecordData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public long? TtlInSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.TxtRecordInfo> TxtRecords { get { throw null; } }
    }
    public partial class TxtRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TxtRecordResource() { }
        public virtual Azure.ResourceManager.Dns.TxtRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.TxtRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.TxtRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.TxtRecordResource> Update(Azure.ResourceManager.Dns.TxtRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.TxtRecordResource>> UpdateAsync(Azure.ResourceManager.Dns.TxtRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Dns.Models
{
    public partial class AaaaRecordInfo
    {
        public AaaaRecordInfo() { }
        public System.Net.IPAddress IPv6Address { get { throw null; } set { } }
    }
    public partial class ARecordInfo
    {
        public ARecordInfo() { }
        public System.Net.IPAddress IPv4Address { get { throw null; } set { } }
    }
    public partial class CaaRecordInfo
    {
        public CaaRecordInfo() { }
        public int? Flags { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
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
    public partial class MXRecordInfo
    {
        public MXRecordInfo() { }
        public string Exchange { get { throw null; } set { } }
        public int? Preference { get { throw null; } set { } }
    }
    public partial class NSRecordInfo
    {
        public NSRecordInfo() { }
        public string DnsNSDomainName { get { throw null; } set { } }
    }
    public partial class PtrRecordInfo
    {
        public PtrRecordInfo() { }
        public string DnsPtrDomainName { get { throw null; } set { } }
    }
    public partial class SoaRecordInfo
    {
        public SoaRecordInfo() { }
        public string Email { get { throw null; } set { } }
        public long? ExpireTimeInSeconds { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        public long? MinimumTtlInSeconds { get { throw null; } set { } }
        public long? RefreshTimeInSeconds { get { throw null; } set { } }
        public long? RetryTimeInSeconds { get { throw null; } set { } }
        public long? SerialNumber { get { throw null; } set { } }
    }
    public partial class SrvRecordInfo
    {
        public SrvRecordInfo() { }
        public int? Port { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        public int? Weight { get { throw null; } set { } }
    }
    public partial class TxtRecordInfo
    {
        public TxtRecordInfo() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
}
