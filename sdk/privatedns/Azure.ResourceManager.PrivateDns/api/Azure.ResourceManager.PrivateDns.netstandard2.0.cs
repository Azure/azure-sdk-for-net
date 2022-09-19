namespace Azure.ResourceManager.PrivateDns
{
    public static partial class PrivateDnsExtensions
    {
        public static Azure.ResourceManager.PrivateDns.PrivateDnsZoneAAAAResource GetPrivateDnsZoneAAAAResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateDns.PrivateDnsZoneAResource GetPrivateDnsZoneAResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateDns.PrivateDnsZoneCNAMEResource GetPrivateDnsZoneCNAMEResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateDns.PrivateDnsZoneMXResource GetPrivateDnsZoneMXResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateDns.PrivateDnsZonePTRResource GetPrivateDnsZonePTRResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateDns.PrivateDnsZoneSOAResource GetPrivateDnsZoneSOAResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateDns.PrivateDnsZoneSRVResource GetPrivateDnsZoneSRVResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateDns.PrivateDnsZoneTXTResource GetPrivateDnsZoneTXTResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PrivateDns.PrivateZoneResource> GetPrivateZone(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateZoneResource>> GetPrivateZoneAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PrivateDns.PrivateZoneResource GetPrivateZoneResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateDns.PrivateZoneCollection GetPrivateZones(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PrivateDns.PrivateZoneResource> GetPrivateZones(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.PrivateZoneResource> GetPrivateZonesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource GetVirtualNetworkLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class PrivateDnsZoneAAAACollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAAAAResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAAAAResource>, System.Collections.IEnumerable
    {
        protected PrivateDnsZoneAAAACollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAAAAResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAAAAResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAAAAResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAAAAResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAAAAResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAAAAResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAAAAResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAAAAResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAAAAResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAAAAResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateDnsZoneAAAAResource : Azure.ResourceManager.PrivateDns.RecordSetResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateDnsZoneAAAAResource() { }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string relativeRecordSetName) { throw null; }
        protected override Azure.ResourceManager.ArmOperation DeleteCore(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteCoreAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAAAAResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAAAAResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource> GetCore(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource>> GetCoreAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAAAAResource> Update(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAAAAResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource> UpdateCore(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource>> UpdateCoreAsync(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateDnsZoneACollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAResource>, System.Collections.IEnumerable
    {
        protected PrivateDnsZoneACollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateDnsZoneAResource : Azure.ResourceManager.PrivateDns.RecordSetResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateDnsZoneAResource() { }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string relativeRecordSetName) { throw null; }
        protected override Azure.ResourceManager.ArmOperation DeleteCore(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteCoreAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource> GetCore(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource>> GetCoreAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAResource> Update(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource> UpdateCore(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource>> UpdateCoreAsync(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateDnsZoneCNAMECollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneCNAMEResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneCNAMEResource>, System.Collections.IEnumerable
    {
        protected PrivateDnsZoneCNAMECollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsZoneCNAMEResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsZoneCNAMEResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneCNAMEResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneCNAMEResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneCNAMEResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneCNAMEResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsZoneCNAMEResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneCNAMEResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsZoneCNAMEResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneCNAMEResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateDnsZoneCNAMEResource : Azure.ResourceManager.PrivateDns.RecordSetResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateDnsZoneCNAMEResource() { }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string relativeRecordSetName) { throw null; }
        protected override Azure.ResourceManager.ArmOperation DeleteCore(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteCoreAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneCNAMEResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneCNAMEResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource> GetCore(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource>> GetCoreAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneCNAMEResource> Update(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneCNAMEResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource> UpdateCore(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource>> UpdateCoreAsync(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateDnsZoneMXCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneMXResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneMXResource>, System.Collections.IEnumerable
    {
        protected PrivateDnsZoneMXCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsZoneMXResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsZoneMXResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneMXResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneMXResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneMXResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneMXResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsZoneMXResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneMXResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsZoneMXResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneMXResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateDnsZoneMXResource : Azure.ResourceManager.PrivateDns.RecordSetResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateDnsZoneMXResource() { }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string relativeRecordSetName) { throw null; }
        protected override Azure.ResourceManager.ArmOperation DeleteCore(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteCoreAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneMXResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneMXResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource> GetCore(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource>> GetCoreAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneMXResource> Update(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneMXResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource> UpdateCore(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource>> UpdateCoreAsync(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateDnsZonePTRCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZonePTRResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZonePTRResource>, System.Collections.IEnumerable
    {
        protected PrivateDnsZonePTRCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsZonePTRResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsZonePTRResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZonePTRResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.PrivateDnsZonePTRResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.PrivateDnsZonePTRResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZonePTRResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsZonePTRResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZonePTRResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsZonePTRResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZonePTRResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateDnsZonePTRResource : Azure.ResourceManager.PrivateDns.RecordSetResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateDnsZonePTRResource() { }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string relativeRecordSetName) { throw null; }
        protected override Azure.ResourceManager.ArmOperation DeleteCore(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteCoreAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZonePTRResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZonePTRResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource> GetCore(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource>> GetCoreAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZonePTRResource> Update(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZonePTRResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource> UpdateCore(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource>> UpdateCoreAsync(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateDnsZoneSOACollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSOAResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSOAResource>, System.Collections.IEnumerable
    {
        protected PrivateDnsZoneSOACollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSOAResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSOAResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSOAResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSOAResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSOAResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSOAResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSOAResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSOAResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSOAResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSOAResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateDnsZoneSOAResource : Azure.ResourceManager.PrivateDns.RecordSetResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateDnsZoneSOAResource() { }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string relativeRecordSetName) { throw null; }
        protected override Azure.ResourceManager.ArmOperation DeleteCore(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteCoreAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSOAResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSOAResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource> GetCore(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource>> GetCoreAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSOAResource> Update(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSOAResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource> UpdateCore(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource>> UpdateCoreAsync(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateDnsZoneSRVCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSRVResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSRVResource>, System.Collections.IEnumerable
    {
        protected PrivateDnsZoneSRVCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSRVResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSRVResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSRVResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSRVResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSRVResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSRVResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSRVResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSRVResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSRVResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSRVResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateDnsZoneSRVResource : Azure.ResourceManager.PrivateDns.RecordSetResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateDnsZoneSRVResource() { }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string relativeRecordSetName) { throw null; }
        protected override Azure.ResourceManager.ArmOperation DeleteCore(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteCoreAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSRVResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSRVResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource> GetCore(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource>> GetCoreAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSRVResource> Update(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSRVResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource> UpdateCore(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource>> UpdateCoreAsync(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateDnsZoneTXTCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneTXTResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneTXTResource>, System.Collections.IEnumerable
    {
        protected PrivateDnsZoneTXTCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsZoneTXTResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsZoneTXTResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relativeRecordSetName, Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneTXTResource> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneTXTResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneTXTResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneTXTResource>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsZoneTXTResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneTXTResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsZoneTXTResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneTXTResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateDnsZoneTXTResource : Azure.ResourceManager.PrivateDns.RecordSetResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateDnsZoneTXTResource() { }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string relativeRecordSetName) { throw null; }
        protected override Azure.ResourceManager.ArmOperation DeleteCore(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteCoreAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneTXTResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneTXTResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource> GetCore(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource>> GetCoreAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneTXTResource> Update(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneTXTResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource> UpdateCore(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource>> UpdateCoreAsync(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public long? MaxNumberOfRecordSets { get { throw null; } }
        public long? MaxNumberOfVirtualNetworkLinks { get { throw null; } }
        public long? MaxNumberOfVirtualNetworkLinksWithRegistration { get { throw null; } }
        public long? NumberOfRecordSets { get { throw null; } }
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
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateZoneResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAResource> GetPrivateDnsZoneA(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAAAAResource> GetPrivateDnsZoneAAAA(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAAAAResource>> GetPrivateDnsZoneAAAAAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsZoneAAAACollection GetPrivateDnsZoneAAAAs() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneAResource>> GetPrivateDnsZoneAAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsZoneACollection GetPrivateDnsZoneAs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneCNAMEResource> GetPrivateDnsZoneCNAME(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneCNAMEResource>> GetPrivateDnsZoneCNAMEAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsZoneCNAMECollection GetPrivateDnsZoneCNAMEs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneMXResource> GetPrivateDnsZoneMX(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneMXResource>> GetPrivateDnsZoneMXAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsZoneMXCollection GetPrivateDnsZoneMXes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZonePTRResource> GetPrivateDnsZonePTR(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZonePTRResource>> GetPrivateDnsZonePTRAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsZonePTRCollection GetPrivateDnsZonePTRs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSOAResource> GetPrivateDnsZoneSOA(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSOAResource>> GetPrivateDnsZoneSOAAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsZoneSOACollection GetPrivateDnsZoneSOAs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSRVResource> GetPrivateDnsZoneSRV(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneSRVResource>> GetPrivateDnsZoneSRVAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsZoneSRVCollection GetPrivateDnsZoneSRVs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneTXTResource> GetPrivateDnsZoneTXT(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneTXTResource>> GetPrivateDnsZoneTXTAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsZoneTXTCollection GetPrivateDnsZoneTXTs() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.RecordSetResource> GetRecordSets(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.RecordSetResource> GetRecordSetsAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class RecordSetData : Azure.ResourceManager.Models.ResourceData
    {
        public RecordSetData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.AaaaRecord> AaaaRecords { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.ARecord> ARecords { get { throw null; } }
        public string Cname { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public bool? IsAutoRegistered { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.MxRecord> MxRecords { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.PtrRecord> PtrRecords { get { throw null; } }
        public Azure.ResourceManager.PrivateDns.Models.SoaRecord SoaRecord { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.SrvRecord> SrvRecords { get { throw null; } }
        public long? Ttl { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.TxtRecord> TxtRecords { get { throw null; } }
    }
    public abstract partial class RecordSetResource : Azure.ResourceManager.ArmResource
    {
        protected RecordSetResource() { }
        public virtual Azure.ResourceManager.PrivateDns.RecordSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected abstract Azure.ResourceManager.ArmOperation DeleteCore(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        protected abstract System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteCoreAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected abstract Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource> GetCore(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        protected abstract System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource>> GetCoreAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource> Update(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected abstract Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource> UpdateCore(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        protected abstract System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.RecordSetResource>> UpdateCoreAsync(Azure.ResourceManager.PrivateDns.RecordSetData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
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
    public partial class AaaaRecord
    {
        public AaaaRecord() { }
        public string IPv6Address { get { throw null; } set { } }
    }
    public partial class ARecord
    {
        public ARecord() { }
        public string IPv4Address { get { throw null; } set { } }
    }
    public partial class MxRecord
    {
        public MxRecord() { }
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
    public partial class PtrRecord
    {
        public PtrRecord() { }
        public string Ptrdname { get { throw null; } set { } }
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
    public partial class TxtRecord
    {
        public TxtRecord() { }
        public System.Collections.Generic.IList<string> Value { get { throw null; } }
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
