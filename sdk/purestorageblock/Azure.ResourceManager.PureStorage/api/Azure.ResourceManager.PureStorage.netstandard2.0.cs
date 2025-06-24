namespace Azure.ResourceManager.PureStorage
{
    public partial class AzureResourceManagerPureStorageContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerPureStorageContext() { }
        public static Azure.ResourceManager.PureStorage.AzureResourceManagerPureStorageContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class PureStorageAvsStorageContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerResource>, System.Collections.IEnumerable
    {
        protected PureStorageAvsStorageContainerCollection() { }
        public virtual Azure.Response<bool> Exists(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerResource> Get(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerResource>> GetAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerResource> GetIfExists(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerResource>> GetIfExistsAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PureStorageAvsStorageContainerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerData>
    {
        internal PureStorageAvsStorageContainerData() { }
        public Azure.ResourceManager.PureStorage.Models.PureStorageAvsStorageContainerProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsStorageContainerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PureStorageAvsStorageContainerResource() { }
        public virtual Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storagePoolName, string storageContainerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeResource> GetPureStorageAvsStorageContainerVolume(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeResource>> GetPureStorageAvsStorageContainerVolumeAsync(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeCollection GetPureStorageAvsStorageContainerVolumes() { throw null; }
        Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsStorageContainerVolumeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeResource>, System.Collections.IEnumerable
    {
        protected PureStorageAvsStorageContainerVolumeCollection() { }
        public virtual Azure.Response<bool> Exists(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeResource> Get(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeResource>> GetAsync(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeResource> GetIfExists(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeResource>> GetIfExistsAsync(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PureStorageAvsStorageContainerVolumeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeData>
    {
        internal PureStorageAvsStorageContainerVolumeData() { }
        public Azure.ResourceManager.PureStorage.Models.PureStorageVolumeProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsStorageContainerVolumeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PureStorageAvsStorageContainerVolumeResource() { }
        public virtual Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storagePoolName, string storageContainerName, string volumeId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorage.Models.PureStorageAvsStorageContainerVolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorage.Models.PureStorageAvsStorageContainerVolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PureStorageAvsVmCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorage.PureStorageAvsVmResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorage.PureStorageAvsVmResource>, System.Collections.IEnumerable
    {
        protected PureStorageAvsVmCollection() { }
        public virtual Azure.Response<bool> Exists(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.PureStorageAvsVmResource> Get(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorage.PureStorageAvsVmResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorage.PureStorageAvsVmResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStorageAvsVmResource>> GetAsync(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PureStorage.PureStorageAvsVmResource> GetIfExists(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PureStorage.PureStorageAvsVmResource>> GetIfExistsAsync(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PureStorage.PureStorageAvsVmResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorage.PureStorageAvsVmResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PureStorage.PureStorageAvsVmResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorage.PureStorageAvsVmResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PureStorageAvsVmData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmData>
    {
        internal PureStorageAvsVmData() { }
        public Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.PureStorageAvsVmData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.PureStorageAvsVmData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsVmResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PureStorageAvsVmResource() { }
        public virtual Azure.ResourceManager.PureStorage.PureStorageAvsVmData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storagePoolName, string avsVmId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.PureStorageAvsVmResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStorageAvsVmResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeResource> GetPureStorageAvsVmVolume(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeResource>> GetPureStorageAvsVmVolumeAsync(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeCollection GetPureStorageAvsVmVolumes() { throw null; }
        Azure.ResourceManager.PureStorage.PureStorageAvsVmData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.PureStorageAvsVmData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorage.PureStorageAvsVmResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorage.PureStorageAvsVmResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PureStorageAvsVmVolumeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeResource>, System.Collections.IEnumerable
    {
        protected PureStorageAvsVmVolumeCollection() { }
        public virtual Azure.Response<bool> Exists(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeResource> Get(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeResource>> GetAsync(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeResource> GetIfExists(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeResource>> GetIfExistsAsync(string volumeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PureStorageAvsVmVolumeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeData>
    {
        internal PureStorageAvsVmVolumeData() { }
        public Azure.ResourceManager.PureStorage.Models.PureStorageVolumeProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsVmVolumeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PureStorageAvsVmVolumeResource() { }
        public virtual Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storagePoolName, string avsVmId, string volumeId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class PureStorageExtensions
    {
        public static Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerResource GetPureStorageAvsStorageContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeResource GetPureStorageAvsStorageContainerVolumeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PureStorage.PureStorageAvsVmResource GetPureStorageAvsVmResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeResource GetPureStorageAvsVmVolumeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PureStorage.PureStoragePoolResource> GetPureStoragePool(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStoragePoolResource>> GetPureStoragePoolAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PureStorage.PureStoragePoolResource GetPureStoragePoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PureStorage.PureStoragePoolCollection GetPureStoragePools(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PureStorage.PureStoragePoolResource> GetPureStoragePools(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PureStorage.PureStoragePoolResource> GetPureStoragePoolsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PureStorage.PureStorageReservationResource> GetPureStorageReservation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStorageReservationResource>> GetPureStorageReservationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PureStorage.PureStorageReservationResource GetPureStorageReservationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PureStorage.PureStorageReservationCollection GetPureStorageReservations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PureStorage.PureStorageReservationResource> GetPureStorageReservations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PureStorage.PureStorageReservationResource> GetPureStorageReservationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PureStoragePoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorage.PureStoragePoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorage.PureStoragePoolResource>, System.Collections.IEnumerable
    {
        protected PureStoragePoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorage.PureStoragePoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storagePoolName, Azure.ResourceManager.PureStorage.PureStoragePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorage.PureStoragePoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storagePoolName, Azure.ResourceManager.PureStorage.PureStoragePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.PureStoragePoolResource> Get(string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorage.PureStoragePoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorage.PureStoragePoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStoragePoolResource>> GetAsync(string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PureStorage.PureStoragePoolResource> GetIfExists(string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PureStorage.PureStoragePoolResource>> GetIfExistsAsync(string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PureStorage.PureStoragePoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorage.PureStoragePoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PureStorage.PureStoragePoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorage.PureStoragePoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PureStoragePoolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStoragePoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStoragePoolData>
    {
        public PureStoragePoolData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.PureStorage.Models.PureStoragePoolProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.PureStoragePoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStoragePoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStoragePoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.PureStoragePoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStoragePoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStoragePoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStoragePoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStoragePoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStoragePoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStoragePoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PureStoragePoolResource() { }
        public virtual Azure.ResourceManager.PureStorage.PureStoragePoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.PureStoragePoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStoragePoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storagePoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DisableAvsConnection(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DisableAvsConnectionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation EnableAvsConnection(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorage.Models.StoragePoolEnableAvsConnectionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> EnableAvsConnectionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorage.Models.StoragePoolEnableAvsConnectionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation FinalizeAvsConnection(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorage.Models.StoragePoolFinalizeAvsConnectionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FinalizeAvsConnectionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorage.Models.StoragePoolFinalizeAvsConnectionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.PureStoragePoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStoragePoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.Models.PureStorageAvsConnection> GetAvsConnection(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.Models.PureStorageAvsConnection>> GetAvsConnectionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.Models.PureStorageAvsStatus> GetAvsStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.Models.PureStorageAvsStatus>> GetAvsStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.Models.StoragePoolHealthInfo> GetHealthStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.Models.StoragePoolHealthInfo>> GetHealthStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerResource> GetPureStorageAvsStorageContainer(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerResource>> GetPureStorageAvsStorageContainerAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerCollection GetPureStorageAvsStorageContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.PureStorageAvsVmResource> GetPureStorageAvsVm(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStorageAvsVmResource>> GetPureStorageAvsVmAsync(string avsVmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PureStorage.PureStorageAvsVmCollection GetPureStorageAvsVms() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.PureStoragePoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStoragePoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RepairAvsConnection(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RepairAvsConnectionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.PureStoragePoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStoragePoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PureStorage.PureStoragePoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStoragePoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStoragePoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.PureStoragePoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStoragePoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStoragePoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStoragePoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorage.PureStoragePoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorage.Models.PureStoragePoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorage.PureStoragePoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorage.Models.PureStoragePoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PureStorageReservationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorage.PureStorageReservationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorage.PureStorageReservationResource>, System.Collections.IEnumerable
    {
        protected PureStorageReservationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorage.PureStorageReservationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string reservationName, Azure.ResourceManager.PureStorage.PureStorageReservationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorage.PureStorageReservationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string reservationName, Azure.ResourceManager.PureStorage.PureStorageReservationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.PureStorageReservationResource> Get(string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorage.PureStorageReservationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorage.PureStorageReservationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStorageReservationResource>> GetAsync(string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PureStorage.PureStorageReservationResource> GetIfExists(string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PureStorage.PureStorageReservationResource>> GetIfExistsAsync(string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PureStorage.PureStorageReservationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PureStorage.PureStorageReservationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PureStorage.PureStorageReservationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorage.PureStorageReservationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PureStorageReservationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageReservationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageReservationData>
    {
        public PureStorageReservationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.PureStorage.Models.PureStorageReservationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.PureStorageReservationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageReservationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageReservationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.PureStorageReservationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageReservationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageReservationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageReservationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageReservationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageReservationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageReservationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PureStorageReservationResource() { }
        public virtual Azure.ResourceManager.PureStorage.PureStorageReservationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.PureStorageReservationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStorageReservationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string reservationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.PureStorageReservationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStorageReservationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.Models.ReservationBillingUsageReport> GetBillingReport(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.Models.ReservationBillingUsageReport>> GetBillingReportAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.Models.ReservationBillingStatus> GetBillingStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.Models.ReservationBillingStatus>> GetBillingStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.Models.PureStorageResourceLimitDetails> GetResourceLimits(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.Models.PureStorageResourceLimitDetails>> GetResourceLimitsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.PureStorageReservationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStorageReservationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.PureStorageReservationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStorageReservationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PureStorage.PureStorageReservationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageReservationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.PureStorageReservationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.PureStorageReservationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageReservationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageReservationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.PureStorageReservationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorage.PureStorageReservationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorage.Models.PureStorageReservationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PureStorage.PureStorageReservationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PureStorage.Models.PureStorageReservationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PureStorage.Mocking
{
    public partial class MockablePureStorageArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePureStorageArmClient() { }
        public virtual Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerResource GetPureStorageAvsStorageContainerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeResource GetPureStorageAvsStorageContainerVolumeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PureStorage.PureStorageAvsVmResource GetPureStorageAvsVmResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeResource GetPureStorageAvsVmVolumeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PureStorage.PureStoragePoolResource GetPureStoragePoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PureStorage.PureStorageReservationResource GetPureStorageReservationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockablePureStorageResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePureStorageResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.PureStoragePoolResource> GetPureStoragePool(string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStoragePoolResource>> GetPureStoragePoolAsync(string storagePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PureStorage.PureStoragePoolCollection GetPureStoragePools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PureStorage.PureStorageReservationResource> GetPureStorageReservation(string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PureStorage.PureStorageReservationResource>> GetPureStorageReservationAsync(string reservationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PureStorage.PureStorageReservationCollection GetPureStorageReservations() { throw null; }
    }
    public partial class MockablePureStorageSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePureStorageSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorage.PureStoragePoolResource> GetPureStoragePools(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorage.PureStoragePoolResource> GetPureStoragePoolsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PureStorage.PureStorageReservationResource> GetPureStorageReservations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PureStorage.PureStorageReservationResource> GetPureStorageReservationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PureStorage.Models
{
    public static partial class ArmPureStorageModelFactory
    {
        public static Azure.ResourceManager.PureStorage.Models.PerformancePolicyLimits PerformancePolicyLimits(Azure.ResourceManager.PureStorage.Models.PropertyValueRangeLimits iopsLimit = null, Azure.ResourceManager.PureStorage.Models.PropertyValueRangeLimits bandwidthLimit = null) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PropertyValueRangeLimits PropertyValueRangeLimits(long min = (long)0, long max = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.ProtectionPolicyLimits ProtectionPolicyLimits(Azure.ResourceManager.PureStorage.Models.PropertyValueRangeLimits frequency = null, Azure.ResourceManager.PureStorage.Models.PropertyValueRangeLimits retention = null) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageAvs PureStorageAvs(bool isAvsEnabled = false, Azure.Core.ResourceIdentifier clusterResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageAvsConnection PureStorageAvsConnection(bool isServiceInitializationCompleted = false, string serviceInitializationHandleEnc = null, Azure.ResourceManager.PureStorage.Models.ServiceInitializationHandle serviceInitializationHandle = null) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageAvsDiskDetails PureStorageAvsDiskDetails(string diskId = null, string diskName = null, string folder = null, string avsVmInternalId = null, Azure.Core.ResourceIdentifier avsVmResourceId = null, string avsVmName = null, Azure.Core.ResourceIdentifier avsStorageContainerResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageAvsStatus PureStorageAvsStatus(bool isAvsEnabled = false, string currentConnectionStatus = null, Azure.Core.ResourceIdentifier clusterResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerData PureStorageAvsStorageContainerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PureStorage.Models.PureStorageAvsStorageContainerProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageAvsStorageContainerProperties PureStorageAvsStorageContainerProperties(Azure.ResourceManager.PureStorage.Models.PureStorageSpaceUsage space = null, string resourceName = null, long? provisionedLimit = default(long?), string datastore = null, bool? mounted = default(bool?)) { throw null; }
        public static Azure.ResourceManager.PureStorage.PureStorageAvsStorageContainerVolumeData PureStorageAvsStorageContainerVolumeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PureStorage.Models.PureStorageVolumeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorage.PureStorageAvsVmData PureStorageAvsVmData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmDetails PureStorageAvsVmDetails(string vmId = null, string vmName = null, Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmType vmType = default(Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmType), string avsVmInternalId = null) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmProperties PureStorageAvsVmProperties(string storagePoolInternalId = null, Azure.Core.ResourceIdentifier storagePoolResourceId = null, string displayName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.PureStorage.Models.PureStorageSoftDeletionState softDeletion = null, Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumeContainerType? volumeContainerType = default(Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumeContainerType?), Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmDetails avs = null, Azure.ResourceManager.PureStorage.Models.PureStorageSpaceUsage space = null, Azure.ResourceManager.PureStorage.Models.PureStorageResourceProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorage.Models.PureStorageResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PureStorage.PureStorageAvsVmVolumeData PureStorageAvsVmVolumeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PureStorage.Models.PureStorageVolumeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageBandwidthUsage PureStorageBandwidthUsage(long current = (long)0, long provisioned = (long)0, long max = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageProperty PureStorageBillingUsageProperty(string propertyId = null, string propertyName = null, string currentValue = null, string previousValue = null, Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageSeverity severity = default(Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageSeverity), string statusMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageProperty> subProperties = null) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlert PureStorageHealthAlert(Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlertLevel level = default(Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlertLevel), string message = null) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageHealthDetails PureStorageHealthDetails(double usedCapacityPercentage = 0, Azure.ResourceManager.PureStorage.Models.PureStorageBandwidthUsage bandwidthUsage = null, Azure.ResourceManager.PureStorage.Models.PureStorageIopsUsage iopsUsage = null, Azure.ResourceManager.PureStorage.Models.PureStorageSpaceUsage space = null, double dataReductionRatio = 0, long estimatedMaxCapacity = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageIopsUsage PureStorageIopsUsage(long current = (long)0, long provisioned = (long)0, long max = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceDetails PureStorageMarketplaceDetails(string subscriptionId = null, Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceSubscriptionStatus? subscriptionStatus = default(Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceSubscriptionStatus?), Azure.ResourceManager.PureStorage.Models.PureStorageOfferDetails offerDetails = null) { throw null; }
        public static Azure.ResourceManager.PureStorage.PureStoragePoolData PureStoragePoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PureStorage.Models.PureStoragePoolProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStoragePoolProperties PureStoragePoolProperties(string storagePoolInternalId = null, string availabilityZone = null, Azure.ResourceManager.PureStorage.Models.PureStoragePoolVnetInjection vnetInjection = null, long? dataRetentionPeriod = default(long?), long provisionedBandwidthMbPerSec = (long)0, long? provisionedIops = default(long?), Azure.ResourceManager.PureStorage.Models.PureStorageAvs avs = null, Azure.ResourceManager.PureStorage.Models.PureStorageProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorage.Models.PureStorageProvisioningState?), Azure.Core.ResourceIdentifier reservationResourceId = null) { throw null; }
        public static Azure.ResourceManager.PureStorage.PureStorageReservationData PureStorageReservationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PureStorage.Models.PureStorageReservationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageReservationProperties PureStorageReservationProperties(string reservationInternalId = null, Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceDetails marketplace = null, Azure.ResourceManager.PureStorage.Models.PureStorageUserDetails user = null, Azure.ResourceManager.PureStorage.Models.PureStorageProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorage.Models.PureStorageProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageResourceLimitDetails PureStorageResourceLimitDetails(Azure.ResourceManager.PureStorage.Models.StoragePoolLimits storagePool = null, Azure.ResourceManager.PureStorage.Models.PropertyValueRangeLimits volumeProvisionedSize = null, Azure.ResourceManager.PureStorage.Models.ProtectionPolicyLimits protectionPolicy = null, Azure.ResourceManager.PureStorage.Models.PerformancePolicyLimits performancePolicy = null) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageSoftDeletionState PureStorageSoftDeletionState(bool isDestroyed = false, System.DateTimeOffset? eradicatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageSpaceUsage PureStorageSpaceUsage(long totalUsed = (long)0, long unique = (long)0, long snapshots = (long)0, long shared = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageVolumeProperties PureStorageVolumeProperties(string storagePoolInternalId = null, Azure.Core.ResourceIdentifier storagePoolResourceId = null, string volumeInternalId = null, string displayName = null, Azure.ResourceManager.PureStorage.Models.PureStorageSpaceUsage space = null, Azure.ResourceManager.PureStorage.Models.PureStorageSoftDeletionState softDeletion = null, string createdTimestamp = null, long? provisionedSize = default(long?), Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumeType? volumeType = default(Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumeType?), Azure.ResourceManager.PureStorage.Models.PureStorageAvsDiskDetails avs = null, Azure.ResourceManager.PureStorage.Models.PureStorageResourceProvisioningState? provisioningState = default(Azure.ResourceManager.PureStorage.Models.PureStorageResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.ReservationBillingStatus ReservationBillingStatus(string timestamp = null, long totalUsedCapacityReported = (long)0, int lowDrrPoolCount = 0, double drrWeightedAverage = 0, long totalNonReducibleReported = (long)0, long extraUsedCapacityNonReducible = (long)0, long extraUsedCapacityLowUsageRounding = (long)0, long extraUsedCapacityNonReduciblePlanDiscount = (long)0, long totalUsedCapacityBilled = (long)0, long totalUsedCapacityIncludedPlan = (long)0, long totalUsedCapacityOverage = (long)0, long totalPerformanceReported = (long)0, long totalPerformanceIncludedPlan = (long)0, long totalPerformanceOverage = (long)0) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.ReservationBillingUsageReport ReservationBillingUsageReport(string timestamp = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageProperty> billingUsageProperties = null, string overallStatusMessage = null) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.ServiceInitializationHandle ServiceInitializationHandle(Azure.Core.ResourceIdentifier clusterResourceId = null, string serviceAccountUsername = null) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.StoragePoolHealthInfo StoragePoolHealthInfo(Azure.ResourceManager.PureStorage.Models.PureStorageHealthDetails health = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlert> alerts = null) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.StoragePoolLimits StoragePoolLimits(Azure.ResourceManager.PureStorage.Models.PropertyValueRangeLimits provisionedBandwidthMbPerSec = null, Azure.ResourceManager.PureStorage.Models.PropertyValueRangeLimits provisionedIops = null, System.Collections.Generic.IEnumerable<string> physicalAvailabilityZones = null) { throw null; }
    }
    public partial class PerformancePolicyLimits : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PerformancePolicyLimits>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PerformancePolicyLimits>
    {
        internal PerformancePolicyLimits() { }
        public Azure.ResourceManager.PureStorage.Models.PropertyValueRangeLimits BandwidthLimit { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.PropertyValueRangeLimits IopsLimit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PerformancePolicyLimits System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PerformancePolicyLimits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PerformancePolicyLimits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PerformancePolicyLimits System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PerformancePolicyLimits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PerformancePolicyLimits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PerformancePolicyLimits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PropertyValueRangeLimits : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PropertyValueRangeLimits>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PropertyValueRangeLimits>
    {
        internal PropertyValueRangeLimits() { }
        public long Max { get { throw null; } }
        public long Min { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PropertyValueRangeLimits System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PropertyValueRangeLimits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PropertyValueRangeLimits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PropertyValueRangeLimits System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PropertyValueRangeLimits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PropertyValueRangeLimits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PropertyValueRangeLimits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProtectionPolicyLimits : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.ProtectionPolicyLimits>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.ProtectionPolicyLimits>
    {
        internal ProtectionPolicyLimits() { }
        public Azure.ResourceManager.PureStorage.Models.PropertyValueRangeLimits Frequency { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.PropertyValueRangeLimits Retention { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.ProtectionPolicyLimits System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.ProtectionPolicyLimits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.ProtectionPolicyLimits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.ProtectionPolicyLimits System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.ProtectionPolicyLimits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.ProtectionPolicyLimits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.ProtectionPolicyLimits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAddressDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAddressDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAddressDetails>
    {
        public PureStorageAddressDetails(string addressLine1, string city, string state, string country, string postalCode) { }
        public string AddressLine1 { get { throw null; } set { } }
        public string AddressLine2 { get { throw null; } set { } }
        public string City { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string PostalCode { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageAddressDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAddressDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAddressDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageAddressDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAddressDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAddressDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAddressDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvs : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvs>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvs>
    {
        internal PureStorageAvs() { }
        public Azure.Core.ResourceIdentifier ClusterResourceId { get { throw null; } }
        public bool IsAvsEnabled { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageAvs System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageAvs System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsConnection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsConnection>
    {
        internal PureStorageAvsConnection() { }
        public bool IsServiceInitializationCompleted { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.ServiceInitializationHandle ServiceInitializationHandle { get { throw null; } }
        public string ServiceInitializationHandleEnc { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageAvsConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageAvsConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsDiskDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsDiskDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsDiskDetails>
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
        Azure.ResourceManager.PureStorage.Models.PureStorageAvsDiskDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsDiskDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsDiskDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageAvsDiskDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsDiskDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsDiskDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsDiskDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsStatus>
    {
        internal PureStorageAvsStatus() { }
        public Azure.Core.ResourceIdentifier ClusterResourceId { get { throw null; } }
        public string CurrentConnectionStatus { get { throw null; } }
        public bool IsAvsEnabled { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageAvsStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageAvsStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsStorageContainerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsStorageContainerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsStorageContainerProperties>
    {
        internal PureStorageAvsStorageContainerProperties() { }
        public string Datastore { get { throw null; } }
        public bool? Mounted { get { throw null; } }
        public long? ProvisionedLimit { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.PureStorageSpaceUsage Space { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageAvsStorageContainerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsStorageContainerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsStorageContainerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageAvsStorageContainerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsStorageContainerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsStorageContainerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsStorageContainerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsStorageContainerVolumePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsStorageContainerVolumePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsStorageContainerVolumePatch>
    {
        public PureStorageAvsStorageContainerVolumePatch() { }
        public Azure.ResourceManager.PureStorage.Models.PureStorageSoftDeletionState AvsStorageContainerVolumeUpdateSoftDeletion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageAvsStorageContainerVolumePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsStorageContainerVolumePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsStorageContainerVolumePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageAvsStorageContainerVolumePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsStorageContainerVolumePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsStorageContainerVolumePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsStorageContainerVolumePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsVmDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmDetails>
    {
        internal PureStorageAvsVmDetails() { }
        public string AvsVmInternalId { get { throw null; } }
        public string VmId { get { throw null; } }
        public string VmName { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmType VmType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsVmPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmPatch>
    {
        public PureStorageAvsVmPatch() { }
        public Azure.ResourceManager.PureStorage.Models.PureStorageSoftDeletionState AvsVmUpdateSoftDeletion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageAvsVmProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmProperties>
    {
        internal PureStorageAvsVmProperties() { }
        public Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmDetails Avs { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.PureStorageResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.PureStorageSoftDeletionState SoftDeletion { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.PureStorageSpaceUsage Space { get { throw null; } }
        public string StoragePoolInternalId { get { throw null; } }
        public Azure.Core.ResourceIdentifier StoragePoolResourceId { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumeContainerType? VolumeContainerType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PureStorageAvsVmType : System.IEquatable<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PureStorageAvsVmType(string value) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmType VVol { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmType left, Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmType left, Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PureStorageAvsVmVolumeContainerType : System.IEquatable<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumeContainerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PureStorageAvsVmVolumeContainerType(string value) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumeContainerType AVS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumeContainerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumeContainerType left, Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumeContainerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumeContainerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumeContainerType left, Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumeContainerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PureStorageAvsVmVolumePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumePatch>
    {
        public PureStorageAvsVmVolumePatch() { }
        public Azure.ResourceManager.PureStorage.Models.PureStorageSoftDeletionState AvsVmVolumeUpdateSoftDeletion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PureStorageAvsVmVolumeType : System.IEquatable<Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PureStorageAvsVmVolumeType(string value) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumeType AVS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumeType left, Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumeType left, Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PureStorageBandwidthUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageBandwidthUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageBandwidthUsage>
    {
        internal PureStorageBandwidthUsage() { }
        public long Current { get { throw null; } }
        public long Max { get { throw null; } }
        public long Provisioned { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageBandwidthUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageBandwidthUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageBandwidthUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageBandwidthUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageBandwidthUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageBandwidthUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageBandwidthUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageBillingUsageProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageProperty>
    {
        internal PureStorageBillingUsageProperty() { }
        public string CurrentValue { get { throw null; } }
        public string PreviousValue { get { throw null; } }
        public string PropertyId { get { throw null; } }
        public string PropertyName { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageSeverity Severity { get { throw null; } }
        public string StatusMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageProperty> SubProperties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PureStorageBillingUsageSeverity : System.IEquatable<Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PureStorageBillingUsageSeverity(string value) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageSeverity ALERT { get { throw null; } }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageSeverity INFORMATION { get { throw null; } }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageSeverity NONE { get { throw null; } }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageSeverity WARNING { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageSeverity left, Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageSeverity left, Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PureStorageCompanyDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageCompanyDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageCompanyDetails>
    {
        public PureStorageCompanyDetails(string companyName) { }
        public Azure.ResourceManager.PureStorage.Models.PureStorageAddressDetails Address { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageCompanyDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageCompanyDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageCompanyDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageCompanyDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageCompanyDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageCompanyDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageCompanyDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageHealthAlert : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlert>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlert>
    {
        internal PureStorageHealthAlert() { }
        public Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlertLevel Level { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlert System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlert>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlert>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlert System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlert>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlert>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlert>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PureStorageHealthAlertLevel : System.IEquatable<Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlertLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PureStorageHealthAlertLevel(string value) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlertLevel Error { get { throw null; } }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlertLevel Info { get { throw null; } }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlertLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlertLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlertLevel left, Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlertLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlertLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlertLevel left, Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlertLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PureStorageHealthDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageHealthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageHealthDetails>
    {
        internal PureStorageHealthDetails() { }
        public Azure.ResourceManager.PureStorage.Models.PureStorageBandwidthUsage BandwidthUsage { get { throw null; } }
        public double DataReductionRatio { get { throw null; } }
        public long EstimatedMaxCapacity { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.PureStorageIopsUsage IopsUsage { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.PureStorageSpaceUsage Space { get { throw null; } }
        public double UsedCapacityPercentage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageHealthDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageHealthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageHealthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageHealthDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageHealthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageHealthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageHealthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageIopsUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageIopsUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageIopsUsage>
    {
        internal PureStorageIopsUsage() { }
        public long Current { get { throw null; } }
        public long Max { get { throw null; } }
        public long Provisioned { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageIopsUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageIopsUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageIopsUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageIopsUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageIopsUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageIopsUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageIopsUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageMarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceDetails>
    {
        public PureStorageMarketplaceDetails(Azure.ResourceManager.PureStorage.Models.PureStorageOfferDetails offerDetails) { }
        public Azure.ResourceManager.PureStorage.Models.PureStorageOfferDetails OfferDetails { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceSubscriptionStatus? SubscriptionStatus { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PureStorageMarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PureStorageMarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceSubscriptionStatus left, Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceSubscriptionStatus left, Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PureStorageOfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageOfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageOfferDetails>
    {
        public PureStorageOfferDetails(string publisherId, string offerId, string planId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageOfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageOfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageOfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageOfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageOfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageOfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageOfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStoragePoolPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStoragePoolPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStoragePoolPatch>
    {
        public PureStoragePoolPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public long? StoragePoolUpdateProvisionedBandwidthMbPerSec { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStoragePoolPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStoragePoolPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStoragePoolPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStoragePoolPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStoragePoolPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStoragePoolPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStoragePoolPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStoragePoolProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStoragePoolProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStoragePoolProperties>
    {
        public PureStoragePoolProperties(string availabilityZone, Azure.ResourceManager.PureStorage.Models.PureStoragePoolVnetInjection vnetInjection, long provisionedBandwidthMbPerSec, Azure.Core.ResourceIdentifier reservationResourceId) { }
        public string AvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.PureStorage.Models.PureStorageAvs Avs { get { throw null; } }
        public long? DataRetentionPeriod { get { throw null; } }
        public long ProvisionedBandwidthMbPerSec { get { throw null; } set { } }
        public long? ProvisionedIops { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.PureStorageProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ReservationResourceId { get { throw null; } set { } }
        public string StoragePoolInternalId { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.PureStoragePoolVnetInjection VnetInjection { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStoragePoolProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStoragePoolProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStoragePoolProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStoragePoolProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStoragePoolProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStoragePoolProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStoragePoolProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStoragePoolVnetInjection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStoragePoolVnetInjection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStoragePoolVnetInjection>
    {
        public PureStoragePoolVnetInjection(Azure.Core.ResourceIdentifier subnetId, Azure.Core.ResourceIdentifier vnetId) { }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VnetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStoragePoolVnetInjection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStoragePoolVnetInjection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStoragePoolVnetInjection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStoragePoolVnetInjection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStoragePoolVnetInjection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStoragePoolVnetInjection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStoragePoolVnetInjection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PureStorageProvisioningState : System.IEquatable<Azure.ResourceManager.PureStorage.Models.PureStorageProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PureStorageProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorage.Models.PureStorageProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorage.Models.PureStorageProvisioningState left, Azure.ResourceManager.PureStorage.Models.PureStorageProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorage.Models.PureStorageProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorage.Models.PureStorageProvisioningState left, Azure.ResourceManager.PureStorage.Models.PureStorageProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PureStorageReservationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageReservationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageReservationPatch>
    {
        public PureStorageReservationPatch() { }
        public Azure.ResourceManager.PureStorage.Models.PureStorageUserDetails ReservationUpdateUser { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageReservationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageReservationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageReservationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageReservationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageReservationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageReservationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageReservationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageReservationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageReservationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageReservationProperties>
    {
        public PureStorageReservationProperties(Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceDetails marketplace, Azure.ResourceManager.PureStorage.Models.PureStorageUserDetails user) { }
        public Azure.ResourceManager.PureStorage.Models.PureStorageMarketplaceDetails Marketplace { get { throw null; } set { } }
        public Azure.ResourceManager.PureStorage.Models.PureStorageProvisioningState? ProvisioningState { get { throw null; } }
        public string ReservationInternalId { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.PureStorageUserDetails User { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageReservationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageReservationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageReservationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageReservationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageReservationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageReservationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageReservationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageResourceLimitDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageResourceLimitDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageResourceLimitDetails>
    {
        internal PureStorageResourceLimitDetails() { }
        public Azure.ResourceManager.PureStorage.Models.PerformancePolicyLimits PerformancePolicy { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.ProtectionPolicyLimits ProtectionPolicy { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.StoragePoolLimits StoragePool { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.PropertyValueRangeLimits VolumeProvisionedSize { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageResourceLimitDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageResourceLimitDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageResourceLimitDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageResourceLimitDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageResourceLimitDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageResourceLimitDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageResourceLimitDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PureStorageResourceProvisioningState : System.IEquatable<Azure.ResourceManager.PureStorage.Models.PureStorageResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PureStorageResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PureStorage.Models.PureStorageResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PureStorage.Models.PureStorageResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PureStorage.Models.PureStorageResourceProvisioningState left, Azure.ResourceManager.PureStorage.Models.PureStorageResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PureStorage.Models.PureStorageResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PureStorage.Models.PureStorageResourceProvisioningState left, Azure.ResourceManager.PureStorage.Models.PureStorageResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PureStorageSoftDeletionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageSoftDeletionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageSoftDeletionState>
    {
        public PureStorageSoftDeletionState(bool isDestroyed) { }
        public System.DateTimeOffset? EradicatedOn { get { throw null; } }
        public bool IsDestroyed { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageSoftDeletionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageSoftDeletionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageSoftDeletionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageSoftDeletionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageSoftDeletionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageSoftDeletionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageSoftDeletionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageSpaceUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageSpaceUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageSpaceUsage>
    {
        internal PureStorageSpaceUsage() { }
        public long Shared { get { throw null; } }
        public long Snapshots { get { throw null; } }
        public long TotalUsed { get { throw null; } }
        public long Unique { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageSpaceUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageSpaceUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageSpaceUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageSpaceUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageSpaceUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageSpaceUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageSpaceUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageUserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageUserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageUserDetails>
    {
        public PureStorageUserDetails(string firstName, string lastName, string emailAddress) { }
        public Azure.ResourceManager.PureStorage.Models.PureStorageCompanyDetails CompanyDetails { get { throw null; } set { } }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageUserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageUserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageUserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageUserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageUserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageUserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageUserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStorageVolumeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageVolumeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageVolumeProperties>
    {
        internal PureStorageVolumeProperties() { }
        public Azure.ResourceManager.PureStorage.Models.PureStorageAvsDiskDetails Avs { get { throw null; } }
        public string CreatedTimestamp { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public long? ProvisionedSize { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.PureStorageResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.PureStorageSoftDeletionState SoftDeletion { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.PureStorageSpaceUsage Space { get { throw null; } }
        public string StoragePoolInternalId { get { throw null; } }
        public Azure.Core.ResourceIdentifier StoragePoolResourceId { get { throw null; } }
        public string VolumeInternalId { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.PureStorageAvsVmVolumeType? VolumeType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageVolumeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageVolumeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.PureStorageVolumeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.PureStorageVolumeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageVolumeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageVolumeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.PureStorageVolumeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReservationBillingStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.ReservationBillingStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.ReservationBillingStatus>
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
        Azure.ResourceManager.PureStorage.Models.ReservationBillingStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.ReservationBillingStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.ReservationBillingStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.ReservationBillingStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.ReservationBillingStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.ReservationBillingStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.ReservationBillingStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReservationBillingUsageReport : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.ReservationBillingUsageReport>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.ReservationBillingUsageReport>
    {
        internal ReservationBillingUsageReport() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PureStorage.Models.PureStorageBillingUsageProperty> BillingUsageProperties { get { throw null; } }
        public string OverallStatusMessage { get { throw null; } }
        public string Timestamp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.ReservationBillingUsageReport System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.ReservationBillingUsageReport>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.ReservationBillingUsageReport>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.ReservationBillingUsageReport System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.ReservationBillingUsageReport>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.ReservationBillingUsageReport>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.ReservationBillingUsageReport>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceInitializationHandle : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.ServiceInitializationHandle>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.ServiceInitializationHandle>
    {
        internal ServiceInitializationHandle() { }
        public Azure.Core.ResourceIdentifier ClusterResourceId { get { throw null; } }
        public string ServiceAccountUsername { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.ServiceInitializationHandle System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.ServiceInitializationHandle>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.ServiceInitializationHandle>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.ServiceInitializationHandle System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.ServiceInitializationHandle>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.ServiceInitializationHandle>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.ServiceInitializationHandle>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceInitializationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.ServiceInitializationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.ServiceInitializationInfo>
    {
        public ServiceInitializationInfo() { }
        public string ServiceAccountPassword { get { throw null; } set { } }
        public string ServiceAccountUsername { get { throw null; } set { } }
        public string VSphereCertificate { get { throw null; } set { } }
        public string VSphereIP { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.ServiceInitializationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.ServiceInitializationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.ServiceInitializationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.ServiceInitializationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.ServiceInitializationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.ServiceInitializationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.ServiceInitializationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StoragePoolEnableAvsConnectionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.StoragePoolEnableAvsConnectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.StoragePoolEnableAvsConnectionContent>
    {
        public StoragePoolEnableAvsConnectionContent(Azure.Core.ResourceIdentifier clusterResourceId) { }
        public Azure.Core.ResourceIdentifier ClusterResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.StoragePoolEnableAvsConnectionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.StoragePoolEnableAvsConnectionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.StoragePoolEnableAvsConnectionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.StoragePoolEnableAvsConnectionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.StoragePoolEnableAvsConnectionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.StoragePoolEnableAvsConnectionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.StoragePoolEnableAvsConnectionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StoragePoolFinalizeAvsConnectionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.StoragePoolFinalizeAvsConnectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.StoragePoolFinalizeAvsConnectionContent>
    {
        public StoragePoolFinalizeAvsConnectionContent() { }
        public Azure.ResourceManager.PureStorage.Models.ServiceInitializationInfo ServiceInitializationData { get { throw null; } set { } }
        public string ServiceInitializationDataEnc { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.StoragePoolFinalizeAvsConnectionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.StoragePoolFinalizeAvsConnectionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.StoragePoolFinalizeAvsConnectionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.StoragePoolFinalizeAvsConnectionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.StoragePoolFinalizeAvsConnectionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.StoragePoolFinalizeAvsConnectionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.StoragePoolFinalizeAvsConnectionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StoragePoolHealthInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.StoragePoolHealthInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.StoragePoolHealthInfo>
    {
        internal StoragePoolHealthInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PureStorage.Models.PureStorageHealthAlert> Alerts { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.PureStorageHealthDetails Health { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.StoragePoolHealthInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.StoragePoolHealthInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.StoragePoolHealthInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.StoragePoolHealthInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.StoragePoolHealthInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.StoragePoolHealthInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.StoragePoolHealthInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StoragePoolLimits : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.StoragePoolLimits>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.StoragePoolLimits>
    {
        internal StoragePoolLimits() { }
        public System.Collections.Generic.IReadOnlyList<string> PhysicalAvailabilityZones { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.PropertyValueRangeLimits ProvisionedBandwidthMbPerSec { get { throw null; } }
        public Azure.ResourceManager.PureStorage.Models.PropertyValueRangeLimits ProvisionedIops { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.StoragePoolLimits System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.StoragePoolLimits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PureStorage.Models.StoragePoolLimits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PureStorage.Models.StoragePoolLimits System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.StoragePoolLimits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.StoragePoolLimits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PureStorage.Models.StoragePoolLimits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
