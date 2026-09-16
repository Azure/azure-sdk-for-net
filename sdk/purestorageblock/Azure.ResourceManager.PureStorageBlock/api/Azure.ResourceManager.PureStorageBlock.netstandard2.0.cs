namespace Azure.ResourceManager.PureStorageBlock
{
    public partial class AzureResourceManagerPureStorageBlockContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerPureStorageBlockContext() { }
        public static Azure.ResourceManager.PureStorageBlock.AzureResourceManagerPureStorageBlockContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class PureStorageAvsStorageContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerResource>, System.Collections.IEnumerable
    {
        protected PureStorageAvsStorageContainerCollection() { }
        public virtual Azure.Response<bool> Exists(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerResource> Get(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerResource>> GetAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerResource> GetIfExists(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerResource>> GetIfExistsAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PureStorageAvsStorageContainerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerData>
    {
        internal PureStorageAvsStorageContainerData() { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsStorageContainerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PureStorageAvsStorageContainerResource() { }
        public virtual Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storagePoolName, string storageContainerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeResource> GetPureStorageAvsStorageContainerVolume(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeResource>> GetPureStorageAvsStorageContainerVolumeAsync(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeCollection GetPureStorageAvsStorageContainerVolumes() { throw null; }
        Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsStorageContainerVolumeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeResource>, System.Collections.IEnumerable
    {
        protected PureStorageAvsStorageContainerVolumeCollection() { }
        public virtual Azure.Response<bool> Exists(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeResource> Get(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeResource>> GetAsync(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeResource> GetIfExists(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeResource>> GetIfExistsAsync(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PureStorageAvsStorageContainerVolumeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeData>
    {
        internal PureStorageAvsStorageContainerVolumeData() { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsStorageContainerVolumeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PureStorageAvsStorageContainerVolumeResource() { }
        public virtual Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storagePoolName, string storageContainerName, string volumeId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerVolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerVolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PureStorageAvsVmCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmResource>, System.Collections.IEnumerable
    {
        protected PureStorageAvsVmCollection() { }
        public virtual Azure.Response<bool> Exists(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmResource> Get(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmResource>> GetAsync(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmResource> GetIfExists(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmResource>> GetIfExistsAsync(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PureStorageAvsVmData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmData>
    {
        internal PureStorageAvsVmData() { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsVmResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PureStorageAvsVmResource() { }
        public virtual Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storagePoolName, string avsVmId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeResource> GetPureStorageAvsVmVolume(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeResource>> GetPureStorageAvsVmVolumeAsync(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeCollection GetPureStorageAvsVmVolumes() { throw null; }
        Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PureStorageAvsVmVolumeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeResource>, System.Collections.IEnumerable
    {
        protected PureStorageAvsVmVolumeCollection() { }
        public virtual Azure.Response<bool> Exists(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeResource> Get(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeResource>> GetAsync(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeResource> GetIfExists(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeResource>> GetIfExistsAsync(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PureStorageAvsVmVolumeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeData>
    {
        internal PureStorageAvsVmVolumeData() { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsVmVolumeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PureStorageAvsVmVolumeResource() { }
        public virtual Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storagePoolName, string avsVmId, string volumeId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class PureStorageBlockExtensions
    {
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockSaaSResourceDetailsResponseResult> ActivateResource(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockActivateSaaSRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockSaaSResourceDetailsResponseResult>> ActivateResourceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockActivateSaaSRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerResource GetPureStorageAvsStorageContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeResource GetPureStorageAvsStorageContainerVolumeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmResource GetPureStorageAvsVmResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeResource GetPureStorageAvsVmVolumeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource> GetPureStoragePool(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource>> GetPureStoragePoolAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource GetPureStoragePoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStoragePoolCollection GetPureStoragePools(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource> GetPureStoragePools(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource> GetPureStoragePoolsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource> GetPureStorageReservation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource>> GetPureStorageReservationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource GetPureStorageReservationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStorageReservationCollection GetPureStorageReservations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource> GetPureStorageReservations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource> GetPureStorageReservationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupResource GetRecoverableVolumeGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.VolumeGroupResource GetVolumeGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotResource GetVolumeGroupSnapshotResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.VolumeResource GetVolumeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class PureStoragePoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource>, System.Collections.IEnumerable
    {
        protected PureStoragePoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storagePoolName, Azure.ResourceManager.PureStorageBlock.PureStoragePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storagePoolName, Azure.ResourceManager.PureStorageBlock.PureStoragePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource> Get(string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource>> GetAsync(string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource> GetIfExists(string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource>> GetIfExistsAsync(string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PureStoragePoolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStoragePoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStoragePoolData>
    {
        public PureStoragePoolData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.PureStoragePoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStoragePoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStoragePoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.PureStoragePoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStoragePoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStoragePoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStoragePoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStoragePoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStoragePoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStoragePoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PureStoragePoolResource() { }
        public virtual Azure.ResourceManager.PureStorageBlock.PureStoragePoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthResult> ConfigurePlatformConsoleAuth(Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthConfig config, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthResult>> ConfigurePlatformConsoleAuthAsync(Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthConfig config, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storagePoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DisableAvsConnection(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DisableAvsConnectionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation EnableAvsConnection(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> EnableAvsConnectionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation FinalizeAvsConnection(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FinalizeAvsConnectionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsConnection> GetAvsConnection(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsConnection>> GetAvsConnectionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStatus> GetAvsStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStatus>> GetAvsStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolHealthInfo> GetHealthStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolHealthInfo>> GetHealthStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleActivationCode> GetPlatformConsoleActivationCode(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleActivationCode>> GetPlatformConsoleActivationCodeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerResource> GetPureStorageAvsStorageContainer(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerResource>> GetPureStorageAvsStorageContainerAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerCollection GetPureStorageAvsStorageContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmResource> GetPureStorageAvsVm(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmResource>> GetPureStorageAvsVmAsync(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmCollection GetPureStorageAvsVms() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupResource> GetRecoverableVolumeGroup(string recoverableVolumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupResource>> GetRecoverableVolumeGroupAsync(string recoverableVolumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupCollection GetRecoverableVolumeGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource> GetVolumeGroup(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource>> GetVolumeGroupAsync(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.VolumeGroupCollection GetVolumeGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RepairAvsConnection(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RepairAvsConnectionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PureStorageBlock.PureStoragePoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStoragePoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStoragePoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.PureStoragePoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStoragePoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStoragePoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStoragePoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PureStorageReservationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource>, System.Collections.IEnumerable
    {
        protected PureStorageReservationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string reservationName, Azure.ResourceManager.PureStorageBlock.PureStorageReservationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string reservationName, Azure.ResourceManager.PureStorageBlock.PureStorageReservationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource> Get(string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource>> GetAsync(string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource> GetIfExists(string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource>> GetIfExistsAsync(string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PureStorageReservationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageReservationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageReservationData>
    {
        public PureStorageReservationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.PureStorageReservationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageReservationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageReservationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.PureStorageReservationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageReservationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageReservationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageReservationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageReservationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageReservationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageReservationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PureStorageReservationResource() { }
        public virtual Azure.ResourceManager.PureStorageBlock.PureStorageReservationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string reservationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport> GetBillingReport(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport>> GetBillingReportAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus> GetBillingStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus>> GetBillingStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceLimitDetails> GetResourceLimits(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceLimitDetails>> GetResourceLimitsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLatestLinkedSaaSResponseResult> LatestLinkedSaaS(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLatestLinkedSaaSResponseResult>> LatestLinkedSaaSAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource> LinkSaaS(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLinkSaaSRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource>> LinkSaaSAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLinkSaaSRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PureStorageBlock.PureStorageReservationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageReservationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.PureStorageReservationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.PureStorageReservationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageReservationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageReservationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.PureStorageReservationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecoverableVolumeGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupResource>, System.Collections.IEnumerable
    {
        protected RecoverableVolumeGroupCollection() { }
        public virtual Azure.Response<bool> Exists(string recoverableVolumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recoverableVolumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupResource> Get(string recoverableVolumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupResource>> GetAsync(string recoverableVolumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupResource> GetIfExists(string recoverableVolumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupResource>> GetIfExistsAsync(string recoverableVolumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecoverableVolumeGroupData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupData>
    {
        internal RecoverableVolumeGroupData() { }
        public Azure.ResourceManager.PureStorageBlock.Models.RecoverableVolumeGroupProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoverableVolumeGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecoverableVolumeGroupResource() { }
        public virtual Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storagePoolName, string recoverableVolumeGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.VolumeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.VolumeResource>, System.Collections.IEnumerable
    {
        protected VolumeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.VolumeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string volumeName, Azure.ResourceManager.PureStorageBlock.VolumeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.VolumeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string volumeName, Azure.ResourceManager.PureStorageBlock.VolumeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.VolumeResource> Get(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorageBlock.VolumeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorageBlock.VolumeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.VolumeResource>> GetAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.VolumeResource> GetIfExists(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.VolumeResource>> GetIfExistsAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PureStorageBlock.VolumeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.VolumeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PureStorageBlock.VolumeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.VolumeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VolumeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.VolumeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.VolumeData>
    {
        public VolumeData() { }
        public Azure.ResourceManager.PureStorageBlock.Models.AzureVolumeProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.VolumeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.VolumeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.VolumeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.VolumeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.VolumeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.VolumeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.VolumeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumeGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource>, System.Collections.IEnumerable
    {
        protected VolumeGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string volumeGroupName, Azure.ResourceManager.PureStorageBlock.VolumeGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string volumeGroupName, Azure.ResourceManager.PureStorageBlock.VolumeGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource> Get(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource>> GetAsync(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource> GetIfExists(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource>> GetIfExistsAsync(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VolumeGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupData>
    {
        public VolumeGroupData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.VolumeGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.VolumeGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumeGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VolumeGroupResource() { }
        public virtual Azure.ResourceManager.PureStorageBlock.VolumeGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storagePoolName, string volumeGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockConnectionParametersResponseResult> GetConnectionParameters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockConnectionParametersResponseResult>> GetConnectionParametersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotPostListResult> GetSnapshots(Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupSnapshotListRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotPostListResult>> GetSnapshotsAsync(Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupSnapshotListRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupStatus> GetStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupStatus>> GetStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.VolumeResource> GetVolume(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.VolumeResource>> GetVolumeAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotResource> GetVolumeGroupSnapshot(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotResource>> GetVolumeGroupSnapshotAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotCollection GetVolumeGroupSnapshots() { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.VolumeCollection GetVolumes() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Overwrite(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupOverwriteRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> OverwriteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupOverwriteRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PureStorageBlock.VolumeGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.VolumeGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.VolumeGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VolumeGroupSnapshotCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotResource>, System.Collections.IEnumerable
    {
        protected VolumeGroupSnapshotCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string snapshotName, Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string snapshotName, Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotResource> Get(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotResource> GetAll(string filter = null, string orderby = null, int? maxCount = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotResource> GetAllAsync(string filter = null, string orderby = null, int? maxCount = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotResource>> GetAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotResource> GetIfExists(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotResource>> GetIfExistsAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VolumeGroupSnapshotData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData>
    {
        public VolumeGroupSnapshotData() { }
        public Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumeGroupSnapshotResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VolumeGroupSnapshotResource() { }
        public virtual Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storagePoolName, string volumeGroupName, string snapshotName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VolumeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.VolumeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.VolumeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VolumeResource() { }
        public virtual Azure.ResourceManager.PureStorageBlock.VolumeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storagePoolName, string volumeGroupName, string volumeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.VolumeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.VolumeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Overwrite(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeOverwriteRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> OverwriteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeOverwriteRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PureStorageBlock.VolumeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.VolumeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.VolumeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.VolumeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.VolumeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.VolumeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.VolumeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.VolumeResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.VolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.VolumeResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.VolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PureStorageBlock.Mocking
{
    public partial class MockablePureStorageBlockArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePureStorageBlockArmClient() { }
        public virtual Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerResource GetPureStorageAvsStorageContainerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeResource GetPureStorageAvsStorageContainerVolumeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmResource GetPureStorageAvsVmResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeResource GetPureStorageAvsVmVolumeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource GetPureStoragePoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource GetPureStorageReservationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupResource GetRecoverableVolumeGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.VolumeGroupResource GetVolumeGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotResource GetVolumeGroupSnapshotResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.VolumeResource GetVolumeResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockablePureStorageBlockResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePureStorageBlockResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource> GetPureStoragePool(string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource>> GetPureStoragePoolAsync(string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.PureStoragePoolCollection GetPureStoragePools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource> GetPureStorageReservation(string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource>> GetPureStorageReservationAsync(string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.PureStorageReservationCollection GetPureStorageReservations() { throw null; }
    }
    public partial class MockablePureStorageBlockSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePureStorageBlockSubscriptionResource() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockSaaSResourceDetailsResponseResult> ActivateResource(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockActivateSaaSRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockSaaSResourceDetailsResponseResult>> ActivateResourceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockActivateSaaSRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource> GetPureStoragePools(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorageBlock.PureStoragePoolResource> GetPureStoragePoolsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource> GetPureStorageReservations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorageBlock.PureStorageReservationResource> GetPureStorageReservationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PureStorageBlock.Models
{
    public static partial class ArmPureStorageBlockModelFactory
    {
        public static Azure.ResourceManager.PureStorageBlock.Models.AzureVolumeProperties AzureVolumeProperties(Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage space = null, long? provisionedSize = default(long?), string serialNumber = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier sourceVolumeResourceId = null, Azure.Core.ResourceIdentifier sourceVolumeGroupResourceId = null, Azure.ResourceManager.PureStorageBlock.Models.VolumeSourceType? sourceType = default(Azure.ResourceManager.PureStorageBlock.Models.VolumeSourceType?), Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotSource sourceVolumeSnapshot = null, string sourceSerialNumber = null, Azure.Core.ResourceIdentifier sourceRecoverableVolumeResourceId = null, Azure.ResourceManager.PureStorageBlock.Models.DestroyedStateProperties softDeletion = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.DestroyedStateProperties DestroyedStateProperties(bool destroyed = false, System.DateTimeOffset? destroyedOn = default(System.DateTimeOffset?), string previousName = null, System.DateTimeOffset? eradicationTimestamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.IscsiEndpoint IscsiEndpoint(string ip = null, int port = 0, string iqn = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits PerformancePolicyLimits(Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits iopsLimit = null, Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits bandwidthLimit = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleActivationCode PlatformConsoleActivationCode(string username = null, string activationCode = null, System.DateTimeOffset expiresOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthConfig PlatformConsoleAuthConfig(string authType = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthResult PlatformConsoleAuthResult(string authType = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSettings PlatformConsoleSettings(bool? enabled = default(bool?), bool? guiEnabled = default(bool?), bool? apiEnabled = default(bool?), bool? cliEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSubnet> subnets = null, string defaultUsername = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSubnet PlatformConsoleSubnet(Azure.Core.ResourceIdentifier id = null, string managementIPAddress = null, System.Collections.Generic.IEnumerable<string> serviceBackendIps = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits PropertyValueRangeLimits(long min = (long)0, long max = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits ProtectionPolicyLimits(Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits frequency = null, Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits retention = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAddressDetails PureStorageAddressDetails(string addressLine1 = null, string addressLine2 = null, string city = null, string state = null, string country = null, string postalCode = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvs PureStorageAvs(bool isAvsEnabled = false, Azure.Core.ResourceIdentifier clusterResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsConnection PureStorageAvsConnection(bool isServiceInitializationCompleted = false, string serviceInitializationHandleEnc = null, Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationHandle serviceInitializationHandle = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsDiskDetails PureStorageAvsDiskDetails(string diskId = null, string diskName = null, string folder = null, string avsVmInternalId = null, Azure.Core.ResourceIdentifier avsVmResourceId = null, string avsVmName = null, Azure.Core.ResourceIdentifier avsStorageContainerResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStatus PureStorageAvsStatus(bool isAvsEnabled = false, string currentConnectionStatus = null, Azure.Core.ResourceIdentifier clusterResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerData PureStorageAvsStorageContainerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerProperties PureStorageAvsStorageContainerProperties(Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage space = null, string resourceName = null, long? provisionedLimit = default(long?), string datastore = null, bool? mounted = default(bool?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeData PureStorageAvsStorageContainerVolumeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerVolumePatch PureStorageAvsStorageContainerVolumePatch(Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState avsStorageContainerVolumeUpdateSoftDeletion = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmData PureStorageAvsVmData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmDetails PureStorageAvsVmDetails(string vmId = null, string vmName = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmType vmType = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmType), string avsVmInternalId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmPatch PureStorageAvsVmPatch(Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState avsVmUpdateSoftDeletion = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties PureStorageAvsVmProperties(string storagePoolInternalId = null, Azure.Core.ResourceIdentifier storagePoolResourceId = null, string displayName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState softDeletion = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeContainerType? volumeContainerType = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeContainerType?), Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmDetails avs = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage space = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeData PureStorageAvsVmVolumeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch PureStorageAvsVmVolumePatch(Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState avsVmVolumeUpdateSoftDeletion = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageBandwidthUsage PureStorageBandwidthUsage(long current = (long)0, long provisioned = (long)0, long max = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageProperty PureStorageBillingUsageProperty(string propertyId = null, string propertyName = null, string currentValue = null, string previousValue = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageSeverity severity = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageSeverity), string statusMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageProperty> subProperties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockActivateSaaSRequestContent PureStorageBlockActivateSaaSRequestContent(string saasGuid = null, string publisherId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockConnectionParametersResponseResult PureStorageBlockConnectionParametersResponseResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.Models.IscsiEndpoint> iscsiEndpoints = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLatestLinkedSaaSResponseResult PureStorageBlockLatestLinkedSaaSResponseResult(string saaSResourceId = null, bool? isHiddenSaaS = default(bool?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLinkSaaSRequestContent PureStorageBlockLinkSaaSRequestContent(string saaSResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockPerformanceParametersContent PureStorageBlockPerformanceParametersContent(long? bandwidthLimitMbPerSec = default(long?), long? iopsLimit = default(long?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockProtectionParametersContent PureStorageBlockProtectionParametersContent(System.TimeSpan? retention = default(System.TimeSpan?), System.TimeSpan? frequency = default(System.TimeSpan?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockSaaSResourceDetailsResponseResult PureStorageBlockSaaSResourceDetailsResponseResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string saasId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupOverwriteRequestContent PureStorageBlockVolumeGroupOverwriteRequestContent(Azure.Core.ResourceIdentifier sourceSnapshotResourceId = null, Azure.Core.ResourceIdentifier sourceVolumeGroupResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupSnapshotListRequestContent PureStorageBlockVolumeGroupSnapshotListRequestContent(string filter = null, string orderby = null, int? top = default(int?), int? skip = default(int?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeOverwriteRequestContent PureStorageBlockVolumeOverwriteRequestContent(Azure.ResourceManager.PureStorageBlock.Models.VolumeSourceType sourceType = default(Azure.ResourceManager.PureStorageBlock.Models.VolumeSourceType), Azure.Core.ResourceIdentifier sourceVolumeGroupResourceId = null, Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotSource sourceVolumeSnapshot = null, string sourceSerialNumber = null, Azure.Core.ResourceIdentifier sourceVolumeResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageCompanyDetails PureStorageCompanyDetails(string companyName = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAddressDetails address = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlert PureStorageHealthAlert(Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlertLevel level = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlertLevel), string message = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthDetails PureStorageHealthDetails(double usedCapacityPercentage = 0, Azure.ResourceManager.PureStorageBlock.Models.PureStorageBandwidthUsage bandwidthUsage = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageIopsUsage iopsUsage = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage space = null, double dataReductionRatio = 0, long estimatedMaxCapacity = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageIopsUsage PureStorageIopsUsage(long current = (long)0, long provisioned = (long)0, long max = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceDetails PureStorageMarketplaceDetails(string subscriptionId = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceSubscriptionStatus? subscriptionStatus = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceSubscriptionStatus?), Azure.ResourceManager.PureStorageBlock.Models.PureStorageOfferDetails offerDetails = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceDetails PureStorageMarketplaceDetails(string subscriptionId = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceSubscriptionStatus? subscriptionStatus = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceSubscriptionStatus?), Azure.ResourceManager.PureStorageBlock.Models.PureStorageOfferDetails offerDetails = null, string saaSResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageOfferDetails PureStorageOfferDetails(string publisherId = null, string offerId = null, string planId = null, string planName = null, string termUnit = null, string termId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStoragePoolData PureStoragePoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolPatch PureStoragePoolPatch(Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.PureStorageBlock.Models.StoragePoolUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolPatch PureStoragePoolPatch(Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IDictionary<string, string> tags = null, long? storagePoolUpdateProvisionedBandwidthMbPerSec = default(long?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties PureStoragePoolProperties(string storagePoolInternalId = null, string availabilityZone = null, Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolVnetInjection vnetInjection = null, long? dataRetentionPeriod = default(long?), long provisionedBandwidthMbPerSec = (long)0, long? provisionedIops = default(long?), Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvs avs = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState?), Azure.Core.ResourceIdentifier reservationResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties PureStoragePoolProperties(string storagePoolInternalId = null, string availabilityZone = null, Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolVnetInjection vnetInjection = null, long? dataRetentionPeriod = default(long?), long provisionedBandwidthMbPerSec = (long)0, long? provisionedIops = default(long?), Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvs avs = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState?), Azure.Core.ResourceIdentifier reservationResourceId = null, Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSettings platformConsoleSettings = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolVnetInjection PureStoragePoolVnetInjection(Azure.Core.ResourceIdentifier subnetId = null, Azure.Core.ResourceIdentifier vnetId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStorageReservationData PureStorageReservationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch PureStorageReservationPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageUserDetails reservationUpdateUser = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties PureStorageReservationProperties(string reservationInternalId = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceDetails marketplace = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageUserDetails user = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceLimitDetails PureStorageResourceLimitDetails(Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits storagePool = null, Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits volumeProvisionedSize = null, Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits protectionPolicy = null, Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits performancePolicy = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState PureStorageSoftDeletionState(bool isDestroyed = false, System.DateTimeOffset? eradicatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage PureStorageSpaceUsage(long totalUsed = (long)0, long unique = (long)0, long snapshots = (long)0, long shared = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageUserDetails PureStorageUserDetails(string firstName = null, string lastName = null, string emailAddress = null, string upn = null, string phoneNumber = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageCompanyDetails companyDetails = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties PureStorageVolumeProperties(string storagePoolInternalId = null, Azure.Core.ResourceIdentifier storagePoolResourceId = null, string volumeInternalId = null, string displayName = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage space = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState softDeletion = null, string createdTimestamp = null, long? provisionedSize = default(long?), Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeType? volumeType = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeType?), Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsDiskDetails avs = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.RecoverableVolumeGroupData RecoverableVolumeGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PureStorageBlock.Models.RecoverableVolumeGroupProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.RecoverableVolumeGroupProperties RecoverableVolumeGroupProperties(System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.PureStorageBlock.Models.DestroyedStateProperties softDeletion = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockPerformanceParametersContent performanceParameters = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockProtectionParametersContent protectionParameters = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage space = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus ReservationBillingStatus(string timestamp = null, long totalUsedCapacityReported = (long)0, int lowDrrPoolCount = 0, double drrWeightedAverage = 0, long totalNonReducibleReported = (long)0, long extraUsedCapacityNonReducible = (long)0, long extraUsedCapacityLowUsageRounding = (long)0, long extraUsedCapacityNonReduciblePlanDiscount = (long)0, long totalUsedCapacityBilled = (long)0, long totalUsedCapacityIncludedPlan = (long)0, long totalUsedCapacityOverage = (long)0, long totalPerformanceReported = (long)0, long totalPerformanceIncludedPlan = (long)0, long totalPerformanceOverage = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport ReservationBillingUsageReport(string timestamp = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageProperty> billingUsageProperties = null, string overallStatusMessage = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationHandle ServiceInitializationHandle(Azure.Core.ResourceIdentifier clusterResourceId = null, string serviceAccountUsername = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationInfo ServiceInitializationInfo(string serviceAccountUsername = null, string serviceAccountPassword = null, string vSphereIP = null, string vSphereCertificate = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.SshPlatformConsoleAuthConfig SshPlatformConsoleAuthConfig(string username = null, string publicKey = null, Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleRole role = default(Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleRole)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.SshPlatformConsoleAuthResult SshPlatformConsoleAuthResult(string username = null, Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleRole role = default(Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleRole)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionContent StoragePoolEnableAvsConnectionContent(Azure.Core.ResourceIdentifier clusterResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionContent StoragePoolFinalizeAvsConnectionContent(string serviceInitializationDataEnc = null, Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationInfo serviceInitializationData = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.StoragePoolHealthInfo StoragePoolHealthInfo(Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthDetails health = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlert> alerts = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits StoragePoolLimits(Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits provisionedBandwidthMbPerSec = null, Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits provisionedIops = null, System.Collections.Generic.IEnumerable<string> physicalAvailabilityZones = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.StoragePoolUpdateProperties StoragePoolUpdateProperties(long? provisionedBandwidthMbPerSec = default(long?), Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSettings platformConsoleSettings = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.VolumeData VolumeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PureStorageBlock.Models.AzureVolumeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.VolumeGroupData VolumeGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupPatch VolumeGroupPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupProperties VolumeGroupProperties(string storagePoolInternalId = null, string volumeGroupInternalId = null, Azure.Core.ResourceIdentifier sourceVolumeGroupResourceId = null, Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSourceType? sourceType = default(Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSourceType?), Azure.Core.ResourceIdentifier sourceSnapshotResourceId = null, Azure.Core.ResourceIdentifier sourceRecoverableVolumeGroupResourceId = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockPerformanceParametersContent performanceParameters = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockProtectionParametersContent protectionParameters = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData VolumeGroupSnapshotData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotPostListResult VolumeGroupSnapshotPostListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData> value = null, int? count = default(int?), int? totalCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotProperties VolumeGroupSnapshotProperties(Azure.Core.ResourceIdentifier sourceSnapshotResourceId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), bool? createdByPolicy = default(bool?), Azure.ResourceManager.PureStorageBlock.Models.DestroyedStateProperties softDeletion = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage space = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotInfo> volumeSnapshots = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupStatus VolumeGroupStatus(Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage space = null, int connectedHostCount = 0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupUpdateProperties VolumeGroupUpdateProperties(Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockPerformanceParametersContent performanceParameters = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockProtectionParametersContent protectionParameters = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.VolumePatch VolumePatch(long? volumeUpdateProvisionedSize = default(long?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotInfo VolumeSnapshotInfo(string name = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage space = null, long? provisionedSize = default(long?), string serialNumber = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotSource VolumeSnapshotSource(Azure.Core.ResourceIdentifier volumeGroupSnapshotResourceId = null, string volumeSnapshotName = null) { throw null; }
    }
    public partial class AzureVolumeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AzureVolumeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AzureVolumeProperties>
    {
        public AzureVolumeProperties() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public long? ProvisionedSize { get { throw null; } set { } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState? ProvisioningState { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.DestroyedStateProperties SoftDeletion { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceRecoverableVolumeResourceId { get { throw null; } set { } }
        public string SourceSerialNumber { get { throw null; } set { } }
        public Azure.ResourceManager.PureStorageBlock.Models.VolumeSourceType? SourceType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVolumeGroupResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVolumeResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotSource SourceVolumeSnapshot { get { throw null; } set { } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage Space { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.AzureVolumeProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.AzureVolumeProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.AzureVolumeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AzureVolumeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.AzureVolumeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.AzureVolumeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AzureVolumeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AzureVolumeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.AzureVolumeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DestroyedStateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.DestroyedStateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.DestroyedStateProperties>
    {
        internal DestroyedStateProperties() { }
        public bool Destroyed { get { throw null; } }
        public System.DateTimeOffset? DestroyedOn { get { throw null; } }
        public System.DateTimeOffset? EradicationTimestamp { get { throw null; } }
        public string PreviousName { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.DestroyedStateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.DestroyedStateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.DestroyedStateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.DestroyedStateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.DestroyedStateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.DestroyedStateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.DestroyedStateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.DestroyedStateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.DestroyedStateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IscsiEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.IscsiEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.IscsiEndpoint>
    {
        internal IscsiEndpoint() { }
        public string IP { get { throw null; } }
        public string Iqn { get { throw null; } }
        public int Port { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.IscsiEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.IscsiEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.IscsiEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.IscsiEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.IscsiEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.IscsiEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.IscsiEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.IscsiEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.IscsiEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PerformancePolicyLimits : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits>
    {
        internal PerformancePolicyLimits() { }
        public Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits BandwidthLimit { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits IopsLimit { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlatformConsoleActivationCode : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleActivationCode>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleActivationCode>
    {
        internal PlatformConsoleActivationCode() { }
        public string ActivationCode { get { throw null; } }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        public string Username { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleActivationCode JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleActivationCode PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleActivationCode System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleActivationCode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleActivationCode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleActivationCode System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleActivationCode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleActivationCode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleActivationCode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class PlatformConsoleAuthConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthConfig>
    {
        internal PlatformConsoleAuthConfig() { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class PlatformConsoleAuthResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthResult>
    {
        internal PlatformConsoleAuthResult() { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlatformConsoleRole : System.IEquatable<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlatformConsoleRole(string value) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleRole ArrayAdmin { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleRole ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleRole StorageAdmin { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleRole other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleRole left, Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleRole (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleRole? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleRole left, Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlatformConsoleSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSettings>
    {
        public PlatformConsoleSettings() { }
        public bool? ApiEnabled { get { throw null; } set { } }
        public bool? CliEnabled { get { throw null; } set { } }
        public string DefaultUsername { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public bool? GuiEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSubnet> Subnets { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlatformConsoleSubnet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSubnet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSubnet>
    {
        public PlatformConsoleSubnet(Azure.Core.ResourceIdentifier id) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string ManagementIPAddress { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ServiceBackendIps { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSubnet JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSubnet PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSubnet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSubnet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSubnet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSubnet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSubnet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSubnet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSubnet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PropertyValueRangeLimits : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits>
    {
        internal PropertyValueRangeLimits() { }
        public long Max { get { throw null; } }
        public long Min { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProtectionPolicyLimits : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits>
    {
        internal ProtectionPolicyLimits() { }
        public Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits Frequency { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits Retention { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAddressDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAddressDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAddressDetails>
    {
        public PureStorageAddressDetails(string addressLine1, string city, string state, string country, string postalCode) { }
        public string AddressLine1 { get { throw null; } set { } }
        public string AddressLine2 { get { throw null; } set { } }
        public string City { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string PostalCode { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageAddressDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageAddressDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAddressDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAddressDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAddressDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAddressDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAddressDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAddressDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAddressDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvs : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvs>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvs>
    {
        internal PureStorageAvs() { }
        public Azure.Core.ResourceIdentifier ClusterResourceId { get { throw null; } }
        public bool IsAvsEnabled { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvs JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvs PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvs System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvs System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsConnection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsConnection>
    {
        internal PureStorageAvsConnection() { }
        public bool IsServiceInitializationCompleted { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationHandle ServiceInitializationHandle { get { throw null; } }
        public string ServiceInitializationHandleEnc { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsConnection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsConnection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsDiskDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsDiskDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsDiskDetails>
    {
        internal PureStorageAvsDiskDetails() { }
        public Azure.Core.ResourceIdentifier AvsStorageContainerResourceId { get { throw null; } }
        public string AvsVmInternalId { get { throw null; } }
        public string AvsVmName { get { throw null; } }
        public Azure.Core.ResourceIdentifier AvsVmResourceId { get { throw null; } }
        public string DiskId { get { throw null; } }
        public string DiskName { get { throw null; } }
        public string Folder { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsDiskDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsDiskDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsDiskDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsDiskDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsDiskDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsDiskDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsDiskDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsDiskDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsDiskDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStatus>
    {
        internal PureStorageAvsStatus() { }
        public Azure.Core.ResourceIdentifier ClusterResourceId { get { throw null; } }
        public string CurrentConnectionStatus { get { throw null; } }
        public bool IsAvsEnabled { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsStorageContainerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerProperties>
    {
        internal PureStorageAvsStorageContainerProperties() { }
        public string Datastore { get { throw null; } }
        public bool? Mounted { get { throw null; } }
        public long? ProvisionedLimit { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage Space { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsStorageContainerVolumePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerVolumePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerVolumePatch>
    {
        public PureStorageAvsStorageContainerVolumePatch() { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState AvsStorageContainerVolumeUpdateSoftDeletion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerVolumePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerVolumePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerVolumePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerVolumePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerVolumePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerVolumePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerVolumePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerVolumePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerVolumePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsVmDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmDetails>
    {
        internal PureStorageAvsVmDetails() { }
        public string AvsVmInternalId { get { throw null; } }
        public string VmId { get { throw null; } }
        public string VmName { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmType VmType { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsVmPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmPatch>
    {
        public PureStorageAvsVmPatch() { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState AvsVmUpdateSoftDeletion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsVmProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties>
    {
        internal PureStorageAvsVmProperties() { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmDetails Avs { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState SoftDeletion { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage Space { get { throw null; } }
        public string StoragePoolInternalId { get { throw null; } }
        public Azure.Core.ResourceIdentifier StoragePoolResourceId { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeContainerType? VolumeContainerType { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PureStorageAvsVmType : System.IEquatable<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PureStorageAvsVmType(string value) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmType VVol { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmType left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmType left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PureStorageAvsVmVolumeContainerType : System.IEquatable<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeContainerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PureStorageAvsVmVolumeContainerType(string value) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeContainerType AVS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeContainerType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeContainerType left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeContainerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeContainerType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeContainerType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeContainerType left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeContainerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PureStorageAvsVmVolumePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch>
    {
        public PureStorageAvsVmVolumePatch() { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState AvsVmVolumeUpdateSoftDeletion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PureStorageAvsVmVolumeType : System.IEquatable<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PureStorageAvsVmVolumeType(string value) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeType AVS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeType left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeType left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PureStorageBandwidthUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBandwidthUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBandwidthUsage>
    {
        internal PureStorageBandwidthUsage() { }
        public long Current { get { throw null; } }
        public long Max { get { throw null; } }
        public long Provisioned { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageBandwidthUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageBandwidthUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageBandwidthUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBandwidthUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBandwidthUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageBandwidthUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBandwidthUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBandwidthUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBandwidthUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageBillingUsageProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageProperty>
    {
        internal PureStorageBillingUsageProperty() { }
        public string CurrentValue { get { throw null; } }
        public string PreviousValue { get { throw null; } }
        public string PropertyId { get { throw null; } }
        public string PropertyName { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageSeverity Severity { get { throw null; } }
        public string StatusMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageProperty> SubProperties { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageProperty JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageProperty PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PureStorageBillingUsageSeverity : System.IEquatable<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PureStorageBillingUsageSeverity(string value) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageSeverity ALERT { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageSeverity INFORMATION { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageSeverity NONE { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageSeverity WARNING { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageSeverity other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageSeverity left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageSeverity (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageSeverity? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageSeverity left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PureStorageBlockActivateSaaSRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockActivateSaaSRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockActivateSaaSRequestContent>
    {
        public PureStorageBlockActivateSaaSRequestContent(string saasGuid) { }
        public string PublisherId { get { throw null; } set { } }
        public string SaasGuid { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockActivateSaaSRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockActivateSaaSRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockActivateSaaSRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockActivateSaaSRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockActivateSaaSRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockActivateSaaSRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockActivateSaaSRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockActivateSaaSRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockActivateSaaSRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageBlockConnectionParametersResponseResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockConnectionParametersResponseResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockConnectionParametersResponseResult>
    {
        internal PureStorageBlockConnectionParametersResponseResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PureStorageBlock.Models.IscsiEndpoint> IscsiEndpoints { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockConnectionParametersResponseResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockConnectionParametersResponseResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockConnectionParametersResponseResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockConnectionParametersResponseResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockConnectionParametersResponseResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockConnectionParametersResponseResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockConnectionParametersResponseResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockConnectionParametersResponseResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockConnectionParametersResponseResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageBlockLatestLinkedSaaSResponseResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLatestLinkedSaaSResponseResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLatestLinkedSaaSResponseResult>
    {
        internal PureStorageBlockLatestLinkedSaaSResponseResult() { }
        public bool? IsHiddenSaaS { get { throw null; } }
        public string SaaSResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLatestLinkedSaaSResponseResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLatestLinkedSaaSResponseResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLatestLinkedSaaSResponseResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLatestLinkedSaaSResponseResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLatestLinkedSaaSResponseResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLatestLinkedSaaSResponseResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLatestLinkedSaaSResponseResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLatestLinkedSaaSResponseResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLatestLinkedSaaSResponseResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageBlockLinkSaaSRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLinkSaaSRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLinkSaaSRequestContent>
    {
        public PureStorageBlockLinkSaaSRequestContent(string saaSResourceId) { }
        public string SaaSResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLinkSaaSRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLinkSaaSRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLinkSaaSRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLinkSaaSRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLinkSaaSRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLinkSaaSRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLinkSaaSRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLinkSaaSRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockLinkSaaSRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageBlockPerformanceParametersContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockPerformanceParametersContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockPerformanceParametersContent>
    {
        public PureStorageBlockPerformanceParametersContent() { }
        public long? BandwidthLimitMbPerSec { get { throw null; } set { } }
        public long? IopsLimit { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockPerformanceParametersContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockPerformanceParametersContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockPerformanceParametersContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockPerformanceParametersContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockPerformanceParametersContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockPerformanceParametersContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockPerformanceParametersContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockPerformanceParametersContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockPerformanceParametersContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageBlockProtectionParametersContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockProtectionParametersContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockProtectionParametersContent>
    {
        public PureStorageBlockProtectionParametersContent() { }
        public System.TimeSpan? Frequency { get { throw null; } set { } }
        public System.TimeSpan? Retention { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockProtectionParametersContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockProtectionParametersContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockProtectionParametersContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockProtectionParametersContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockProtectionParametersContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockProtectionParametersContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockProtectionParametersContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockProtectionParametersContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockProtectionParametersContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageBlockSaaSResourceDetailsResponseResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockSaaSResourceDetailsResponseResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockSaaSResourceDetailsResponseResult>
    {
        internal PureStorageBlockSaaSResourceDetailsResponseResult() { }
        public string SaasId { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockSaaSResourceDetailsResponseResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockSaaSResourceDetailsResponseResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockSaaSResourceDetailsResponseResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockSaaSResourceDetailsResponseResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockSaaSResourceDetailsResponseResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockSaaSResourceDetailsResponseResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockSaaSResourceDetailsResponseResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageBlockVolumeGroupOverwriteRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupOverwriteRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupOverwriteRequestContent>
    {
        public PureStorageBlockVolumeGroupOverwriteRequestContent(Azure.Core.ResourceIdentifier sourceSnapshotResourceId, Azure.Core.ResourceIdentifier sourceVolumeGroupResourceId) { }
        public Azure.Core.ResourceIdentifier SourceSnapshotResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceVolumeGroupResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupOverwriteRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupOverwriteRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupOverwriteRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupOverwriteRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupOverwriteRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupOverwriteRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupOverwriteRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupOverwriteRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupOverwriteRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageBlockVolumeGroupSnapshotListRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupSnapshotListRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupSnapshotListRequestContent>
    {
        public PureStorageBlockVolumeGroupSnapshotListRequestContent() { }
        public string Filter { get { throw null; } set { } }
        public string Orderby { get { throw null; } set { } }
        public int? Skip { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupSnapshotListRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupSnapshotListRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupSnapshotListRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupSnapshotListRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupSnapshotListRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupSnapshotListRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupSnapshotListRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupSnapshotListRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeGroupSnapshotListRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageBlockVolumeOverwriteRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeOverwriteRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeOverwriteRequestContent>
    {
        public PureStorageBlockVolumeOverwriteRequestContent(Azure.ResourceManager.PureStorageBlock.Models.VolumeSourceType sourceType) { }
        public string SourceSerialNumber { get { throw null; } set { } }
        public Azure.ResourceManager.PureStorageBlock.Models.VolumeSourceType SourceType { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceVolumeGroupResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVolumeResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotSource SourceVolumeSnapshot { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeOverwriteRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeOverwriteRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeOverwriteRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeOverwriteRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeOverwriteRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeOverwriteRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeOverwriteRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeOverwriteRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockVolumeOverwriteRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageCompanyDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageCompanyDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageCompanyDetails>
    {
        public PureStorageCompanyDetails(string companyName) { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageAddressDetails Address { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageCompanyDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageCompanyDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageCompanyDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageCompanyDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageCompanyDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageCompanyDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageCompanyDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageCompanyDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageCompanyDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageHealthAlert : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlert>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlert>
    {
        internal PureStorageHealthAlert() { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlertLevel Level { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlert JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlert PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlert System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlert>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlert>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlert System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlert>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlert>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlert>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PureStorageHealthAlertLevel : System.IEquatable<Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlertLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PureStorageHealthAlertLevel(string value) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlertLevel Error { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlertLevel Info { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlertLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlertLevel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlertLevel left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlertLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlertLevel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlertLevel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlertLevel left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlertLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PureStorageHealthDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthDetails>
    {
        internal PureStorageHealthDetails() { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageBandwidthUsage BandwidthUsage { get { throw null; } }
        public double DataReductionRatio { get { throw null; } }
        public long EstimatedMaxCapacity { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageIopsUsage IopsUsage { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage Space { get { throw null; } }
        public double UsedCapacityPercentage { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageIopsUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageIopsUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageIopsUsage>
    {
        internal PureStorageIopsUsage() { }
        public long Current { get { throw null; } }
        public long Max { get { throw null; } }
        public long Provisioned { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageIopsUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageIopsUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageIopsUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageIopsUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageIopsUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageIopsUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageIopsUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageIopsUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageIopsUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageMarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceDetails>
    {
        public PureStorageMarketplaceDetails() { }
        public PureStorageMarketplaceDetails(Azure.ResourceManager.PureStorageBlock.Models.PureStorageOfferDetails offerDetails) { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageOfferDetails OfferDetails { get { throw null; } set { } }
        public string SaaSResourceId { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceSubscriptionStatus? SubscriptionStatus { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PureStorageMarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PureStorageMarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceSubscriptionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceSubscriptionStatus left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceSubscriptionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceSubscriptionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceSubscriptionStatus left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PureStorageOfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageOfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageOfferDetails>
    {
        public PureStorageOfferDetails(string publisherId, string offerId, string planId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageOfferDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageOfferDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageOfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageOfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageOfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageOfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageOfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageOfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageOfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStoragePoolPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolPatch>
    {
        public PureStoragePoolPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.PureStorageBlock.Models.StoragePoolUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStoragePoolProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties>
    {
        public PureStoragePoolProperties(string availabilityZone, Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolVnetInjection vnetInjection, long provisionedBandwidthMbPerSec, Azure.Core.ResourceIdentifier reservationResourceId) { }
        public string AvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvs Avs { get { throw null; } }
        public long? DataRetentionPeriod { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSettings PlatformConsoleSettings { get { throw null; } set { } }
        public long ProvisionedBandwidthMbPerSec { get { throw null; } set { } }
        public long? ProvisionedIops { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ReservationResourceId { get { throw null; } set { } }
        public string StoragePoolInternalId { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolVnetInjection VnetInjection { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStoragePoolVnetInjection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolVnetInjection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolVnetInjection>
    {
        public PureStoragePoolVnetInjection(Azure.Core.ResourceIdentifier subnetId, Azure.Core.ResourceIdentifier vnetId) { }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VnetId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolVnetInjection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolVnetInjection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolVnetInjection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolVnetInjection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolVnetInjection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolVnetInjection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolVnetInjection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolVnetInjection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolVnetInjection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PureStorageProvisioningState : System.IEquatable<Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PureStorageProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PureStorageReservationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch>
    {
        public PureStorageReservationPatch() { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageUserDetails ReservationUpdateUser { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageReservationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties>
    {
        public PureStorageReservationProperties(Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceDetails marketplace) { }
        public PureStorageReservationProperties(Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceDetails marketplace, Azure.ResourceManager.PureStorageBlock.Models.PureStorageUserDetails user) { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceDetails Marketplace { get { throw null; } set { } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState? ProvisioningState { get { throw null; } }
        public string ReservationInternalId { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageUserDetails User { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageResourceLimitDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceLimitDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceLimitDetails>
    {
        internal PureStorageResourceLimitDetails() { }
        public Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits PerformancePolicy { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits ProtectionPolicy { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits StoragePool { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits VolumeProvisionedSize { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceLimitDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceLimitDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceLimitDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceLimitDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceLimitDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceLimitDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceLimitDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceLimitDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceLimitDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PureStorageResourceProvisioningState : System.IEquatable<Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PureStorageResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PureStorageSoftDeletionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState>
    {
        public PureStorageSoftDeletionState(bool isDestroyed) { }
        public System.DateTimeOffset? EradicatedOn { get { throw null; } }
        public bool IsDestroyed { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageSpaceUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage>
    {
        internal PureStorageSpaceUsage() { }
        public long Shared { get { throw null; } }
        public long Snapshots { get { throw null; } }
        public long TotalUsed { get { throw null; } }
        public long Unique { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageUserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageUserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageUserDetails>
    {
        public PureStorageUserDetails(string firstName, string lastName, string emailAddress) { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageCompanyDetails CompanyDetails { get { throw null; } set { } }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageUserDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageUserDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageUserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageUserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageUserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageUserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageUserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageUserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageUserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageVolumeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties>
    {
        internal PureStorageVolumeProperties() { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsDiskDetails Avs { get { throw null; } }
        public string CreatedTimestamp { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public long? ProvisionedSize { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState SoftDeletion { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage Space { get { throw null; } }
        public string StoragePoolInternalId { get { throw null; } }
        public Azure.Core.ResourceIdentifier StoragePoolResourceId { get { throw null; } }
        public string VolumeInternalId { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeType? VolumeType { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoverableVolumeGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.RecoverableVolumeGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.RecoverableVolumeGroupProperties>
    {
        internal RecoverableVolumeGroupProperties() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockPerformanceParametersContent PerformanceParameters { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockProtectionParametersContent ProtectionParameters { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.DestroyedStateProperties SoftDeletion { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage Space { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.RecoverableVolumeGroupProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.RecoverableVolumeGroupProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.RecoverableVolumeGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.RecoverableVolumeGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.RecoverableVolumeGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.RecoverableVolumeGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.RecoverableVolumeGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.RecoverableVolumeGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.RecoverableVolumeGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReservationBillingUsageReport : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport>
    {
        internal ReservationBillingUsageReport() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageProperty> BillingUsageProperties { get { throw null; } }
        public string OverallStatusMessage { get { throw null; } }
        public string Timestamp { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceInitializationHandle : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationHandle>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationHandle>
    {
        internal ServiceInitializationHandle() { }
        public Azure.Core.ResourceIdentifier ClusterResourceId { get { throw null; } }
        public string ServiceAccountUsername { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationHandle JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationHandle PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SshPlatformConsoleAuthConfig : Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthConfig, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.SshPlatformConsoleAuthConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.SshPlatformConsoleAuthConfig>
    {
        public SshPlatformConsoleAuthConfig(string username, string publicKey, Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleRole role) { }
        public string PublicKey { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleRole Role { get { throw null; } }
        public string Username { get { throw null; } }
        protected override Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.SshPlatformConsoleAuthConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.SshPlatformConsoleAuthConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.SshPlatformConsoleAuthConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.SshPlatformConsoleAuthConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.SshPlatformConsoleAuthConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.SshPlatformConsoleAuthConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.SshPlatformConsoleAuthConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SshPlatformConsoleAuthResult : Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.SshPlatformConsoleAuthResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.SshPlatformConsoleAuthResult>
    {
        internal SshPlatformConsoleAuthResult() { }
        public Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleRole Role { get { throw null; } }
        public string Username { get { throw null; } }
        protected override Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleAuthResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.SshPlatformConsoleAuthResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.SshPlatformConsoleAuthResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.SshPlatformConsoleAuthResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.SshPlatformConsoleAuthResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.SshPlatformConsoleAuthResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.SshPlatformConsoleAuthResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.SshPlatformConsoleAuthResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StoragePoolEnableAvsConnectionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionContent>
    {
        public StoragePoolEnableAvsConnectionContent(Azure.Core.ResourceIdentifier clusterResourceId) { }
        public Azure.Core.ResourceIdentifier ClusterResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StoragePoolFinalizeAvsConnectionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionContent>
    {
        public StoragePoolFinalizeAvsConnectionContent() { }
        public Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationInfo ServiceInitializationData { get { throw null; } set { } }
        public string ServiceInitializationDataEnc { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StoragePoolHealthInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolHealthInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolHealthInfo>
    {
        internal StoragePoolHealthInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlert> Alerts { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthDetails Health { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.StoragePoolHealthInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.StoragePoolHealthInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits ProvisionedBandwidthMbPerSec { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits ProvisionedIops { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StoragePoolUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolUpdateProperties>
    {
        public StoragePoolUpdateProperties() { }
        public Azure.ResourceManager.PureStorageBlock.Models.PlatformConsoleSettings PlatformConsoleSettings { get { throw null; } set { } }
        public long? ProvisionedBandwidthMbPerSec { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.StoragePoolUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.StoragePoolUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.StoragePoolUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.StoragePoolUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumeGroupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupPatch>
    {
        public VolumeGroupPatch() { }
        public Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumeGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupProperties>
    {
        public VolumeGroupProperties() { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockPerformanceParametersContent PerformanceParameters { get { throw null; } set { } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockProtectionParametersContent ProtectionParameters { get { throw null; } set { } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceRecoverableVolumeGroupResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceSnapshotResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSourceType? SourceType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVolumeGroupResourceId { get { throw null; } set { } }
        public string StoragePoolInternalId { get { throw null; } }
        public string VolumeGroupInternalId { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumeGroupSnapshotPostListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotPostListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotPostListResult>
    {
        internal VolumeGroupSnapshotPostListResult() { }
        public int? Count { get { throw null; } }
        public int? TotalCount { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PureStorageBlock.VolumeGroupSnapshotData> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotPostListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotPostListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotPostListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotPostListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotPostListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotPostListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotPostListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotPostListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotPostListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumeGroupSnapshotProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotProperties>
    {
        public VolumeGroupSnapshotProperties() { }
        public bool? CreatedByPolicy { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.DestroyedStateProperties SoftDeletion { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceSnapshotResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage Space { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotInfo> VolumeSnapshots { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSnapshotProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VolumeGroupSourceType : System.IEquatable<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VolumeGroupSourceType(string value) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSourceType None { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSourceType RecoverableVolumeGroup { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSourceType Snapshot { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSourceType VolumeGroup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSourceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSourceType left, Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSourceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSourceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSourceType left, Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VolumeGroupStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupStatus>
    {
        internal VolumeGroupStatus() { }
        public int ConnectedHostCount { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage Space { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumeGroupUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupUpdateProperties>
    {
        public VolumeGroupUpdateProperties() { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockPerformanceParametersContent PerformanceParameters { get { throw null; } set { } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageBlockProtectionParametersContent ProtectionParameters { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeGroupUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumePatch>
    {
        public VolumePatch() { }
        public long? VolumeUpdateProvisionedSize { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.VolumePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.VolumePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.VolumePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.VolumePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumeSnapshotInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotInfo>
    {
        internal VolumeSnapshotInfo() { }
        public string Name { get { throw null; } }
        public long? ProvisionedSize { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage Space { get { throw null; } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumeSnapshotSource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotSource>
    {
        public VolumeSnapshotSource(Azure.Core.ResourceIdentifier volumeGroupSnapshotResourceId, string volumeSnapshotName) { }
        public Azure.Core.ResourceIdentifier VolumeGroupSnapshotResourceId { get { throw null; } set { } }
        public string VolumeSnapshotName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.VolumeSnapshotSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VolumeSourceType : System.IEquatable<Azure.ResourceManager.PureStorageBlock.Models.VolumeSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VolumeSourceType(string value) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.VolumeSourceType None { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.VolumeSourceType RecoverableVolume { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.VolumeSourceType SerialNumber { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.VolumeSourceType Snapshot { get { throw null; } }
        public static Azure.ResourceManager.PureStorageBlock.Models.VolumeSourceType Volume { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorageBlock.Models.VolumeSourceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.VolumeSourceType left, Azure.ResourceManager.PureStorageBlock.Models.VolumeSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.VolumeSourceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.VolumeSourceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorageBlock.Models.VolumeSourceType left, Azure.ResourceManager.PureStorageBlock.Models.VolumeSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
