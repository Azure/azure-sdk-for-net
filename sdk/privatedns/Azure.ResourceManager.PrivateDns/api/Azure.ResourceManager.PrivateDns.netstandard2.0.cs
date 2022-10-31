namespace Azure.ResourceManager.PrivateDns
{
    public partial class AaaaRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.AaaaRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.AaaaRecordResource>, System.Collections.IEnumerable
    {
        protected AaaaRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.AaaaRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string aaaaRecordName, Azure.ResourceManager.PrivateDns.AaaaRecordData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.AaaaRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string aaaaRecordName, Azure.ResourceManager.PrivateDns.AaaaRecordData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string aaaaRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string aaaaRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.AaaaRecordResource> Get(string aaaaRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.AaaaRecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.AaaaRecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.AaaaRecordResource>> GetAsync(string aaaaRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.AaaaRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.AaaaRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.AaaaRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.AaaaRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AaaaRecordData : Azure.ResourceManager.PrivateDns.RecordData
    {
        public AaaaRecordData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.AaaaRecordInfo> AaaaRecords { get { throw null; } }
    }
    public partial class AaaaRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AaaaRecordResource() { }
        public virtual Azure.ResourceManager.PrivateDns.AaaaRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string aaaaRecordName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.AaaaRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.AaaaRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.AaaaRecordResource> Update(Azure.ResourceManager.PrivateDns.AaaaRecordData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.AaaaRecordResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.AaaaRecordData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ARecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.ARecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.ARecordResource>, System.Collections.IEnumerable
    {
        protected ARecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.ARecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string aRecordName, Azure.ResourceManager.PrivateDns.ARecordData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.ARecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string aRecordName, Azure.ResourceManager.PrivateDns.ARecordData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string aRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string aRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.ARecordResource> Get(string aRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.ARecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.ARecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.ARecordResource>> GetAsync(string aRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.ARecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.ARecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.ARecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.ARecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ARecordData : Azure.ResourceManager.PrivateDns.RecordData
    {
        public ARecordData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.ARecordInfo> ARecords { get { throw null; } }
    }
    public partial class ARecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ARecordResource() { }
        public virtual Azure.ResourceManager.PrivateDns.ARecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string aRecordName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.ARecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.ARecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.ARecordResource> Update(Azure.ResourceManager.PrivateDns.ARecordData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.ARecordResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.ARecordData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CnameRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.CnameRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.CnameRecordResource>, System.Collections.IEnumerable
    {
        protected CnameRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.CnameRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cnameRecordName, Azure.ResourceManager.PrivateDns.CnameRecordData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.CnameRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cnameRecordName, Azure.ResourceManager.PrivateDns.CnameRecordData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cnameRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cnameRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.CnameRecordResource> Get(string cnameRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.CnameRecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.CnameRecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.CnameRecordResource>> GetAsync(string cnameRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.CnameRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.CnameRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.CnameRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.CnameRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CnameRecordData : Azure.ResourceManager.PrivateDns.RecordData
    {
        public CnameRecordData() { }
        public string Cname { get { throw null; } set { } }
    }
    public partial class CnameRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CnameRecordResource() { }
        public virtual Azure.ResourceManager.PrivateDns.CnameRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string cnameRecordName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.CnameRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.CnameRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.CnameRecordResource> Update(Azure.ResourceManager.PrivateDns.CnameRecordData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.CnameRecordResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.CnameRecordData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MXRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.MXRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.MXRecordResource>, System.Collections.IEnumerable
    {
        protected MXRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.MXRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string MXRecordName, Azure.ResourceManager.PrivateDns.MXRecordData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.MXRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string MXRecordName, Azure.ResourceManager.PrivateDns.MXRecordData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string MXRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string MXRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.MXRecordResource> Get(string MXRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.MXRecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.MXRecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.MXRecordResource>> GetAsync(string MXRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.MXRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.MXRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.MXRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.MXRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MXRecordData : Azure.ResourceManager.PrivateDns.RecordData
    {
        public MXRecordData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.MXRecordInfo> MXRecords { get { throw null; } }
    }
    public partial class MXRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MXRecordResource() { }
        public virtual Azure.ResourceManager.PrivateDns.MXRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string MXRecordName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.MXRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.MXRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.MXRecordResource> Update(Azure.ResourceManager.PrivateDns.MXRecordData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.MXRecordResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.MXRecordData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class PrivateDnsExtensions
    {
        public static Azure.ResourceManager.PrivateDns.AaaaRecordResource GetAaaaRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateDns.ARecordResource GetARecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateDns.CnameRecordResource GetCnameRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateDns.MXRecordResource GetMXRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PrivateDns.PrivateZoneResource> GetPrivateZone(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateZoneResource>> GetPrivateZoneAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PrivateDns.PrivateZoneResource GetPrivateZoneResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateDns.PrivateZoneCollection GetPrivateZones(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PrivateDns.PrivateZoneResource> GetPrivateZones(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.PrivateZoneResource> GetPrivateZonesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PrivateDns.PtrRecordResource GetPtrRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateDns.SoaRecordResource GetSoaRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateDns.SrvRecordResource GetSrvRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateDns.TxtRecordResource GetTxtRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource GetVirtualNetworkLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class PrivateZoneCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateZoneResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateZoneResource>, System.Collections.IEnumerable
    {
        protected PrivateZoneCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateZoneResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateZoneName, Azure.ResourceManager.PrivateDns.PrivateZoneData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateZoneResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateZoneName, Azure.ResourceManager.PrivateDns.PrivateZoneData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateZoneResource> Get(string privateZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.PrivateZoneResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.PrivateZoneResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateZoneResource>> GetAsync(string privateZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.PrivateZoneResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateZoneResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.PrivateZoneResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateZoneResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateZoneData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PrivateZoneData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string InternalId { get { throw null; } }
        public long? MaxNumberOfRecords { get { throw null; } }
        public long? MaxNumberOfVirtualNetworkLinks { get { throw null; } }
        public long? MaxNumberOfVirtualNetworkLinksWithRegistration { get { throw null; } }
        public long? NumberOfRecords { get { throw null; } }
        public long? NumberOfVirtualNetworkLinks { get { throw null; } }
        public long? NumberOfVirtualNetworkLinksWithRegistration { get { throw null; } }
        public Azure.ResourceManager.PrivateDns.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PrivateZoneResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateZoneResource() { }
        public virtual Azure.ResourceManager.PrivateDns.PrivateZoneData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateZoneResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateZoneResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateZoneResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.AaaaRecordResource> GetAaaaRecord(string aaaaRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.AaaaRecordResource>> GetAaaaRecordAsync(string aaaaRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.AaaaRecordCollection GetAaaaRecords() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.ARecordResource> GetARecord(string aRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.ARecordResource>> GetARecordAsync(string aRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.ARecordCollection GetARecords() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateZoneResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.CnameRecordResource> GetCnameRecord(string cnameRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.CnameRecordResource>> GetCnameRecordAsync(string cnameRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.CnameRecordCollection GetCnameRecords() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.MXRecordResource> GetMXRecord(string MXRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.MXRecordResource>> GetMXRecordAsync(string MXRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.MXRecordCollection GetMXRecords() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PtrRecordResource> GetPtrRecord(string ptrRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PtrRecordResource>> GetPtrRecordAsync(string ptrRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PtrRecordCollection GetPtrRecords() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.RecordSeriesData> GetRecords(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.RecordSeriesData> GetRecordsAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.SoaRecordResource> GetSoaRecord(string soaRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.SoaRecordResource>> GetSoaRecordAsync(string soaRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.SoaRecordCollection GetSoaRecords() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.SrvRecordResource> GetSrvRecord(string srvRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.SrvRecordResource>> GetSrvRecordAsync(string srvRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.SrvRecordCollection GetSrvRecords() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.TxtRecordResource> GetTxtRecord(string txtRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.TxtRecordResource>> GetTxtRecordAsync(string txtRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.TxtRecordCollection GetTxtRecords() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource> GetVirtualNetworkLink(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource>> GetVirtualNetworkLinkAsync(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.VirtualNetworkLinkCollection GetVirtualNetworkLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateZoneResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateZoneResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateZoneResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateZoneResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateZoneResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PrivateDns.PrivateZoneData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateZoneResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PrivateDns.PrivateZoneData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PtrRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PtrRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PtrRecordResource>, System.Collections.IEnumerable
    {
        protected PtrRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PtrRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ptrRecordName, Azure.ResourceManager.PrivateDns.PtrRecordData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PtrRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ptrRecordName, Azure.ResourceManager.PrivateDns.PtrRecordData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ptrRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ptrRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PtrRecordResource> Get(string ptrRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.PtrRecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.PtrRecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PtrRecordResource>> GetAsync(string ptrRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.PtrRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PtrRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.PtrRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PtrRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PtrRecordData : Azure.ResourceManager.PrivateDns.RecordData
    {
        public PtrRecordData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.PtrRecordInfo> PtrRecords { get { throw null; } }
    }
    public partial class PtrRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PtrRecordResource() { }
        public virtual Azure.ResourceManager.PrivateDns.PtrRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string ptrRecordName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PtrRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PtrRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PtrRecordResource> Update(Azure.ResourceManager.PrivateDns.PtrRecordData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PtrRecordResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.PtrRecordData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecordData : Azure.ResourceManager.Models.ResourceData
    {
        public RecordData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public bool? IsAutoRegistered { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public long? TtlInSeconds { get { throw null; } set { } }
    }
    public partial class RecordSeriesData : Azure.ResourceManager.Models.ResourceData
    {
        public RecordSeriesData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.AaaaRecordInfo> AaaaRecords { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.ARecordInfo> ARecords { get { throw null; } }
        public string Cname { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public bool? IsAutoRegistered { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.MXRecordInfo> MxRecords { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.PtrRecordInfo> PtrRecords { get { throw null; } }
        public Azure.ResourceManager.PrivateDns.Models.SoaRecordInfo SoaRecordInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.SrvRecordInfo> SrvRecords { get { throw null; } }
        public long? TtlInSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.TxtRecordInfo> TxtRecords { get { throw null; } }
    }
    public partial class SoaRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.SoaRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.SoaRecordResource>, System.Collections.IEnumerable
    {
        protected SoaRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.SoaRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string soaRecordName, Azure.ResourceManager.PrivateDns.SoaRecordData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.SoaRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string soaRecordName, Azure.ResourceManager.PrivateDns.SoaRecordData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string soaRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string soaRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.SoaRecordResource> Get(string soaRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.SoaRecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.SoaRecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.SoaRecordResource>> GetAsync(string soaRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.SoaRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.SoaRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.SoaRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.SoaRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SoaRecordData : Azure.ResourceManager.PrivateDns.RecordData
    {
        public SoaRecordData() { }
        public Azure.ResourceManager.PrivateDns.Models.SoaRecordInfo SoaRecord { get { throw null; } set { } }
    }
    public partial class SoaRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SoaRecordResource() { }
        public virtual Azure.ResourceManager.PrivateDns.SoaRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string soaRecordName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.SoaRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.SoaRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.SoaRecordResource> Update(Azure.ResourceManager.PrivateDns.SoaRecordData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.SoaRecordResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.SoaRecordData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SrvRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.SrvRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.SrvRecordResource>, System.Collections.IEnumerable
    {
        protected SrvRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.SrvRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string srvRecordName, Azure.ResourceManager.PrivateDns.SrvRecordData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.SrvRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string srvRecordName, Azure.ResourceManager.PrivateDns.SrvRecordData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string srvRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string srvRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.SrvRecordResource> Get(string srvRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.SrvRecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.SrvRecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.SrvRecordResource>> GetAsync(string srvRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.SrvRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.SrvRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.SrvRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.SrvRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SrvRecordData : Azure.ResourceManager.PrivateDns.RecordData
    {
        public SrvRecordData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.SrvRecordInfo> SrvRecords { get { throw null; } }
    }
    public partial class SrvRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SrvRecordResource() { }
        public virtual Azure.ResourceManager.PrivateDns.SrvRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string srvRecordName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.SrvRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.SrvRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.SrvRecordResource> Update(Azure.ResourceManager.PrivateDns.SrvRecordData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.SrvRecordResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.SrvRecordData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TxtRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.TxtRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.TxtRecordResource>, System.Collections.IEnumerable
    {
        protected TxtRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.TxtRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string txtRecordName, Azure.ResourceManager.PrivateDns.TxtRecordData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.TxtRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string txtRecordName, Azure.ResourceManager.PrivateDns.TxtRecordData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string txtRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string txtRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.TxtRecordResource> Get(string txtRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.TxtRecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.TxtRecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.TxtRecordResource>> GetAsync(string txtRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.TxtRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.TxtRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.TxtRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.TxtRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TxtRecordData : Azure.ResourceManager.PrivateDns.RecordData
    {
        public TxtRecordData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.TxtRecordInfo> TxtRecords { get { throw null; } }
    }
    public partial class TxtRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TxtRecordResource() { }
        public virtual Azure.ResourceManager.PrivateDns.TxtRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string txtRecordName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.TxtRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.TxtRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.TxtRecordResource> Update(Azure.ResourceManager.PrivateDns.TxtRecordData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.TxtRecordResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.TxtRecordData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkLinkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource>, System.Collections.IEnumerable
    {
        protected VirtualNetworkLinkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualNetworkLinkName, Azure.ResourceManager.PrivateDns.VirtualNetworkLinkData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualNetworkLinkName, Azure.ResourceManager.PrivateDns.VirtualNetworkLinkData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource> Get(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource>> GetAsync(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualNetworkLinkData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VirtualNetworkLinkData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateDns.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public bool? RegistrationEnabled { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualNetworkId { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateDns.Models.VirtualNetworkLinkState? VirtualNetworkLinkState { get { throw null; } }
    }
    public partial class VirtualNetworkLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualNetworkLinkResource() { }
        public virtual Azure.ResourceManager.PrivateDns.VirtualNetworkLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string virtualNetworkLinkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PrivateDns.VirtualNetworkLinkData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PrivateDns.VirtualNetworkLinkData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PrivateDns.Models
{
    public partial class AaaaRecordInfo
    {
        public AaaaRecordInfo() { }
        public string IPv6Address { get { throw null; } set { } }
    }
    public partial class ARecordInfo
    {
        public ARecordInfo() { }
        public string IPv4Address { get { throw null; } set { } }
    }
    public partial class MXRecordInfo
    {
        public MXRecordInfo() { }
        public string Exchange { get { throw null; } set { } }
        public int? Preference { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.PrivateDns.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PrivateDns.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PrivateDns.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.PrivateDns.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.PrivateDns.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PrivateDns.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.PrivateDns.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PrivateDns.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PrivateDns.Models.ProvisioningState left, Azure.ResourceManager.PrivateDns.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateDns.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PrivateDns.Models.ProvisioningState left, Azure.ResourceManager.PrivateDns.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PtrRecordInfo
    {
        public PtrRecordInfo() { }
        public string PtrDomainName { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualNetworkLinkState : System.IEquatable<Azure.ResourceManager.PrivateDns.Models.VirtualNetworkLinkState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualNetworkLinkState(string value) { throw null; }
        public static Azure.ResourceManager.PrivateDns.Models.VirtualNetworkLinkState Completed { get { throw null; } }
        public static Azure.ResourceManager.PrivateDns.Models.VirtualNetworkLinkState InProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PrivateDns.Models.VirtualNetworkLinkState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PrivateDns.Models.VirtualNetworkLinkState left, Azure.ResourceManager.PrivateDns.Models.VirtualNetworkLinkState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateDns.Models.VirtualNetworkLinkState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PrivateDns.Models.VirtualNetworkLinkState left, Azure.ResourceManager.PrivateDns.Models.VirtualNetworkLinkState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
