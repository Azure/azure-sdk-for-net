namespace Azure.ResourceManager.HorizonDB
{
    public partial class AzureResourceManagerHorizonDBContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerHorizonDBContext() { }
        public static Azure.ResourceManager.HorizonDB.AzureResourceManagerHorizonDBContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class CapabilityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.CapabilityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.CapabilityData>
    {
        internal CapabilityData() { }
        public Azure.ResourceManager.HorizonDB.Models.CapabilityProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.CapabilityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.CapabilityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.CapabilityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.CapabilityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.CapabilityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.CapabilityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.CapabilityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CapabilityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.CapabilityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.CapabilityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CapabilityResource() { }
        public virtual Azure.ResourceManager.HorizonDB.CapabilityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.CapabilityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.CapabilityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.CapabilityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.CapabilityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.CapabilityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.CapabilityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.CapabilityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.CapabilityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.CapabilityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChangeDataCaptureCapabilityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>
    {
        public ChangeDataCaptureCapabilityData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChangeDataCaptureCapabilityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChangeDataCaptureCapabilityResource() { }
        public virtual Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChangeDataCaptureConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource>, System.Collections.IEnumerable
    {
        protected ChangeDataCaptureConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource> GetIfExists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource>> GetIfExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChangeDataCaptureConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>
    {
        public ChangeDataCaptureConfigurationData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChangeDataCaptureConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChangeDataCaptureConfigurationResource() { }
        public virtual Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string configurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChangeDataCaptureDestinationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource>, System.Collections.IEnumerable
    {
        protected ChangeDataCaptureDestinationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string destinationName, Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string destinationName, Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string destinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string destinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource> Get(string destinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource>> GetAsync(string destinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource> GetIfExists(string destinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource>> GetIfExistsAsync(string destinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChangeDataCaptureDestinationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>
    {
        public ChangeDataCaptureDestinationData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChangeDataCaptureDestinationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChangeDataCaptureDestinationResource() { }
        public virtual Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult> ActivateIdentity(Azure.WaitUntil waitUntil, string ifMatch, Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult>> ActivateIdentityAsync(Azure.WaitUntil waitUntil, string ifMatch, Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string destinationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.IdentityAssignmentResource> GetIdentityAssignment(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.IdentityAssignmentResource>> GetIdentityAssignmentAsync(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.IdentityAssignmentCollection GetIdentityAssignments() { throw null; }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DefaultParameterGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.DefaultParameterGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.DefaultParameterGroupResource>, System.Collections.IEnumerable
    {
        protected DefaultParameterGroupCollection() { }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.DefaultParameterGroupResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.DefaultParameterGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.DefaultParameterGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.DefaultParameterGroupResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.DefaultParameterGroupResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.DefaultParameterGroupResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.DefaultParameterGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.DefaultParameterGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.DefaultParameterGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.DefaultParameterGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DefaultParameterGroupData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.DefaultParameterGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.DefaultParameterGroupData>
    {
        internal DefaultParameterGroupData() { }
        public Azure.ResourceManager.HorizonDB.Models.DefaultParameterGroupProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.DefaultParameterGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.DefaultParameterGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.DefaultParameterGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.DefaultParameterGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.DefaultParameterGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.DefaultParameterGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.DefaultParameterGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DefaultParameterGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.DefaultParameterGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.DefaultParameterGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DefaultParameterGroupResource() { }
        public virtual Azure.ResourceManager.HorizonDB.DefaultParameterGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.DefaultParameterGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.DefaultParameterGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.DefaultParameterGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.DefaultParameterGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.DefaultParameterGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.DefaultParameterGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.DefaultParameterGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.DefaultParameterGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.DefaultParameterGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.EndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.EndpointResource>, System.Collections.IEnumerable
    {
        protected EndpointCollection() { }
        public virtual Azure.Response<bool> Exists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.EndpointResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.EndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.EndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.EndpointResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.EndpointResource> GetIfExists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.EndpointResource>> GetIfExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.EndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.EndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.EndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.EndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EndpointData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.EndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.EndpointData>
    {
        internal EndpointData() { }
        public Azure.ResourceManager.HorizonDB.Models.EndpointProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.EndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.EndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.EndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.EndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.EndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.EndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.EndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.EndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.EndpointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EndpointResource() { }
        public virtual Azure.ResourceManager.HorizonDB.EndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string endpointName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.EndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.EndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.EndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.EndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.EndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.EndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.EndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.EndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.EndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.FirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.FirewallRuleResource>, System.Collections.IEnumerable
    {
        protected FirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.FirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.HorizonDB.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.FirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.HorizonDB.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.FirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.FirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.FirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.FirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.FirewallRuleResource> GetIfExists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.FirewallRuleResource>> GetIfExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.FirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.FirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.FirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.FirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FirewallRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.FirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.FirewallRuleData>
    {
        public FirewallRuleData() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.FirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.FirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.FirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.FirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.FirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.FirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.FirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirewallRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.FirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.FirewallRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FirewallRuleResource() { }
        public virtual Azure.ResourceManager.HorizonDB.FirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string poolName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.FirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.FirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.FirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.FirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.FirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.FirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.FirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.FirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.FirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.FirewallRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.FirewallRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HorizonDBClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>, System.Collections.IEnumerable
    {
        protected HorizonDBClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.HorizonDB.HorizonDBClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.HorizonDB.HorizonDBClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDBClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>
    {
        public HorizonDBClusterData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBClusterResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> Failover(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> FailoverAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.Models.Authentication> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.Models.Authentication> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityResource GetChangeDataCaptureCapability() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource> GetChangeDataCaptureConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource>> GetChangeDataCaptureConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationCollection GetChangeDataCaptureConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource> GetChangeDataCaptureDestination(string destinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource>> GetChangeDataCaptureDestinationAsync(string destinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationCollection GetChangeDataCaptureDestinations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.EndpointResource> GetEndpoint(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.EndpointResource>> GetEndpointAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.EndpointCollection GetEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> GetHorizonDBPool(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> GetHorizonDBPoolAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPoolCollection GetHorizonDBPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> GetHorizonDBPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>> GetHorizonDBPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionCollection GetHorizonDBPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource> GetHorizonDBPrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource>> GetHorizonDBPrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceCollection GetHorizonDBPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationResource> GetLogCaptureConfiguration(string logCaptureConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationResource>> GetLogCaptureConfigurationAsync(string logCaptureConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.LogCaptureConfigurationCollection GetLogCaptureConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.LogFileResource> GetLogFile(string logFileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.LogFileResource>> GetLogFileAsync(string logFileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.LogFileCollection GetLogFiles() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource> GetMicrosoftEntraAdministrator(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource>> GetMicrosoftEntraAdministratorAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorCollection GetMicrosoftEntraAdministrators() { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationResource GetMicrosoftEntraAuthentication() { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.PasswordAuthenticationResource GetPasswordAuthentication() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class HorizonDBExtensions
    {
        public static Azure.ResourceManager.HorizonDB.CapabilityResource GetCapability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.HorizonDB.CapabilityResource GetCapabilityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityResource GetChangeDataCaptureCapabilityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource GetChangeDataCaptureConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource GetChangeDataCaptureDestinationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HorizonDB.DefaultParameterGroupResource> GetDefaultParameterGroup(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.DefaultParameterGroupResource>> GetDefaultParameterGroupAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.DefaultParameterGroupResource GetDefaultParameterGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.DefaultParameterGroupCollection GetDefaultParameterGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.ResourceManager.HorizonDB.EndpointResource GetEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.FirewallRuleResource GetFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetHorizonDBCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> GetHorizonDBClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBClusterResource GetHorizonDBClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBClusterCollection GetHorizonDBClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetHorizonDBClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetHorizonDBClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetHorizonDBParameterGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> GetHorizonDBParameterGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource GetHorizonDBParameterGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupCollection GetHorizonDBParameterGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetHorizonDBParameterGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetHorizonDBParameterGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBPoolResource GetHorizonDBPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource GetHorizonDBPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource GetHorizonDBPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.IdentityAssignmentResource GetIdentityAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.LogCaptureConfigurationResource GetLogCaptureConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.LogFileResource GetLogFileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.MaintenanceEventResource GetMaintenanceEventResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource GetMicrosoftEntraAdministratorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationResource GetMicrosoftEntraAuthenticationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.NodeResource GetNodeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.PasswordAuthenticationResource GetPasswordAuthenticationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class HorizonDBParameterGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>, System.Collections.IEnumerable
    {
        protected HorizonDBParameterGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string parameterGroupName, Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string parameterGroupName, Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> Get(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> GetAsync(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetIfExists(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> GetIfExistsAsync(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDBParameterGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>
    {
        public HorizonDBParameterGroupData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBParameterGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBParameterGroupResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parameterGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties> GetConnections(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties> GetConnectionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HorizonDBPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>, System.Collections.IEnumerable
    {
        protected HorizonDBPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string poolName, Azure.ResourceManager.HorizonDB.HorizonDBPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string poolName, Azure.ResourceManager.HorizonDB.HorizonDBPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> Get(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> GetAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> GetIfExists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> GetIfExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDBPoolData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>
    {
        public HorizonDBPoolData() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBPoolResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string poolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.FirewallRuleResource> GetFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.FirewallRuleResource>> GetFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.FirewallRuleCollection GetFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.MaintenanceEventResource> GetMaintenanceEvent(string maintenanceEventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.MaintenanceEventResource>> GetMaintenanceEventAsync(string maintenanceEventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.MaintenanceEventCollection GetMaintenanceEvents() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.NodeResource> GetNode(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.NodeResource>> GetNodeAsync(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.NodeCollection GetNodes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HorizonDBPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected HorizonDBPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDBPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>
    {
        public HorizonDBPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HorizonDBPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBPrivateLinkResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected HorizonDBPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDBPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>
    {
        internal HorizonDBPrivateLinkResourceData() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IdentityAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.IdentityAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.IdentityAssignmentResource>, System.Collections.IEnumerable
    {
        protected IdentityAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.IdentityAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assignmentName, Azure.ResourceManager.HorizonDB.IdentityAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.IdentityAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assignmentName, Azure.ResourceManager.HorizonDB.IdentityAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.IdentityAssignmentResource> Get(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.IdentityAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.IdentityAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.IdentityAssignmentResource>> GetAsync(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.IdentityAssignmentResource> GetIfExists(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.IdentityAssignmentResource>> GetIfExistsAsync(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.IdentityAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.IdentityAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.IdentityAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.IdentityAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IdentityAssignmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.IdentityAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.IdentityAssignmentData>
    {
        public IdentityAssignmentData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.IdentityAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.IdentityAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.IdentityAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.IdentityAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.IdentityAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.IdentityAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.IdentityAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IdentityAssignmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.IdentityAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.IdentityAssignmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IdentityAssignmentResource() { }
        public virtual Azure.ResourceManager.HorizonDB.IdentityAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string destinationName, string assignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.IdentityAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.IdentityAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.IdentityAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.IdentityAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.IdentityAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.IdentityAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.IdentityAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.IdentityAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.IdentityAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.IdentityAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.IdentityAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.IdentityAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.IdentityAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogCaptureConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationResource>, System.Collections.IEnumerable
    {
        protected LogCaptureConfigurationCollection() { }
        public virtual Azure.Response<bool> Exists(string logCaptureConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string logCaptureConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationResource> Get(string logCaptureConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationResource>> GetAsync(string logCaptureConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationResource> GetIfExists(string logCaptureConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationResource>> GetIfExistsAsync(string logCaptureConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogCaptureConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationData>
    {
        internal LogCaptureConfigurationData() { }
        public Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.LogCaptureConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.LogCaptureConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogCaptureConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogCaptureConfigurationResource() { }
        public virtual Azure.ResourceManager.HorizonDB.LogCaptureConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string logCaptureConfigurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.LogCaptureConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.LogCaptureConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.LogCaptureConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogFileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.LogFileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.LogFileResource>, System.Collections.IEnumerable
    {
        protected LogFileCollection() { }
        public virtual Azure.Response<bool> Exists(string logFileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string logFileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.LogFileResource> Get(string logFileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.LogFileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.LogFileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.LogFileResource>> GetAsync(string logFileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.LogFileResource> GetIfExists(string logFileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.LogFileResource>> GetIfExistsAsync(string logFileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.LogFileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.LogFileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.LogFileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.LogFileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogFileData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.LogFileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.LogFileData>
    {
        internal LogFileData() { }
        public Azure.ResourceManager.HorizonDB.Models.LogFileProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.LogFileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.LogFileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.LogFileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.LogFileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.LogFileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.LogFileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.LogFileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogFileResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.LogFileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.LogFileData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogFileResource() { }
        public virtual Azure.ResourceManager.HorizonDB.LogFileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string logFileName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.LogFileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.LogFileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri> GetDownloadUrls(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri>> GetDownloadUrlsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.LogFileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.LogFileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.LogFileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.LogFileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.LogFileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.LogFileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.LogFileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MaintenanceEventCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.MaintenanceEventResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.MaintenanceEventResource>, System.Collections.IEnumerable
    {
        protected MaintenanceEventCollection() { }
        public virtual Azure.Response<bool> Exists(string maintenanceEventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string maintenanceEventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.MaintenanceEventResource> Get(string maintenanceEventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.MaintenanceEventResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.MaintenanceEventResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.MaintenanceEventResource>> GetAsync(string maintenanceEventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.MaintenanceEventResource> GetIfExists(string maintenanceEventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.MaintenanceEventResource>> GetIfExistsAsync(string maintenanceEventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.MaintenanceEventResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.MaintenanceEventResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.MaintenanceEventResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.MaintenanceEventResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MaintenanceEventData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MaintenanceEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MaintenanceEventData>
    {
        internal MaintenanceEventData() { }
        public Azure.ResourceManager.HorizonDB.Models.MaintenanceEventProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.MaintenanceEventData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MaintenanceEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MaintenanceEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.MaintenanceEventData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MaintenanceEventData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MaintenanceEventData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MaintenanceEventData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MaintenanceEventResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MaintenanceEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MaintenanceEventData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MaintenanceEventResource() { }
        public virtual Azure.ResourceManager.HorizonDB.MaintenanceEventData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult> ApplyNow(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult>> ApplyNowAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string poolName, string maintenanceEventId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.MaintenanceEventResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.MaintenanceEventResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult> Reschedule(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult>> RescheduleAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.MaintenanceEventData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MaintenanceEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MaintenanceEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.MaintenanceEventData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MaintenanceEventData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MaintenanceEventData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MaintenanceEventData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftEntraAdministratorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource>, System.Collections.IEnumerable
    {
        protected MicrosoftEntraAdministratorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string objectId, Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorAdd resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string objectId, Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorAdd resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource> Get(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource>> GetAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource> GetIfExists(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource>> GetIfExistsAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MicrosoftEntraAdministratorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>
    {
        internal MicrosoftEntraAdministratorData() { }
        public Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftEntraAdministratorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MicrosoftEntraAdministratorResource() { }
        public virtual Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string objectId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorAdd resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorAdd resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MicrosoftEntraAuthenticationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>
    {
        public MicrosoftEntraAuthenticationData() { }
        public Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftEntraAuthenticationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MicrosoftEntraAuthenticationResource() { }
        public virtual Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NodeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.NodeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.NodeResource>, System.Collections.IEnumerable
    {
        protected NodeCollection() { }
        public virtual Azure.Response<bool> Exists(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.NodeResource> Get(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.NodeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.NodeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.NodeResource>> GetAsync(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.NodeResource> GetIfExists(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.NodeResource>> GetIfExistsAsync(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.NodeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.NodeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.NodeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.NodeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NodeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.NodeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.NodeData>
    {
        internal NodeData() { }
        public Azure.ResourceManager.HorizonDB.Models.NodeProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.NodeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.NodeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.NodeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.NodeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.NodeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.NodeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.NodeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.NodeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.NodeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NodeResource() { }
        public virtual Azure.ResourceManager.HorizonDB.NodeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string poolName, string nodeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.NodeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.NodeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.NodeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.NodeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.NodeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.NodeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.NodeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.NodeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.NodeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PasswordAuthenticationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.PasswordAuthenticationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.PasswordAuthenticationData>
    {
        public PasswordAuthenticationData() { }
        public Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.PasswordAuthenticationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.PasswordAuthenticationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.PasswordAuthenticationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.PasswordAuthenticationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.PasswordAuthenticationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.PasswordAuthenticationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.PasswordAuthenticationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PasswordAuthenticationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.PasswordAuthenticationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.PasswordAuthenticationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PasswordAuthenticationResource() { }
        public virtual Azure.ResourceManager.HorizonDB.PasswordAuthenticationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.PasswordAuthenticationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.PasswordAuthenticationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.PasswordAuthenticationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.PasswordAuthenticationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.PasswordAuthenticationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.PasswordAuthenticationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.PasswordAuthenticationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.PasswordAuthenticationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.PasswordAuthenticationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.PasswordAuthenticationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.PasswordAuthenticationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.PasswordAuthenticationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.PasswordAuthenticationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.PasswordAuthenticationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.PasswordAuthenticationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HorizonDB.Mocking
{
    public partial class MockableHorizonDBArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHorizonDBArmClient() { }
        public virtual Azure.ResourceManager.HorizonDB.CapabilityResource GetCapabilityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityResource GetChangeDataCaptureCapabilityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource GetChangeDataCaptureConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource GetChangeDataCaptureDestinationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.DefaultParameterGroupResource GetDefaultParameterGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.EndpointResource GetEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.FirewallRuleResource GetFirewallRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBClusterResource GetHorizonDBClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource GetHorizonDBParameterGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPoolResource GetHorizonDBPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource GetHorizonDBPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource GetHorizonDBPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.IdentityAssignmentResource GetIdentityAssignmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.LogCaptureConfigurationResource GetLogCaptureConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.LogFileResource GetLogFileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.MaintenanceEventResource GetMaintenanceEventResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource GetMicrosoftEntraAdministratorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationResource GetMicrosoftEntraAuthenticationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.NodeResource GetNodeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.PasswordAuthenticationResource GetPasswordAuthenticationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHorizonDBResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHorizonDBResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetHorizonDBCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> GetHorizonDBClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBClusterCollection GetHorizonDBClusters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetHorizonDBParameterGroup(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> GetHorizonDBParameterGroupAsync(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupCollection GetHorizonDBParameterGroups() { throw null; }
    }
    public partial class MockableHorizonDBSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHorizonDBSubscriptionResource() { }
        public virtual Azure.ResourceManager.HorizonDB.CapabilityResource GetCapability() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.DefaultParameterGroupResource> GetDefaultParameterGroup(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.DefaultParameterGroupResource>> GetDefaultParameterGroupAsync(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.DefaultParameterGroupCollection GetDefaultParameterGroups(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetHorizonDBClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetHorizonDBClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetHorizonDBParameterGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetHorizonDBParameterGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HorizonDB.Models
{
    public partial class ActivateChangeDataCaptureIdentityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult>
    {
        internal ActivateChangeDataCaptureIdentityResult() { }
        public Azure.Core.ResourceIdentifier PreviousIdentityAssignmentResourceId { get { throw null; } }
        public string Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetIdentityAssignmentResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AiModelManagementStatus : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AiModelManagementStatus(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus left, Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus left, Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmHorizonDBModelFactory
    {
        public static Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult ActivateChangeDataCaptureIdentityResult(Azure.Core.ResourceIdentifier targetIdentityAssignmentResourceId = null, Azure.Core.ResourceIdentifier previousIdentityAssignmentResourceId = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.Authentication Authentication(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.AuthenticationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.AuthenticationProperties AuthenticationProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState state = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState), Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.BackupProperties BackupProperties(Azure.ResourceManager.HorizonDB.Models.GeoRedundancyState geoRedundancy = default(Azure.ResourceManager.HorizonDB.Models.GeoRedundancyState), int? retentionDays = default(int?), System.DateTimeOffset? earliestRestorePointUtc = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.CapabilityData CapabilityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.CapabilityProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.CapabilityProperties CapabilityProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?), Azure.ResourceManager.HorizonDB.Models.ClusterCapability clusterCapabilities = null, Azure.ResourceManager.HorizonDB.Models.PoolCapability poolCapabilities = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData ChangeDataCaptureCapabilityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties properties = null, string eTag = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch ChangeDataCaptureCapabilityPatch(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesForPatchUpdate properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties ChangeDataCaptureCapabilityProperties(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState desiredState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState), Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState effectiveState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState), Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?), bool? autoUpgradeExtension = default(bool?), Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture replicationArchitecture = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture), Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus extension = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus prerequisites = null, int destinationCount = 0, int configurationCount = 0, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus status = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesForPatchUpdate ChangeDataCaptureCapabilityPropertiesForPatchUpdate(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState? desiredState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState?), bool? autoUpgradeExtension = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData ChangeDataCaptureConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties properties = null, string eTag = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch ChangeDataCaptureConfigurationPatch(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState? changeDataCaptureConfigurationPropertiesForPatchUpdateDesiredState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties ChangeDataCaptureConfigurationProperties(string databaseName = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile usageProfile = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile), Azure.Core.ResourceIdentifier destinationResourceId = null, string logicalStreamId = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState desiredState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState), Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState effectiveState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState), Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?), Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus extension = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus replication = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus topology = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus status = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData ChangeDataCaptureDestinationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties properties = null, string eTag = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails ChangeDataCaptureDestinationDetails(string destinationType = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol protocol = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch ChangeDataCaptureDestinationPatch(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState? changeDataCaptureDestinationPropertiesForPatchUpdateDesiredState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties ChangeDataCaptureDestinationProperties(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails destination = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState desiredState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState), Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState effectiveState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState), Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?), Azure.Core.ResourceIdentifier activeIdentityAssignmentResourceId = null, int configurationCount = 0, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus status = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus ChangeDataCaptureExtensionStatus(string name = null, string version = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState state = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties ChangeDataCaptureIdentityAssignmentProperties(Azure.Core.ResourceIdentifier identityResourceId = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState effectiveState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState), Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState activationState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState), string principalId = null, string tenantId = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?), Azure.ResourceManager.HorizonDB.Models.IdentityValidationStatus validation = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus status = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus ChangeDataCapturePrerequisiteStatus(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState engineConfigurationState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState), Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState readWriteEndpointState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus ChangeDataCaptureReplicationStatus(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState state = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState), string externalArtifactId = null, System.DateTimeOffset? lastConnectedAtUtc = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus ChangeDataCaptureStatus(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus ChangeDataCaptureTopologyBindingStatus(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState state = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState), long generation = (long)0, Azure.Core.ResourceIdentifier activeClusterResourceId = null, Azure.Core.ResourceIdentifier replacementConfigurationResourceId = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ClusterCapability ClusterCapability(Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion recommendedPostgreSqlVersion = default(Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability> supportedPostgreSqlVersions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.ClusterFeatureCapability> supportedFeatures = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ClusterFeatureCapability ClusterFeatureCapability(string name = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ComputeGenerationCapability ComputeGenerationCapability(int computeGeneration = 0, Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType recommendedComputeModelType = default(Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.ComputeModelCapability> supportedComputeModels = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ComputeModelCapability ComputeModelCapability(string type = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ComputeProcessorCapability ComputeProcessorCapability(Azure.ResourceManager.HorizonDB.Models.ComputeProcessorType name = default(Azure.ResourceManager.HorizonDB.Models.ComputeProcessorType), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.ComputeGenerationCapability> supportedGenerations = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ComputeSizeCapability ComputeSizeCapability(int vCores = 0, long memoryPerVCoreInMb = (long)0) { throw null; }
        public static Azure.ResourceManager.HorizonDB.DefaultParameterGroupData DefaultParameterGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.DefaultParameterGroupProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.DefaultParameterGroupProperties DefaultParameterGroupProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties> parameters = null, string description = null, Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion postgreSqlVersion = default(Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.EndpointData EndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.EndpointProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.EndpointProperties EndpointProperties(Azure.ResourceManager.HorizonDB.Models.EndpointScope scope = default(Azure.ResourceManager.HorizonDB.Models.EndpointScope), Azure.Core.ResourceIdentifier associatedResourceId = null, string fullyQualifiedDomainName = null, Azure.ResourceManager.HorizonDB.Models.EndpointRole role = default(Azure.ResourceManager.HorizonDB.Models.EndpointRole)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.FabricDestinationDetails FabricDestinationDetails(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol protocol = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol), string workspaceId = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.FirewallRuleData FirewallRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent HorizonDBActivateChangeDataCaptureIdentityContent(Azure.Core.ResourceIdentifier identityAssignmentResourceId = null, bool? drainExistingSessions = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBClusterData HorizonDBClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties properties = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption HorizonDBClusterDataEncryption(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType? type = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType?), System.Uri primaryKeyUri = null, Azure.Core.ResourceIdentifier primaryUserAssignedIdentityId = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus? primaryEncryptionKeyStatus = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus?), string primaryEncryptionKeyCurrentVersion = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionForPatchUpdate HorizonDBClusterDataEncryptionForPatchUpdate(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType? type = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType?), System.Uri primaryKeyUri = null, Azure.Core.ResourceIdentifier primaryUserAssignedIdentityId = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity HorizonDBClusterManagedServiceIdentity(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType type = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch HorizonDBClusterPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity identity = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties HorizonDBClusterPatchProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState? networkPublicAccess = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState?), int? backupRetentionDays = default(int?), Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionForPatchUpdate dataEncryption = null, Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus? aiModelManagement = default(Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties HorizonDBClusterProperties(Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion? postgreSqlVersion = default(Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion?), Azure.ResourceManager.HorizonDB.Models.ClusterCreateMode? creationMode = default(Azure.ResourceManager.HorizonDB.Models.ClusterCreateMode?), System.DateTimeOffset? pointInTimeUtc = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier creationSourceClusterResourceId = null, string creationSourceClusterLocation = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState? networkPublicAccess = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState?), Azure.ResourceManager.HorizonDB.Models.BackupProperties backup = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption dataEncryption = null, Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus? aiModelManagement = default(Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus?), Azure.ResourceManager.HorizonDB.Models.ClusterState state = default(Azure.ResourceManager.HorizonDB.Models.ClusterState), Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState), Azure.Core.ResourceIdentifier designatedPoolResourceId = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties HorizonDBFirewallRuleProperties(string startIPAddress = null, string endIPAddress = null, string description = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult HorizonDBMaintenanceEventActionResult(string maintenanceEventId = null, Azure.Core.ResourceIdentifier poolResourceId = null, Azure.ResourceManager.HorizonDB.Models.MaintenanceEventStatus? status = default(Azure.ResourceManager.HorizonDB.Models.MaintenanceEventStatus?), System.DateTimeOffset? plannedStartTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? plannedEndTimeUtc = default(System.DateTimeOffset?), bool? appliedNow = default(bool?), System.DateTimeOffset? lastUpdatedTimeUtc = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent HorizonDBMaintenanceEventRescheduleContent(System.DateTimeOffset postponeToDateTimeUtc = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties HorizonDBParameterGroupConnectionProperties(Azure.Core.ResourceIdentifier poolResourceId = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData HorizonDBParameterGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch HorizonDBParameterGroupPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties HorizonDBParameterGroupPatchProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties> parameters = null, string description = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties HorizonDBParameterGroupProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties> parameters = null, string description = null, Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion postgreSqlVersion = default(Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion), Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties HorizonDBParameterProperties(string name = null, string description = null, string value = null, string defaultValue = null, Azure.ResourceManager.HorizonDB.Models.ParameterValueSource? valueSource = default(Azure.ResourceManager.HorizonDB.Models.ParameterValueSource?), string dataType = null, string allowedValues = null, bool? isDynamic = default(bool?), bool? isReadOnly = default(bool?), System.Uri documentationLink = null, string unit = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBPoolData HorizonDBPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch HorizonDBPoolPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.HorizonDB.Models.PoolPropertiesForPatchUpdate properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties HorizonDBPoolProperties(Azure.ResourceManager.HorizonDB.Models.PoolState? state = default(Azure.ResourceManager.HorizonDB.Models.PoolState?), Azure.ResourceManager.HorizonDB.Models.PoolComputeModel computeModel = null, int nodeCount = 0, Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode highAvailabilityMode = default(Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode), Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference parameterGroup = null, Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceProperties scheduledMaintenance = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData HorizonDBPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties HorizonDBPrivateEndpointConnectionProperties(System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData HorizonDBPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties HorizonDBPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState HorizonDBPrivateLinkServiceConnectionState(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus? status = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus?), string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.IdentityAssignmentData IdentityAssignmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties properties = null, string eTag = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.IdentityValidationStatus IdentityValidationStatus(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState state = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState), System.DateTimeOffset? validatedAtUtc = default(System.DateTimeOffset?), Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.LogCaptureConfigurationData LogCaptureConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPatch LogCaptureConfigurationPatch(Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPropertiesForPatchUpdate properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationProperties LogCaptureConfigurationProperties(Azure.ResourceManager.HorizonDB.Models.LogCaptureState state = default(Azure.ResourceManager.HorizonDB.Models.LogCaptureState), int retentionDays = 0, Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPropertiesForPatchUpdate LogCaptureConfigurationPropertiesForPatchUpdate(Azure.ResourceManager.HorizonDB.Models.LogCaptureState? state = default(Azure.ResourceManager.HorizonDB.Models.LogCaptureState?), int? retentionDays = default(int?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.LogFileData LogFileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.LogFileProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri LogFileDownloadUri(System.Uri downloadUri = null, System.DateTimeOffset expiresAtUtc = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.LogFileProperties LogFileProperties(Azure.ResourceManager.HorizonDB.Models.LogFileType logType = default(Azure.ResourceManager.HorizonDB.Models.LogFileType), System.DateTimeOffset createdAtUtc = default(System.DateTimeOffset), System.DateTimeOffset lastModifiedAtUtc = default(System.DateTimeOffset), System.DateTimeOffset retentionExpiresAtUtc = default(System.DateTimeOffset), bool isMutable = false, long sizeInKilobytes = (long)0, string pool = null, string node = null, Azure.ResourceManager.HorizonDB.Models.NodeRole role = default(Azure.ResourceManager.HorizonDB.Models.NodeRole)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.MaintenanceEventData MaintenanceEventData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.MaintenanceEventProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.MaintenanceEventProperties MaintenanceEventProperties(string maintenanceEventId = null, Azure.ResourceManager.HorizonDB.Models.MaintenanceType maintenanceType = default(Azure.ResourceManager.HorizonDB.Models.MaintenanceType), string description = null, Azure.ResourceManager.HorizonDB.Models.MaintenanceEventStatus status = default(Azure.ResourceManager.HorizonDB.Models.MaintenanceEventStatus), System.DateTimeOffset startTimeUtc = default(System.DateTimeOffset), System.DateTimeOffset endTimeUtc = default(System.DateTimeOffset), System.TimeSpan? estimatedDowntime = default(System.TimeSpan?), bool deferrable = false, System.DateTimeOffset? deferralDeadlineUtc = default(System.DateTimeOffset?), System.DateTimeOffset? rescheduledFromUtc = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset originalStartTimeUtc = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorAdd MicrosoftEntraAdministratorAdd(Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData MicrosoftEntraAdministratorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties MicrosoftEntraAdministratorProperties(string principalName = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType principalType = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType), string objectId = null, string tenantId = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd MicrosoftEntraAdministratorPropertiesForAdd(string principalName = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType principalType = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType), string tenantId = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData MicrosoftEntraAuthenticationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch MicrosoftEntraAuthenticationPatch(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState? microsoftEntraAuthenticationPropertiesForPatchUpdateState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties MicrosoftEntraAuthenticationProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState state = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState), Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.NodeData NodeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.NodeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.NodeProperties NodeProperties(Azure.ResourceManager.HorizonDB.Models.NodeRole role = default(Azure.ResourceManager.HorizonDB.Models.NodeRole), string availabilityZone = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.PasswordAuthenticationData PasswordAuthenticationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPatch PasswordAuthenticationPatch(Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPropertiesForPatchUpdate properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationProperties PasswordAuthenticationProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState state = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState), string administratorLogin = null, string administratorLoginPassword = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPropertiesForPatchUpdate PasswordAuthenticationPropertiesForPatchUpdate(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState? state = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState?), string administratorLoginPassword = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PoolCapability PoolCapability(Azure.ResourceManager.HorizonDB.Models.ComputeProcessorType recommendedComputeProcessor = default(Azure.ResourceManager.HorizonDB.Models.ComputeProcessorType), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.ComputeProcessorCapability> supportedProcessors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.PoolFeatureCapability> supportedFeatures = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PoolComputeModel PoolComputeModel(Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType type = default(Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType), Azure.ResourceManager.HorizonDB.Models.ComputeProcessorType computeProcessor = default(Azure.ResourceManager.HorizonDB.Models.ComputeProcessorType), int computeGeneration = 0, int vCores = 0) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PoolComputeModelForPatchUpdate PoolComputeModelForPatchUpdate(Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType? type = default(Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType?), Azure.ResourceManager.HorizonDB.Models.ComputeProcessorType? computeProcessor = default(Azure.ResourceManager.HorizonDB.Models.ComputeProcessorType?), int? computeGeneration = default(int?), int? vCores = default(int?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PoolFeatureCapability PoolFeatureCapability(string name = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference PoolParameterGroupReference(Azure.Core.ResourceIdentifier parameterGroupResourceId = null, Azure.ResourceManager.HorizonDB.Models.ParameterApplyMethod applyMethod = default(Azure.ResourceManager.HorizonDB.Models.ParameterApplyMethod), Azure.ResourceManager.HorizonDB.Models.ParameterGroupSyncStatus? syncStatus = default(Azure.ResourceManager.HorizonDB.Models.ParameterGroupSyncStatus?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferenceForPatchUpdate PoolParameterGroupReferenceForPatchUpdate(Azure.Core.ResourceIdentifier parameterGroupResourceId = null, Azure.ResourceManager.HorizonDB.Models.ParameterApplyMethod? applyMethod = default(Azure.ResourceManager.HorizonDB.Models.ParameterApplyMethod?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PoolPropertiesForPatchUpdate PoolPropertiesForPatchUpdate(Azure.ResourceManager.HorizonDB.Models.PoolComputeModelForPatchUpdate computeModel = null, int? nodeCount = default(int?), Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode? highAvailabilityMode = default(Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode?), Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferenceForPatchUpdate parameterGroup = null, Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceManagementType? maintenanceManagementType = default(Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceManagementType?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability PostgreSqlVersionCapability(Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion name = default(Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion> supportedVersionsToUpgrade = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ProvisionedComputeModelCapability ProvisionedComputeModelCapability(int recommendedVCoreCount = 0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.ComputeSizeCapability> supportedComputeSizes = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceProperties ScheduledMaintenanceProperties(string maintenanceManagementType = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.SystemScheduledMaintenanceProperties SystemScheduledMaintenanceProperties() { throw null; }
    }
    public partial class Authentication : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.Authentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.Authentication>
    {
        internal Authentication() { }
        public Azure.ResourceManager.HorizonDB.Models.AuthenticationProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.Authentication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.Authentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.Authentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.Authentication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.Authentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.Authentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.Authentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AuthenticationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.AuthenticationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.AuthenticationProperties>
    {
        internal AuthenticationProperties() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState State { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.AuthenticationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.AuthenticationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.AuthenticationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.AuthenticationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.AuthenticationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.AuthenticationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.AuthenticationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.AuthenticationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.AuthenticationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.BackupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.BackupProperties>
    {
        public BackupProperties(Azure.ResourceManager.HorizonDB.Models.GeoRedundancyState geoRedundancy) { }
        public System.DateTimeOffset? EarliestRestorePointUtc { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.GeoRedundancyState GeoRedundancy { get { throw null; } set { } }
        public int? RetentionDays { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.BackupProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.BackupProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.BackupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.BackupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.BackupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.BackupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.BackupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.BackupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.BackupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CapabilityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.CapabilityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.CapabilityProperties>
    {
        internal CapabilityProperties() { }
        public Azure.ResourceManager.HorizonDB.Models.ClusterCapability ClusterCapabilities { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.PoolCapability PoolCapabilities { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.CapabilityProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.CapabilityProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.CapabilityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.CapabilityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.CapabilityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.CapabilityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.CapabilityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.CapabilityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.CapabilityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChangeDataCaptureCapabilityPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch>
    {
        public ChangeDataCaptureCapabilityPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesForPatchUpdate Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChangeDataCaptureCapabilityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties>
    {
        public ChangeDataCaptureCapabilityProperties(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState desiredState) { }
        public bool? AutoUpgradeExtension { get { throw null; } set { } }
        public int ConfigurationCount { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState DesiredState { get { throw null; } set { } }
        public int DestinationCount { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState EffectiveState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus Extension { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus Prerequisites { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture ReplicationArchitecture { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChangeDataCaptureCapabilityPropertiesForPatchUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesForPatchUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesForPatchUpdate>
    {
        public ChangeDataCaptureCapabilityPropertiesForPatchUpdate() { }
        public bool? AutoUpgradeExtension { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState? DesiredState { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesForPatchUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesForPatchUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesForPatchUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesForPatchUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesForPatchUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesForPatchUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesForPatchUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesForPatchUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesForPatchUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChangeDataCaptureConfigurationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch>
    {
        public ChangeDataCaptureConfigurationPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState? ChangeDataCaptureConfigurationPropertiesForPatchUpdateDesiredState { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChangeDataCaptureConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties>
    {
        public ChangeDataCaptureConfigurationProperties(string databaseName, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile usageProfile, Azure.Core.ResourceIdentifier destinationResourceId, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState desiredState) { }
        public string DatabaseName { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState DesiredState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DestinationResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState EffectiveState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus Extension { get { throw null; } }
        public string LogicalStreamId { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus Replication { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus Status { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus Topology { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile UsageProfile { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureDesiredState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureDesiredState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState Disabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ChangeDataCaptureDestinationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails>
    {
        internal ChangeDataCaptureDestinationDetails() { }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol Protocol { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureDestinationEffectiveState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureDestinationEffectiveState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState Degraded { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState Disabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState Disabling { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState Enabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState Enabling { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState Failed { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState WaitingForIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChangeDataCaptureDestinationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch>
    {
        public ChangeDataCaptureDestinationPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState? ChangeDataCaptureDestinationPropertiesForPatchUpdateDesiredState { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChangeDataCaptureDestinationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties>
    {
        public ChangeDataCaptureDestinationProperties(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails destination, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState desiredState) { }
        public Azure.Core.ResourceIdentifier ActiveIdentityAssignmentResourceId { get { throw null; } }
        public int ConfigurationCount { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState DesiredState { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails Destination { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState EffectiveState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureEffectiveState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureEffectiveState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState Degraded { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState Disabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState Disabling { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState Enabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState Enabling { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState Failed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureEngineConfigurationState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureEngineConfigurationState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState Failed { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState NotReady { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState Ready { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState Reconciling { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureExtensionState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureExtensionState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState Failed { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState Installing { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState NotInstalled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState Ready { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState Removing { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState Upgrading { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChangeDataCaptureExtensionStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus>
    {
        internal ChangeDataCaptureExtensionStatus() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState State { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureIdentityActivationState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureIdentityActivationState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState Activating { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState Active { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState Deactivating { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState Failed { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChangeDataCaptureIdentityAssignmentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties>
    {
        public ChangeDataCaptureIdentityAssignmentProperties(Azure.Core.ResourceIdentifier identityResourceId) { }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState ActivationState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState EffectiveState { get { throw null; } }
        public Azure.Core.ResourceIdentifier IdentityResourceId { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus Status { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.IdentityValidationStatus Validation { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureIdentityAssignmentState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureIdentityAssignmentState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState Assigned { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState Assigning { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState Failed { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState Removing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureIdentityValidationState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureIdentityValidationState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState Failed { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState NotStarted { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState Running { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChangeDataCapturePrerequisiteStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus>
    {
        internal ChangeDataCapturePrerequisiteStatus() { }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState EngineConfigurationState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState ReadWriteEndpointState { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureProtocol : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureProtocol(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol Native { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureReadWriteEndpointState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureReadWriteEndpointState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState Ready { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureReplicationArchitecture : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureReplicationArchitecture(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture ComputeBased { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture Hybrid { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture StorageBased { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureReplicationState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureReplicationState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState Connecting { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState Degraded { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState Failed { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState NotConnected { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState Paused { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState Reconnecting { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState Replicating { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState Stopping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChangeDataCaptureReplicationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus>
    {
        internal ChangeDataCaptureReplicationStatus() { }
        public string ExternalArtifactId { get { throw null; } }
        public System.DateTimeOffset? LastConnectedAtUtc { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState State { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChangeDataCaptureStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus>
    {
        internal ChangeDataCaptureStatus() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureTopologyBindingState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureTopologyBindingState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState Active { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState Conflict { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState RebindRequired { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState Reconciling { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState Superseded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChangeDataCaptureTopologyBindingStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus>
    {
        internal ChangeDataCaptureTopologyBindingStatus() { }
        public Azure.Core.ResourceIdentifier ActiveClusterResourceId { get { throw null; } }
        public long Generation { get { throw null; } }
        public Azure.Core.ResourceIdentifier ReplacementConfigurationResourceId { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState State { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureUsageProfile : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureUsageProfile(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile Mirroring { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ClusterCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ClusterCapability>
    {
        internal ClusterCapability() { }
        public Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion RecommendedPostgreSqlVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HorizonDB.Models.ClusterFeatureCapability> SupportedFeatures { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability> SupportedPostgreSqlVersions { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ClusterCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ClusterCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ClusterCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ClusterCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ClusterCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ClusterCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ClusterCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ClusterCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ClusterCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterCreateMode : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ClusterCreateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterCreateMode(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ClusterCreateMode Create { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ClusterCreateMode PointInTimeRestore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ClusterCreateMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ClusterCreateMode left, Azure.ResourceManager.HorizonDB.Models.ClusterCreateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ClusterCreateMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ClusterCreateMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ClusterCreateMode left, Azure.ResourceManager.HorizonDB.Models.ClusterCreateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterFeatureCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ClusterFeatureCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ClusterFeatureCapability>
    {
        internal ClusterFeatureCapability() { }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ClusterFeatureCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ClusterFeatureCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ClusterFeatureCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ClusterFeatureCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ClusterFeatureCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ClusterFeatureCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ClusterFeatureCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ClusterFeatureCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ClusterFeatureCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ClusterState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ClusterState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ClusterState Inaccessible { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ClusterState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ClusterState Ready { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ClusterState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ClusterState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ClusterState left, Azure.ResourceManager.HorizonDB.Models.ClusterState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ClusterState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ClusterState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ClusterState left, Azure.ResourceManager.HorizonDB.Models.ClusterState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeGenerationCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ComputeGenerationCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ComputeGenerationCapability>
    {
        internal ComputeGenerationCapability() { }
        public int ComputeGeneration { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType RecommendedComputeModelType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HorizonDB.Models.ComputeModelCapability> SupportedComputeModels { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ComputeGenerationCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ComputeGenerationCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ComputeGenerationCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ComputeGenerationCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ComputeGenerationCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ComputeGenerationCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ComputeGenerationCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ComputeGenerationCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ComputeGenerationCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ComputeModelCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ComputeModelCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ComputeModelCapability>
    {
        internal ComputeModelCapability() { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ComputeModelCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ComputeModelCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ComputeModelCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ComputeModelCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ComputeModelCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ComputeModelCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ComputeModelCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ComputeModelCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ComputeModelCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeProcessorCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ComputeProcessorCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ComputeProcessorCapability>
    {
        internal ComputeProcessorCapability() { }
        public Azure.ResourceManager.HorizonDB.Models.ComputeProcessorType Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HorizonDB.Models.ComputeGenerationCapability> SupportedGenerations { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ComputeProcessorCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ComputeProcessorCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ComputeProcessorCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ComputeProcessorCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ComputeProcessorCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ComputeProcessorCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ComputeProcessorCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ComputeProcessorCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ComputeProcessorCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeProcessorType : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ComputeProcessorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeProcessorType(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ComputeProcessorType AMD { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ComputeProcessorType Intel { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ComputeProcessorType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ComputeProcessorType left, Azure.ResourceManager.HorizonDB.Models.ComputeProcessorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ComputeProcessorType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ComputeProcessorType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ComputeProcessorType left, Azure.ResourceManager.HorizonDB.Models.ComputeProcessorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeSizeCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ComputeSizeCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ComputeSizeCapability>
    {
        internal ComputeSizeCapability() { }
        public long MemoryPerVCoreInMb { get { throw null; } }
        public int VCores { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ComputeSizeCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ComputeSizeCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ComputeSizeCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ComputeSizeCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ComputeSizeCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ComputeSizeCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ComputeSizeCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ComputeSizeCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ComputeSizeCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DefaultParameterGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.DefaultParameterGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.DefaultParameterGroupProperties>
    {
        internal DefaultParameterGroupProperties() { }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties> Parameters { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion PostgreSqlVersion { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.DefaultParameterGroupProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.DefaultParameterGroupProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.DefaultParameterGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.DefaultParameterGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.DefaultParameterGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.DefaultParameterGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.DefaultParameterGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.DefaultParameterGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.DefaultParameterGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.EndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.EndpointProperties>
    {
        internal EndpointProperties() { }
        public Azure.Core.ResourceIdentifier AssociatedResourceId { get { throw null; } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.EndpointRole Role { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.EndpointScope Scope { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.EndpointProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.EndpointProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.EndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.EndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.EndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.EndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.EndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.EndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.EndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointRole : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.EndpointRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointRole(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.EndpointRole ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.EndpointRole ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.EndpointRole other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.EndpointRole left, Azure.ResourceManager.HorizonDB.Models.EndpointRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.EndpointRole (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.EndpointRole? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.EndpointRole left, Azure.ResourceManager.HorizonDB.Models.EndpointRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointScope : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.EndpointScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointScope(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.EndpointScope Cluster { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.EndpointScope Pool { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.EndpointScope other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.EndpointScope left, Azure.ResourceManager.HorizonDB.Models.EndpointScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.EndpointScope (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.EndpointScope? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.EndpointScope left, Azure.ResourceManager.HorizonDB.Models.EndpointScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FabricDestinationDetails : Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.FabricDestinationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.FabricDestinationDetails>
    {
        public FabricDestinationDetails(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol protocol, string workspaceId) { }
        public string WorkspaceId { get { throw null; } set { } }
        protected override Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.FabricDestinationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.FabricDestinationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.FabricDestinationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.FabricDestinationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.FabricDestinationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.FabricDestinationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.FabricDestinationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeoRedundancyState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.GeoRedundancyState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GeoRedundancyState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.GeoRedundancyState Disabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.GeoRedundancyState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.GeoRedundancyState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.GeoRedundancyState left, Azure.ResourceManager.HorizonDB.Models.GeoRedundancyState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.GeoRedundancyState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.GeoRedundancyState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.GeoRedundancyState left, Azure.ResourceManager.HorizonDB.Models.GeoRedundancyState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDBActivateChangeDataCaptureIdentityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent>
    {
        public HorizonDBActivateChangeDataCaptureIdentityContent(Azure.Core.ResourceIdentifier identityAssignmentResourceId) { }
        public bool? DrainExistingSessions { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier IdentityAssignmentResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBAuthenticationState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBAuthenticationState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState Disabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDBClusterDataEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption>
    {
        public HorizonDBClusterDataEncryption() { }
        public string PrimaryEncryptionKeyCurrentVersion { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus? PrimaryEncryptionKeyStatus { get { throw null; } }
        public System.Uri PrimaryKeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrimaryUserAssignedIdentityId { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBClusterDataEncryptionForPatchUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionForPatchUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionForPatchUpdate>
    {
        public HorizonDBClusterDataEncryptionForPatchUpdate() { }
        public System.Uri PrimaryKeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrimaryUserAssignedIdentityId { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionForPatchUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionForPatchUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionForPatchUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionForPatchUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionForPatchUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionForPatchUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionForPatchUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionForPatchUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionForPatchUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBClusterDataEncryptionType : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBClusterDataEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType AzureKeyVault { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType SystemManaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType left, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType left, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBClusterEncryptionKeyStatus : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBClusterEncryptionKeyStatus(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus Valid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus left, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus left, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBClusterIdentityType : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBClusterIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType left, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType left, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDBClusterManagedServiceIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity>
    {
        public HorizonDBClusterManagedServiceIdentity(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType type) { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch>
    {
        public HorizonDBClusterPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBClusterPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties>
    {
        public HorizonDBClusterPatchProperties() { }
        public Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus? AiModelManagement { get { throw null; } set { } }
        public int? BackupRetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionForPatchUpdate DataEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState? NetworkPublicAccess { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBClusterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties>
    {
        public HorizonDBClusterProperties() { }
        public Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus? AiModelManagement { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.BackupProperties Backup { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.ClusterCreateMode? CreationMode { get { throw null; } set { } }
        public string CreationSourceClusterLocation { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CreationSourceClusterResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption DataEncryption { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DesignatedPoolResourceId { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState? NetworkPublicAccess { get { throw null; } set { } }
        public System.DateTimeOffset? PointInTimeUtc { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion? PostgreSqlVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ClusterState State { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBFirewallRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties>
    {
        public HorizonDBFirewallRuleProperties(string startIPAddress, string endIPAddress) { }
        public string Description { get { throw null; } set { } }
        public string EndIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public string StartIPAddress { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBMaintenanceEventActionResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult>
    {
        internal HorizonDBMaintenanceEventActionResult() { }
        public bool? AppliedNow { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedTimeUtc { get { throw null; } }
        public string MaintenanceEventId { get { throw null; } }
        public System.DateTimeOffset? PlannedEndTimeUtc { get { throw null; } }
        public System.DateTimeOffset? PlannedStartTimeUtc { get { throw null; } }
        public Azure.Core.ResourceIdentifier PoolResourceId { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.MaintenanceEventStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBMaintenanceEventRescheduleContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent>
    {
        public HorizonDBMaintenanceEventRescheduleContent(System.DateTimeOffset postponeToDateTimeUtc) { }
        public System.DateTimeOffset PostponeToDateTimeUtc { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBParameterGroupConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties>
    {
        internal HorizonDBParameterGroupConnectionProperties() { }
        public Azure.Core.ResourceIdentifier PoolResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBParameterGroupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch>
    {
        public HorizonDBParameterGroupPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBParameterGroupPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties>
    {
        public HorizonDBParameterGroupPatchProperties() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties> Parameters { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBParameterGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties>
    {
        public HorizonDBParameterGroupProperties(Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion postgreSqlVersion) { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties> Parameters { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion PostgreSqlVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBParameterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties>
    {
        public HorizonDBParameterProperties() { }
        public string AllowedValues { get { throw null; } }
        public string DataType { get { throw null; } }
        public string DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Uri DocumentationLink { get { throw null; } }
        public bool? IsDynamic { get { throw null; } }
        public bool? IsReadOnly { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string Unit { get { throw null; } }
        public string Value { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.ParameterValueSource? ValueSource { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPoolPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch>
    {
        public HorizonDBPoolPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.PoolPropertiesForPatchUpdate Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPoolProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties>
    {
        public HorizonDBPoolProperties(Azure.ResourceManager.HorizonDB.Models.PoolComputeModel computeModel, int nodeCount, Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode highAvailabilityMode, Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference parameterGroup) { }
        public Azure.ResourceManager.HorizonDB.Models.PoolComputeModel ComputeModel { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode HighAvailabilityMode { get { throw null; } set { } }
        public int NodeCount { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference ParameterGroup { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceProperties ScheduledMaintenance { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.PoolState? State { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBPrincipalType : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBPrincipalType(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType Group { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType ServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType Unknown { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType left, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType left, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDBPrivateEndpointConnectionPatchProperties
    {
        public HorizonDBPrivateEndpointConnectionPatchProperties() { }
    }
    public partial class HorizonDBPrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties>
    {
        public HorizonDBPrivateEndpointConnectionProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState privateLinkServiceConnectionState) { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDBPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties>
    {
        internal HorizonDBPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState>
    {
        public HorizonDBPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBProvisioningState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBPublicNetworkAccessState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBPublicNetworkAccessState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState Disabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IdentityValidationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.IdentityValidationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.IdentityValidationStatus>
    {
        internal IdentityValidationStatus() { }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState State { get { throw null; } }
        public System.DateTimeOffset? ValidatedAtUtc { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.IdentityValidationStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.IdentityValidationStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.IdentityValidationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.IdentityValidationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.IdentityValidationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.IdentityValidationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.IdentityValidationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.IdentityValidationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.IdentityValidationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogCaptureConfigurationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPatch>
    {
        public LogCaptureConfigurationPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPropertiesForPatchUpdate Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogCaptureConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationProperties>
    {
        internal LogCaptureConfigurationProperties() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public int RetentionDays { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.LogCaptureState State { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogCaptureConfigurationPropertiesForPatchUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPropertiesForPatchUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPropertiesForPatchUpdate>
    {
        public LogCaptureConfigurationPropertiesForPatchUpdate() { }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.LogCaptureState? State { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPropertiesForPatchUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPropertiesForPatchUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPropertiesForPatchUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPropertiesForPatchUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPropertiesForPatchUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPropertiesForPatchUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPropertiesForPatchUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPropertiesForPatchUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.LogCaptureConfigurationPropertiesForPatchUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogCaptureState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.LogCaptureState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogCaptureState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.LogCaptureState Disabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.LogCaptureState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.LogCaptureState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.LogCaptureState left, Azure.ResourceManager.HorizonDB.Models.LogCaptureState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.LogCaptureState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.LogCaptureState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.LogCaptureState left, Azure.ResourceManager.HorizonDB.Models.LogCaptureState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogFileDownloadUri : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri>
    {
        internal LogFileDownloadUri() { }
        public System.Uri DownloadUri { get { throw null; } }
        public System.DateTimeOffset ExpiresAtUtc { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogFileProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.LogFileProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.LogFileProperties>
    {
        internal LogFileProperties() { }
        public System.DateTimeOffset CreatedAtUtc { get { throw null; } }
        public bool IsMutable { get { throw null; } }
        public System.DateTimeOffset LastModifiedAtUtc { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.LogFileType LogType { get { throw null; } }
        public string Node { get { throw null; } }
        public string Pool { get { throw null; } }
        public System.DateTimeOffset RetentionExpiresAtUtc { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.NodeRole Role { get { throw null; } }
        public long SizeInKilobytes { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.LogFileProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.LogFileProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.LogFileProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.LogFileProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.LogFileProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.LogFileProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.LogFileProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.LogFileProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.LogFileProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogFileType : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.LogFileType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogFileType(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.LogFileType PostgreSqlServer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.LogFileType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.LogFileType left, Azure.ResourceManager.HorizonDB.Models.LogFileType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.LogFileType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.LogFileType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.LogFileType left, Azure.ResourceManager.HorizonDB.Models.LogFileType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MaintenanceEventProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MaintenanceEventProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MaintenanceEventProperties>
    {
        internal MaintenanceEventProperties() { }
        public bool Deferrable { get { throw null; } }
        public System.DateTimeOffset? DeferralDeadlineUtc { get { throw null; } }
        public string Description { get { throw null; } }
        public System.DateTimeOffset EndTimeUtc { get { throw null; } }
        public System.TimeSpan? EstimatedDowntime { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedTimeUtc { get { throw null; } }
        public string MaintenanceEventId { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.MaintenanceType MaintenanceType { get { throw null; } }
        public System.DateTimeOffset OriginalStartTimeUtc { get { throw null; } }
        public System.DateTimeOffset? RescheduledFromUtc { get { throw null; } }
        public System.DateTimeOffset StartTimeUtc { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.MaintenanceEventStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.MaintenanceEventProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.MaintenanceEventProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.MaintenanceEventProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MaintenanceEventProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MaintenanceEventProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.MaintenanceEventProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MaintenanceEventProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MaintenanceEventProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MaintenanceEventProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaintenanceEventStatus : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.MaintenanceEventStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaintenanceEventStatus(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.MaintenanceEventStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.MaintenanceEventStatus Complete { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.MaintenanceEventStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.MaintenanceEventStatus Planned { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.MaintenanceEventStatus Rescheduled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.MaintenanceEventStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.MaintenanceEventStatus left, Azure.ResourceManager.HorizonDB.Models.MaintenanceEventStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.MaintenanceEventStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.MaintenanceEventStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.MaintenanceEventStatus left, Azure.ResourceManager.HorizonDB.Models.MaintenanceEventStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaintenanceType : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.MaintenanceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaintenanceType(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.MaintenanceType PlannedMaintenance { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.MaintenanceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.MaintenanceType left, Azure.ResourceManager.HorizonDB.Models.MaintenanceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.MaintenanceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.MaintenanceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.MaintenanceType left, Azure.ResourceManager.HorizonDB.Models.MaintenanceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MicrosoftEntraAdministratorAdd : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorAdd>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorAdd>
    {
        public MicrosoftEntraAdministratorAdd(Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd properties) { }
        public Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorAdd JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorAdd PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorAdd System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorAdd>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorAdd>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorAdd System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorAdd>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorAdd>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorAdd>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftEntraAdministratorProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties>
    {
        internal MicrosoftEntraAdministratorProperties() { }
        public string ObjectId { get { throw null; } }
        public string PrincipalName { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType PrincipalType { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public string TenantId { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftEntraAdministratorPropertiesForAdd : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd>
    {
        public MicrosoftEntraAdministratorPropertiesForAdd(string principalName, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType principalType) { }
        public string PrincipalName { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType PrincipalType { get { throw null; } }
        public string TenantId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftEntraAuthenticationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch>
    {
        public MicrosoftEntraAuthenticationPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState? MicrosoftEntraAuthenticationPropertiesForPatchUpdateState { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftEntraAuthenticationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties>
    {
        public MicrosoftEntraAuthenticationProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState state) { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState State { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.NodeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.NodeProperties>
    {
        internal NodeProperties() { }
        public string AvailabilityZone { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.NodeRole Role { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.NodeProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.NodeProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.NodeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.NodeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.NodeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.NodeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.NodeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.NodeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.NodeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeRole : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.NodeRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeRole(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.NodeRole ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.NodeRole ReadWrite { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.NodeRole Unassigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.NodeRole other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.NodeRole left, Azure.ResourceManager.HorizonDB.Models.NodeRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.NodeRole (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.NodeRole? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.NodeRole left, Azure.ResourceManager.HorizonDB.Models.NodeRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ParameterApplyMethod : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ParameterApplyMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParameterApplyMethod(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ParameterApplyMethod Immediate { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ParameterApplyMethod PendingReboot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ParameterApplyMethod other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ParameterApplyMethod left, Azure.ResourceManager.HorizonDB.Models.ParameterApplyMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ParameterApplyMethod (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ParameterApplyMethod? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ParameterApplyMethod left, Azure.ResourceManager.HorizonDB.Models.ParameterApplyMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ParameterGroupSyncStatus : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ParameterGroupSyncStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParameterGroupSyncStatus(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ParameterGroupSyncStatus Applying { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ParameterGroupSyncStatus FailedToApply { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ParameterGroupSyncStatus InSync { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ParameterGroupSyncStatus PendingReboot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ParameterGroupSyncStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ParameterGroupSyncStatus left, Azure.ResourceManager.HorizonDB.Models.ParameterGroupSyncStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ParameterGroupSyncStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ParameterGroupSyncStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ParameterGroupSyncStatus left, Azure.ResourceManager.HorizonDB.Models.ParameterGroupSyncStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ParameterValueSource : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ParameterValueSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParameterValueSource(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ParameterValueSource SystemDefault { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ParameterValueSource UserOverride { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ParameterValueSource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ParameterValueSource left, Azure.ResourceManager.HorizonDB.Models.ParameterValueSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ParameterValueSource (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ParameterValueSource? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ParameterValueSource left, Azure.ResourceManager.HorizonDB.Models.ParameterValueSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PasswordAuthenticationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPatch>
    {
        public PasswordAuthenticationPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPropertiesForPatchUpdate Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PasswordAuthenticationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationProperties>
    {
        public PasswordAuthenticationProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState state) { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState State { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PasswordAuthenticationPropertiesForPatchUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPropertiesForPatchUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPropertiesForPatchUpdate>
    {
        public PasswordAuthenticationPropertiesForPatchUpdate() { }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState? State { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPropertiesForPatchUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPropertiesForPatchUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPropertiesForPatchUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPropertiesForPatchUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPropertiesForPatchUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPropertiesForPatchUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPropertiesForPatchUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPropertiesForPatchUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PasswordAuthenticationPropertiesForPatchUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PoolCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolCapability>
    {
        internal PoolCapability() { }
        public Azure.ResourceManager.HorizonDB.Models.ComputeProcessorType RecommendedComputeProcessor { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HorizonDB.Models.PoolFeatureCapability> SupportedFeatures { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HorizonDB.Models.ComputeProcessorCapability> SupportedProcessors { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PoolCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PoolCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.PoolCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.PoolCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PoolComputeModel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolComputeModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolComputeModel>
    {
        public PoolComputeModel(Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType type, Azure.ResourceManager.HorizonDB.Models.ComputeProcessorType computeProcessor, int computeGeneration, int vCores) { }
        public int ComputeGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.ComputeProcessorType ComputeProcessor { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType Type { get { throw null; } set { } }
        public int VCores { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PoolComputeModel JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PoolComputeModel PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.PoolComputeModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolComputeModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolComputeModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.PoolComputeModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolComputeModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolComputeModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolComputeModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PoolComputeModelForPatchUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolComputeModelForPatchUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolComputeModelForPatchUpdate>
    {
        public PoolComputeModelForPatchUpdate() { }
        public int? ComputeGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.ComputeProcessorType? ComputeProcessor { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType? Type { get { throw null; } set { } }
        public int? VCores { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PoolComputeModelForPatchUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PoolComputeModelForPatchUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.PoolComputeModelForPatchUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolComputeModelForPatchUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolComputeModelForPatchUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.PoolComputeModelForPatchUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolComputeModelForPatchUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolComputeModelForPatchUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolComputeModelForPatchUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PoolComputeModelType : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PoolComputeModelType(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType Provisioned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType left, Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType left, Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PoolFeatureCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolFeatureCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolFeatureCapability>
    {
        internal PoolFeatureCapability() { }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PoolFeatureCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PoolFeatureCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.PoolFeatureCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolFeatureCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolFeatureCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.PoolFeatureCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolFeatureCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolFeatureCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolFeatureCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PoolHighAvailabilityMode : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PoolHighAvailabilityMode(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode AnyZone { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode ZoneRedundant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode left, Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode left, Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PoolParameterGroupReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference>
    {
        public PoolParameterGroupReference(Azure.Core.ResourceIdentifier parameterGroupResourceId, Azure.ResourceManager.HorizonDB.Models.ParameterApplyMethod applyMethod) { }
        public Azure.ResourceManager.HorizonDB.Models.ParameterApplyMethod ApplyMethod { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ParameterGroupResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.ParameterGroupSyncStatus? SyncStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PoolParameterGroupReferenceForPatchUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferenceForPatchUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferenceForPatchUpdate>
    {
        public PoolParameterGroupReferenceForPatchUpdate() { }
        public Azure.ResourceManager.HorizonDB.Models.ParameterApplyMethod? ApplyMethod { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ParameterGroupResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferenceForPatchUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferenceForPatchUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferenceForPatchUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferenceForPatchUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferenceForPatchUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferenceForPatchUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferenceForPatchUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferenceForPatchUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferenceForPatchUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PoolPropertiesForPatchUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolPropertiesForPatchUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolPropertiesForPatchUpdate>
    {
        public PoolPropertiesForPatchUpdate() { }
        public Azure.ResourceManager.HorizonDB.Models.PoolComputeModelForPatchUpdate ComputeModel { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode? HighAvailabilityMode { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceManagementType? MaintenanceManagementType { get { throw null; } set { } }
        public int? NodeCount { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferenceForPatchUpdate ParameterGroup { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PoolPropertiesForPatchUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PoolPropertiesForPatchUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.PoolPropertiesForPatchUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolPropertiesForPatchUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolPropertiesForPatchUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.PoolPropertiesForPatchUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolPropertiesForPatchUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolPropertiesForPatchUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolPropertiesForPatchUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PoolState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.PoolState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PoolState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PoolState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.PoolState Inaccessible { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.PoolState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.PoolState Ready { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.PoolState Restarting { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.PoolState Starting { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.PoolState Stopped { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.PoolState Stopping { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.PoolState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.PoolState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.PoolState left, Azure.ResourceManager.HorizonDB.Models.PoolState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.PoolState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.PoolState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.PoolState left, Azure.ResourceManager.HorizonDB.Models.PoolState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlCapabilityVersion : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlCapabilityVersion(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion V17 { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion V18 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion left, Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion left, Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlVersion : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlVersion(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion V17 { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion V18 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion left, Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion left, Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlVersionCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability>
    {
        internal PostgreSqlVersionCapability() { }
        public Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion> SupportedVersionsToUpgrade { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProvisionedComputeModelCapability : Azure.ResourceManager.HorizonDB.Models.ComputeModelCapability, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ProvisionedComputeModelCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ProvisionedComputeModelCapability>
    {
        internal ProvisionedComputeModelCapability() { }
        public int RecommendedVCoreCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HorizonDB.Models.ComputeSizeCapability> SupportedComputeSizes { get { throw null; } }
        protected override Azure.ResourceManager.HorizonDB.Models.ComputeModelCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.HorizonDB.Models.ComputeModelCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ProvisionedComputeModelCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ProvisionedComputeModelCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ProvisionedComputeModelCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ProvisionedComputeModelCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ProvisionedComputeModelCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ProvisionedComputeModelCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ProvisionedComputeModelCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledMaintenanceManagementType : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceManagementType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledMaintenanceManagementType(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceManagementType System { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceManagementType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceManagementType left, Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceManagementType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceManagementType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceManagementType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceManagementType left, Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceManagementType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ScheduledMaintenanceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceProperties>
    {
        internal ScheduledMaintenanceProperties() { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SystemScheduledMaintenanceProperties : Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.SystemScheduledMaintenanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.SystemScheduledMaintenanceProperties>
    {
        public SystemScheduledMaintenanceProperties() { }
        protected override Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.HorizonDB.Models.ScheduledMaintenanceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.SystemScheduledMaintenanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.SystemScheduledMaintenanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.SystemScheduledMaintenanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.SystemScheduledMaintenanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.SystemScheduledMaintenanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.SystemScheduledMaintenanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.SystemScheduledMaintenanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
