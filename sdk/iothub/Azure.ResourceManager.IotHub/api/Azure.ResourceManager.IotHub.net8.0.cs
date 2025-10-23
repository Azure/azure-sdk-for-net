namespace Azure.ResourceManager.IotHub
{
    public partial class AzureResourceManagerIotHubContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerIotHubContext() { }
        public static Azure.ResourceManager.IotHub.AzureResourceManagerIotHubContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class EventHubConsumerGroupInfoCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource>, System.Collections.IEnumerable
    {
        protected EventHubConsumerGroupInfoCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.IotHub.Models.EventHubConsumerGroupInfoCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.IotHub.Models.EventHubConsumerGroupInfoCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventHubConsumerGroupInfoData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoData>
    {
        internal EventHubConsumerGroupInfoData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventHubConsumerGroupInfoResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventHubConsumerGroupInfoResource() { }
        public virtual Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string eventHubEndpointName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.Models.EventHubConsumerGroupInfoCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.Models.EventHubConsumerGroupInfoCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotHubCertificateDescriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource>, System.Collections.IEnumerable
    {
        protected IotHubCertificateDescriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource> Get(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource>> GetAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource> GetIfExists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource>> GetIfExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotHubCertificateDescriptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData>
    {
        public IotHubCertificateDescriptionData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubCertificateProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubCertificateDescriptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotHubCertificateDescriptionResource() { }
        public virtual Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string certificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubCertificateWithNonceDescription> GenerateVerificationCode(string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubCertificateWithNonceDescription>> GenerateVerificationCodeAsync(string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource> Verify(string ifMatch, Azure.ResourceManager.IotHub.Models.IotHubCertificateVerificationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource>> VerifyAsync(string ifMatch, Azure.ResourceManager.IotHub.Models.IotHubCertificateVerificationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotHubDescriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotHub.IotHubDescriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.IotHubDescriptionResource>, System.Collections.IEnumerable
    {
        protected IotHubDescriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubDescriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.IotHub.IotHubDescriptionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.IotHub.IotHubDescriptionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.IotHubDescriptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.IotHubDescriptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotHub.IotHubDescriptionResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotHub.IotHubDescriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotHub.IotHubDescriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotHub.IotHubDescriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.IotHubDescriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotHubDescriptionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.IotHubDescriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubDescriptionData>
    {
        public IotHubDescriptionData(Azure.Core.AzureLocation location, Azure.ResourceManager.IotHub.Models.IotHubSkuInfo sku) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.IotHubProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.IotHubSkuInfo Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.IotHubDescriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.IotHubDescriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.IotHubDescriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.IotHubDescriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubDescriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubDescriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubDescriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubDescriptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.IotHubDescriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubDescriptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotHubDescriptionResource() { }
        public virtual Azure.ResourceManager.IotHub.IotHubDescriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubDescriptionResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubJobInfo> ExportDevices(Azure.ResourceManager.IotHub.Models.ExportDevicesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubJobInfo>> ExportDevicesAsync(Azure.ResourceManager.IotHub.Models.ExportDevicesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationCollection GetAllIotHubPrivateEndpointGroupInformation() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthInfo> GetEndpointHealth(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthInfo> GetEndpointHealthAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource> GetEventHubConsumerGroupInfo(string eventHubEndpointName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource>> GetEventHubConsumerGroupInfoAsync(string eventHubEndpointName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoCollection GetEventHubConsumerGroupInfos(string eventHubEndpointName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource> GetIotHubCertificateDescription(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource>> GetIotHubCertificateDescriptionAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotHub.IotHubCertificateDescriptionCollection GetIotHubCertificateDescriptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource> GetIotHubPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource>> GetIotHubPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionCollection GetIotHubPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource> GetIotHubPrivateEndpointGroupInformation(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource>> GetIotHubPrivateEndpointGroupInformationAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubJobInfo> GetJob(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubJobInfo>> GetJobAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.Models.IotHubJobInfo> GetJobs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.Models.IotHubJobInfo> GetJobsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule> GetKeysForKeyName(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule>> GetKeysForKeyNameAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.Models.IotHubQuotaMetricInfo> GetQuotaMetrics(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.Models.IotHubQuotaMetricInfo> GetQuotaMetricsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubRegistryStatistics> GetStats(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubRegistryStatistics>> GetStatsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.Models.IotHubSkuDescription> GetValidSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.Models.IotHubSkuDescription> GetValidSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubJobInfo> ImportDevices(Azure.ResourceManager.IotHub.Models.IotHubImportDevicesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubJobInfo>> ImportDevicesAsync(Azure.ResourceManager.IotHub.Models.IotHubImportDevicesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ManualFailoverIotHub(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.Models.IotHubFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ManualFailoverIotHubAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.Models.IotHubFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.IotHub.IotHubDescriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.IotHubDescriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.IotHubDescriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.IotHubDescriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubDescriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubDescriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubDescriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesResult> TestAllRoutes(Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesResult>> TestAllRoutesAsync(Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubTestRouteResult> TestRoute(Azure.ResourceManager.IotHub.Models.IotHubTestRouteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubTestRouteResult>> TestRouteAsync(Azure.ResourceManager.IotHub.Models.IotHubTestRouteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubDescriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.Models.IotHubDescriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.Models.IotHubDescriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class IotHubExtensions
    {
        public static Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityResponse> CheckIotHubNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityResponse>> CheckIotHubNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource GetEventHubConsumerGroupInfoResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource GetIotHubCertificateDescriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource> GetIotHubDescription(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> GetIotHubDescriptionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IotHub.IotHubDescriptionResource GetIotHubDescriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotHub.IotHubDescriptionCollection GetIotHubDescriptions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.IotHub.IotHubDescriptionResource> GetIotHubDescriptions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IotHub.IotHubDescriptionResource> GetIotHubDescriptionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource GetIotHubPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource GetIotHubPrivateEndpointGroupInformationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.IotHub.Models.IotHubUserSubscriptionQuota> GetIotHubUserSubscriptionQuota(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IotHub.Models.IotHubUserSubscriptionQuota> GetIotHubUserSubscriptionQuotaAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotHubPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected IotHubPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotHubPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData>
    {
        public IotHubPrivateEndpointConnectionData(Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointConnectionProperties properties) { }
        public Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotHubPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotHubPrivateEndpointGroupInformationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource>, System.Collections.IEnumerable
    {
        protected IotHubPrivateEndpointGroupInformationCollection() { }
        public virtual Azure.Response<bool> Exists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource> Get(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource>> GetAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource> GetIfExists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource>> GetIfExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotHubPrivateEndpointGroupInformationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationData>
    {
        internal IotHubPrivateEndpointGroupInformationData() { }
        public Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointGroupInformationProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubPrivateEndpointGroupInformationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotHubPrivateEndpointGroupInformationResource() { }
        public virtual Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string groupId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.IotHub.Mocking
{
    public partial class MockableIotHubArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableIotHubArmClient() { }
        public virtual Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoResource GetEventHubConsumerGroupInfoResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IotHub.IotHubCertificateDescriptionResource GetIotHubCertificateDescriptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IotHub.IotHubDescriptionResource GetIotHubDescriptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionResource GetIotHubPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationResource GetIotHubPrivateEndpointGroupInformationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableIotHubResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableIotHubResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource> GetIotHubDescription(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.IotHubDescriptionResource>> GetIotHubDescriptionAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotHub.IotHubDescriptionCollection GetIotHubDescriptions() { throw null; }
    }
    public partial class MockableIotHubSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableIotHubSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityResponse> CheckIotHubNameAvailability(Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityResponse>> CheckIotHubNameAvailabilityAsync(Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.IotHubDescriptionResource> GetIotHubDescriptions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.IotHubDescriptionResource> GetIotHubDescriptionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotHub.Models.IotHubUserSubscriptionQuota> GetIotHubUserSubscriptionQuota(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotHub.Models.IotHubUserSubscriptionQuota> GetIotHubUserSubscriptionQuotaAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.IotHub.Models
{
    public static partial class ArmIotHubModelFactory
    {
        public static Azure.ResourceManager.IotHub.Models.EventHubCompatibleEndpointProperties EventHubCompatibleEndpointProperties(long? retentionTimeInDays = default(long?), int? partitionCount = default(int?), System.Collections.Generic.IEnumerable<string> partitionIds = null, string eventHubCompatibleName = null, string endpoint = null) { throw null; }
        public static Azure.ResourceManager.IotHub.EventHubConsumerGroupInfoData EventHubConsumerGroupInfoData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> properties = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.ExportDevicesContent ExportDevicesContent(System.Uri exportBlobContainerUri = null, bool excludeKeys = false, string exportBlobName = null, Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType? authenticationType = default(Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType?), Azure.Core.ResourceIdentifier userAssignedIdentity = null, bool? includeConfigurations = default(bool?), string configurationsBlobName = null) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubCapacity IotHubCapacity(long? minimum = default(long?), long? maximum = default(long?), long? @default = default(long?), Azure.ResourceManager.IotHub.Models.IotHubScaleType? scaleType = default(Azure.ResourceManager.IotHub.Models.IotHubScaleType?)) { throw null; }
        public static Azure.ResourceManager.IotHub.IotHubCertificateDescriptionData IotHubCertificateDescriptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.IotHub.Models.IotHubCertificateProperties properties = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubCertificateProperties IotHubCertificateProperties(string subject = null, System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), string thumbprintString = null, bool? isVerified = default(bool?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), System.BinaryData certificate = null) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubCertificatePropertiesWithNonce IotHubCertificatePropertiesWithNonce(string subject = null, System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), string thumbprintString = null, bool? isVerified = default(bool?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string verificationCode = null, System.BinaryData certificate = null) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubCertificateWithNonceDescription IotHubCertificateWithNonceDescription(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.IotHub.Models.IotHubCertificatePropertiesWithNonce properties = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.IotHub.IotHubDescriptionData IotHubDescriptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.IotHub.Models.IotHubProperties properties = null, Azure.ResourceManager.IotHub.Models.IotHubSkuInfo sku = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthInfo IotHubEndpointHealthInfo(string endpointId = null, Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus? healthStatus = default(Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus?), string lastKnownError = null, System.DateTimeOffset? lastKnownErrorOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastSuccessfulSendAttemptOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastSendAttemptOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubImportDevicesContent IotHubImportDevicesContent(System.Uri inputBlobContainerUri = null, System.Uri outputBlobContainerUri = null, string inputBlobName = null, string outputBlobName = null, Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType? authenticationType = default(Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType?), Azure.Core.ResourceIdentifier userAssignedIdentity = null, bool? includeConfigurations = default(bool?), string configurationsBlobName = null) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubJobInfo IotHubJobInfo(string jobId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.IotHub.Models.IotHubJobType? jobType = default(Azure.ResourceManager.IotHub.Models.IotHubJobType?), Azure.ResourceManager.IotHub.Models.IotHubJobStatus? status = default(Azure.ResourceManager.IotHub.Models.IotHubJobStatus?), string failureReason = null, string statusMessage = null, string parentJobId = null) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubLocationDescription IotHubLocationDescription(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.IotHub.Models.IotHubReplicaRoleType? role = default(Azure.ResourceManager.IotHub.Models.IotHubReplicaRoleType?)) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubMatchedRoute IotHubMatchedRoute(Azure.ResourceManager.IotHub.Models.RoutingRuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityResponse IotHubNameAvailabilityResponse(bool? isNameAvailable = default(bool?), Azure.ResourceManager.IotHub.Models.IotHubNameUnavailableReason? reason = default(Azure.ResourceManager.IotHub.Models.IotHubNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData IotHubPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.IotHub.IotHubPrivateEndpointGroupInformationData IotHubPrivateEndpointGroupInformationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointGroupInformationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointGroupInformationProperties IotHubPrivateEndpointGroupInformationProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredDnsZoneNames = null) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubProperties IotHubProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule> authorizationPolicies = null, bool? disableLocalAuth = default(bool?), bool? disableDeviceSas = default(bool?), bool? disableModuleSas = default(bool?), bool? restrictOutboundNetworkAccess = default(bool?), System.Collections.Generic.IEnumerable<string> allowedFqdns = null, Azure.ResourceManager.IotHub.Models.IotHubPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.IotHub.Models.IotHubPublicNetworkAccess?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.Models.IotHubIPFilterRule> ipFilterRules = null, Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetProperties networkRuleSets = null, string minTlsVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData> privateEndpointConnections = null, string provisioningState = null, string state = null, string hostName = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.IotHub.Models.EventHubCompatibleEndpointProperties> eventHubEndpoints = null, Azure.ResourceManager.IotHub.Models.IotHubRoutingProperties routing = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.IotHub.Models.IotHubStorageEndpointProperties> storageEndpoints = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.IotHub.Models.MessagingEndpointProperties> messagingEndpoints = null, bool? enableFileUploadNotifications = default(bool?), Azure.ResourceManager.IotHub.Models.CloudToDeviceProperties cloudToDevice = null, string comments = null, Azure.ResourceManager.IotHub.Models.IotHubCapability? features = default(Azure.ResourceManager.IotHub.Models.IotHubCapability?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.Models.IotHubLocationDescription> locations = null, bool? enableDataResidency = default(bool?)) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubQuotaMetricInfo IotHubQuotaMetricInfo(string name = null, long? currentValue = default(long?), long? maxValue = default(long?)) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubRegistryStatistics IotHubRegistryStatistics(long? totalDeviceCount = default(long?), long? enabledDeviceCount = default(long?), long? disabledDeviceCount = default(long?)) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubSkuDescription IotHubSkuDescription(Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), Azure.ResourceManager.IotHub.Models.IotHubSkuInfo sku = null, Azure.ResourceManager.IotHub.Models.IotHubCapacity capacity = null) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubSkuInfo IotHubSkuInfo(Azure.ResourceManager.IotHub.Models.IotHubSku name = default(Azure.ResourceManager.IotHub.Models.IotHubSku), Azure.ResourceManager.IotHub.Models.IotHubSkuTier? tier = default(Azure.ResourceManager.IotHub.Models.IotHubSkuTier?), long? capacity = default(long?)) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesResult IotHubTestAllRoutesResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.Models.IotHubMatchedRoute> routes = null) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubTestRouteContent IotHubTestRouteContent(Azure.ResourceManager.IotHub.Models.RoutingMessage message = null, Azure.ResourceManager.IotHub.Models.RoutingRuleProperties route = null, Azure.ResourceManager.IotHub.Models.RoutingTwin twin = null) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubTestRouteResult IotHubTestRouteResult(Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus? result = default(Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.Models.RouteCompilationError> detailsCompilationErrors = null) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubTypeName IotHubTypeName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubUserSubscriptionQuota IotHubUserSubscriptionQuota(string iotHubTypeId = null, string userSubscriptionQuotaType = null, string unit = null, int? currentValue = default(int?), int? limit = default(int?), Azure.ResourceManager.IotHub.Models.IotHubTypeName name = null) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.RouteCompilationError RouteCompilationError(string message = null, Azure.ResourceManager.IotHub.Models.RouteErrorSeverity? severity = default(Azure.ResourceManager.IotHub.Models.RouteErrorSeverity?), Azure.ResourceManager.IotHub.Models.RouteErrorRange location = null) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.RouteErrorPosition RouteErrorPosition(int? line = default(int?), int? column = default(int?)) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.RouteErrorRange RouteErrorRange(Azure.ResourceManager.IotHub.Models.RouteErrorPosition start = null, Azure.ResourceManager.IotHub.Models.RouteErrorPosition end = null) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.RoutingCosmosDBSqlApiProperties RoutingCosmosDBSqlApiProperties(string name = null, string id = null, string subscriptionId = null, string resourceGroup = null, System.Uri endpointUri = null, Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType? authenticationType = default(Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType?), Azure.Core.ResourceIdentifier userAssignedIdentity = null, string primaryKey = null, string secondaryKey = null, string databaseName = null, string containerName = null, string partitionKeyName = null, string partitionKeyTemplate = null) { throw null; }
    }
    public partial class CloudToDeviceFeedbackQueueProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.CloudToDeviceFeedbackQueueProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.CloudToDeviceFeedbackQueueProperties>
    {
        public CloudToDeviceFeedbackQueueProperties() { }
        public System.TimeSpan? LockDurationAsIso8601 { get { throw null; } set { } }
        public int? MaxDeliveryCount { get { throw null; } set { } }
        public System.TimeSpan? TtlAsIso8601 { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.CloudToDeviceFeedbackQueueProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.CloudToDeviceFeedbackQueueProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.CloudToDeviceFeedbackQueueProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.CloudToDeviceFeedbackQueueProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.CloudToDeviceFeedbackQueueProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.CloudToDeviceFeedbackQueueProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.CloudToDeviceFeedbackQueueProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudToDeviceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.CloudToDeviceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.CloudToDeviceProperties>
    {
        public CloudToDeviceProperties() { }
        public System.TimeSpan? DefaultTtlAsIso8601 { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.CloudToDeviceFeedbackQueueProperties Feedback { get { throw null; } set { } }
        public int? MaxDeliveryCount { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.CloudToDeviceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.CloudToDeviceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.CloudToDeviceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.CloudToDeviceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.CloudToDeviceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.CloudToDeviceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.CloudToDeviceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventHubCompatibleEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.EventHubCompatibleEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.EventHubCompatibleEndpointProperties>
    {
        public EventHubCompatibleEndpointProperties() { }
        public string Endpoint { get { throw null; } }
        public string EventHubCompatibleName { get { throw null; } }
        public int? PartitionCount { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> PartitionIds { get { throw null; } }
        public long? RetentionTimeInDays { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.EventHubCompatibleEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.EventHubCompatibleEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.EventHubCompatibleEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.EventHubCompatibleEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.EventHubCompatibleEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.EventHubCompatibleEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.EventHubCompatibleEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventHubConsumerGroupInfoCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.EventHubConsumerGroupInfoCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.EventHubConsumerGroupInfoCreateOrUpdateContent>
    {
        public EventHubConsumerGroupInfoCreateOrUpdateContent(string name) { }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.EventHubConsumerGroupInfoCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.EventHubConsumerGroupInfoCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.EventHubConsumerGroupInfoCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.EventHubConsumerGroupInfoCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.EventHubConsumerGroupInfoCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.EventHubConsumerGroupInfoCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.EventHubConsumerGroupInfoCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportDevicesContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.ExportDevicesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.ExportDevicesContent>
    {
        public ExportDevicesContent(System.Uri exportBlobContainerUri, bool excludeKeys) { }
        public Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string ConfigurationsBlobName { get { throw null; } set { } }
        public bool ExcludeKeys { get { throw null; } }
        public System.Uri ExportBlobContainerUri { get { throw null; } }
        public string ExportBlobName { get { throw null; } set { } }
        public bool? IncludeConfigurations { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.ExportDevicesContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.ExportDevicesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.ExportDevicesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.ExportDevicesContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.ExportDevicesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.ExportDevicesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.ExportDevicesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubAuthenticationType : System.IEquatable<Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType IdentityBased { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType KeyBased { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType left, Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType left, Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubCapability : System.IEquatable<Azure.ResourceManager.IotHub.Models.IotHubCapability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubCapability(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubCapability DeviceManagement { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubCapability None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.IotHubCapability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.IotHubCapability left, Azure.ResourceManager.IotHub.Models.IotHubCapability right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.IotHubCapability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.IotHubCapability left, Azure.ResourceManager.IotHub.Models.IotHubCapability right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubCapacity>
    {
        internal IotHubCapacity() { }
        public long? Default { get { throw null; } }
        public long? Maximum { get { throw null; } }
        public long? Minimum { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubScaleType? ScaleType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubCertificateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubCertificateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubCertificateProperties>
    {
        public IotHubCertificateProperties() { }
        public System.BinaryData Certificate { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public bool? IsVerified { get { throw null; } set { } }
        public string Subject { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Please use `ThumbprintString` instead.", false)]
        public System.BinaryData Thumbprint { get { throw null; } }
        public string ThumbprintString { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubCertificateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubCertificateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubCertificateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubCertificateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubCertificateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubCertificateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubCertificateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubCertificatePropertiesWithNonce : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubCertificatePropertiesWithNonce>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubCertificatePropertiesWithNonce>
    {
        internal IotHubCertificatePropertiesWithNonce() { }
        public System.BinaryData Certificate { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public bool? IsVerified { get { throw null; } }
        public string Subject { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Please use `ThumbprintString` instead.", false)]
        public System.BinaryData Thumbprint { get { throw null; } }
        public string ThumbprintString { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public string VerificationCode { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubCertificatePropertiesWithNonce System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubCertificatePropertiesWithNonce>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubCertificatePropertiesWithNonce>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubCertificatePropertiesWithNonce System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubCertificatePropertiesWithNonce>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubCertificatePropertiesWithNonce>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubCertificatePropertiesWithNonce>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubCertificateVerificationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubCertificateVerificationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubCertificateVerificationContent>
    {
        public IotHubCertificateVerificationContent() { }
        public System.BinaryData Certificate { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubCertificateVerificationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubCertificateVerificationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubCertificateVerificationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubCertificateVerificationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubCertificateVerificationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubCertificateVerificationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubCertificateVerificationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubCertificateWithNonceDescription : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubCertificateWithNonceDescription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubCertificateWithNonceDescription>
    {
        internal IotHubCertificateWithNonceDescription() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubCertificatePropertiesWithNonce Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubCertificateWithNonceDescription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubCertificateWithNonceDescription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubCertificateWithNonceDescription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubCertificateWithNonceDescription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubCertificateWithNonceDescription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubCertificateWithNonceDescription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubCertificateWithNonceDescription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubDescriptionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubDescriptionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubDescriptionPatch>
    {
        public IotHubDescriptionPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubDescriptionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubDescriptionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubDescriptionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubDescriptionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubDescriptionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubDescriptionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubDescriptionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubEndpointHealthInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthInfo>
    {
        internal IotHubEndpointHealthInfo() { }
        public string EndpointId { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus? HealthStatus { get { throw null; } }
        public string LastKnownError { get { throw null; } }
        public System.DateTimeOffset? LastKnownErrorOn { get { throw null; } }
        public System.DateTimeOffset? LastSendAttemptOn { get { throw null; } }
        public System.DateTimeOffset? LastSuccessfulSendAttemptOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubEndpointHealthStatus : System.IEquatable<Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubEndpointHealthStatus(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus Dead { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus Degraded { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus Unhealthy { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus left, Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus left, Azure.ResourceManager.IotHub.Models.IotHubEndpointHealthStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubEnrichmentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubEnrichmentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubEnrichmentProperties>
    {
        public IotHubEnrichmentProperties(string key, string value, System.Collections.Generic.IEnumerable<string> endpointNames) { }
        public System.Collections.Generic.IList<string> EndpointNames { get { throw null; } }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubEnrichmentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubEnrichmentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubEnrichmentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubEnrichmentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubEnrichmentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubEnrichmentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubEnrichmentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubFailoverContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubFailoverContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubFailoverContent>
    {
        public IotHubFailoverContent(string failoverRegion) { }
        public string FailoverRegion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubFailoverContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubFailoverContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubFailoverContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubFailoverContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubFailoverContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubFailoverContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubFailoverContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubFallbackRouteProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubFallbackRouteProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubFallbackRouteProperties>
    {
        public IotHubFallbackRouteProperties(Azure.ResourceManager.IotHub.Models.IotHubRoutingSource source, System.Collections.Generic.IEnumerable<string> endpointNames, bool isEnabled) { }
        public string Condition { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EndpointNames { get { throw null; } }
        public bool IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.IotHubRoutingSource Source { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubFallbackRouteProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubFallbackRouteProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubFallbackRouteProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubFallbackRouteProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubFallbackRouteProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubFallbackRouteProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubFallbackRouteProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubImportDevicesContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubImportDevicesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubImportDevicesContent>
    {
        public IotHubImportDevicesContent(System.Uri inputBlobContainerUri, System.Uri outputBlobContainerUri) { }
        public Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string ConfigurationsBlobName { get { throw null; } set { } }
        public bool? IncludeConfigurations { get { throw null; } set { } }
        public System.Uri InputBlobContainerUri { get { throw null; } }
        public string InputBlobName { get { throw null; } set { } }
        public System.Uri OutputBlobContainerUri { get { throw null; } }
        public string OutputBlobName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubImportDevicesContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubImportDevicesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubImportDevicesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubImportDevicesContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubImportDevicesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubImportDevicesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubImportDevicesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum IotHubIPFilterActionType
    {
        Accept = 0,
        Reject = 1,
    }
    public partial class IotHubIPFilterRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubIPFilterRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubIPFilterRule>
    {
        public IotHubIPFilterRule(string filterName, Azure.ResourceManager.IotHub.Models.IotHubIPFilterActionType action, string ipMask) { }
        public Azure.ResourceManager.IotHub.Models.IotHubIPFilterActionType Action { get { throw null; } set { } }
        public string FilterName { get { throw null; } set { } }
        public string IPMask { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubIPFilterRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubIPFilterRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubIPFilterRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubIPFilterRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubIPFilterRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubIPFilterRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubIPFilterRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubJobInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubJobInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubJobInfo>
    {
        internal IotHubJobInfo() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string FailureReason { get { throw null; } }
        public string JobId { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubJobType? JobType { get { throw null; } }
        public string ParentJobId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubJobStatus? Status { get { throw null; } }
        public string StatusMessage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubJobInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubJobInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubJobInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubJobInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubJobInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubJobInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubJobInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum IotHubJobStatus
    {
        Unknown = 0,
        Enqueued = 1,
        Running = 2,
        Completed = 3,
        Failed = 4,
        Cancelled = 5,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubJobType : System.IEquatable<Azure.ResourceManager.IotHub.Models.IotHubJobType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubJobType(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubJobType Backup { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubJobType Export { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubJobType FactoryResetDevice { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubJobType FirmwareUpdate { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubJobType Import { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubJobType ReadDeviceProperties { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubJobType RebootDevice { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubJobType Unknown { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubJobType UpdateDeviceConfiguration { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubJobType WriteDeviceProperties { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.IotHubJobType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.IotHubJobType left, Azure.ResourceManager.IotHub.Models.IotHubJobType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.IotHubJobType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.IotHubJobType left, Azure.ResourceManager.IotHub.Models.IotHubJobType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubLocationDescription : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubLocationDescription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubLocationDescription>
    {
        internal IotHubLocationDescription() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubReplicaRoleType? Role { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubLocationDescription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubLocationDescription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubLocationDescription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubLocationDescription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubLocationDescription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubLocationDescription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubLocationDescription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubMatchedRoute : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubMatchedRoute>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubMatchedRoute>
    {
        internal IotHubMatchedRoute() { }
        public Azure.ResourceManager.IotHub.Models.RoutingRuleProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubMatchedRoute System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubMatchedRoute>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubMatchedRoute>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubMatchedRoute System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubMatchedRoute>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubMatchedRoute>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubMatchedRoute>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityContent>
    {
        public IotHubNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubNameAvailabilityResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityResponse>
    {
        internal IotHubNameAvailabilityResponse() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubNameUnavailableReason? Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubNameAvailabilityResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum IotHubNameUnavailableReason
    {
        Invalid = 0,
        AlreadyExists = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubNetworkRuleIPAction : System.IEquatable<Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleIPAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubNetworkRuleIPAction(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleIPAction Allow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleIPAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleIPAction left, Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleIPAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleIPAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleIPAction left, Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleIPAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubNetworkRuleSetDefaultAction : System.IEquatable<Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetDefaultAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubNetworkRuleSetDefaultAction(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetDefaultAction Allow { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetDefaultAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetDefaultAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetDefaultAction left, Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetDefaultAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetDefaultAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetDefaultAction left, Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetDefaultAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubNetworkRuleSetIPRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetIPRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetIPRule>
    {
        public IotHubNetworkRuleSetIPRule(string filterName, string ipMask) { }
        public Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleIPAction? Action { get { throw null; } set { } }
        public string FilterName { get { throw null; } set { } }
        public string IPMask { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetIPRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetIPRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetIPRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetIPRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetIPRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetIPRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetIPRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubNetworkRuleSetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetProperties>
    {
        public IotHubNetworkRuleSetProperties(bool applyToBuiltInEventHubEndpoint, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetIPRule> ipRules) { }
        public bool ApplyToBuiltInEventHubEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetDefaultAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetIPRule> IPRules { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubPrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointConnectionProperties>
    {
        public IotHubPrivateEndpointConnectionProperties(Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionState connectionState) { }
        public Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubPrivateEndpointGroupInformationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointGroupInformationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointGroupInformationProperties>
    {
        internal IotHubPrivateEndpointGroupInformationProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredDnsZoneNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointGroupInformationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointGroupInformationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointGroupInformationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointGroupInformationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointGroupInformationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointGroupInformationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubPrivateEndpointGroupInformationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionState>
    {
        public IotHubPrivateLinkServiceConnectionState(Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus status, string description) { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubPrivateLinkServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubPrivateLinkServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.IotHub.Models.IotHubPrivateLinkServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubProperties>
    {
        public IotHubProperties() { }
        public System.Collections.Generic.IList<string> AllowedFqdns { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule> AuthorizationPolicies { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.CloudToDeviceProperties CloudToDevice { get { throw null; } set { } }
        public string Comments { get { throw null; } set { } }
        public bool? DisableDeviceSas { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public bool? DisableModuleSas { get { throw null; } set { } }
        public bool? EnableDataResidency { get { throw null; } set { } }
        public bool? EnableFileUploadNotifications { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.IotHub.Models.EventHubCompatibleEndpointProperties> EventHubEndpoints { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubCapability? Features { get { throw null; } set { } }
        public string HostName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.Models.IotHubIPFilterRule> IPFilterRules { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IotHub.Models.IotHubLocationDescription> Locations { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.IotHub.Models.MessagingEndpointProperties> MessagingEndpoints { get { throw null; } }
        public string MinTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.IotHubNetworkRuleSetProperties NetworkRuleSets { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.IotHubPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public bool? RestrictOutboundNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.IotHubRoutingProperties Routing { get { throw null; } set { } }
        public string State { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.IotHub.Models.IotHubStorageEndpointProperties> StorageEndpoints { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.IotHub.Models.IotHubPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.IotHubPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.IotHubPublicNetworkAccess left, Azure.ResourceManager.IotHub.Models.IotHubPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.IotHubPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.IotHubPublicNetworkAccess left, Azure.ResourceManager.IotHub.Models.IotHubPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubQuotaMetricInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubQuotaMetricInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubQuotaMetricInfo>
    {
        internal IotHubQuotaMetricInfo() { }
        public long? CurrentValue { get { throw null; } }
        public long? MaxValue { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubQuotaMetricInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubQuotaMetricInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubQuotaMetricInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubQuotaMetricInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubQuotaMetricInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubQuotaMetricInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubQuotaMetricInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubRegistryStatistics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubRegistryStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubRegistryStatistics>
    {
        internal IotHubRegistryStatistics() { }
        public long? DisabledDeviceCount { get { throw null; } }
        public long? EnabledDeviceCount { get { throw null; } }
        public long? TotalDeviceCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubRegistryStatistics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubRegistryStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubRegistryStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubRegistryStatistics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubRegistryStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubRegistryStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubRegistryStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubReplicaRoleType : System.IEquatable<Azure.ResourceManager.IotHub.Models.IotHubReplicaRoleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubReplicaRoleType(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubReplicaRoleType Primary { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubReplicaRoleType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.IotHubReplicaRoleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.IotHubReplicaRoleType left, Azure.ResourceManager.IotHub.Models.IotHubReplicaRoleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.IotHubReplicaRoleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.IotHubReplicaRoleType left, Azure.ResourceManager.IotHub.Models.IotHubReplicaRoleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubRoutingProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubRoutingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubRoutingProperties>
    {
        public IotHubRoutingProperties() { }
        public Azure.ResourceManager.IotHub.Models.RoutingEndpoints Endpoints { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.Models.IotHubEnrichmentProperties> Enrichments { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubFallbackRouteProperties FallbackRoute { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.Models.RoutingRuleProperties> Routes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubRoutingProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubRoutingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubRoutingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubRoutingProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubRoutingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubRoutingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubRoutingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubRoutingSource : System.IEquatable<Azure.ResourceManager.IotHub.Models.IotHubRoutingSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubRoutingSource(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubRoutingSource DeviceConnectionStateEvents { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubRoutingSource DeviceJobLifecycleEvents { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubRoutingSource DeviceLifecycleEvents { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubRoutingSource DeviceMessages { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubRoutingSource Invalid { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubRoutingSource TwinChangeEvents { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.IotHubRoutingSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.IotHubRoutingSource left, Azure.ResourceManager.IotHub.Models.IotHubRoutingSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.IotHubRoutingSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.IotHubRoutingSource left, Azure.ResourceManager.IotHub.Models.IotHubRoutingSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum IotHubScaleType
    {
        None = 0,
        Automatic = 1,
        Manual = 2,
    }
    public enum IotHubSharedAccessRight
    {
        RegistryRead = 0,
        RegistryWrite = 1,
        ServiceConnect = 2,
        DeviceConnect = 3,
        RegistryReadRegistryWrite = 4,
        RegistryReadServiceConnect = 5,
        RegistryReadDeviceConnect = 6,
        RegistryWriteServiceConnect = 7,
        RegistryWriteDeviceConnect = 8,
        ServiceConnectDeviceConnect = 9,
        RegistryReadRegistryWriteServiceConnect = 10,
        RegistryReadRegistryWriteDeviceConnect = 11,
        RegistryReadServiceConnectDeviceConnect = 12,
        RegistryWriteServiceConnectDeviceConnect = 13,
        RegistryReadRegistryWriteServiceConnectDeviceConnect = 14,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubSku : System.IEquatable<Azure.ResourceManager.IotHub.Models.IotHubSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubSku(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubSku B1 { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubSku B2 { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubSku B3 { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubSku F1 { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubSku S1 { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubSku S2 { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubSku S3 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.IotHubSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.IotHubSku left, Azure.ResourceManager.IotHub.Models.IotHubSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.IotHubSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.IotHubSku left, Azure.ResourceManager.IotHub.Models.IotHubSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubSkuDescription : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubSkuDescription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubSkuDescription>
    {
        internal IotHubSkuDescription() { }
        public Azure.ResourceManager.IotHub.Models.IotHubCapacity Capacity { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubSkuInfo Sku { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubSkuDescription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubSkuDescription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubSkuDescription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubSkuDescription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubSkuDescription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubSkuDescription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubSkuDescription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubSkuInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubSkuInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubSkuInfo>
    {
        public IotHubSkuInfo(Azure.ResourceManager.IotHub.Models.IotHubSku name) { }
        public long? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.IotHubSku Name { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.IotHubSkuTier? Tier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubSkuInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubSkuInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubSkuInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubSkuInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubSkuInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubSkuInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubSkuInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum IotHubSkuTier
    {
        Free = 0,
        Standard = 1,
        Basic = 2,
    }
    public partial class IotHubStorageEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubStorageEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubStorageEndpointProperties>
    {
        public IotHubStorageEndpointProperties(string connectionString, string containerName) { }
        public Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public System.TimeSpan? SasTtlAsIso8601 { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubStorageEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubStorageEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubStorageEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubStorageEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubStorageEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubStorageEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubStorageEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubTestAllRoutesContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesContent>
    {
        public IotHubTestAllRoutesContent() { }
        public Azure.ResourceManager.IotHub.Models.RoutingMessage Message { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.IotHubRoutingSource? RoutingSource { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.RoutingTwin Twin { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubTestAllRoutesResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesResult>
    {
        internal IotHubTestAllRoutesResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IotHub.Models.IotHubMatchedRoute> Routes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubTestAllRoutesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubTestResultStatus : System.IEquatable<Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubTestResultStatus(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus False { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus True { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus Undefined { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus left, Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus left, Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubTestRouteContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubTestRouteContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubTestRouteContent>
    {
        public IotHubTestRouteContent(Azure.ResourceManager.IotHub.Models.RoutingRuleProperties route) { }
        public Azure.ResourceManager.IotHub.Models.RoutingMessage Message { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.RoutingRuleProperties Route { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.RoutingTwin Twin { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubTestRouteContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubTestRouteContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubTestRouteContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubTestRouteContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubTestRouteContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubTestRouteContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubTestRouteContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubTestRouteResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubTestRouteResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubTestRouteResult>
    {
        internal IotHubTestRouteResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IotHub.Models.RouteCompilationError> DetailsCompilationErrors { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubTestResultStatus? Result { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubTestRouteResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubTestRouteResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubTestRouteResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubTestRouteResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubTestRouteResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubTestRouteResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubTestRouteResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubTypeName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubTypeName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubTypeName>
    {
        internal IotHubTypeName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubTypeName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubTypeName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubTypeName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubTypeName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubTypeName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubTypeName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubTypeName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubUserSubscriptionQuota : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubUserSubscriptionQuota>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubUserSubscriptionQuota>
    {
        internal IotHubUserSubscriptionQuota() { }
        public int? CurrentValue { get { throw null; } }
        public string IotHubTypeId { get { throw null; } }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.IotHubTypeName Name { get { throw null; } }
        public string Unit { get { throw null; } }
        public string UserSubscriptionQuotaType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubUserSubscriptionQuota System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubUserSubscriptionQuota>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.IotHubUserSubscriptionQuota>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.IotHubUserSubscriptionQuota System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubUserSubscriptionQuota>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubUserSubscriptionQuota>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.IotHubUserSubscriptionQuota>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessagingEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.MessagingEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.MessagingEndpointProperties>
    {
        public MessagingEndpointProperties() { }
        public System.TimeSpan? LockDurationAsIso8601 { get { throw null; } set { } }
        public int? MaxDeliveryCount { get { throw null; } set { } }
        public System.TimeSpan? TtlAsIso8601 { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.MessagingEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.MessagingEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.MessagingEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.MessagingEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.MessagingEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.MessagingEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.MessagingEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RouteCompilationError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RouteCompilationError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RouteCompilationError>
    {
        internal RouteCompilationError() { }
        public Azure.ResourceManager.IotHub.Models.RouteErrorRange Location { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.RouteErrorSeverity? Severity { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RouteCompilationError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RouteCompilationError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RouteCompilationError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RouteCompilationError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RouteCompilationError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RouteCompilationError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RouteCompilationError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RouteErrorPosition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RouteErrorPosition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RouteErrorPosition>
    {
        internal RouteErrorPosition() { }
        public int? Column { get { throw null; } }
        public int? Line { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RouteErrorPosition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RouteErrorPosition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RouteErrorPosition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RouteErrorPosition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RouteErrorPosition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RouteErrorPosition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RouteErrorPosition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RouteErrorRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RouteErrorRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RouteErrorRange>
    {
        internal RouteErrorRange() { }
        public Azure.ResourceManager.IotHub.Models.RouteErrorPosition End { get { throw null; } }
        public Azure.ResourceManager.IotHub.Models.RouteErrorPosition Start { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RouteErrorRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RouteErrorRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RouteErrorRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RouteErrorRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RouteErrorRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RouteErrorRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RouteErrorRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RouteErrorSeverity : System.IEquatable<Azure.ResourceManager.IotHub.Models.RouteErrorSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RouteErrorSeverity(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.RouteErrorSeverity Error { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.RouteErrorSeverity Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.RouteErrorSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.RouteErrorSeverity left, Azure.ResourceManager.IotHub.Models.RouteErrorSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.RouteErrorSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.RouteErrorSeverity left, Azure.ResourceManager.IotHub.Models.RouteErrorSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoutingCosmosDBSqlApiProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingCosmosDBSqlApiProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingCosmosDBSqlApiProperties>
    {
        public RoutingCosmosDBSqlApiProperties(string name, System.Uri endpointUri, string databaseName, string containerName) { }
        public Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public System.Uri EndpointUri { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string PartitionKeyName { get { throw null; } set { } }
        public string PartitionKeyTemplate { get { throw null; } set { } }
        public string PrimaryKey { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RoutingCosmosDBSqlApiProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingCosmosDBSqlApiProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingCosmosDBSqlApiProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RoutingCosmosDBSqlApiProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingCosmosDBSqlApiProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingCosmosDBSqlApiProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingCosmosDBSqlApiProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoutingEndpoints : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingEndpoints>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingEndpoints>
    {
        public RoutingEndpoints() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.Models.RoutingCosmosDBSqlApiProperties> CosmosDBSqlContainers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.Models.RoutingEventHubProperties> EventHubs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.Models.RoutingServiceBusQueueEndpointProperties> ServiceBusQueues { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.Models.RoutingServiceBusTopicEndpointProperties> ServiceBusTopics { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotHub.Models.RoutingStorageContainerProperties> StorageContainers { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RoutingEndpoints System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingEndpoints>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingEndpoints>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RoutingEndpoints System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingEndpoints>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingEndpoints>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingEndpoints>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoutingEventHubProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingEventHubProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingEventHubProperties>
    {
        public RoutingEventHubProperties(string name) { }
        public Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string EntityPath { get { throw null; } set { } }
        public System.Guid? Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RoutingEventHubProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingEventHubProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingEventHubProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RoutingEventHubProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingEventHubProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingEventHubProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingEventHubProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoutingMessage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingMessage>
    {
        public RoutingMessage() { }
        public System.Collections.Generic.IDictionary<string, string> AppProperties { get { throw null; } }
        public string Body { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> SystemProperties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RoutingMessage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RoutingMessage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoutingRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingRuleProperties>
    {
        public RoutingRuleProperties(string name, Azure.ResourceManager.IotHub.Models.IotHubRoutingSource source, System.Collections.Generic.IEnumerable<string> endpointNames, bool isEnabled) { }
        public string Condition { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EndpointNames { get { throw null; } }
        public bool IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.IotHubRoutingSource Source { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RoutingRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RoutingRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoutingServiceBusQueueEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingServiceBusQueueEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingServiceBusQueueEndpointProperties>
    {
        public RoutingServiceBusQueueEndpointProperties(string name) { }
        public Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string EntityPath { get { throw null; } set { } }
        public System.Guid? Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RoutingServiceBusQueueEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingServiceBusQueueEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingServiceBusQueueEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RoutingServiceBusQueueEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingServiceBusQueueEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingServiceBusQueueEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingServiceBusQueueEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoutingServiceBusTopicEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingServiceBusTopicEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingServiceBusTopicEndpointProperties>
    {
        public RoutingServiceBusTopicEndpointProperties(string name) { }
        public Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string EntityPath { get { throw null; } set { } }
        public System.Guid? Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RoutingServiceBusTopicEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingServiceBusTopicEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingServiceBusTopicEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RoutingServiceBusTopicEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingServiceBusTopicEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingServiceBusTopicEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingServiceBusTopicEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoutingStorageContainerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingStorageContainerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingStorageContainerProperties>
    {
        public RoutingStorageContainerProperties(string name, string containerName) { }
        public Azure.ResourceManager.IotHub.Models.IotHubAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public int? BatchFrequencyInSeconds { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.RoutingStorageContainerPropertiesEncoding? Encoding { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string FileNameFormat { get { throw null; } set { } }
        public System.Guid? Id { get { throw null; } set { } }
        public int? MaxChunkSizeInBytes { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RoutingStorageContainerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingStorageContainerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingStorageContainerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RoutingStorageContainerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingStorageContainerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingStorageContainerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingStorageContainerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoutingStorageContainerPropertiesEncoding : System.IEquatable<Azure.ResourceManager.IotHub.Models.RoutingStorageContainerPropertiesEncoding>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoutingStorageContainerPropertiesEncoding(string value) { throw null; }
        public static Azure.ResourceManager.IotHub.Models.RoutingStorageContainerPropertiesEncoding Avro { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.RoutingStorageContainerPropertiesEncoding AvroDeflate { get { throw null; } }
        public static Azure.ResourceManager.IotHub.Models.RoutingStorageContainerPropertiesEncoding Json { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotHub.Models.RoutingStorageContainerPropertiesEncoding other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotHub.Models.RoutingStorageContainerPropertiesEncoding left, Azure.ResourceManager.IotHub.Models.RoutingStorageContainerPropertiesEncoding right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotHub.Models.RoutingStorageContainerPropertiesEncoding (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotHub.Models.RoutingStorageContainerPropertiesEncoding left, Azure.ResourceManager.IotHub.Models.RoutingStorageContainerPropertiesEncoding right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoutingTwin : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingTwin>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingTwin>
    {
        public RoutingTwin() { }
        public Azure.ResourceManager.IotHub.Models.RoutingTwinProperties Properties { get { throw null; } set { } }
        public System.BinaryData Tags { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RoutingTwin System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingTwin>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingTwin>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RoutingTwin System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingTwin>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingTwin>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingTwin>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoutingTwinProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingTwinProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingTwinProperties>
    {
        public RoutingTwinProperties() { }
        public System.BinaryData Desired { get { throw null; } set { } }
        public System.BinaryData Reported { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RoutingTwinProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingTwinProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.RoutingTwinProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.RoutingTwinProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingTwinProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingTwinProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.RoutingTwinProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharedAccessSignatureAuthorizationRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule>
    {
        public SharedAccessSignatureAuthorizationRule(string keyName, Azure.ResourceManager.IotHub.Models.IotHubSharedAccessRight rights) { }
        public string KeyName { get { throw null; } set { } }
        public string PrimaryKey { get { throw null; } set { } }
        public Azure.ResourceManager.IotHub.Models.IotHubSharedAccessRight Rights { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotHub.Models.SharedAccessSignatureAuthorizationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
