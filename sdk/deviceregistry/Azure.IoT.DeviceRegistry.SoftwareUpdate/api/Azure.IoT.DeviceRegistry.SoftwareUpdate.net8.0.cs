namespace Azure.IoT.DeviceRegistry._SoftwareUpdate
{
    public partial class AzureIoTDeviceRegistry_SoftwareUpdateContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureIoTDeviceRegistry_SoftwareUpdateContext() { }
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.AzureIoTDeviceRegistry_SoftwareUpdateContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BestCompatibleUpdate : System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.BestCompatibleUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.BestCompatibleUpdate>
    {
        internal BestCompatibleUpdate() { }
        public Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateId UpdateId { get { throw null; } }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.BestCompatibleUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.BestCompatibleUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.BestCompatibleUpdate System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.BestCompatibleUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.BestCompatibleUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.BestCompatibleUpdate System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.BestCompatibleUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.BestCompatibleUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.BestCompatibleUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceClass : System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClass>, System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClass>
    {
        internal DeviceClass() { }
        public Azure.IoT.DeviceRegistry._SoftwareUpdate.BestCompatibleUpdate BestCompatibleUpdate { get { throw null; } }
        public string DeviceClassId { get { throw null; } }
        public Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClassProperties DeviceClassProperties { get { throw null; } }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClass JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClass (Azure.Response response) { throw null; }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClass PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClass System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClass>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClass>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClass System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClass>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClass>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClass>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceClasses
    {
        protected DeviceClasses() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Delete(string deviceClassId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response Delete(string deviceClassId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string deviceClassId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string deviceClassId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAll(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClass> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAllAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClass> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDeviceClass(string deviceClassId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClass> GetDeviceClass(string deviceClassId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeviceClassAsync(string deviceClassId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClass>> GetDeviceClassAsync(string deviceClassId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceClassProperties : System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClassProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClassProperties>
    {
        internal DeviceClassProperties() { }
        public int AgentProfile { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> CompatProperties { get { throw null; } }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClassProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClassProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClassProperties System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClassProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClassProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClassProperties System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClassProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClassProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClassProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistrySoftwareUpdateClient
    {
        protected DeviceRegistrySoftwareUpdateClient() { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public DeviceRegistrySoftwareUpdateClient(Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceRegistrySoftwareUpdateClientSettings settings) { }
        public DeviceRegistrySoftwareUpdateClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DeviceRegistrySoftwareUpdateClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceRegistrySoftwareUpdateClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClasses GetDeviceClassesClient() { throw null; }
        public virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdate GetSoftwareUpdateClient() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public static partial class DeviceRegistrySoftwareUpdateClientHostExtensions
    {
        public static System.ClientModel.Primitives.IClientBuilder AddDeviceRegistrySoftwareUpdateClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddDeviceRegistrySoftwareUpdateClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName, System.Action<Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceRegistrySoftwareUpdateClientSettings> configureSettings) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedDeviceRegistrySoftwareUpdateClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedDeviceRegistrySoftwareUpdateClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName, System.Action<Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceRegistrySoftwareUpdateClientSettings> configureSettings) { throw null; }
    }
    public partial class DeviceRegistrySoftwareUpdateClientOptions : Azure.Core.ClientOptions
    {
        public DeviceRegistrySoftwareUpdateClientOptions(Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceRegistrySoftwareUpdateClientOptions.ServiceVersion version = Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceRegistrySoftwareUpdateClientOptions.ServiceVersion.V2026_11_02_Preview) { }
        public enum ServiceVersion
        {
            V2026_11_02_Preview = 1,
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public partial class DeviceRegistrySoftwareUpdateClientSettings : System.ClientModel.Primitives.ClientSettings
    {
        public DeviceRegistrySoftwareUpdateClientSettings() { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceRegistrySoftwareUpdateClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    public static partial class DeviceRegistrySoftwareUpdateModelFactory
    {
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.BestCompatibleUpdate BestCompatibleUpdate(Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateId updateId = null) { throw null; }
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClass DeviceClass(string deviceClassId = null, Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClassProperties deviceClassProperties = null, Azure.IoT.DeviceRegistry._SoftwareUpdate.BestCompatibleUpdate bestCompatibleUpdate = null) { throw null; }
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.DeviceClassProperties DeviceClassProperties(System.Collections.Generic.IDictionary<string, string> compatProperties = null, int agentProfile = 0) { throw null; }
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.FileImportMetadata FileImportMetadata(string fileName = null, string url = null) { throw null; }
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportManifestMetadata ImportManifestMetadata(string url = null, long sizeInBytes = (long)0, System.Collections.Generic.IDictionary<string, string> hashes = null) { throw null; }
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateInputItem ImportUpdateInputItem(Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportManifestMetadata importManifest = null, string friendlyName = null, System.Collections.Generic.IEnumerable<Azure.IoT.DeviceRegistry._SoftwareUpdate.FileImportMetadata> files = null) { throw null; }
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateRequest ImportUpdateRequest(System.Collections.Generic.IEnumerable<Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateInputItem> importUpdateInput = null, bool? enableScan = default(bool?)) { throw null; }
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateCompatibility SoftwareUpdateCompatibility(System.Collections.Generic.IReadOnlyDictionary<string, string> additionalProperties = null) { throw null; }
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateInstructions SoftwareUpdateInstructions(System.Collections.Generic.IEnumerable<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateStep> steps = null) { throw null; }
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateStep SoftwareUpdateStep(Azure.IoT.DeviceRegistry._SoftwareUpdate.StepType? type = default(Azure.IoT.DeviceRegistry._SoftwareUpdate.StepType?), string description = null, string handler = null, System.Collections.Generic.IDictionary<string, System.BinaryData> handlerProperties = null, System.Collections.Generic.IEnumerable<string> fileNames = null, Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateId updateId = null) { throw null; }
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateContent UpdateContent(Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateId updateId = null, string description = null, string friendlyName = null, bool? isDeployable = default(bool?), string updateType = null, string installedCriteria = null, System.Collections.Generic.IEnumerable<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateCompatibility> compatibility = null, Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateInstructions instructions = null, System.Collections.Generic.IEnumerable<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateId> referencedBy = null, string scanResult = null, string manifestVersion = null, System.DateTimeOffset importedOn = default(System.DateTimeOffset), System.DateTimeOffset createdOn = default(System.DateTimeOffset), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFile UpdateFile(string fileName = null, long sizeInBytes = (long)0, System.Collections.Generic.IDictionary<string, string> hashes = null, string mimeType = null, string scanResult = null, string scanDetails = null, System.Collections.Generic.IDictionary<string, string> properties = null, string fileId = null, System.Collections.Generic.IEnumerable<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileBase> relatedFiles = null, Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileDownloadHandler downloadHandler = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileBase UpdateFileBase(string fileName = null, long sizeInBytes = (long)0, System.Collections.Generic.IDictionary<string, string> hashes = null, string mimeType = null, string scanResult = null, string scanDetails = null, System.Collections.Generic.IDictionary<string, string> properties = null) { throw null; }
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileDownloadHandler UpdateFileDownloadHandler(string id = null) { throw null; }
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateId UpdateId(string provider = null, string name = null, string version = null) { throw null; }
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateInfo UpdateInfo(Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateId updateId = null, string description = null, string friendlyName = null) { throw null; }
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateOperation UpdateOperation(string operationId = null, Azure.IoT.DeviceRegistry._SoftwareUpdate.OperationState status = default(Azure.IoT.DeviceRegistry._SoftwareUpdate.OperationState), Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateInfo update = null, string resourceLocation = null, Azure.ResponseError error = null, string traceId = null, System.DateTimeOffset lastActionOn = default(System.DateTimeOffset), System.DateTimeOffset createdOn = default(System.DateTimeOffset), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
    }
    public partial class FileImportMetadata : System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.FileImportMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.FileImportMetadata>
    {
        public FileImportMetadata(string fileName, string url) { }
        public string FileName { get { throw null; } }
        public string Url { get { throw null; } }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.FileImportMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.FileImportMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.FileImportMetadata System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.FileImportMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.FileImportMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.FileImportMetadata System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.FileImportMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.FileImportMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.FileImportMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImportManifestMetadata : System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportManifestMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportManifestMetadata>
    {
        public ImportManifestMetadata(string url, long sizeInBytes, System.Collections.Generic.IDictionary<string, string> hashes) { }
        public System.Collections.Generic.IDictionary<string, string> Hashes { get { throw null; } }
        public long SizeInBytes { get { throw null; } }
        public string Url { get { throw null; } }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportManifestMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportManifestMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportManifestMetadata System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportManifestMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportManifestMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportManifestMetadata System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportManifestMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportManifestMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportManifestMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImportUpdateInputItem : System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateInputItem>, System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateInputItem>
    {
        public ImportUpdateInputItem(Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportManifestMetadata importManifest) { }
        public System.Collections.Generic.IList<Azure.IoT.DeviceRegistry._SoftwareUpdate.FileImportMetadata> Files { get { throw null; } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportManifestMetadata ImportManifest { get { throw null; } }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateInputItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateInputItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateInputItem System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateInputItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateInputItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateInputItem System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateInputItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateInputItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateInputItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImportUpdateRequest : System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateRequest>
    {
        public ImportUpdateRequest(System.Collections.Generic.IEnumerable<Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateInputItem> importUpdateInput) { }
        public bool? EnableScan { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateInputItem> ImportUpdateInput { get { throw null; } }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateRequest importUpdateRequest) { throw null; }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateRequest System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateRequest System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationState : System.IEquatable<Azure.IoT.DeviceRegistry._SoftwareUpdate.OperationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationState(string value) { throw null; }
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.OperationState Canceled { get { throw null; } }
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.OperationState Failed { get { throw null; } }
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.OperationState NotStarted { get { throw null; } }
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.OperationState Running { get { throw null; } }
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.OperationState Succeeded { get { throw null; } }
        public bool Equals(Azure.IoT.DeviceRegistry._SoftwareUpdate.OperationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.DeviceRegistry._SoftwareUpdate.OperationState left, Azure.IoT.DeviceRegistry._SoftwareUpdate.OperationState right) { throw null; }
        public static implicit operator Azure.IoT.DeviceRegistry._SoftwareUpdate.OperationState (string value) { throw null; }
        public static implicit operator Azure.IoT.DeviceRegistry._SoftwareUpdate.OperationState? (string value) { throw null; }
        public static bool operator !=(Azure.IoT.DeviceRegistry._SoftwareUpdate.OperationState left, Azure.IoT.DeviceRegistry._SoftwareUpdate.OperationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SoftwareUpdate
    {
        protected SoftwareUpdate() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation DeleteUpdate(Azure.WaitUntil waitUntil, string provider, string name, string version, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation DeleteUpdate(Azure.WaitUntil waitUntil, string provider, string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteUpdateAsync(Azure.WaitUntil waitUntil, string provider, string name, string version, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteUpdateAsync(Azure.WaitUntil waitUntil, string provider, string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetFile(string provider, string name, string version, string fileId, Azure.ETag? ifNoneMatch, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFile> GetFile(string provider, string name, string version, string fileId, Azure.ETag? ifNoneMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetFileAsync(string provider, string name, string version, string fileId, Azure.ETag? ifNoneMatch, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFile>> GetFileAsync(string provider, string name, string version, string fileId, Azure.ETag? ifNoneMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetFiles(string provider, string name, string version, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<string> GetFiles(string provider, string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetFilesAsync(string provider, string name, string version, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<string> GetFilesAsync(string provider, string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetNames(string provider, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<string> GetNames(string provider, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetNamesAsync(string provider, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<string> GetNamesAsync(string provider, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetOperationStatus(string operationId, Azure.ETag? ifNoneMatch, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateOperation> GetOperationStatus(string operationId, Azure.ETag? ifNoneMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetOperationStatusAsync(string operationId, Azure.ETag? ifNoneMatch, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateOperation>> GetOperationStatusAsync(string operationId, Azure.ETag? ifNoneMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetOperationStatuses(string filter, int? maxPageSize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateOperation> GetOperationStatuses(string filter = null, int? maxPageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetOperationStatusesAsync(string filter, int? maxPageSize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateOperation> GetOperationStatusesAsync(string filter = null, int? maxPageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetProviders(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<string> GetProviders(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetProvidersAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<string> GetProvidersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetUpdate(string provider, string name, string version, Azure.ETag? ifNoneMatch, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateContent> GetUpdate(string provider, string name, string version, Azure.ETag? ifNoneMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUpdateAsync(string provider, string name, string version, Azure.ETag? ifNoneMatch, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateContent>> GetUpdateAsync(string provider, string name, string version, Azure.ETag? ifNoneMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetUpdates(string search, string filter, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateContent> GetUpdates(string search = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetUpdatesAsync(string search, string filter, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateContent> GetUpdatesAsync(string search = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetVersions(string provider, string name, string filter, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<string> GetVersions(string provider, string name, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetVersionsAsync(string provider, string name, string filter, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<string> GetVersionsAsync(string provider, string name, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation ImportUpdate(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation ImportUpdate(Azure.WaitUntil waitUntil, Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateRequest importUpdateRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportUpdateAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportUpdateAsync(Azure.WaitUntil waitUntil, Azure.IoT.DeviceRegistry._SoftwareUpdate.ImportUpdateRequest importUpdateRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SoftwareUpdateCompatibility : System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateCompatibility>, System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateCompatibility>
    {
        internal SoftwareUpdateCompatibility() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AdditionalProperties { get { throw null; } }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateCompatibility JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateCompatibility PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateCompatibility System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateCompatibility>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateCompatibility>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateCompatibility System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateCompatibility>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateCompatibility>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateCompatibility>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SoftwareUpdateInstructions : System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateInstructions>, System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateInstructions>
    {
        internal SoftwareUpdateInstructions() { }
        public System.Collections.Generic.IList<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateStep> Steps { get { throw null; } }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateInstructions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateInstructions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateInstructions System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateInstructions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateInstructions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateInstructions System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateInstructions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateInstructions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateInstructions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SoftwareUpdateStep : System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateStep>, System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateStep>
    {
        internal SoftwareUpdateStep() { }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IList<string> FileNames { get { throw null; } }
        public string Handler { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> HandlerProperties { get { throw null; } }
        public Azure.IoT.DeviceRegistry._SoftwareUpdate.StepType? Type { get { throw null; } }
        public Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateId UpdateId { get { throw null; } }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateStep JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateStep PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateStep System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateStep System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StepType : System.IEquatable<Azure.IoT.DeviceRegistry._SoftwareUpdate.StepType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StepType(string value) { throw null; }
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.StepType Inline { get { throw null; } }
        public static Azure.IoT.DeviceRegistry._SoftwareUpdate.StepType Reference { get { throw null; } }
        public bool Equals(Azure.IoT.DeviceRegistry._SoftwareUpdate.StepType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.DeviceRegistry._SoftwareUpdate.StepType left, Azure.IoT.DeviceRegistry._SoftwareUpdate.StepType right) { throw null; }
        public static implicit operator Azure.IoT.DeviceRegistry._SoftwareUpdate.StepType (string value) { throw null; }
        public static implicit operator Azure.IoT.DeviceRegistry._SoftwareUpdate.StepType? (string value) { throw null; }
        public static bool operator !=(Azure.IoT.DeviceRegistry._SoftwareUpdate.StepType left, Azure.IoT.DeviceRegistry._SoftwareUpdate.StepType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateContent>
    {
        internal UpdateContent() { }
        public System.Collections.Generic.IList<Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateCompatibility> Compatibility { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ETag? Etag { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public System.DateTimeOffset ImportedOn { get { throw null; } }
        public string InstalledCriteria { get { throw null; } }
        public Azure.IoT.DeviceRegistry._SoftwareUpdate.SoftwareUpdateInstructions Instructions { get { throw null; } }
        public bool? IsDeployable { get { throw null; } }
        public string ManifestVersion { get { throw null; } }
        public System.Collections.Generic.IList<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateId> ReferencedBy { get { throw null; } }
        public string ScanResult { get { throw null; } }
        public Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateId UpdateId { get { throw null; } }
        public string UpdateType { get { throw null; } }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateContent (Azure.Response response) { throw null; }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateContent System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateFile : Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileBase, System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFile>, System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFile>
    {
        internal UpdateFile() { }
        public Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileDownloadHandler DownloadHandler { get { throw null; } }
        public Azure.ETag? Etag { get { throw null; } }
        public string FileId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileBase> RelatedFiles { get { throw null; } }
        protected override Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFile (Azure.Response response) { throw null; }
        protected override Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFile System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFile System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateFileBase : System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileBase>, System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileBase>
    {
        internal UpdateFileBase() { }
        public string FileName { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Hashes { get { throw null; } }
        public string MimeType { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string ScanDetails { get { throw null; } }
        public string ScanResult { get { throw null; } }
        public long SizeInBytes { get { throw null; } }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileBase System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileBase System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateFileDownloadHandler : System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileDownloadHandler>, System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileDownloadHandler>
    {
        internal UpdateFileDownloadHandler() { }
        public string Id { get { throw null; } }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileDownloadHandler JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileDownloadHandler PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileDownloadHandler System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileDownloadHandler>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileDownloadHandler>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileDownloadHandler System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileDownloadHandler>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileDownloadHandler>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateFileDownloadHandler>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateId : System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateId>, System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateId>
    {
        internal UpdateId() { }
        public string Name { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateId JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateId PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateId System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateId System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateInfo : System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateInfo>
    {
        internal UpdateInfo() { }
        public string Description { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateId UpdateId { get { throw null; } }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateInfo System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateInfo System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateOperation : System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateOperation>
    {
        internal UpdateOperation() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ETag? Etag { get { throw null; } }
        public System.DateTimeOffset LastActionOn { get { throw null; } }
        public string OperationId { get { throw null; } }
        public string ResourceLocation { get { throw null; } }
        public Azure.IoT.DeviceRegistry._SoftwareUpdate.OperationState Status { get { throw null; } }
        public string TraceId { get { throw null; } }
        public Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateInfo Update { get { throw null; } }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateOperation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateOperation (Azure.Response response) { throw null; }
        protected virtual Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateOperation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateOperation System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateOperation System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.IoT.DeviceRegistry._SoftwareUpdate.UpdateOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
