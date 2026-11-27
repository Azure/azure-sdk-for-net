namespace Azure.ResourceManager.DigitalAssets
{
    public partial class AzureResourceManagerDigitalAssetsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDigitalAssetsContext() { }
        public static Azure.ResourceManager.DigitalAssets.AzureResourceManagerDigitalAssetsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class DigitalAssetsExtensions
    {
        public static Azure.ResourceManager.DigitalAssets.PartitionResource GetPartitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DigitalAssets.ZkpRollupResource> GetZkpRollup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string zkpRollupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalAssets.ZkpRollupResource>> GetZkpRollupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string zkpRollupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DigitalAssets.ZkpRollupResource GetZkpRollupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DigitalAssets.ZkpRollupCollection GetZkpRollups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DigitalAssets.ZkpRollupResource> GetZkpRollups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DigitalAssets.ZkpRollupResource> GetZkpRollupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PartitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DigitalAssets.PartitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DigitalAssets.PartitionResource>, System.Collections.IEnumerable
    {
        protected PartitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalAssets.PartitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string partitionName, Azure.ResourceManager.DigitalAssets.PartitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalAssets.PartitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string partitionName, Azure.ResourceManager.DigitalAssets.PartitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string partitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string partitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalAssets.PartitionResource> Get(string partitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DigitalAssets.PartitionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DigitalAssets.PartitionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalAssets.PartitionResource>> GetAsync(string partitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DigitalAssets.PartitionResource> GetIfExists(string partitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DigitalAssets.PartitionResource>> GetIfExistsAsync(string partitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DigitalAssets.PartitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DigitalAssets.PartitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DigitalAssets.PartitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DigitalAssets.PartitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PartitionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.PartitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.PartitionData>
    {
        public PartitionData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DigitalAssets.Models.PartitionProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DigitalAssets.PartitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.PartitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.PartitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DigitalAssets.PartitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.PartitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.PartitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.PartitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.PartitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.PartitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PartitionResource() { }
        public virtual Azure.ResourceManager.DigitalAssets.PartitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DigitalAssets.PartitionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalAssets.PartitionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zkpRollupName, string partitionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalAssets.PartitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalAssets.PartitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalAssets.PartitionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalAssets.PartitionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalAssets.PartitionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalAssets.PartitionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DigitalAssets.PartitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.PartitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.PartitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DigitalAssets.PartitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.PartitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.PartitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.PartitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalAssets.PartitionResource> Update(Azure.ResourceManager.DigitalAssets.Models.PartitionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalAssets.PartitionResource>> UpdateAsync(Azure.ResourceManager.DigitalAssets.Models.PartitionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ZkpRollupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DigitalAssets.ZkpRollupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DigitalAssets.ZkpRollupResource>, System.Collections.IEnumerable
    {
        protected ZkpRollupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalAssets.ZkpRollupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string zkpRollupName, Azure.ResourceManager.DigitalAssets.ZkpRollupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalAssets.ZkpRollupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string zkpRollupName, Azure.ResourceManager.DigitalAssets.ZkpRollupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string zkpRollupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string zkpRollupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalAssets.ZkpRollupResource> Get(string zkpRollupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DigitalAssets.ZkpRollupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DigitalAssets.ZkpRollupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalAssets.ZkpRollupResource>> GetAsync(string zkpRollupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DigitalAssets.ZkpRollupResource> GetIfExists(string zkpRollupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DigitalAssets.ZkpRollupResource>> GetIfExistsAsync(string zkpRollupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DigitalAssets.ZkpRollupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DigitalAssets.ZkpRollupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DigitalAssets.ZkpRollupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DigitalAssets.ZkpRollupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ZkpRollupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.ZkpRollupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.ZkpRollupData>
    {
        public ZkpRollupData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DigitalAssets.Models.ZkpRollupProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DigitalAssets.ZkpRollupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.ZkpRollupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.ZkpRollupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DigitalAssets.ZkpRollupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.ZkpRollupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.ZkpRollupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.ZkpRollupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ZkpRollupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.ZkpRollupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.ZkpRollupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ZkpRollupResource() { }
        public virtual Azure.ResourceManager.DigitalAssets.ZkpRollupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DigitalAssets.ZkpRollupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalAssets.ZkpRollupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zkpRollupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalAssets.ZkpRollupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalAssets.ZkpRollupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalAssets.PartitionResource> GetPartition(string partitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalAssets.PartitionResource>> GetPartitionAsync(string partitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DigitalAssets.PartitionCollection GetPartitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalAssets.ZkpRollupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalAssets.ZkpRollupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalAssets.ZkpRollupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalAssets.ZkpRollupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DigitalAssets.ZkpRollupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.ZkpRollupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.ZkpRollupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DigitalAssets.ZkpRollupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.ZkpRollupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.ZkpRollupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.ZkpRollupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalAssets.ZkpRollupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalAssets.ZkpRollupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DigitalAssets.Mocking
{
    public partial class MockableDigitalAssetsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDigitalAssetsArmClient() { }
        public virtual Azure.ResourceManager.DigitalAssets.PartitionResource GetPartitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DigitalAssets.ZkpRollupResource GetZkpRollupResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDigitalAssetsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDigitalAssetsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DigitalAssets.ZkpRollupResource> GetZkpRollup(string zkpRollupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalAssets.ZkpRollupResource>> GetZkpRollupAsync(string zkpRollupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DigitalAssets.ZkpRollupCollection GetZkpRollups() { throw null; }
    }
    public partial class MockableDigitalAssetsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDigitalAssetsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DigitalAssets.ZkpRollupResource> GetZkpRollups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DigitalAssets.ZkpRollupResource> GetZkpRollupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DigitalAssets.Models
{
    public static partial class ArmDigitalAssetsModelFactory
    {
        public static Azure.ResourceManager.DigitalAssets.Models.OperationalStatus OperationalStatus(string status = null, System.DateTimeOffset evaluatedOn = default(System.DateTimeOffset), System.DateTimeOffset validUntil = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.DigitalAssets.PartitionData PartitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DigitalAssets.Models.PartitionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DigitalAssets.Models.PartitionPatch PartitionPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.DigitalAssets.Models.PartitionProperties PartitionProperties(Azure.ResourceManager.DigitalAssets.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.DigitalAssets.Models.ProvisioningState?), Azure.ResourceManager.DigitalAssets.Models.OperationalStatus operationalStatus = null) { throw null; }
        public static Azure.ResourceManager.DigitalAssets.ZkpRollupData ZkpRollupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DigitalAssets.Models.ZkpRollupProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.DigitalAssets.Models.ZkpRollupIdentityUpdate ZkpRollupIdentityUpdate(Azure.ResourceManager.Models.ManagedServiceIdentityType? type = default(Azure.ResourceManager.Models.ManagedServiceIdentityType?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatch ZkpRollupPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.DigitalAssets.Models.ZkpRollupIdentityUpdate identity = null, Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatchProperties ZkpRollupPatchProperties(System.Collections.Generic.IEnumerable<string> tokenOwnerAccounts = null, string bootNodeId = null, string bootNodeIP = null, int? bootNodeP2pPort = default(int?), int? bootNodeRpcPort = default(int?)) { throw null; }
        public static Azure.ResourceManager.DigitalAssets.Models.ZkpRollupProperties ZkpRollupProperties(System.Collections.Generic.IEnumerable<string> tokenOwnerAccounts = null, Azure.Core.ResourceIdentifier keyVaultId = null, Azure.Core.ResourceIdentifier keyVaultUserAssignedIdentityResourceId = null, int? blocksPerProof = default(int?), string customerVpnPublicIP = null, System.Collections.Generic.IEnumerable<string> customerOnPremAddressPrefixes = null, string serviceVpnPublicIP = null, string serviceVpnAddressSpace = null, string bootNodeId = null, string bootNodeIP = null, int bootNodeP2pPort = 0, int bootNodeRpcPort = 0, System.Uri serviceBusEndpoint = null, string serviceBusQueueName = null, Azure.ResourceManager.DigitalAssets.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.DigitalAssets.Models.ProvisioningState?), Azure.ResourceManager.DigitalAssets.Models.OperationalStatus operationalStatus = null) { throw null; }
    }
    public partial class OperationalStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.Models.OperationalStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.OperationalStatus>
    {
        internal OperationalStatus() { }
        public System.DateTimeOffset EvaluatedOn { get { throw null; } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset ValidUntil { get { throw null; } }
        protected virtual Azure.ResourceManager.DigitalAssets.Models.OperationalStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DigitalAssets.Models.OperationalStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DigitalAssets.Models.OperationalStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.Models.OperationalStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.Models.OperationalStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DigitalAssets.Models.OperationalStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.OperationalStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.OperationalStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.OperationalStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartitionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.Models.PartitionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.PartitionPatch>
    {
        public PartitionPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.DigitalAssets.Models.PartitionPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DigitalAssets.Models.PartitionPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DigitalAssets.Models.PartitionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.Models.PartitionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.Models.PartitionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DigitalAssets.Models.PartitionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.PartitionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.PartitionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.PartitionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartitionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.Models.PartitionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.PartitionProperties>
    {
        public PartitionProperties() { }
        public Azure.ResourceManager.DigitalAssets.Models.OperationalStatus OperationalStatus { get { throw null; } }
        public Azure.ResourceManager.DigitalAssets.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.DigitalAssets.Models.PartitionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DigitalAssets.Models.PartitionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DigitalAssets.Models.PartitionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.Models.PartitionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.Models.PartitionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DigitalAssets.Models.PartitionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.PartitionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.PartitionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.PartitionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.DigitalAssets.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DigitalAssets.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.DigitalAssets.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DigitalAssets.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DigitalAssets.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DigitalAssets.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DigitalAssets.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DigitalAssets.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalAssets.Models.ProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalAssets.Models.ProvisioningState left, Azure.ResourceManager.DigitalAssets.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalAssets.Models.ProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalAssets.Models.ProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalAssets.Models.ProvisioningState left, Azure.ResourceManager.DigitalAssets.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ZkpRollupIdentityUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupIdentityUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupIdentityUpdate>
    {
        public ZkpRollupIdentityUpdate() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.DigitalAssets.Models.ZkpRollupIdentityUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DigitalAssets.Models.ZkpRollupIdentityUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DigitalAssets.Models.ZkpRollupIdentityUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupIdentityUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupIdentityUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DigitalAssets.Models.ZkpRollupIdentityUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupIdentityUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupIdentityUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupIdentityUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ZkpRollupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatch>
    {
        public ZkpRollupPatch() { }
        public Azure.ResourceManager.DigitalAssets.Models.ZkpRollupIdentityUpdate Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ZkpRollupPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatchProperties>
    {
        public ZkpRollupPatchProperties() { }
        public string BootNodeId { get { throw null; } set { } }
        public string BootNodeIP { get { throw null; } set { } }
        public int? BootNodeP2pPort { get { throw null; } set { } }
        public int? BootNodeRpcPort { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TokenOwnerAccounts { get { throw null; } }
        protected virtual Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ZkpRollupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupProperties>
    {
        public ZkpRollupProperties(System.Collections.Generic.IEnumerable<string> tokenOwnerAccounts, Azure.Core.ResourceIdentifier keyVaultId, Azure.Core.ResourceIdentifier keyVaultUserAssignedIdentityResourceId, string bootNodeId, string bootNodeIP, int bootNodeP2pPort, int bootNodeRpcPort, System.Uri serviceBusEndpoint, string serviceBusQueueName) { }
        public int? BlocksPerProof { get { throw null; } set { } }
        public string BootNodeId { get { throw null; } set { } }
        public string BootNodeIP { get { throw null; } set { } }
        public int BootNodeP2pPort { get { throw null; } set { } }
        public int BootNodeRpcPort { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> CustomerOnPremAddressPrefixes { get { throw null; } }
        public string CustomerVpnPublicIP { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier KeyVaultId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier KeyVaultUserAssignedIdentityResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DigitalAssets.Models.OperationalStatus OperationalStatus { get { throw null; } }
        public Azure.ResourceManager.DigitalAssets.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Uri ServiceBusEndpoint { get { throw null; } set { } }
        public string ServiceBusQueueName { get { throw null; } set { } }
        public string ServiceVpnAddressSpace { get { throw null; } }
        public string ServiceVpnPublicIP { get { throw null; } }
        public System.Collections.Generic.IList<string> TokenOwnerAccounts { get { throw null; } }
        protected virtual Azure.ResourceManager.DigitalAssets.Models.ZkpRollupProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DigitalAssets.Models.ZkpRollupProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DigitalAssets.Models.ZkpRollupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DigitalAssets.Models.ZkpRollupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DigitalAssets.Models.ZkpRollupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
