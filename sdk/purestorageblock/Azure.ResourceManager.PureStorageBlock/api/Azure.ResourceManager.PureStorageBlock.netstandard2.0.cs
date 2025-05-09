namespace Azure.ResourceManager.PureStorageBlock
{
    public partial class AvsStorageContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerResource>, System.Collections.IEnumerable
    {
        protected AvsStorageContainerCollection() { }
        public virtual Azure.Response<bool> Exists(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerResource> Get(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerResource>> GetAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerResource> GetIfExists(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerResource>> GetIfExistsAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvsStorageContainerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerData>
    {
        internal AvsStorageContainerData() { }
        public Azure.ResourceManager.PureStorageBlock.Models.AvsStorageContainerProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.AvsStorageContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.AvsStorageContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsStorageContainerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvsStorageContainerResource() { }
        public virtual Azure.ResourceManager.PureStorageBlock.AvsStorageContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storagePoolName, string storageContainerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeResource> GetAvsStorageContainerVolume(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeResource>> GetAvsStorageContainerVolumeAsync(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeCollection GetAvsStorageContainerVolumes() { throw null; }
        Azure.ResourceManager.PureStorageBlock.AvsStorageContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.AvsStorageContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsStorageContainerVolumeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeResource>, System.Collections.IEnumerable
    {
        protected AvsStorageContainerVolumeCollection() { }
        public virtual Azure.Response<bool> Exists(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeResource> Get(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeResource>> GetAsync(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeResource> GetIfExists(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeResource>> GetIfExistsAsync(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvsStorageContainerVolumeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeData>
    {
        internal AvsStorageContainerVolumeData() { }
        public Azure.ResourceManager.PureStorageBlock.Models.VolumeProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsStorageContainerVolumeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvsStorageContainerVolumeResource() { }
        public virtual Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storagePoolName, string storageContainerName, string volumeId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.AvsStorageContainerVolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.AvsStorageContainerVolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AvsVmCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.AvsVmResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.AvsVmResource>, System.Collections.IEnumerable
    {
        protected AvsVmCollection() { }
        public virtual Azure.Response<bool> Exists(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.AvsVmResource> Get(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorageBlock.AvsVmResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorageBlock.AvsVmResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.AvsVmResource>> GetAsync(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.AvsVmResource> GetIfExists(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.AvsVmResource>> GetIfExistsAsync(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PureStorageBlock.AvsVmResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.AvsVmResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PureStorageBlock.AvsVmResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.AvsVmResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvsVmData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.AvsVmData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsVmData>
    {
        internal AvsVmData() { }
        public Azure.ResourceManager.PureStorageBlock.Models.AvsVmProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.AvsVmData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.AvsVmData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.AvsVmData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.AvsVmData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsVmData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsVmData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsVmData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsVmResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.AvsVmData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsVmData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvsVmResource() { }
        public virtual Azure.ResourceManager.PureStorageBlock.AvsVmData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storagePoolName, string avsVmId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.AvsVmResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.AvsVmResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeResource> GetAvsVmVolume(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeResource>> GetAvsVmVolumeAsync(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.AvsVmVolumeCollection GetAvsVmVolumes() { throw null; }
        Azure.ResourceManager.PureStorageBlock.AvsVmData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.AvsVmData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.AvsVmData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.AvsVmData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsVmData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsVmData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsVmData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.AvsVmResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.AvsVmPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.AvsVmResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.AvsVmPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AvsVmVolumeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeResource>, System.Collections.IEnumerable
    {
        protected AvsVmVolumeCollection() { }
        public virtual Azure.Response<bool> Exists(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeResource> Get(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeResource>> GetAsync(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeResource> GetIfExists(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeResource>> GetIfExistsAsync(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvsVmVolumeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeData>
    {
        internal AvsVmVolumeData() { }
        public Azure.ResourceManager.PureStorageBlock.Models.VolumeProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.AvsVmVolumeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.AvsVmVolumeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsVmVolumeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvsVmVolumeResource() { }
        public virtual Azure.ResourceManager.PureStorageBlock.AvsVmVolumeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storagePoolName, string avsVmId, string volumeId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PureStorageBlock.AvsVmVolumeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.AvsVmVolumeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.AvsVmVolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.AvsVmVolumeResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.AvsVmVolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerPureStorageBlockContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerPureStorageBlockContext() { }
        public static Azure.ResourceManager.PureStorageBlock.AzureResourceManagerPureStorageBlockContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class PureStorageBlockExtensions
    {
        public static Azure.ResourceManager.PureStorageBlock.AvsStorageContainerResource GetAvsStorageContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeResource GetAvsStorageContainerVolumeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.AvsVmResource GetAvsVmResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.AvsVmVolumeResource GetAvsVmVolumeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PureStorageBlock.ReservationResource> GetReservation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.ReservationResource>> GetReservationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.ReservationResource GetReservationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.ReservationCollection GetReservations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PureStorageBlock.ReservationResource> GetReservations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PureStorageBlock.ReservationResource> GetReservationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PureStorageBlock.StoragePoolResource> GetStoragePool(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.StoragePoolResource>> GetStoragePoolAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.StoragePoolResource GetStoragePoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.StoragePoolCollection GetStoragePools(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PureStorageBlock.StoragePoolResource> GetStoragePools(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PureStorageBlock.StoragePoolResource> GetStoragePoolsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReservationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.ReservationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.ReservationResource>, System.Collections.IEnumerable
    {
        protected ReservationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.ReservationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string reservationName, Azure.ResourceManager.PureStorageBlock.ReservationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.ReservationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string reservationName, Azure.ResourceManager.PureStorageBlock.ReservationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.ReservationResource> Get(string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorageBlock.ReservationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorageBlock.ReservationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.ReservationResource>> GetAsync(string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.ReservationResource> GetIfExists(string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.ReservationResource>> GetIfExistsAsync(string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PureStorageBlock.ReservationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.ReservationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PureStorageBlock.ReservationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.ReservationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ReservationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.ReservationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.ReservationData>
    {
        public ReservationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.PureStorageBlock.Models.ReservationPropertiesBaseResourceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.ReservationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.ReservationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.ReservationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.ReservationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.ReservationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.ReservationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.ReservationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReservationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.ReservationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.ReservationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ReservationResource() { }
        public virtual Azure.ResourceManager.PureStorageBlock.ReservationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.ReservationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.ReservationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string reservationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.ReservationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.ReservationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport> GetBillingReport(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport>> GetBillingReportAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus> GetBillingStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus>> GetBillingStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.LimitDetails> GetResourceLimits(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.LimitDetails>> GetResourceLimitsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.ReservationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.ReservationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.ReservationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.ReservationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PureStorageBlock.ReservationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.ReservationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.ReservationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.ReservationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.ReservationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.ReservationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.ReservationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.ReservationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.ReservationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.ReservationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.ReservationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StoragePoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.StoragePoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.StoragePoolResource>, System.Collections.IEnumerable
    {
        protected StoragePoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.StoragePoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storagePoolName, Azure.ResourceManager.PureStorageBlock.StoragePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.StoragePoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storagePoolName, Azure.ResourceManager.PureStorageBlock.StoragePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.StoragePoolResource> Get(string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorageBlock.StoragePoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorageBlock.StoragePoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.StoragePoolResource>> GetAsync(string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.StoragePoolResource> GetIfExists(string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.StoragePoolResource>> GetIfExistsAsync(string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PureStorageBlock.StoragePoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.StoragePoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PureStorageBlock.StoragePoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.StoragePoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StoragePoolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.StoragePoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.StoragePoolData>
    {
        public StoragePoolData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.PureStorageBlock.Models.StoragePoolProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.StoragePoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.StoragePoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.StoragePoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.StoragePoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.StoragePoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.StoragePoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.StoragePoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StoragePoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.StoragePoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.StoragePoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StoragePoolResource() { }
        public virtual Azure.ResourceManager.PureStorageBlock.StoragePoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.StoragePoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.StoragePoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storagePoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DisableAvsConnection(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DisableAvsConnectionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation EnableAvsConnection(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionPost properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> EnableAvsConnectionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionPost properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation FinalizeAvsConnection(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionPost properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FinalizeAvsConnectionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionPost properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.StoragePoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.StoragePoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.AvsConnection> GetAvsConnection(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.AvsConnection>> GetAvsConnectionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.AvsStatus> GetAvsStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.AvsStatus>> GetAvsStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerResource> GetAvsStorageContainer(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.AvsStorageContainerResource>> GetAvsStorageContainerAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.AvsStorageContainerCollection GetAvsStorageContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.AvsVmResource> GetAvsVm(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.AvsVmResource>> GetAvsVmAsync(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.AvsVmCollection GetAvsVms() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolHealthInfo> GetHealthStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolHealthInfo>> GetHealthStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.StoragePoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.StoragePoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RepairAvsConnection(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RepairAvsConnectionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.StoragePoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.StoragePoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PureStorageBlock.StoragePoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.StoragePoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.StoragePoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.StoragePoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.StoragePoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.StoragePoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.StoragePoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.StoragePoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.StoragePoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.StoragePoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.StoragePoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PureStorageBlock.Mocking
{
    public partial class MockablePureStorageBlockArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePureStorageBlockArmClient() { }
        public virtual Azure.ResourceManager.PureStorageBlock.AvsStorageContainerResource GetAvsStorageContainerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeResource GetAvsStorageContainerVolumeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.AvsVmResource GetAvsVmResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.AvsVmVolumeResource GetAvsVmVolumeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.ReservationResource GetReservationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.StoragePoolResource GetStoragePoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockablePureStorageBlockResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePureStorageBlockResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.ReservationResource> GetReservation(string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.ReservationResource>> GetReservationAsync(string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.ReservationCollection GetReservations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.StoragePoolResource> GetStoragePool(string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.StoragePoolResource>> GetStoragePoolAsync(string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.StoragePoolCollection GetStoragePools() { throw null; }
    }
    public partial class MockablePureStorageBlockSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePureStorageBlockSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorageBlock.ReservationResource> GetReservations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorageBlock.ReservationResource> GetReservationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorageBlock.StoragePoolResource> GetStoragePools(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorageBlock.StoragePoolResource> GetStoragePoolsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PureStorageBlock.Models
{
    public partial class Address : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.Address>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.Address>
    {
        public Address(string addressLine1, string city, string state, string country, string postalCode) { }
        public string AddressLine1 { get { throw null; } set { } }
        public string AddressLine2 { get { throw null; } set { } }
        public string City { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string PostalCode { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.Address System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.Address>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.Address>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.Address System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.Address>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.Address>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.Address>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Alert : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.Alert>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.Alert>
    {
        internal Alert() { }
        public Azure.ResourceManager.PureStorageBlock.Models.AlertLevel Level { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.Alert System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.Alert>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.Alert>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.Alert System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.Alert>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.Alert>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.Alert>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertLevel : System.IEquatable<Azure.ResourceManager.PureStorageBlock.Models.AlertLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertLevel(string value) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.AlertLevel Error { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.AlertLevel Info { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.AlertLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorageBlock.Models.AlertLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.AlertLevel left, Azure.ResourceManager.PureStorageBlock.Models.AlertLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.AlertLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorageBlock.Models.AlertLevel left, Azure.ResourceManager.PureStorageBlock.Models.AlertLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmPureStorageBlockModelFactory
    {
        public static Azure.ResourceManager.PureStorageBlock.Models.Alert Alert(Azure.ResourceManager.PureStorageBlock.Models.AlertLevel level = default(Azure.ResourceManager.PureStorageBlock.Models.AlertLevel), string message = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.AvsConnection AvsConnection(bool serviceInitializationCompleted = false, string serviceInitializationHandleEnc = null, Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationHandle serviceInitializationHandle = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.AvsDiskDetails AvsDiskDetails(string diskId = null, string diskName = null, string folder = null, string avsVmInternalId = null, string avsVmResourceId = null, string avsVmName = null, string avsStorageContainerResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.AvsStatus AvsStatus(bool avsEnabled = false, string currentConnectionStatus = null, string clusterResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.AvsStorageContainerData AvsStorageContainerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PureStorageBlock.Models.AvsStorageContainerProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.AvsStorageContainerProperties AvsStorageContainerProperties(Azure.ResourceManager.PureStorageBlock.Models.Space space = null, string resourceName = null, long? provisionedLimit = default(long?), string datastore = null, bool? mounted = default(bool?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.AvsStorageContainerVolumeData AvsStorageContainerVolumeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PureStorageBlock.Models.VolumeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.AvsVmData AvsVmData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PureStorageBlock.Models.AvsVmProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.AvsVmDetails AvsVmDetails(string vmId = null, string vmName = null, Azure.ResourceManager.PureStorageBlock.Models.VmType vmType = default(Azure.ResourceManager.PureStorageBlock.Models.VmType), string avsVmInternalId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.AvsVmProperties AvsVmProperties(string storagePoolInternalId = null, string storagePoolResourceId = null, string displayName = null, string createdTimestamp = null, Azure.ResourceManager.PureStorageBlock.Models.SoftDeletion softDeletion = null, Azure.ResourceManager.PureStorageBlock.Models.VolumeContainerType? volumeContainerType = default(Azure.ResourceManager.PureStorageBlock.Models.VolumeContainerType?), Azure.ResourceManager.PureStorageBlock.Models.AvsVmDetails avs = null, Azure.ResourceManager.PureStorageBlock.Models.Space space = null, Azure.ResourceManager.PureStorageBlock.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorageBlock.Models.ResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.AvsVmVolumeData AvsVmVolumeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PureStorageBlock.Models.VolumeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.AzureVmwareService AzureVmwareService(bool avsEnabled = false, string clusterResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.BandwidthUsage BandwidthUsage(long current = (long)0, long provisioned = (long)0, long max = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.BillingUsageProperty BillingUsageProperty(string propertyId = null, string propertyName = null, string currentValue = null, string previousValue = null, Azure.ResourceManager.PureStorageBlock.Models.UsageSeverity severity = default(Azure.ResourceManager.PureStorageBlock.Models.UsageSeverity), string statusMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.Models.BillingUsageProperty> subProperties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.HealthDetails HealthDetails(double usedCapacityPercentage = 0, Azure.ResourceManager.PureStorageBlock.Models.BandwidthUsage bandwidthUsage = null, Azure.ResourceManager.PureStorageBlock.Models.IopsUsage iopsUsage = null, Azure.ResourceManager.PureStorageBlock.Models.Space space = null, double dataReductionRatio = 0, long estimatedMaxCapacity = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.IopsUsage IopsUsage(long current = (long)0, long provisioned = (long)0, long max = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.LimitDetails LimitDetails(Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits storagePool = null, Azure.ResourceManager.PureStorageBlock.Models.RangeLimits volumeProvisionedSize = null, Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits protectionPolicy = null, Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits performancePolicy = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.MarketplaceDetails MarketplaceDetails(string subscriptionId = null, Azure.ResourceManager.PureStorageBlock.Models.MarketplaceSubscriptionStatus? subscriptionStatus = default(Azure.ResourceManager.PureStorageBlock.Models.MarketplaceSubscriptionStatus?), Azure.ResourceManager.PureStorageBlock.Models.OfferDetails offerDetails = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits PerformancePolicyLimits(Azure.ResourceManager.PureStorageBlock.Models.RangeLimits iopsLimit = null, Azure.ResourceManager.PureStorageBlock.Models.RangeLimits bandwidthLimit = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits ProtectionPolicyLimits(Azure.ResourceManager.PureStorageBlock.Models.RangeLimits frequency = null, Azure.ResourceManager.PureStorageBlock.Models.RangeLimits retention = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.RangeLimits RangeLimits(long min = (long)0, long max = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus ReservationBillingStatus(string timestamp = null, long totalUsedCapacityReported = (long)0, int lowDrrPoolCount = 0, double drrWeightedAverage = 0, long totalNonReducibleReported = (long)0, long extraUsedCapacityNonReducible = (long)0, long extraUsedCapacityLowUsageRounding = (long)0, long extraUsedCapacityNonReduciblePlanDiscount = (long)0, long totalUsedCapacityBilled = (long)0, long totalUsedCapacityIncludedPlan = (long)0, long totalUsedCapacityOverage = (long)0, long totalPerformanceReported = (long)0, long totalPerformanceIncludedPlan = (long)0, long totalPerformanceOverage = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport ReservationBillingUsageReport(string timestamp = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.Models.BillingUsageProperty> billingUsageProperties = null, string overallStatusMessage = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.ReservationData ReservationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PureStorageBlock.Models.ReservationPropertiesBaseResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.ReservationPropertiesBaseResourceProperties ReservationPropertiesBaseResourceProperties(string reservationInternalId = null, Azure.ResourceManager.PureStorageBlock.Models.MarketplaceDetails marketplace = null, Azure.ResourceManager.PureStorageBlock.Models.UserDetails user = null, Azure.ResourceManager.PureStorageBlock.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorageBlock.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationHandle ServiceInitializationHandle(string clusterResourceId = null, string serviceAccountUsername = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.SoftDeletion SoftDeletion(bool destroyed = false, string eradicationTimestamp = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.Space Space(long totalUsed = (long)0, long unique = (long)0, long snapshots = (long)0, long shared = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.StoragePoolData StoragePoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PureStorageBlock.Models.StoragePoolProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.StoragePoolHealthInfo StoragePoolHealthInfo(Azure.ResourceManager.PureStorageBlock.Models.HealthDetails health = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.Models.Alert> alerts = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits StoragePoolLimits(Azure.ResourceManager.PureStorageBlock.Models.RangeLimits provisionedBandwidthMbPerSec = null, Azure.ResourceManager.PureStorageBlock.Models.RangeLimits provisionedIops = null, System.Collections.Generic.IEnumerable<string> physicalAvailabilityZones = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.StoragePoolProperties StoragePoolProperties(string storagePoolInternalId = null, string availabilityZone = null, Azure.ResourceManager.PureStorageBlock.Models.VnetInjection vnetInjection = null, long? dataRetentionPeriod = default(long?), long provisionedBandwidthMbPerSec = (long)0, long? provisionedIops = default(long?), Azure.ResourceManager.PureStorageBlock.Models.AzureVmwareService avs = null, Azure.ResourceManager.PureStorageBlock.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorageBlock.Models.ProvisioningState?), string reservationResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.VolumeProperties VolumeProperties(string storagePoolInternalId = null, string storagePoolResourceId = null, string volumeInternalId = null, string displayName = null, Azure.ResourceManager.PureStorageBlock.Models.Space space = null, Azure.ResourceManager.PureStorageBlock.Models.SoftDeletion softDeletion = null, string createdTimestamp = null, long? provisionedSize = default(long?), Azure.ResourceManager.PureStorageBlock.Models.VolumeType? volumeType = default(Azure.ResourceManager.PureStorageBlock.Models.VolumeType?), Azure.ResourceManager.PureStorageBlock.Models.AvsDiskDetails avs = null, Azure.ResourceManager.PureStorageBlock.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorageBlock.Models.ResourceProvisioningState?)) { throw null; }
    }
    public partial class AvsConnection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsConnection>
    {
        internal AvsConnection() { }
        public bool ServiceInitializationCompleted { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationHandle ServiceInitializationHandle { get { throw null; } }
        public string ServiceInitializationHandleEnc { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.AvsConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.AvsConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsDiskDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsDiskDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsDiskDetails>
    {
        internal AvsDiskDetails() { }
        public string AvsStorageContainerResourceId { get { throw null; } }
        public string AvsVmInternalId { get { throw null; } }
        public string AvsVmName { get { throw null; } }
        public string AvsVmResourceId { get { throw null; } }
        public string DiskId { get { throw null; } }
        public string DiskName { get { throw null; } }
        public string Folder { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.AvsDiskDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsDiskDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsDiskDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.AvsDiskDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsDiskDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsDiskDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsDiskDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsStatus>
    {
        internal AvsStatus() { }
        public bool AvsEnabled { get { throw null; } }
        public string ClusterResourceId { get { throw null; } }
        public string CurrentConnectionStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.AvsStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.AvsStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsStorageContainerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsStorageContainerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsStorageContainerProperties>
    {
        internal AvsStorageContainerProperties() { }
        public string Datastore { get { throw null; } }
        public bool? Mounted { get { throw null; } }
        public long? ProvisionedLimit { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.Space Space { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.AvsStorageContainerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsStorageContainerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsStorageContainerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.AvsStorageContainerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsStorageContainerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsStorageContainerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsStorageContainerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsStorageContainerVolumePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsStorageContainerVolumePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsStorageContainerVolumePatch>
    {
        public AvsStorageContainerVolumePatch() { }
        public Azure.ResourceManager.PureStorageBlock.Models.SoftDeletion AvsStorageContainerVolumeUpdateSoftDeletion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.AvsStorageContainerVolumePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsStorageContainerVolumePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsStorageContainerVolumePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.AvsStorageContainerVolumePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsStorageContainerVolumePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsStorageContainerVolumePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsStorageContainerVolumePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsVmDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmDetails>
    {
        internal AvsVmDetails() { }
        public string AvsVmInternalId { get { throw null; } }
        public string VmId { get { throw null; } }
        public string VmName { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.VmType VmType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.AvsVmDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.AvsVmDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsVmPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmPatch>
    {
        public AvsVmPatch() { }
        public Azure.ResourceManager.PureStorageBlock.Models.SoftDeletion AvsVmUpdateSoftDeletion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.AvsVmPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.AvsVmPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsVmProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmProperties>
    {
        internal AvsVmProperties() { }
        public Azure.ResourceManager.PureStorageBlock.Models.AvsVmDetails Avs { get { throw null; } }
        public string CreatedTimestamp { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.SoftDeletion SoftDeletion { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.Space Space { get { throw null; } }
        public string StoragePoolInternalId { get { throw null; } }
        public string StoragePoolResourceId { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.VolumeContainerType? VolumeContainerType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.AvsVmProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.AvsVmProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsVmVolumePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmVolumePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmVolumePatch>
    {
        public AvsVmVolumePatch() { }
        public Azure.ResourceManager.PureStorageBlock.Models.SoftDeletion AvsVmVolumeUpdateSoftDeletion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.AvsVmVolumePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmVolumePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmVolumePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.AvsVmVolumePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmVolumePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmVolumePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AvsVmVolumePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureVmwareService : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AzureVmwareService>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AzureVmwareService>
    {
        internal AzureVmwareService() { }
        public bool AvsEnabled { get { throw null; } }
        public string ClusterResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.AzureVmwareService System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AzureVmwareService>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AzureVmwareService>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.AzureVmwareService System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AzureVmwareService>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AzureVmwareService>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AzureVmwareService>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BandwidthUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.BandwidthUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.BandwidthUsage>
    {
        internal BandwidthUsage() { }
        public long Current { get { throw null; } }
        public long Max { get { throw null; } }
        public long Provisioned { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.BandwidthUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.BandwidthUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.BandwidthUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.BandwidthUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.BandwidthUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.BandwidthUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.BandwidthUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingUsageProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.BillingUsageProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.BillingUsageProperty>
    {
        internal BillingUsageProperty() { }
        public string CurrentValue { get { throw null; } }
        public string PreviousValue { get { throw null; } }
        public string PropertyId { get { throw null; } }
        public string PropertyName { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.UsageSeverity Severity { get { throw null; } }
        public string StatusMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PureStorageBlock.Models.BillingUsageProperty> SubProperties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.BillingUsageProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.BillingUsageProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.BillingUsageProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.BillingUsageProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.BillingUsageProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.BillingUsageProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.BillingUsageProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CompanyDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.CompanyDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.CompanyDetails>
    {
        public CompanyDetails(string companyName) { }
        public Azure.ResourceManager.PureStorageBlock.Models.Address Address { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.CompanyDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.CompanyDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.CompanyDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.CompanyDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.CompanyDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.CompanyDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.CompanyDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.HealthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.HealthDetails>
    {
        internal HealthDetails() { }
        public Azure.ResourceManager.PureStorageBlock.Models.BandwidthUsage BandwidthUsage { get { throw null; } }
        public double DataReductionRatio { get { throw null; } }
        public long EstimatedMaxCapacity { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.IopsUsage IopsUsage { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.Space Space { get { throw null; } }
        public double UsedCapacityPercentage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.HealthDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.HealthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.HealthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.HealthDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.HealthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.HealthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.HealthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IopsUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.IopsUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.IopsUsage>
    {
        internal IopsUsage() { }
        public long Current { get { throw null; } }
        public long Max { get { throw null; } }
        public long Provisioned { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.IopsUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.IopsUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.IopsUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.IopsUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.IopsUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.IopsUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.IopsUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LimitDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.LimitDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.LimitDetails>
    {
        internal LimitDetails() { }
        public Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits PerformancePolicy { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits ProtectionPolicy { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits StoragePool { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.RangeLimits VolumeProvisionedSize { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.LimitDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.LimitDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.LimitDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.LimitDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.LimitDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.LimitDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.LimitDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.MarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.MarketplaceDetails>
    {
        public MarketplaceDetails(Azure.ResourceManager.PureStorageBlock.Models.OfferDetails offerDetails) { }
        public Azure.ResourceManager.PureStorageBlock.Models.OfferDetails OfferDetails { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.MarketplaceSubscriptionStatus? SubscriptionStatus { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.MarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.MarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.MarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.MarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.MarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.MarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.MarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.PureStorageBlock.Models.MarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.MarketplaceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.MarketplaceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.MarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.MarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorageBlock.Models.MarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.PureStorageBlock.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.MarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorageBlock.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.PureStorageBlock.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.OfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.OfferDetails>
    {
        public OfferDetails(string publisherId, string offerId, string planId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.OfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.OfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.OfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.OfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.OfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.OfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.OfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PerformancePolicyLimits : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits>
    {
        internal PerformancePolicyLimits() { }
        public Azure.ResourceManager.PureStorageBlock.Models.RangeLimits BandwidthLimit { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.RangeLimits IopsLimit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProtectionPolicyLimits : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits>
    {
        internal ProtectionPolicyLimits() { }
        public Azure.ResourceManager.PureStorageBlock.Models.RangeLimits Frequency { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.RangeLimits Retention { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.PureStorageBlock.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorageBlock.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.ProvisioningState left, Azure.ResourceManager.PureStorageBlock.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorageBlock.Models.ProvisioningState left, Azure.ResourceManager.PureStorageBlock.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RangeLimits : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.RangeLimits>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.RangeLimits>
    {
        internal RangeLimits() { }
        public long Max { get { throw null; } }
        public long Min { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.RangeLimits System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.RangeLimits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.RangeLimits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.RangeLimits System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.RangeLimits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.RangeLimits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.RangeLimits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReservationBillingStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus>
    {
        internal ReservationBillingStatus() { }
        public double DrrWeightedAverage { get { throw null; } }
        public long ExtraUsedCapacityLowUsageRounding { get { throw null; } }
        public long ExtraUsedCapacityNonReducible { get { throw null; } }
        public long ExtraUsedCapacityNonReduciblePlanDiscount { get { throw null; } }
        public int LowDrrPoolCount { get { throw null; } }
        public string Timestamp { get { throw null; } }
        public long TotalNonReducibleReported { get { throw null; } }
        public long TotalPerformanceIncludedPlan { get { throw null; } }
        public long TotalPerformanceOverage { get { throw null; } }
        public long TotalPerformanceReported { get { throw null; } }
        public long TotalUsedCapacityBilled { get { throw null; } }
        public long TotalUsedCapacityIncludedPlan { get { throw null; } }
        public long TotalUsedCapacityOverage { get { throw null; } }
        public long TotalUsedCapacityReported { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReservationBillingUsageReport : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport>
    {
        internal ReservationBillingUsageReport() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PureStorageBlock.Models.BillingUsageProperty> BillingUsageProperties { get { throw null; } }
        public string OverallStatusMessage { get { throw null; } }
        public string Timestamp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReservationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationPatch>
    {
        public ReservationPatch() { }
        public Azure.ResourceManager.PureStorageBlock.Models.UserDetails ReservationUpdateUser { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.ReservationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.ReservationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReservationPropertiesBaseResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationPropertiesBaseResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationPropertiesBaseResourceProperties>
    {
        public ReservationPropertiesBaseResourceProperties(Azure.ResourceManager.PureStorageBlock.Models.MarketplaceDetails marketplace, Azure.ResourceManager.PureStorageBlock.Models.UserDetails user) { }
        public Azure.ResourceManager.PureStorageBlock.Models.MarketplaceDetails Marketplace { get { throw null; } set { } }
        public Azure.ResourceManager.PureStorageBlock.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ReservationInternalId { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.UserDetails User { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.ReservationPropertiesBaseResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationPropertiesBaseResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationPropertiesBaseResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.ReservationPropertiesBaseResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationPropertiesBaseResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationPropertiesBaseResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationPropertiesBaseResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.PureStorageBlock.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorageBlock.Models.ResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.ResourceProvisioningState left, Azure.ResourceManager.PureStorageBlock.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.ResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorageBlock.Models.ResourceProvisioningState left, Azure.ResourceManager.PureStorageBlock.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceInitializationHandle : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationHandle>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationHandle>
    {
        internal ServiceInitializationHandle() { }
        public string ClusterResourceId { get { throw null; } }
        public string ServiceAccountUsername { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationHandle System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationHandle>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationHandle>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationHandle System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationHandle>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationHandle>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationHandle>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceInitializationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationInfo>
    {
        public ServiceInitializationInfo() { }
        public string ServiceAccountPassword { get { throw null; } set { } }
        public string ServiceAccountUsername { get { throw null; } set { } }
        public string VSphereCertificate { get { throw null; } set { } }
        public string VSphereIP { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SoftDeletion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.SoftDeletion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.SoftDeletion>
    {
        public SoftDeletion(bool destroyed) { }
        public bool Destroyed { get { throw null; } set { } }
        public string EradicationTimestamp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.SoftDeletion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.SoftDeletion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.SoftDeletion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.SoftDeletion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.SoftDeletion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.SoftDeletion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.SoftDeletion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Space : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.Space>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.Space>
    {
        internal Space() { }
        public long Shared { get { throw null; } }
        public long Snapshots { get { throw null; } }
        public long TotalUsed { get { throw null; } }
        public long Unique { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.Space System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.Space>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.Space>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.Space System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.Space>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.Space>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.Space>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StoragePoolEnableAvsConnectionPost : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionPost>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionPost>
    {
        public StoragePoolEnableAvsConnectionPost(string clusterResourceId) { }
        public string ClusterResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionPost System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionPost>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionPost>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionPost System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionPost>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionPost>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionPost>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StoragePoolFinalizeAvsConnectionPost : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionPost>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionPost>
    {
        public StoragePoolFinalizeAvsConnectionPost() { }
        public Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationInfo ServiceInitializationData { get { throw null; } set { } }
        public string ServiceInitializationDataEnc { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionPost System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionPost>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionPost>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionPost System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionPost>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionPost>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionPost>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StoragePoolHealthInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolHealthInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolHealthInfo>
    {
        internal StoragePoolHealthInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PureStorageBlock.Models.Alert> Alerts { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.HealthDetails Health { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.StoragePoolHealthInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolHealthInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolHealthInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.StoragePoolHealthInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolHealthInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolHealthInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolHealthInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StoragePoolLimits : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits>
    {
        internal StoragePoolLimits() { }
        public System.Collections.Generic.IReadOnlyList<string> PhysicalAvailabilityZones { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.RangeLimits ProvisionedBandwidthMbPerSec { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.RangeLimits ProvisionedIops { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StoragePoolPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolPatch>
    {
        public StoragePoolPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public long? StoragePoolUpdateProvisionedBandwidthMbPerSec { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.StoragePoolPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.StoragePoolPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StoragePoolProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolProperties>
    {
        public StoragePoolProperties(string availabilityZone, Azure.ResourceManager.PureStorageBlock.Models.VnetInjection vnetInjection, long provisionedBandwidthMbPerSec, string reservationResourceId) { }
        public string AvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.PureStorageBlock.Models.AzureVmwareService Avs { get { throw null; } }
        public long? DataRetentionPeriod { get { throw null; } }
        public long ProvisionedBandwidthMbPerSec { get { throw null; } set { } }
        public long? ProvisionedIops { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ReservationResourceId { get { throw null; } set { } }
        public string StoragePoolInternalId { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.VnetInjection VnetInjection { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.StoragePoolProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.StoragePoolProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsageSeverity : System.IEquatable<Azure.ResourceManager.PureStorageBlock.Models.UsageSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsageSeverity(string value) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.UsageSeverity ALERT { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.UsageSeverity INFORMATION { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.UsageSeverity NONE { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.UsageSeverity WARNING { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorageBlock.Models.UsageSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.UsageSeverity left, Azure.ResourceManager.PureStorageBlock.Models.UsageSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.UsageSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorageBlock.Models.UsageSeverity left, Azure.ResourceManager.PureStorageBlock.Models.UsageSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.UserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.UserDetails>
    {
        public UserDetails(string firstName, string lastName, string emailAddress) { }
        public Azure.ResourceManager.PureStorageBlock.Models.CompanyDetails CompanyDetails { get { throw null; } set { } }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.UserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.UserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.UserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.UserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.UserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.UserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.UserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmType : System.IEquatable<Azure.ResourceManager.PureStorageBlock.Models.VmType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmType(string value) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.VmType VVol { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorageBlock.Models.VmType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.VmType left, Azure.ResourceManager.PureStorageBlock.Models.VmType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.VmType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorageBlock.Models.VmType left, Azure.ResourceManager.PureStorageBlock.Models.VmType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VnetInjection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VnetInjection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VnetInjection>
    {
        public VnetInjection(string subnetId, string vnetId) { }
        public string SubnetId { get { throw null; } set { } }
        public string VnetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.VnetInjection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VnetInjection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VnetInjection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.VnetInjection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VnetInjection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VnetInjection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VnetInjection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VolumeContainerType : System.IEquatable<Azure.ResourceManager.PureStorageBlock.Models.VolumeContainerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VolumeContainerType(string value) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.VolumeContainerType AVS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorageBlock.Models.VolumeContainerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.VolumeContainerType left, Azure.ResourceManager.PureStorageBlock.Models.VolumeContainerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.VolumeContainerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorageBlock.Models.VolumeContainerType left, Azure.ResourceManager.PureStorageBlock.Models.VolumeContainerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VolumeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeProperties>
    {
        internal VolumeProperties() { }
        public Azure.ResourceManager.PureStorageBlock.Models.AvsDiskDetails Avs { get { throw null; } }
        public string CreatedTimestamp { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public long? ProvisionedSize { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.SoftDeletion SoftDeletion { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.Space Space { get { throw null; } }
        public string StoragePoolInternalId { get { throw null; } }
        public string StoragePoolResourceId { get { throw null; } }
        public string VolumeInternalId { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.VolumeType? VolumeType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.VolumeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.VolumeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VolumeType : System.IEquatable<Azure.ResourceManager.PureStorageBlock.Models.VolumeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VolumeType(string value) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.VolumeType AVS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorageBlock.Models.VolumeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.VolumeType left, Azure.ResourceManager.PureStorageBlock.Models.VolumeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.VolumeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorageBlock.Models.VolumeType left, Azure.ResourceManager.PureStorageBlock.Models.VolumeType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
