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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerResource> GetPureStorageAvsStorageContainer(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerResource>> GetPureStorageAvsStorageContainerAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerCollection GetPureStorageAvsStorageContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmResource> GetPureStorageAvsVm(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmResource>> GetPureStorageAvsVmAsync(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmCollection GetPureStorageAvsVms() { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits PerformancePolicyLimits(Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits iopsLimit = null, Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits bandwidthLimit = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits PropertyValueRangeLimits(long min = (long)0, long max = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits ProtectionPolicyLimits(Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits frequency = null, Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits retention = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvs PureStorageAvs(bool isAvsEnabled = false, Azure.Core.ResourceIdentifier clusterResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsConnection PureStorageAvsConnection(bool isServiceInitializationCompleted = false, string serviceInitializationHandleEnc = null, Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationHandle serviceInitializationHandle = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsDiskDetails PureStorageAvsDiskDetails(string diskId = null, string diskName = null, string folder = null, string avsVmInternalId = null, Azure.Core.ResourceIdentifier avsVmResourceId = null, string avsVmName = null, Azure.Core.ResourceIdentifier avsStorageContainerResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStatus PureStorageAvsStatus(bool isAvsEnabled = false, string currentConnectionStatus = null, Azure.Core.ResourceIdentifier clusterResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerData PureStorageAvsStorageContainerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerProperties PureStorageAvsStorageContainerProperties(Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage space = null, string resourceName = null, long? provisionedLimit = default(long?), string datastore = null, bool? mounted = default(bool?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeData PureStorageAvsStorageContainerVolumeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmData PureStorageAvsVmData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmDetails PureStorageAvsVmDetails(string vmId = null, string vmName = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmType vmType = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmType), string avsVmInternalId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties PureStorageAvsVmProperties(string storagePoolInternalId = null, Azure.Core.ResourceIdentifier storagePoolResourceId = null, string displayName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState softDeletion = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeContainerType? volumeContainerType = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeContainerType?), Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmDetails avs = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage space = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeData PureStorageAvsVmVolumeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageBandwidthUsage PureStorageBandwidthUsage(long current = (long)0, long provisioned = (long)0, long max = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageProperty PureStorageBillingUsageProperty(string propertyId = null, string propertyName = null, string currentValue = null, string previousValue = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageSeverity severity = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageSeverity), string statusMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageProperty> subProperties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlert PureStorageHealthAlert(Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlertLevel level = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlertLevel), string message = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthDetails PureStorageHealthDetails(double usedCapacityPercentage = 0, Azure.ResourceManager.PureStorageBlock.Models.PureStorageBandwidthUsage bandwidthUsage = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageIopsUsage iopsUsage = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage space = null, double dataReductionRatio = 0, long estimatedMaxCapacity = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageIopsUsage PureStorageIopsUsage(long current = (long)0, long provisioned = (long)0, long max = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceDetails PureStorageMarketplaceDetails(string subscriptionId = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceSubscriptionStatus? subscriptionStatus = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceSubscriptionStatus?), Azure.ResourceManager.PureStorageBlock.Models.PureStorageOfferDetails offerDetails = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStoragePoolData PureStoragePoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties PureStoragePoolProperties(string storagePoolInternalId = null, string availabilityZone = null, Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolVnetInjection vnetInjection = null, long? dataRetentionPeriod = default(long?), long provisionedBandwidthMbPerSec = (long)0, long? provisionedIops = default(long?), Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvs avs = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState?), Azure.Core.ResourceIdentifier reservationResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStorageReservationData PureStorageReservationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties PureStorageReservationProperties(string reservationInternalId = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceDetails marketplace = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageUserDetails user = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceLimitDetails PureStorageResourceLimitDetails(Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits storagePool = null, Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits volumeProvisionedSize = null, Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits protectionPolicy = null, Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits performancePolicy = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState PureStorageSoftDeletionState(bool isDestroyed = false, System.DateTimeOffset? eradicatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage PureStorageSpaceUsage(long totalUsed = (long)0, long unique = (long)0, long snapshots = (long)0, long shared = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties PureStorageVolumeProperties(string storagePoolInternalId = null, Azure.Core.ResourceIdentifier storagePoolResourceId = null, string volumeInternalId = null, string displayName = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageSpaceUsage space = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState softDeletion = null, string createdTimestamp = null, long? provisionedSize = default(long?), Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeType? volumeType = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeType?), Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsDiskDetails avs = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus ReservationBillingStatus(string timestamp = null, long totalUsedCapacityReported = (long)0, int lowDrrPoolCount = 0, double drrWeightedAverage = 0, long totalNonReducibleReported = (long)0, long extraUsedCapacityNonReducible = (long)0, long extraUsedCapacityLowUsageRounding = (long)0, long extraUsedCapacityNonReduciblePlanDiscount = (long)0, long totalUsedCapacityBilled = (long)0, long totalUsedCapacityIncludedPlan = (long)0, long totalUsedCapacityOverage = (long)0, long totalPerformanceReported = (long)0, long totalPerformanceIncludedPlan = (long)0, long totalPerformanceOverage = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport ReservationBillingUsageReport(string timestamp = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageProperty> billingUsageProperties = null, string overallStatusMessage = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationHandle ServiceInitializationHandle(Azure.Core.ResourceIdentifier clusterResourceId = null, string serviceAccountUsername = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.StoragePoolHealthInfo StoragePoolHealthInfo(Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthDetails health = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlert> alerts = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits StoragePoolLimits(Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits provisionedBandwidthMbPerSec = null, Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits provisionedIops = null, System.Collections.Generic.IEnumerable<string> physicalAvailabilityZones = null) { throw null; }
    }
    public partial class PerformancePolicyLimits : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits>
    {
        internal PerformancePolicyLimits() { }
        public Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits BandwidthLimit { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits IopsLimit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PropertyValueRangeLimits : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits>
    {
        internal PropertyValueRangeLimits() { }
        public long Max { get { throw null; } }
        public long Min { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmType left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmType (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeContainerType left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeContainerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeContainerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeContainerType left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeContainerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PureStorageAvsVmVolumePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch>
    {
        public PureStorageAvsVmVolumePatch() { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState AvsVmVolumeUpdateSoftDeletion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeType left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeType left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PureStorageBandwidthUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBandwidthUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBandwidthUsage>
    {
        internal PureStorageBandwidthUsage() { }
        public long Current { get { throw null; } }
        public long Max { get { throw null; } }
        public long Provisioned { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageSeverity left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageSeverity left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PureStorageCompanyDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageCompanyDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageCompanyDetails>
    {
        public PureStorageCompanyDetails(string companyName) { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageAddressDetails Address { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlertLevel left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlertLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlertLevel (string value) { throw null; }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageIopsUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageIopsUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageIopsUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageIopsUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageIopsUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageIopsUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageIopsUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageMarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceDetails>
    {
        public PureStorageMarketplaceDetails(Azure.ResourceManager.PureStorageBlock.Models.PureStorageOfferDetails offerDetails) { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageOfferDetails OfferDetails { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceSubscriptionStatus? SubscriptionStatus { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceSubscriptionStatus left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceSubscriptionStatus (string value) { throw null; }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public long? StoragePoolUpdateProvisionedBandwidthMbPerSec { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public long ProvisionedBandwidthMbPerSec { get { throw null; } set { } }
        public long? ProvisionedIops { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ReservationResourceId { get { throw null; } set { } }
        public string StoragePoolInternalId { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolVnetInjection VnetInjection { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PureStorageReservationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch>
    {
        public PureStorageReservationPatch() { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageUserDetails ReservationUpdateUser { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageReservationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties>
    {
        public PureStorageReservationProperties(Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceDetails marketplace, Azure.ResourceManager.PureStorageBlock.Models.PureStorageUserDetails user) { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageMarketplaceDetails Marketplace { get { throw null; } set { } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageProvisioningState? ProvisioningState { get { throw null; } }
        public string ReservationInternalId { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageUserDetails User { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState left, Azure.ResourceManager.PureStorageBlock.Models.PureStorageResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PureStorageSoftDeletionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageSoftDeletionState>
    {
        public PureStorageSoftDeletionState(bool isDestroyed) { }
        public System.DateTimeOffset? EradicatedOn { get { throw null; } }
        public bool IsDestroyed { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PureStorageBlock.Models.PureStorageBillingUsageProperty> BillingUsageProperties { get { throw null; } }
        public string OverallStatusMessage { get { throw null; } }
        public string Timestamp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    public partial class StoragePoolEnableAvsConnectionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionContent>
    {
        public StoragePoolEnableAvsConnectionContent(Azure.Core.ResourceIdentifier clusterResourceId) { }
        public Azure.Core.ResourceIdentifier ClusterResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits ProvisionedBandwidthMbPerSec { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.PropertyValueRangeLimits ProvisionedIops { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
