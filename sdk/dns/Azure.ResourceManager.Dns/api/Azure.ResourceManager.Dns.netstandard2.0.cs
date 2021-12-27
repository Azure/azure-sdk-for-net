namespace Azure.ResourceManager.Dns
{
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.Dns.RecordSetA GetRecordSetA(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.RecordSetAaaa GetRecordSetAaaa(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.RecordSetCaa GetRecordSetCaa(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.RecordSetCname GetRecordSetCname(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.RecordSetMx GetRecordSetMx(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.RecordSetNs GetRecordSetNs(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.RecordSetPtr GetRecordSetPtr(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.RecordSetSoa GetRecordSetSoa(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.RecordSetSrv GetRecordSetSrv(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.RecordSetTxt GetRecordSetTxt(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dns.Zone GetZone(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
    }
    public partial class RecordSetA : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected RecordSetA() { }
        public virtual Azure.ResourceManager.Dns.RecordSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string recordType, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.Dns.Models.RecordSetDeleteOperation Delete(string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Dns.Models.RecordSetDeleteOperation> DeleteAsync(string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetA> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetA>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetA> Update(Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetA>> UpdateAsync(Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecordSetAaaa : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected RecordSetAaaa() { }
        public virtual Azure.ResourceManager.Dns.RecordSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string recordType, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.Dns.Models.RecordSetDeleteOperation Delete(string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Dns.Models.RecordSetDeleteOperation> DeleteAsync(string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetAaaa> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetAaaa>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetAaaa> Update(Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetAaaa>> UpdateAsync(Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecordSetAaaaCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetAaaa>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetAaaa>, System.Collections.IEnumerable
    {
        protected RecordSetAaaaCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Dns.Models.RecordSetCreateOrUpdateOperation CreateOrUpdate(string relativeRecordSetName, Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, string ifNoneMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Dns.Models.RecordSetCreateOrUpdateOperation> CreateOrUpdateAsync(string relativeRecordSetName, Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, string ifNoneMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetAaaa> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetAaaa> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetAaaa> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetAaaa>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetAaaa> GetIfExists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetAaaa>> GetIfExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.RecordSetAaaa> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetAaaa>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.RecordSetAaaa> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetAaaa>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecordSetACollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetA>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetA>, System.Collections.IEnumerable
    {
        protected RecordSetACollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Dns.Models.RecordSetCreateOrUpdateOperation CreateOrUpdate(string relativeRecordSetName, Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, string ifNoneMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Dns.Models.RecordSetCreateOrUpdateOperation> CreateOrUpdateAsync(string relativeRecordSetName, Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, string ifNoneMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetA> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetA> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetA> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetA>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetA> GetIfExists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetA>> GetIfExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.RecordSetA> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetA>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.RecordSetA> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetA>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecordSetCaa : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected RecordSetCaa() { }
        public virtual Azure.ResourceManager.Dns.RecordSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string recordType, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.Dns.Models.RecordSetDeleteOperation Delete(string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Dns.Models.RecordSetDeleteOperation> DeleteAsync(string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetCaa> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetCaa>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetCaa> Update(Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetCaa>> UpdateAsync(Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecordSetCaaCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetCaa>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetCaa>, System.Collections.IEnumerable
    {
        protected RecordSetCaaCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Dns.Models.RecordSetCreateOrUpdateOperation CreateOrUpdate(string relativeRecordSetName, Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, string ifNoneMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Dns.Models.RecordSetCreateOrUpdateOperation> CreateOrUpdateAsync(string relativeRecordSetName, Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, string ifNoneMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetCaa> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetCaa> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetCaa> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetCaa>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetCaa> GetIfExists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetCaa>> GetIfExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.RecordSetCaa> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetCaa>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.RecordSetCaa> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetCaa>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecordSetCname : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected RecordSetCname() { }
        public virtual Azure.ResourceManager.Dns.RecordSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string recordType, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.Dns.Models.RecordSetDeleteOperation Delete(string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Dns.Models.RecordSetDeleteOperation> DeleteAsync(string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetCname> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetCname>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetCname> Update(Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetCname>> UpdateAsync(Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecordSetCnameCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetCname>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetCname>, System.Collections.IEnumerable
    {
        protected RecordSetCnameCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Dns.Models.RecordSetCreateOrUpdateOperation CreateOrUpdate(string relativeRecordSetName, Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, string ifNoneMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Dns.Models.RecordSetCreateOrUpdateOperation> CreateOrUpdateAsync(string relativeRecordSetName, Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, string ifNoneMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetCname> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetCname> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetCname> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetCname>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetCname> GetIfExists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetCname>> GetIfExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.RecordSetCname> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetCname>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.RecordSetCname> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetCname>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecordSetData : Azure.ResourceManager.Models.Resource
    {
        public RecordSetData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.AaaaRecord> AaaaRecords { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.ARecord> ARecords { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.CaaRecord> CaaRecords { get { throw null; } }
        public Azure.ResourceManager.Dns.Models.CnameRecord CnameRecord { get { throw null; } set { } }
        public string Etag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.MxRecord> MxRecords { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.NsRecord> NsRecords { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.PtrRecord> PtrRecords { get { throw null; } }
        public Azure.ResourceManager.Dns.Models.SoaRecord SoaRecord { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.SrvRecord> SrvRecords { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource TargetResource { get { throw null; } set { } }
        public long? TTL { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dns.Models.TxtRecord> TxtRecords { get { throw null; } }
    }
    public partial class RecordSetMx : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected RecordSetMx() { }
        public virtual Azure.ResourceManager.Dns.RecordSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string recordType, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.Dns.Models.RecordSetDeleteOperation Delete(string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Dns.Models.RecordSetDeleteOperation> DeleteAsync(string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetMx> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetMx>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetMx> Update(Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetMx>> UpdateAsync(Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecordSetMxCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetMx>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetMx>, System.Collections.IEnumerable
    {
        protected RecordSetMxCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Dns.Models.RecordSetCreateOrUpdateOperation CreateOrUpdate(string relativeRecordSetName, Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, string ifNoneMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Dns.Models.RecordSetCreateOrUpdateOperation> CreateOrUpdateAsync(string relativeRecordSetName, Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, string ifNoneMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetMx> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetMx> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetMx> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetMx>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetMx> GetIfExists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetMx>> GetIfExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.RecordSetMx> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetMx>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.RecordSetMx> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetMx>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecordSetNs : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected RecordSetNs() { }
        public virtual Azure.ResourceManager.Dns.RecordSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string recordType, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.Dns.Models.RecordSetDeleteOperation Delete(string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Dns.Models.RecordSetDeleteOperation> DeleteAsync(string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetNs> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetNs>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetNs> Update(Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetNs>> UpdateAsync(Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecordSetNsCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetNs>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetNs>, System.Collections.IEnumerable
    {
        protected RecordSetNsCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Dns.Models.RecordSetCreateOrUpdateOperation CreateOrUpdate(string relativeRecordSetName, Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, string ifNoneMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Dns.Models.RecordSetCreateOrUpdateOperation> CreateOrUpdateAsync(string relativeRecordSetName, Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, string ifNoneMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetNs> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetNs> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetNs> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetNs>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetNs> GetIfExists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetNs>> GetIfExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.RecordSetNs> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetNs>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.RecordSetNs> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetNs>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecordSetPtr : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected RecordSetPtr() { }
        public virtual Azure.ResourceManager.Dns.RecordSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string recordType, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.Dns.Models.RecordSetDeleteOperation Delete(string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Dns.Models.RecordSetDeleteOperation> DeleteAsync(string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetPtr> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetPtr>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetPtr> Update(Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetPtr>> UpdateAsync(Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecordSetPtrCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetPtr>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetPtr>, System.Collections.IEnumerable
    {
        protected RecordSetPtrCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Dns.Models.RecordSetCreateOrUpdateOperation CreateOrUpdate(string relativeRecordSetName, Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, string ifNoneMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Dns.Models.RecordSetCreateOrUpdateOperation> CreateOrUpdateAsync(string relativeRecordSetName, Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, string ifNoneMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetPtr> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetPtr> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetPtr> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetPtr>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetPtr> GetIfExists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetPtr>> GetIfExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.RecordSetPtr> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetPtr>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.RecordSetPtr> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetPtr>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecordSetSoa : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected RecordSetSoa() { }
        public virtual Azure.ResourceManager.Dns.RecordSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string recordType, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.Dns.Models.RecordSetDeleteOperation Delete(string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Dns.Models.RecordSetDeleteOperation> DeleteAsync(string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetSoa> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetSoa>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetSoa> Update(Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetSoa>> UpdateAsync(Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecordSetSoaCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetSoa>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetSoa>, System.Collections.IEnumerable
    {
        protected RecordSetSoaCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Dns.Models.RecordSetCreateOrUpdateOperation CreateOrUpdate(string relativeRecordSetName, Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, string ifNoneMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Dns.Models.RecordSetCreateOrUpdateOperation> CreateOrUpdateAsync(string relativeRecordSetName, Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, string ifNoneMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetSoa> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetSoa> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetSoa> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetSoa>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetSoa> GetIfExists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetSoa>> GetIfExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.RecordSetSoa> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetSoa>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.RecordSetSoa> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetSoa>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecordSetSrv : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected RecordSetSrv() { }
        public virtual Azure.ResourceManager.Dns.RecordSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string recordType, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.Dns.Models.RecordSetDeleteOperation Delete(string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Dns.Models.RecordSetDeleteOperation> DeleteAsync(string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetSrv> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetSrv>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetSrv> Update(Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetSrv>> UpdateAsync(Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecordSetSrvCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetSrv>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetSrv>, System.Collections.IEnumerable
    {
        protected RecordSetSrvCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Dns.Models.RecordSetCreateOrUpdateOperation CreateOrUpdate(string relativeRecordSetName, Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, string ifNoneMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Dns.Models.RecordSetCreateOrUpdateOperation> CreateOrUpdateAsync(string relativeRecordSetName, Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, string ifNoneMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetSrv> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetSrv> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetSrv> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetSrv>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetSrv> GetIfExists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetSrv>> GetIfExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.RecordSetSrv> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetSrv>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.RecordSetSrv> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetSrv>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecordSetTxt : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected RecordSetTxt() { }
        public virtual Azure.ResourceManager.Dns.RecordSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string recordType, string relativeRecordSetName) { throw null; }
        public virtual Azure.ResourceManager.Dns.Models.RecordSetDeleteOperation Delete(string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Dns.Models.RecordSetDeleteOperation> DeleteAsync(string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetTxt> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetTxt>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetTxt> Update(Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetTxt>> UpdateAsync(Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecordSetTxtCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetTxt>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetTxt>, System.Collections.IEnumerable
    {
        protected RecordSetTxtCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Dns.Models.RecordSetCreateOrUpdateOperation CreateOrUpdate(string relativeRecordSetName, Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, string ifNoneMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Dns.Models.RecordSetCreateOrUpdateOperation> CreateOrUpdateAsync(string relativeRecordSetName, Azure.ResourceManager.Dns.RecordSetData parameters, string ifMatch = null, string ifNoneMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetTxt> Get(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetTxt> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetTxt> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetTxt>> GetAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.RecordSetTxt> GetIfExists(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.RecordSetTxt>> GetIfExistsAsync(string relativeRecordSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.RecordSetTxt> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.RecordSetTxt>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.RecordSetTxt> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.RecordSetTxt>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.ResourceManager.Dns.ZoneCollection GetZones(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Dns.Models.DnsResourceReferenceResult> GetByTargetResourcesDnsResourceReference(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.Dns.Models.DnsResourceReferenceRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.Models.DnsResourceReferenceResult>> GetByTargetResourcesDnsResourceReferenceAsync(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.Dns.Models.DnsResourceReferenceRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Dns.Zone> GetZones(this Azure.ResourceManager.Resources.Subscription subscription, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetZonesAsGenericResources(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetZonesAsGenericResourcesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Dns.Zone> GetZonesAsync(this Azure.ResourceManager.Resources.Subscription subscription, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class Zone : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected Zone() { }
        public virtual Azure.ResourceManager.Dns.ZoneData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Dns.Zone> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.Zone>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName) { throw null; }
        public virtual Azure.ResourceManager.Dns.Models.ZoneDeleteOperation Delete(string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Dns.Models.ZoneDeleteOperation> DeleteAsync(string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.Zone> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetData> GetAllRecordSets(int? top = default(int?), string recordSetNameSuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetData> GetAllRecordSetsAsync(int? top = default(int?), string recordSetNameSuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.Zone>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.Dns.RecordSetAaaaCollection GetRecordSetAaaas() { throw null; }
        public Azure.ResourceManager.Dns.RecordSetACollection GetRecordSetAs() { throw null; }
        public Azure.ResourceManager.Dns.RecordSetCaaCollection GetRecordSetCaas() { throw null; }
        public Azure.ResourceManager.Dns.RecordSetCnameCollection GetRecordSetCnames() { throw null; }
        public Azure.ResourceManager.Dns.RecordSetMxCollection GetRecordSetMxes() { throw null; }
        public Azure.ResourceManager.Dns.RecordSetNsCollection GetRecordSetNs() { throw null; }
        public Azure.ResourceManager.Dns.RecordSetPtrCollection GetRecordSetPtrs() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.RecordSetData> GetRecordSets(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.RecordSetData> GetRecordSetsAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.Dns.RecordSetSoaCollection GetRecordSetSoas() { throw null; }
        public Azure.ResourceManager.Dns.RecordSetSrvCollection GetRecordSetSrvs() { throw null; }
        public Azure.ResourceManager.Dns.RecordSetTxtCollection GetRecordSetTxts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.Zone> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.Zone>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.Zone> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.Zone>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.Zone> Update(Azure.ResourceManager.Dns.Models.ZoneUpdate parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.Zone>> UpdateAsync(Azure.ResourceManager.Dns.Models.ZoneUpdate parameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ZoneCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.Zone>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.Zone>, System.Collections.IEnumerable
    {
        protected ZoneCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Dns.Models.ZoneCreateOrUpdateOperation CreateOrUpdate(string zoneName, Azure.ResourceManager.Dns.ZoneData parameters, string ifMatch = null, string ifNoneMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Dns.Models.ZoneCreateOrUpdateOperation> CreateOrUpdateAsync(string zoneName, Azure.ResourceManager.Dns.ZoneData parameters, string ifMatch = null, string ifNoneMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string zoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string zoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.Zone> Get(string zoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dns.Zone> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dns.Zone> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.Zone>> GetAsync(string zoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dns.Zone> GetIfExists(string zoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dns.Zone>> GetIfExistsAsync(string zoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dns.Zone> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dns.Zone>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dns.Zone> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dns.Zone>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ZoneData : Azure.ResourceManager.Models.TrackedResource
    {
        public ZoneData(Azure.ResourceManager.Resources.Models.Location location) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public string Etag { get { throw null; } set { } }
        public long? MaxNumberOfRecordSets { get { throw null; } }
        public long? MaxNumberOfRecordsPerRecordSet { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NameServers { get { throw null; } }
        public long? NumberOfRecordSets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> RegistrationVirtualNetworks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ResolutionVirtualNetworks { get { throw null; } }
        public Azure.ResourceManager.Dns.Models.ZoneType? ZoneType { get { throw null; } set { } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WritableSubResource> DnsResources { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource TargetResource { get { throw null; } }
    }
    public partial class DnsResourceReferenceRequest
    {
        public DnsResourceReferenceRequest() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> TargetResources { get { throw null; } }
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
    public partial class RecordSetCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Dns.RecordSetData>
    {
        protected RecordSetCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Dns.RecordSetData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Dns.RecordSetData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Dns.RecordSetData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecordSetDeleteOperation : Azure.Operation
    {
        protected RecordSetDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecordSetUpdateOperation : Azure.Operation<Azure.ResourceManager.Dns.RecordSetData>
    {
        protected RecordSetUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Dns.RecordSetData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Dns.RecordSetData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Dns.RecordSetData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ZoneCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Dns.Zone>
    {
        protected ZoneCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Dns.Zone Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Dns.Zone>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Dns.Zone>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ZoneDeleteOperation : Azure.Operation
    {
        protected ZoneDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
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
    public partial class ZoneUpdateOperation : Azure.Operation<Azure.ResourceManager.Dns.Zone>
    {
        protected ZoneUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Dns.Zone Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Dns.Zone>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Dns.Zone>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
