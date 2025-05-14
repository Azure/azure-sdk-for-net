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
        public virtual Azure.ResourceManager.ArmOperation EnableAvsConnection(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionPost properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> EnableAvsConnectionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.StoragePoolEnableAvsConnectionPost properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation FinalizeAvsConnection(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionPost properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FinalizeAvsConnectionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorageBlock.Models.StoragePoolFinalizeAvsConnectionPost properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.LimitDetails> GetResourceLimits(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorageBlock.Models.LimitDetails>> GetResourceLimitsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.PureStorageBlock.Models.BandwidthUsage BandwidthUsage(long current = (long)0, long provisioned = (long)0, long max = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.BillingUsageProperty BillingUsageProperty(string propertyId = null, string propertyName = null, string currentValue = null, string previousValue = null, Azure.ResourceManager.PureStorageBlock.Models.UsageSeverity severity = default(Azure.ResourceManager.PureStorageBlock.Models.UsageSeverity), string statusMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.Models.BillingUsageProperty> subProperties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.HealthDetails HealthDetails(double usedCapacityPercentage = 0, Azure.ResourceManager.PureStorageBlock.Models.BandwidthUsage bandwidthUsage = null, Azure.ResourceManager.PureStorageBlock.Models.IopsUsage iopsUsage = null, Azure.ResourceManager.PureStorageBlock.Models.Space space = null, double dataReductionRatio = 0, long estimatedMaxCapacity = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.IopsUsage IopsUsage(long current = (long)0, long provisioned = (long)0, long max = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.LimitDetails LimitDetails(Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits storagePool = null, Azure.ResourceManager.PureStorageBlock.Models.RangeLimits volumeProvisionedSize = null, Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits protectionPolicy = null, Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits performancePolicy = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.MarketplaceDetails MarketplaceDetails(string subscriptionId = null, Azure.ResourceManager.PureStorageBlock.Models.MarketplaceSubscriptionStatus? subscriptionStatus = default(Azure.ResourceManager.PureStorageBlock.Models.MarketplaceSubscriptionStatus?), Azure.ResourceManager.PureStorageBlock.Models.OfferDetails offerDetails = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PerformancePolicyLimits PerformancePolicyLimits(Azure.ResourceManager.PureStorageBlock.Models.RangeLimits iopsLimit = null, Azure.ResourceManager.PureStorageBlock.Models.RangeLimits bandwidthLimit = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.ProtectionPolicyLimits ProtectionPolicyLimits(Azure.ResourceManager.PureStorageBlock.Models.RangeLimits frequency = null, Azure.ResourceManager.PureStorageBlock.Models.RangeLimits retention = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvs PureStorageAvs(bool isAvsEnabled = false, Azure.Core.ResourceIdentifier clusterResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsConnection PureStorageAvsConnection(bool isServiceInitializationCompleted = false, string serviceInitializationHandleEnc = null, Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationHandle serviceInitializationHandle = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsDiskDetails PureStorageAvsDiskDetails(string diskId = null, string diskName = null, string folder = null, string avsVmInternalId = null, Azure.Core.ResourceIdentifier avsVmResourceId = null, string avsVmName = null, Azure.Core.ResourceIdentifier avsStorageContainerResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStatus PureStorageAvsStatus(bool isAvsEnabled = false, string currentConnectionStatus = null, Azure.Core.ResourceIdentifier clusterResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerData PureStorageAvsStorageContainerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsStorageContainerProperties PureStorageAvsStorageContainerProperties(Azure.ResourceManager.PureStorageBlock.Models.Space space = null, string resourceName = null, long? provisionedLimit = default(long?), string datastore = null, bool? mounted = default(bool?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStorageAvsStorageContainerVolumeData PureStorageAvsStorageContainerVolumeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmData PureStorageAvsVmData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmDetails PureStorageAvsVmDetails(string vmId = null, string vmName = null, Azure.ResourceManager.PureStorageBlock.Models.VmType vmType = default(Azure.ResourceManager.PureStorageBlock.Models.VmType), string avsVmInternalId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties PureStorageAvsVmProperties(string storagePoolInternalId = null, Azure.Core.ResourceIdentifier storagePoolResourceId = null, string displayName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.PureStorageBlock.Models.SoftDeletion softDeletion = null, Azure.ResourceManager.PureStorageBlock.Models.VolumeContainerType? volumeContainerType = default(Azure.ResourceManager.PureStorageBlock.Models.VolumeContainerType?), Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmDetails avs = null, Azure.ResourceManager.PureStorageBlock.Models.Space space = null, Azure.ResourceManager.PureStorageBlock.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorageBlock.Models.ResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStorageAvsVmVolumeData PureStorageAvsVmVolumeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlert PureStorageHealthAlert(Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlertLevel level = default(Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlertLevel), string message = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStoragePoolData PureStoragePoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties PureStoragePoolProperties(string storagePoolInternalId = null, string availabilityZone = null, Azure.ResourceManager.PureStorageBlock.Models.VnetInjection vnetInjection = null, long? dataRetentionPeriod = default(long?), long provisionedBandwidthMbPerSec = (long)0, long? provisionedIops = default(long?), Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvs avs = null, Azure.ResourceManager.PureStorageBlock.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorageBlock.Models.ProvisioningState?), string reservationResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.PureStorageReservationData PureStorageReservationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties PureStorageReservationProperties(string reservationInternalId = null, Azure.ResourceManager.PureStorageBlock.Models.MarketplaceDetails marketplace = null, Azure.ResourceManager.PureStorageBlock.Models.UserDetails user = null, Azure.ResourceManager.PureStorageBlock.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorageBlock.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties PureStorageVolumeProperties(string storagePoolInternalId = null, string storagePoolResourceId = null, string volumeInternalId = null, string displayName = null, Azure.ResourceManager.PureStorageBlock.Models.Space space = null, Azure.ResourceManager.PureStorageBlock.Models.SoftDeletion softDeletion = null, string createdTimestamp = null, long? provisionedSize = default(long?), Azure.ResourceManager.PureStorageBlock.Models.VolumeType? volumeType = default(Azure.ResourceManager.PureStorageBlock.Models.VolumeType?), Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsDiskDetails avs = null, Azure.ResourceManager.PureStorageBlock.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorageBlock.Models.ResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.RangeLimits RangeLimits(long min = (long)0, long max = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingStatus ReservationBillingStatus(string timestamp = null, long totalUsedCapacityReported = (long)0, int lowDrrPoolCount = 0, double drrWeightedAverage = 0, long totalNonReducibleReported = (long)0, long extraUsedCapacityNonReducible = (long)0, long extraUsedCapacityLowUsageRounding = (long)0, long extraUsedCapacityNonReduciblePlanDiscount = (long)0, long totalUsedCapacityBilled = (long)0, long totalUsedCapacityIncludedPlan = (long)0, long totalUsedCapacityOverage = (long)0, long totalPerformanceReported = (long)0, long totalPerformanceIncludedPlan = (long)0, long totalPerformanceOverage = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.ReservationBillingUsageReport ReservationBillingUsageReport(string timestamp = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.Models.BillingUsageProperty> billingUsageProperties = null, string overallStatusMessage = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.ServiceInitializationHandle ServiceInitializationHandle(string clusterResourceId = null, string serviceAccountUsername = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.SoftDeletion SoftDeletion(bool destroyed = false, string eradicationTimestamp = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.Space Space(long totalUsed = (long)0, long unique = (long)0, long snapshots = (long)0, long shared = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.StoragePoolHealthInfo StoragePoolHealthInfo(Azure.ResourceManager.PureStorageBlock.Models.HealthDetails health = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlert> alerts = null) { throw null; }
        public static Azure.ResourceManager.PureStorageBlock.Models.StoragePoolLimits StoragePoolLimits(Azure.ResourceManager.PureStorageBlock.Models.RangeLimits provisionedBandwidthMbPerSec = null, Azure.ResourceManager.PureStorageBlock.Models.RangeLimits provisionedIops = null, System.Collections.Generic.IEnumerable<string> physicalAvailabilityZones = null) { throw null; }
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
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageAddressDetails Address { get { throw null; } set { } }
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
        public Azure.ResourceManager.PureStorageBlock.Models.Space Space { get { throw null; } }
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
        public Azure.ResourceManager.PureStorageBlock.Models.SoftDeletion AvsStorageContainerVolumeUpdateSoftDeletion { get { throw null; } set { } }
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
        public Azure.ResourceManager.PureStorageBlock.Models.VmType VmType { get { throw null; } }
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
        public Azure.ResourceManager.PureStorageBlock.Models.SoftDeletion AvsVmUpdateSoftDeletion { get { throw null; } set { } }
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
        public Azure.ResourceManager.PureStorageBlock.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.SoftDeletion SoftDeletion { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.Space Space { get { throw null; } }
        public string StoragePoolInternalId { get { throw null; } }
        public Azure.Core.ResourceIdentifier StoragePoolResourceId { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.VolumeContainerType? VolumeContainerType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsVmVolumePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch>
    {
        public PureStorageAvsVmVolumePatch() { }
        public Azure.ResourceManager.PureStorageBlock.Models.SoftDeletion AvsVmVolumeUpdateSoftDeletion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsVmVolumePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public PureStoragePoolProperties(string availabilityZone, Azure.ResourceManager.PureStorageBlock.Models.VnetInjection vnetInjection, long provisionedBandwidthMbPerSec, string reservationResourceId) { }
        public string AvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvs Avs { get { throw null; } }
        public long? DataRetentionPeriod { get { throw null; } }
        public long ProvisionedBandwidthMbPerSec { get { throw null; } set { } }
        public long? ProvisionedIops { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ReservationResourceId { get { throw null; } set { } }
        public string StoragePoolInternalId { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.VnetInjection VnetInjection { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStoragePoolProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageReservationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationPatch>
    {
        public PureStorageReservationPatch() { }
        public Azure.ResourceManager.PureStorageBlock.Models.UserDetails ReservationUpdateUser { get { throw null; } set { } }
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
        public PureStorageReservationProperties(Azure.ResourceManager.PureStorageBlock.Models.MarketplaceDetails marketplace, Azure.ResourceManager.PureStorageBlock.Models.UserDetails user) { }
        public Azure.ResourceManager.PureStorageBlock.Models.MarketplaceDetails Marketplace { get { throw null; } set { } }
        public Azure.ResourceManager.PureStorageBlock.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ReservationInternalId { get { throw null; } }
        public Azure.ResourceManager.PureStorageBlock.Models.UserDetails User { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageReservationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageVolumeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties>
    {
        internal PureStorageVolumeProperties() { }
        public Azure.ResourceManager.PureStorageBlock.Models.PureStorageAvsDiskDetails Avs { get { throw null; } }
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
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorageBlock.Models.PureStorageVolumeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PureStorageBlock.Models.PureStorageHealthAlert> Alerts { get { throw null; } }
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
