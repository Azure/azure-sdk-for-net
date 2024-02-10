namespace Azure.ResourceManager.PrivateDns
{
    public partial class PrivateDnsAaaaRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordResource>, System.Collections.IEnumerable
    {
        protected PrivateDnsAaaaRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string aaaaRecordName, Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string aaaaRecordName, Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string aaaaRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string aaaaRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordResource> Get(string aaaaRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordResource>> GetAsync(string aaaaRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateDnsAaaaRecordData : Azure.ResourceManager.PrivateDns.PrivateDnsBaseRecordData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordData>
    {
        public PrivateDnsAaaaRecordData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.PrivateDnsAaaaRecordInfo> PrivateDnsAaaaRecords { get { throw null; } }
        Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateDnsAaaaRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateDnsAaaaRecordResource() { }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string aaaaRecordName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordResource> Update(Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateDnsARecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsARecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsARecordResource>, System.Collections.IEnumerable
    {
        protected PrivateDnsARecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsARecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string aRecordName, Azure.ResourceManager.PrivateDns.PrivateDnsARecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsARecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string aRecordName, Azure.ResourceManager.PrivateDns.PrivateDnsARecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string aRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string aRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsARecordResource> Get(string aRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.PrivateDnsARecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.PrivateDnsARecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsARecordResource>> GetAsync(string aRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsARecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsARecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsARecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsARecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateDnsARecordData : Azure.ResourceManager.PrivateDns.PrivateDnsBaseRecordData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsARecordData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsARecordData>
    {
        public PrivateDnsARecordData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.PrivateDnsARecordInfo> PrivateDnsARecords { get { throw null; } }
        Azure.ResourceManager.PrivateDns.PrivateDnsARecordData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsARecordData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsARecordData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateDns.PrivateDnsARecordData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsARecordData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsARecordData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsARecordData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateDnsARecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateDnsARecordResource() { }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsARecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string aRecordName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsARecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsARecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsARecordResource> Update(Azure.ResourceManager.PrivateDns.PrivateDnsARecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsARecordResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.PrivateDnsARecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateDnsBaseRecordData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsBaseRecordData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsBaseRecordData>
    {
        public PrivateDnsBaseRecordData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public bool? IsAutoRegistered { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public long? TtlInSeconds { get { throw null; } set { } }
        Azure.ResourceManager.PrivateDns.PrivateDnsBaseRecordData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsBaseRecordData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsBaseRecordData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateDns.PrivateDnsBaseRecordData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsBaseRecordData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsBaseRecordData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsBaseRecordData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateDnsCnameRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordResource>, System.Collections.IEnumerable
    {
        protected PrivateDnsCnameRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cnameRecordName, Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cnameRecordName, Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cnameRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cnameRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordResource> Get(string cnameRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordResource>> GetAsync(string cnameRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateDnsCnameRecordData : Azure.ResourceManager.PrivateDns.PrivateDnsBaseRecordData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordData>
    {
        public PrivateDnsCnameRecordData() { }
        public string Cname { get { throw null; } set { } }
        Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateDnsCnameRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateDnsCnameRecordResource() { }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string cnameRecordName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordResource> Update(Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class PrivateDnsExtensions
    {
        public static Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordResource GetPrivateDnsAaaaRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateDns.PrivateDnsARecordResource GetPrivateDnsARecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordResource GetPrivateDnsCnameRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordResource GetPrivateDnsMXRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordResource GetPrivateDnsPtrRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordResource GetPrivateDnsSoaRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordResource GetPrivateDnsSrvRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordResource GetPrivateDnsTxtRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource> GetPrivateDnsZone(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource>> GetPrivateDnsZoneAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource GetPrivateDnsZoneResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateDns.PrivateDnsZoneCollection GetPrivateDnsZones(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource> GetPrivateDnsZones(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource> GetPrivateDnsZonesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource GetVirtualNetworkLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class PrivateDnsMXRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordResource>, System.Collections.IEnumerable
    {
        protected PrivateDnsMXRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string mxRecordName, Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string mxRecordName, Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string mxRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string mxRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordResource> Get(string mxRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordResource>> GetAsync(string mxRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateDnsMXRecordData : Azure.ResourceManager.PrivateDns.PrivateDnsBaseRecordData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordData>
    {
        public PrivateDnsMXRecordData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.PrivateDnsMXRecordInfo> PrivateDnsMXRecords { get { throw null; } }
        Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateDnsMXRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateDnsMXRecordResource() { }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string mxRecordName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordResource> Update(Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateDnsPtrRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordResource>, System.Collections.IEnumerable
    {
        protected PrivateDnsPtrRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ptrRecordName, Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ptrRecordName, Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ptrRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ptrRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordResource> Get(string ptrRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordResource>> GetAsync(string ptrRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateDnsPtrRecordData : Azure.ResourceManager.PrivateDns.PrivateDnsBaseRecordData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordData>
    {
        public PrivateDnsPtrRecordData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.PrivateDnsPtrRecordInfo> PrivateDnsPtrRecords { get { throw null; } }
        Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateDnsPtrRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateDnsPtrRecordResource() { }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string ptrRecordName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordResource> Update(Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateDnsRecordData : Azure.ResourceManager.PrivateDns.PrivateDnsBaseRecordData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsRecordData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsRecordData>
    {
        public PrivateDnsRecordData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.PrivateDnsAaaaRecordInfo> AaaaRecords { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.PrivateDnsARecordInfo> ARecords { get { throw null; } }
        public string Cname { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.PrivateDnsMXRecordInfo> MXRecords { get { throw null; } }
        public Azure.ResourceManager.PrivateDns.Models.PrivateDnsSoaRecordInfo PrivateDnsSoaRecordInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.PrivateDnsPtrRecordInfo> PtrRecords { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.PrivateDnsSrvRecordInfo> SrvRecords { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.PrivateDnsTxtRecordInfo> TxtRecords { get { throw null; } }
        Azure.ResourceManager.PrivateDns.PrivateDnsRecordData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsRecordData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsRecordData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateDns.PrivateDnsRecordData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsRecordData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsRecordData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsRecordData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateDnsSoaRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordResource>, System.Collections.IEnumerable
    {
        protected PrivateDnsSoaRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string soaRecordName, Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string soaRecordName, Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string soaRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string soaRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordResource> Get(string soaRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordResource>> GetAsync(string soaRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateDnsSoaRecordData : Azure.ResourceManager.PrivateDns.PrivateDnsBaseRecordData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordData>
    {
        public PrivateDnsSoaRecordData() { }
        public Azure.ResourceManager.PrivateDns.Models.PrivateDnsSoaRecordInfo PrivateDnsSoaRecord { get { throw null; } set { } }
        Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateDnsSoaRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateDnsSoaRecordResource() { }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string soaRecordName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordResource> Update(Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateDnsSrvRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordResource>, System.Collections.IEnumerable
    {
        protected PrivateDnsSrvRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string srvRecordName, Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string srvRecordName, Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string srvRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string srvRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordResource> Get(string srvRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordResource>> GetAsync(string srvRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateDnsSrvRecordData : Azure.ResourceManager.PrivateDns.PrivateDnsBaseRecordData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordData>
    {
        public PrivateDnsSrvRecordData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.PrivateDnsSrvRecordInfo> PrivateDnsSrvRecords { get { throw null; } }
        Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateDnsSrvRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateDnsSrvRecordResource() { }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string srvRecordName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordResource> Update(Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateDnsTxtRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordResource>, System.Collections.IEnumerable
    {
        protected PrivateDnsTxtRecordCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string txtRecordName, Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string txtRecordName, Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string txtRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string txtRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordResource> Get(string txtRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordResource> GetAll(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordResource> GetAllAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordResource>> GetAsync(string txtRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateDnsTxtRecordData : Azure.ResourceManager.PrivateDns.PrivateDnsBaseRecordData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordData>
    {
        public PrivateDnsTxtRecordData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateDns.Models.PrivateDnsTxtRecordInfo> PrivateDnsTxtRecords { get { throw null; } }
        Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateDnsTxtRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateDnsTxtRecordResource() { }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string txtRecordName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordResource> Update(Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordResource>> UpdateAsync(Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateDnsZoneCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource>, System.Collections.IEnumerable
    {
        protected PrivateDnsZoneCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateZoneName, Azure.ResourceManager.PrivateDns.PrivateDnsZoneData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateZoneName, Azure.ResourceManager.PrivateDns.PrivateDnsZoneData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource> Get(string privateZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource>> GetAsync(string privateZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource> GetIfExists(string privateZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource>> GetIfExistsAsync(string privateZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateDnsZoneData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsZoneData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsZoneData>
    {
        public PrivateDnsZoneData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string InternalId { get { throw null; } }
        public long? MaxNumberOfRecords { get { throw null; } }
        public long? MaxNumberOfVirtualNetworkLinks { get { throw null; } }
        public long? MaxNumberOfVirtualNetworkLinksWithRegistration { get { throw null; } }
        public long? NumberOfRecords { get { throw null; } }
        public long? NumberOfVirtualNetworkLinks { get { throw null; } }
        public long? NumberOfVirtualNetworkLinksWithRegistration { get { throw null; } }
        public Azure.ResourceManager.PrivateDns.Models.PrivateDnsProvisioningState? PrivateDnsProvisioningState { get { throw null; } }
        Azure.ResourceManager.PrivateDns.PrivateDnsZoneData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsZoneData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.PrivateDnsZoneData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateDns.PrivateDnsZoneData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsZoneData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsZoneData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.PrivateDnsZoneData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateDnsZoneResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateDnsZoneResource() { }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsZoneData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordResource> GetPrivateDnsAaaaRecord(string aaaaRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordResource>> GetPrivateDnsAaaaRecordAsync(string aaaaRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordCollection GetPrivateDnsAaaaRecords() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsARecordResource> GetPrivateDnsARecord(string aRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsARecordResource>> GetPrivateDnsARecordAsync(string aRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsARecordCollection GetPrivateDnsARecords() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordResource> GetPrivateDnsCnameRecord(string cnameRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordResource>> GetPrivateDnsCnameRecordAsync(string cnameRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordCollection GetPrivateDnsCnameRecords() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordResource> GetPrivateDnsMXRecord(string mxRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordResource>> GetPrivateDnsMXRecordAsync(string mxRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordCollection GetPrivateDnsMXRecords() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordResource> GetPrivateDnsPtrRecord(string ptrRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordResource>> GetPrivateDnsPtrRecordAsync(string ptrRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordCollection GetPrivateDnsPtrRecords() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordResource> GetPrivateDnsSoaRecord(string soaRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordResource>> GetPrivateDnsSoaRecordAsync(string soaRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordCollection GetPrivateDnsSoaRecords() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordResource> GetPrivateDnsSrvRecord(string srvRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordResource>> GetPrivateDnsSrvRecordAsync(string srvRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordCollection GetPrivateDnsSrvRecords() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordResource> GetPrivateDnsTxtRecord(string txtRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordResource>> GetPrivateDnsTxtRecordAsync(string txtRecordName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordCollection GetPrivateDnsTxtRecords() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.PrivateDnsRecordData> GetRecords(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.PrivateDnsRecordData> GetRecordsAsync(int? top = default(int?), string recordsetnamesuffix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource> GetVirtualNetworkLink(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource>> GetVirtualNetworkLinkAsync(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.VirtualNetworkLinkCollection GetVirtualNetworkLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PrivateDns.PrivateDnsZoneData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PrivateDns.PrivateDnsZoneData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkLinkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource>, System.Collections.IEnumerable
    {
        protected VirtualNetworkLinkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualNetworkLinkName, Azure.ResourceManager.PrivateDns.VirtualNetworkLinkData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualNetworkLinkName, Azure.ResourceManager.PrivateDns.VirtualNetworkLinkData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource> Get(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource>> GetAsync(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource> GetIfExists(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource>> GetIfExistsAsync(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualNetworkLinkData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkData>
    {
        public VirtualNetworkLinkData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateDns.Models.PrivateDnsProvisioningState? PrivateDnsProvisioningState { get { throw null; } }
        public bool? RegistrationEnabled { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualNetworkId { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateDns.Models.VirtualNetworkLinkState? VirtualNetworkLinkState { get { throw null; } }
        Azure.ResourceManager.PrivateDns.VirtualNetworkLinkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateDns.VirtualNetworkLinkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PrivateDns.VirtualNetworkLinkData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PrivateDns.VirtualNetworkLinkData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PrivateDns.Mocking
{
    public partial class MockablePrivateDnsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePrivateDnsArmClient() { }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsAaaaRecordResource GetPrivateDnsAaaaRecordResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsARecordResource GetPrivateDnsARecordResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsCnameRecordResource GetPrivateDnsCnameRecordResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsMXRecordResource GetPrivateDnsMXRecordResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsPtrRecordResource GetPrivateDnsPtrRecordResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsSoaRecordResource GetPrivateDnsSoaRecordResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsSrvRecordResource GetPrivateDnsSrvRecordResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsTxtRecordResource GetPrivateDnsTxtRecordResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource GetPrivateDnsZoneResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.VirtualNetworkLinkResource GetVirtualNetworkLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockablePrivateDnsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePrivateDnsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource> GetPrivateDnsZone(string privateZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource>> GetPrivateDnsZoneAsync(string privateZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateDns.PrivateDnsZoneCollection GetPrivateDnsZones() { throw null; }
    }
    public partial class MockablePrivateDnsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePrivateDnsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource> GetPrivateDnsZones(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateDns.PrivateDnsZoneResource> GetPrivateDnsZonesAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PrivateDns.Models
{
    public static partial class ArmPrivateDnsModelFactory
    {
        public static Azure.ResourceManager.PrivateDns.PrivateDnsZoneData PrivateDnsZoneData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), long? maxNumberOfRecords = default(long?), long? numberOfRecords = default(long?), long? maxNumberOfVirtualNetworkLinks = default(long?), long? numberOfVirtualNetworkLinks = default(long?), long? maxNumberOfVirtualNetworkLinksWithRegistration = default(long?), long? numberOfVirtualNetworkLinksWithRegistration = default(long?), Azure.ResourceManager.PrivateDns.Models.PrivateDnsProvisioningState? privateDnsProvisioningState = default(Azure.ResourceManager.PrivateDns.Models.PrivateDnsProvisioningState?), string internalId = null) { throw null; }
        public static Azure.ResourceManager.PrivateDns.VirtualNetworkLinkData VirtualNetworkLinkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.Core.ResourceIdentifier virtualNetworkId = null, bool? registrationEnabled = default(bool?), Azure.ResourceManager.PrivateDns.Models.VirtualNetworkLinkState? virtualNetworkLinkState = default(Azure.ResourceManager.PrivateDns.Models.VirtualNetworkLinkState?), Azure.ResourceManager.PrivateDns.Models.PrivateDnsProvisioningState? privateDnsProvisioningState = default(Azure.ResourceManager.PrivateDns.Models.PrivateDnsProvisioningState?)) { throw null; }
    }
    public partial class PrivateDnsAaaaRecordInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsAaaaRecordInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsAaaaRecordInfo>
    {
        public PrivateDnsAaaaRecordInfo() { }
        public System.Net.IPAddress IPv6Address { get { throw null; } set { } }
        Azure.ResourceManager.PrivateDns.Models.PrivateDnsAaaaRecordInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsAaaaRecordInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsAaaaRecordInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateDns.Models.PrivateDnsAaaaRecordInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsAaaaRecordInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsAaaaRecordInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsAaaaRecordInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateDnsARecordInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsARecordInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsARecordInfo>
    {
        public PrivateDnsARecordInfo() { }
        public System.Net.IPAddress IPv4Address { get { throw null; } set { } }
        Azure.ResourceManager.PrivateDns.Models.PrivateDnsARecordInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsARecordInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsARecordInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateDns.Models.PrivateDnsARecordInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsARecordInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsARecordInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsARecordInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateDnsMXRecordInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsMXRecordInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsMXRecordInfo>
    {
        public PrivateDnsMXRecordInfo() { }
        public string Exchange { get { throw null; } set { } }
        public int? Preference { get { throw null; } set { } }
        Azure.ResourceManager.PrivateDns.Models.PrivateDnsMXRecordInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsMXRecordInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsMXRecordInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateDns.Models.PrivateDnsMXRecordInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsMXRecordInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsMXRecordInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsMXRecordInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateDnsProvisioningState : System.IEquatable<Azure.ResourceManager.PrivateDns.Models.PrivateDnsProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateDnsProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PrivateDns.Models.PrivateDnsProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PrivateDns.Models.PrivateDnsProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.PrivateDns.Models.PrivateDnsProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.PrivateDns.Models.PrivateDnsProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PrivateDns.Models.PrivateDnsProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.PrivateDns.Models.PrivateDnsProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PrivateDns.Models.PrivateDnsProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PrivateDns.Models.PrivateDnsProvisioningState left, Azure.ResourceManager.PrivateDns.Models.PrivateDnsProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateDns.Models.PrivateDnsProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PrivateDns.Models.PrivateDnsProvisioningState left, Azure.ResourceManager.PrivateDns.Models.PrivateDnsProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateDnsPtrRecordInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsPtrRecordInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsPtrRecordInfo>
    {
        public PrivateDnsPtrRecordInfo() { }
        public string PtrDomainName { get { throw null; } set { } }
        Azure.ResourceManager.PrivateDns.Models.PrivateDnsPtrRecordInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsPtrRecordInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsPtrRecordInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateDns.Models.PrivateDnsPtrRecordInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsPtrRecordInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsPtrRecordInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsPtrRecordInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateDnsSoaRecordInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsSoaRecordInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsSoaRecordInfo>
    {
        public PrivateDnsSoaRecordInfo() { }
        public string Email { get { throw null; } set { } }
        public long? ExpireTimeInSeconds { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        public long? MinimumTtlInSeconds { get { throw null; } set { } }
        public long? RefreshTimeInSeconds { get { throw null; } set { } }
        public long? RetryTimeInSeconds { get { throw null; } set { } }
        public long? SerialNumber { get { throw null; } set { } }
        Azure.ResourceManager.PrivateDns.Models.PrivateDnsSoaRecordInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsSoaRecordInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsSoaRecordInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateDns.Models.PrivateDnsSoaRecordInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsSoaRecordInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsSoaRecordInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsSoaRecordInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateDnsSrvRecordInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsSrvRecordInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsSrvRecordInfo>
    {
        public PrivateDnsSrvRecordInfo() { }
        public int? Port { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        public int? Weight { get { throw null; } set { } }
        Azure.ResourceManager.PrivateDns.Models.PrivateDnsSrvRecordInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsSrvRecordInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsSrvRecordInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateDns.Models.PrivateDnsSrvRecordInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsSrvRecordInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsSrvRecordInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsSrvRecordInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateDnsTxtRecordInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsTxtRecordInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsTxtRecordInfo>
    {
        public PrivateDnsTxtRecordInfo() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        Azure.ResourceManager.PrivateDns.Models.PrivateDnsTxtRecordInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsTxtRecordInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsTxtRecordInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateDns.Models.PrivateDnsTxtRecordInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsTxtRecordInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsTxtRecordInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateDns.Models.PrivateDnsTxtRecordInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
