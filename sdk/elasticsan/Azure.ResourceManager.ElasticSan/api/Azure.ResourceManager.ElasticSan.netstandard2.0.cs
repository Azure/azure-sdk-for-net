namespace Azure.ResourceManager.ElasticSan
{
    public partial class ElasticSanCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanResource>, System.Collections.IEnumerable
    {
        protected ElasticSanCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string elasticSanName, Azure.ResourceManager.ElasticSan.ElasticSanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string elasticSanName, Azure.ResourceManager.ElasticSan.ElasticSanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string elasticSanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string elasticSanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource> Get(string elasticSanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ElasticSan.ElasticSanResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ElasticSan.ElasticSanResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource>> GetAsync(string elasticSanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ElasticSan.ElasticSanResource> GetIfExists(string elasticSanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ElasticSan.ElasticSanResource>> GetIfExistsAsync(string elasticSanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ElasticSan.ElasticSanResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ElasticSan.ElasticSanResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ElasticSanData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.ElasticSanData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.ElasticSanData>
    {
        public ElasticSanData(Azure.Core.AzureLocation location, Azure.ResourceManager.ElasticSan.Models.ElasticSanSku sku, long baseSizeTiB, long extendedCapacitySizeTiB) { }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public long BaseSizeTiB { get { throw null; } set { } }
        public long ExtendedCapacitySizeTiB { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanSku Sku { get { throw null; } set { } }
        public long? TotalIops { get { throw null; } }
        public long? TotalMbps { get { throw null; } }
        public long? TotalSizeTiB { get { throw null; } }
        public long? TotalVolumeSizeGiB { get { throw null; } }
        public long? VolumeGroupCount { get { throw null; } }
        Azure.ResourceManager.ElasticSan.ElasticSanData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.ElasticSanData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.ElasticSanData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ElasticSan.ElasticSanData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.ElasticSanData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.ElasticSanData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.ElasticSanData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ElasticSanExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource> GetElasticSan(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string elasticSanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource>> GetElasticSanAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string elasticSanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionResource GetElasticSanPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ElasticSan.ElasticSanResource GetElasticSanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ElasticSan.ElasticSanCollection GetElasticSans(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ElasticSan.ElasticSanResource> GetElasticSans(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ElasticSan.ElasticSanResource> GetElasticSansAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ElasticSan.ElasticSanSnapshotResource GetElasticSanSnapshotResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource GetElasticSanVolumeGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource GetElasticSanVolumeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuInformation> GetSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuInformation> GetSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ElasticSanPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected ElasticSanPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ElasticSanPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionData>
    {
        public ElasticSanPrivateEndpointConnectionData(Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateLinkServiceConnectionState connectionState) { }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticSanPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ElasticSanPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string elasticSanName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ElasticSanResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ElasticSanResource() { }
        public virtual Azure.ResourceManager.ElasticSan.ElasticSanData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string elasticSanName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionResource> GetElasticSanPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionResource>> GetElasticSanPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionCollection GetElasticSanPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource> GetElasticSanVolumeGroup(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource>> GetElasticSanVolumeGroupAsync(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupCollection GetElasticSanVolumeGroups() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateLinkResource> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateLinkResource> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ElasticSan.Models.ElasticSanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ElasticSan.Models.ElasticSanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ElasticSanSnapshotCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotResource>, System.Collections.IEnumerable
    {
        protected ElasticSanSnapshotCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string snapshotName, Azure.ResourceManager.ElasticSan.ElasticSanSnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string snapshotName, Azure.ResourceManager.ElasticSan.ElasticSanSnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotResource> Get(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotResource>> GetAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotResource> GetIfExists(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotResource>> GetIfExistsAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ElasticSanSnapshotData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotData>
    {
        public ElasticSanSnapshotData(Azure.ResourceManager.ElasticSan.Models.SnapshotCreationInfo creationData) { }
        public Azure.Core.ResourceIdentifier CreationDataSourceId { get { throw null; } set { } }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState? ProvisioningState { get { throw null; } }
        public long? SourceVolumeSizeGiB { get { throw null; } }
        public string VolumeName { get { throw null; } }
        Azure.ResourceManager.ElasticSan.ElasticSanSnapshotData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ElasticSan.ElasticSanSnapshotData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticSanSnapshotResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ElasticSanSnapshotResource() { }
        public virtual Azure.ResourceManager.ElasticSan.ElasticSanSnapshotData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string elasticSanName, string volumeGroupName, string snapshotName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ElasticSan.ElasticSanSnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ElasticSan.ElasticSanSnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ElasticSanVolumeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource>, System.Collections.IEnumerable
    {
        protected ElasticSanVolumeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string volumeName, Azure.ResourceManager.ElasticSan.ElasticSanVolumeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string volumeName, Azure.ResourceManager.ElasticSan.ElasticSanVolumeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource> Get(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource>> GetAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource> GetIfExists(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource>> GetIfExistsAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ElasticSanVolumeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.ElasticSanVolumeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.ElasticSanVolumeData>
    {
        public ElasticSanVolumeData(long sizeGiB) { }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeDataSourceInfo CreationData { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ManagedByResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState? ProvisioningState { get { throw null; } }
        public long SizeGiB { get { throw null; } set { } }
        public Azure.ResourceManager.ElasticSan.Models.IscsiTargetInfo StorageTarget { get { throw null; } }
        public System.Guid? VolumeId { get { throw null; } }
        Azure.ResourceManager.ElasticSan.ElasticSanVolumeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.ElasticSanVolumeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.ElasticSanVolumeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ElasticSan.ElasticSanVolumeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.ElasticSanVolumeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.ElasticSanVolumeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.ElasticSanVolumeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticSanVolumeGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource>, System.Collections.IEnumerable
    {
        protected ElasticSanVolumeGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string volumeGroupName, Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string volumeGroupName, Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource> Get(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource>> GetAsync(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource> GetIfExists(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource>> GetIfExistsAsync(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ElasticSanVolumeGroupData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupData>
    {
        public ElasticSanVolumeGroupData() { }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionType? Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionProperties EncryptionProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanStorageTargetType? ProtocolType { get { throw null; } set { } }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ElasticSan.Models.ElasticSanVirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
        Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticSanVolumeGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ElasticSanVolumeGroupResource() { }
        public virtual Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string elasticSanName, string volumeGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotResource> GetElasticSanSnapshot(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanSnapshotResource>> GetElasticSanSnapshotAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ElasticSan.ElasticSanSnapshotCollection GetElasticSanSnapshots() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource> GetElasticSanVolume(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource>> GetElasticSanVolumeAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ElasticSan.ElasticSanVolumeCollection GetElasticSanVolumes() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ElasticSanVolumeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ElasticSanVolumeResource() { }
        public virtual Azure.ResourceManager.ElasticSan.ElasticSanVolumeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string elasticSanName, string volumeGroupName, string volumeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.ElasticSan.Models.XmsDeleteSnapshot? xmsDeleteSnapshots = default(Azure.ResourceManager.ElasticSan.Models.XmsDeleteSnapshot?), Azure.ResourceManager.ElasticSan.Models.XmsForceDelete? xmsForceDelete = default(Azure.ResourceManager.ElasticSan.Models.XmsForceDelete?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ElasticSan.Models.XmsDeleteSnapshot? xmsDeleteSnapshots = default(Azure.ResourceManager.ElasticSan.Models.XmsDeleteSnapshot?), Azure.ResourceManager.ElasticSan.Models.XmsForceDelete? xmsForceDelete = default(Azure.ResourceManager.ElasticSan.Models.XmsForceDelete?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ElasticSan.Mocking
{
    public partial class MockableElasticSanArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableElasticSanArmClient() { }
        public virtual Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionResource GetElasticSanPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ElasticSan.ElasticSanResource GetElasticSanResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ElasticSan.ElasticSanSnapshotResource GetElasticSanSnapshotResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource GetElasticSanVolumeGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource GetElasticSanVolumeResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableElasticSanResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableElasticSanResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource> GetElasticSan(string elasticSanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource>> GetElasticSanAsync(string elasticSanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ElasticSan.ElasticSanCollection GetElasticSans() { throw null; }
    }
    public partial class MockableElasticSanSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableElasticSanSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ElasticSan.ElasticSanResource> GetElasticSans(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ElasticSan.ElasticSanResource> GetElasticSansAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuInformation> GetSkus(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuInformation> GetSkusAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ElasticSan.Models
{
    public static partial class ArmElasticSanModelFactory
    {
        public static Azure.ResourceManager.ElasticSan.ElasticSanData ElasticSanData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ElasticSan.Models.ElasticSanSku sku = null, System.Collections.Generic.IEnumerable<string> availabilityZones = null, Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState? provisioningState = default(Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState?), long baseSizeTiB = (long)0, long extendedCapacitySizeTiB = (long)0, long? totalVolumeSizeGiB = default(long?), long? volumeGroupCount = default(long?), long? totalIops = default(long?), long? totalMbps = default(long?), long? totalSizeTiB = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.ElasticSan.Models.ElasticSanPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.ElasticSan.Models.ElasticSanPublicNetworkAccess?)) { throw null; }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanKeyVaultProperties ElasticSanKeyVaultProperties(string keyName = null, string keyVersion = null, System.Uri keyVaultUri = null, string currentVersionedKeyIdentifier = null, System.DateTimeOffset? lastKeyRotationTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? currentVersionedKeyExpirationTimestamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionData ElasticSanPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState? provisioningState = default(Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState?), Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateLinkServiceConnectionState connectionState = null, System.Collections.Generic.IEnumerable<string> groupIds = null) { throw null; }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateLinkResource ElasticSanPrivateLinkResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuCapability ElasticSanSkuCapability(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuInformation ElasticSanSkuInformation(Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName name = default(Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName), Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuTier? tier = default(Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuTier?), string resourceType = null, System.Collections.Generic.IEnumerable<string> locations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuLocationInfo> locationInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuCapability> capabilities = null) { throw null; }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuLocationInfo ElasticSanSkuLocationInfo(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.ElasticSan.ElasticSanSnapshotData ElasticSanSnapshotData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier creationDataSourceId = null, Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState? provisioningState = default(Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState?), long? sourceVolumeSizeGiB = default(long?), string volumeName = null) { throw null; }
        public static Azure.ResourceManager.ElasticSan.ElasticSanVolumeData ElasticSanVolumeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? volumeId = default(System.Guid?), Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeDataSourceInfo creationData = null, long sizeGiB = (long)0, Azure.ResourceManager.ElasticSan.Models.IscsiTargetInfo storageTarget = null, Azure.Core.ResourceIdentifier managedByResourceId = null, Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState? provisioningState = default(Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupData ElasticSanVolumeGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState? provisioningState = default(Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState?), Azure.ResourceManager.ElasticSan.Models.ElasticSanStorageTargetType? protocolType = default(Azure.ResourceManager.ElasticSan.Models.ElasticSanStorageTargetType?), Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionType? encryption = default(Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionType?), Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionProperties encryptionProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ElasticSan.Models.ElasticSanVirtualNetworkRule> virtualNetworkRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanPrivateEndpointConnectionData> privateEndpointConnections = null) { throw null; }
        public static Azure.ResourceManager.ElasticSan.Models.IscsiTargetInfo IscsiTargetInfo(string targetIqn = null, string targetPortalHostname = null, int? targetPortalPort = default(int?), Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState? provisioningState = default(Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState?), Azure.ResourceManager.ElasticSan.Models.ResourceOperationalStatus? status = default(Azure.ResourceManager.ElasticSan.Models.ResourceOperationalStatus?)) { throw null; }
    }
    public partial class ElasticSanEncryptionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionProperties>
    {
        public ElasticSanEncryptionProperties() { }
        public Azure.Core.ResourceIdentifier EncryptionUserAssignedIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticSanEncryptionType : System.IEquatable<Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ElasticSanEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionType EncryptionAtRestWithCustomerManagedKey { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionType EncryptionAtRestWithPlatformKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionType left, Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionType left, Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ElasticSanKeyVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanKeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanKeyVaultProperties>
    {
        public ElasticSanKeyVaultProperties() { }
        public System.DateTimeOffset? CurrentVersionedKeyExpirationTimestamp { get { throw null; } }
        public string CurrentVersionedKeyIdentifier { get { throw null; } }
        public string KeyName { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public System.DateTimeOffset? LastKeyRotationTimestamp { get { throw null; } }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanKeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanKeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanKeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanKeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanKeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanKeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanKeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticSanPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanPatch>
    {
        public ElasticSanPatch() { }
        public long? BaseSizeTiB { get { throw null; } set { } }
        public long? ExtendedCapacitySizeTiB { get { throw null; } set { } }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticSanPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ElasticSanPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateEndpointServiceConnectionStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ElasticSanPrivateLinkResource : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateLinkResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateLinkResource>
    {
        public ElasticSanPrivateLinkResource() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateLinkResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateLinkResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateLinkResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateLinkResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateLinkResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateLinkResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateLinkResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticSanPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateLinkServiceConnectionState>
    {
        public ElasticSanPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticSanProvisioningState : System.IEquatable<Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ElasticSanProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState Invalid { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState left, Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState left, Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticSanPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.ElasticSan.Models.ElasticSanPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ElasticSanPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ElasticSan.Models.ElasticSanPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ElasticSan.Models.ElasticSanPublicNetworkAccess left, Azure.ResourceManager.ElasticSan.Models.ElasticSanPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.ElasticSan.Models.ElasticSanPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ElasticSan.Models.ElasticSanPublicNetworkAccess left, Azure.ResourceManager.ElasticSan.Models.ElasticSanPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ElasticSanSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSku>
    {
        public ElasticSanSku(Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName name) { }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuTier? Tier { get { throw null; } set { } }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticSanSkuCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuCapability>
    {
        internal ElasticSanSkuCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticSanSkuInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuInformation>
    {
        internal ElasticSanSkuInformation() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuCapability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuLocationInfo> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuTier? Tier { get { throw null; } }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticSanSkuLocationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuLocationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuLocationInfo>
    {
        internal ElasticSanSkuLocationInfo() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuLocationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuLocationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuLocationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuLocationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuLocationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuLocationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuLocationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticSanSkuName : System.IEquatable<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ElasticSanSkuName(string value) { throw null; }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName PremiumLrs { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName PremiumZrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName left, Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName left, Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticSanSkuTier : System.IEquatable<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ElasticSanSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuTier Premium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuTier left, Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuTier left, Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticSanStorageTargetType : System.IEquatable<Azure.ResourceManager.ElasticSan.Models.ElasticSanStorageTargetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ElasticSanStorageTargetType(string value) { throw null; }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanStorageTargetType Iscsi { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanStorageTargetType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ElasticSan.Models.ElasticSanStorageTargetType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ElasticSan.Models.ElasticSanStorageTargetType left, Azure.ResourceManager.ElasticSan.Models.ElasticSanStorageTargetType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ElasticSan.Models.ElasticSanStorageTargetType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ElasticSan.Models.ElasticSanStorageTargetType left, Azure.ResourceManager.ElasticSan.Models.ElasticSanStorageTargetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ElasticSanVirtualNetworkRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVirtualNetworkRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVirtualNetworkRule>
    {
        public ElasticSanVirtualNetworkRule(Azure.Core.ResourceIdentifier virtualNetworkResourceId) { }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanVirtualNetworkRuleAction? Action { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualNetworkResourceId { get { throw null; } set { } }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanVirtualNetworkRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVirtualNetworkRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVirtualNetworkRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanVirtualNetworkRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVirtualNetworkRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVirtualNetworkRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVirtualNetworkRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticSanVirtualNetworkRuleAction : System.IEquatable<Azure.ResourceManager.ElasticSan.Models.ElasticSanVirtualNetworkRuleAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ElasticSanVirtualNetworkRuleAction(string value) { throw null; }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanVirtualNetworkRuleAction Allow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ElasticSan.Models.ElasticSanVirtualNetworkRuleAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ElasticSan.Models.ElasticSanVirtualNetworkRuleAction left, Azure.ResourceManager.ElasticSan.Models.ElasticSanVirtualNetworkRuleAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ElasticSan.Models.ElasticSanVirtualNetworkRuleAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ElasticSan.Models.ElasticSanVirtualNetworkRuleAction left, Azure.ResourceManager.ElasticSan.Models.ElasticSanVirtualNetworkRuleAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticSanVolumeCreateOption : System.IEquatable<Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeCreateOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ElasticSanVolumeCreateOption(string value) { throw null; }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeCreateOption Disk { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeCreateOption DiskRestorePoint { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeCreateOption DiskSnapshot { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeCreateOption None { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeCreateOption VolumeSnapshot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeCreateOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeCreateOption left, Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeCreateOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeCreateOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeCreateOption left, Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeCreateOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ElasticSanVolumeDataSourceInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeDataSourceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeDataSourceInfo>
    {
        public ElasticSanVolumeDataSourceInfo() { }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeCreateOption? CreateSource { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceId { get { throw null; } set { } }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeDataSourceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeDataSourceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeDataSourceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeDataSourceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeDataSourceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeDataSourceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeDataSourceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticSanVolumeGroupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeGroupPatch>
    {
        public ElasticSanVolumeGroupPatch() { }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionType? Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanEncryptionProperties EncryptionProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanStorageTargetType? ProtocolType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ElasticSan.Models.ElasticSanVirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticSanVolumePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumePatch>
    {
        public ElasticSanVolumePatch() { }
        public Azure.Core.ResourceIdentifier ManagedByResourceId { get { throw null; } set { } }
        public long? SizeGiB { get { throw null; } set { } }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IscsiTargetInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.IscsiTargetInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.IscsiTargetInfo>
    {
        internal IscsiTargetInfo() { }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ElasticSan.Models.ResourceOperationalStatus? Status { get { throw null; } }
        public string TargetIqn { get { throw null; } }
        public string TargetPortalHostname { get { throw null; } }
        public int? TargetPortalPort { get { throw null; } }
        Azure.ResourceManager.ElasticSan.Models.IscsiTargetInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.IscsiTargetInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.IscsiTargetInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ElasticSan.Models.IscsiTargetInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.IscsiTargetInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.IscsiTargetInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.IscsiTargetInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceOperationalStatus : System.IEquatable<Azure.ResourceManager.ElasticSan.Models.ResourceOperationalStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceOperationalStatus(string value) { throw null; }
        public static Azure.ResourceManager.ElasticSan.Models.ResourceOperationalStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ResourceOperationalStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ResourceOperationalStatus Running { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ResourceOperationalStatus Stopped { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ResourceOperationalStatus StoppedDeallocated { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ResourceOperationalStatus Unhealthy { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ResourceOperationalStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ResourceOperationalStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ElasticSan.Models.ResourceOperationalStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ElasticSan.Models.ResourceOperationalStatus left, Azure.ResourceManager.ElasticSan.Models.ResourceOperationalStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ElasticSan.Models.ResourceOperationalStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ElasticSan.Models.ResourceOperationalStatus left, Azure.ResourceManager.ElasticSan.Models.ResourceOperationalStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SnapshotCreationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.SnapshotCreationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.SnapshotCreationInfo>
    {
        public SnapshotCreationInfo(Azure.Core.ResourceIdentifier sourceId) { }
        public Azure.Core.ResourceIdentifier SourceId { get { throw null; } set { } }
        Azure.ResourceManager.ElasticSan.Models.SnapshotCreationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.SnapshotCreationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ElasticSan.Models.SnapshotCreationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ElasticSan.Models.SnapshotCreationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.SnapshotCreationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.SnapshotCreationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ElasticSan.Models.SnapshotCreationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct XmsDeleteSnapshot : System.IEquatable<Azure.ResourceManager.ElasticSan.Models.XmsDeleteSnapshot>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public XmsDeleteSnapshot(string value) { throw null; }
        public static Azure.ResourceManager.ElasticSan.Models.XmsDeleteSnapshot False { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.XmsDeleteSnapshot True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ElasticSan.Models.XmsDeleteSnapshot other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ElasticSan.Models.XmsDeleteSnapshot left, Azure.ResourceManager.ElasticSan.Models.XmsDeleteSnapshot right) { throw null; }
        public static implicit operator Azure.ResourceManager.ElasticSan.Models.XmsDeleteSnapshot (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ElasticSan.Models.XmsDeleteSnapshot left, Azure.ResourceManager.ElasticSan.Models.XmsDeleteSnapshot right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct XmsForceDelete : System.IEquatable<Azure.ResourceManager.ElasticSan.Models.XmsForceDelete>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public XmsForceDelete(string value) { throw null; }
        public static Azure.ResourceManager.ElasticSan.Models.XmsForceDelete False { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.XmsForceDelete True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ElasticSan.Models.XmsForceDelete other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ElasticSan.Models.XmsForceDelete left, Azure.ResourceManager.ElasticSan.Models.XmsForceDelete right) { throw null; }
        public static implicit operator Azure.ResourceManager.ElasticSan.Models.XmsForceDelete (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ElasticSan.Models.XmsForceDelete left, Azure.ResourceManager.ElasticSan.Models.XmsForceDelete right) { throw null; }
        public override string ToString() { throw null; }
    }
}
