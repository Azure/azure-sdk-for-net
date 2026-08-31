namespace Azure.ResourceManager.WorkloadsSapMonitor
{
    public partial class AzureResourceManagerWorkloadsSapMonitorContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerWorkloadsSapMonitorContext() { }
        public static Azure.ResourceManager.WorkloadsSapMonitor.AzureResourceManagerWorkloadsSapMonitorContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class SapLandscapeMonitorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorData>
    {
        public SapLandscapeMonitorData() { }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorPropertiesGrouping Grouping { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorMetricThresholds> TopMetricsThresholds { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapLandscapeMonitorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SapLandscapeMonitorResource() { }
        public virtual Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorResource> Update(Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorResource>> UpdateAsync(Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SapMonitorAlertCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertResource>, System.Collections.IEnumerable
    {
        protected SapMonitorAlertCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string alertName, Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string alertName, Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertResource> Get(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertResource>> GetAsync(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertResource> GetIfExists(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertResource>> GetIfExistsAsync(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapMonitorAlertData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertData>
    {
        public SapMonitorAlertData() { }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapMonitorAlertResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SapMonitorAlertResource() { }
        public virtual Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string alertName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SapMonitorAlertTemplateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateResource>, System.Collections.IEnumerable
    {
        protected SapMonitorAlertTemplateCollection() { }
        public virtual Azure.Response<bool> Exists(string alertTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateResource> Get(string alertTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateResource> GetAll(string providerType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateResource> GetAllAsync(string providerType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateResource>> GetAsync(string alertTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateResource> GetIfExists(string alertTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateResource>> GetIfExistsAsync(string alertTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapMonitorAlertTemplateData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateData>
    {
        internal SapMonitorAlertTemplateData() { }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertTemplateProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapMonitorAlertTemplateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SapMonitorAlertTemplateResource() { }
        public virtual Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string alertTemplateName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapMonitorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource>, System.Collections.IEnumerable
    {
        protected SapMonitorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource> Get(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource>> GetAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource> GetIfExists(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource>> GetIfExistsAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapMonitorData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorData>
    {
        public SapMonitorData(Azure.Core.AzureLocation location) { }
        public Azure.Core.AzureLocation? AppLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanConfiguration AppServicePlanConfiguration { get { throw null; } set { } }
        public Azure.ResponseError Errors { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogAnalyticsWorkspaceArmId { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MonitorSubnetId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MsiArmId { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.SapRoutingPreference? RoutingPreference { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountArmId { get { throw null; } }
        public string ZoneRedundancyPreference { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapMonitorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SapMonitorResource() { }
        public virtual Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorResource GetSapLandscapeMonitor() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertResource> GetSapMonitorAlert(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertResource>> GetSapMonitorAlertAsync(string alertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertCollection GetSapMonitorAlerts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateResource> GetSapMonitorAlertTemplate(string alertTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateResource>> GetSapMonitorAlertTemplateAsync(string alertTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateCollection GetSapMonitorAlertTemplates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceResource> GetSapProviderInstance(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceResource>> GetSapProviderInstanceAsync(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceCollection GetSapProviderInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SapProviderInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceResource>, System.Collections.IEnumerable
    {
        protected SapProviderInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string providerInstanceName, Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string providerInstanceName, Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceResource> Get(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceResource>> GetAsync(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceResource> GetIfExists(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceResource>> GetIfExistsAsync(string providerInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapProviderInstanceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceData>
    {
        public SapProviderInstanceData() { }
        public Azure.ResponseError Errors { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorHealth Health { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties ProviderSettings { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapProviderInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SapProviderInstanceResource() { }
        public virtual Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string providerInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class WorkloadsSapMonitorExtensions
    {
        public static Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorResource GetSapLandscapeMonitorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource> GetSapMonitor(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertResource GetSapMonitorAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateResource GetSapMonitorAlertTemplateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource>> GetSapMonitorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource GetSapMonitorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorCollection GetSapMonitors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource> GetSapMonitors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource> GetSapMonitorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceResource GetSapProviderInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.WorkloadsSapMonitor.Mocking
{
    public partial class MockableWorkloadsSapMonitorArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableWorkloadsSapMonitorArmClient() { }
        public virtual Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorResource GetSapLandscapeMonitorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertResource GetSapMonitorAlertResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateResource GetSapMonitorAlertTemplateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource GetSapMonitorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceResource GetSapProviderInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableWorkloadsSapMonitorResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableWorkloadsSapMonitorResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource> GetSapMonitor(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource>> GetSapMonitorAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorCollection GetSapMonitors() { throw null; }
    }
    public partial class MockableWorkloadsSapMonitorSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableWorkloadsSapMonitorSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource> GetSapMonitors(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorResource> GetSapMonitorsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.WorkloadsSapMonitor.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertAutoMitigate : System.IEquatable<Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertAutoMitigate>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertAutoMitigate(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertAutoMitigate Disable { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertAutoMitigate Enable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertAutoMitigate other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertAutoMitigate left, Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertAutoMitigate right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertAutoMitigate (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertAutoMitigate? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertAutoMitigate left, Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertAutoMitigate right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertRuleConditionalOperator : System.IEquatable<Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertRuleConditionalOperator(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator LessThanOrEqual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator left, Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator left, Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertRuleStatus : System.IEquatable<Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertRuleStatus(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleStatus left, Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleStatus left, Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertTemplateDefaultThresholdInputOption : System.IEquatable<Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateDefaultThresholdInputOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertTemplateDefaultThresholdInputOption(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateDefaultThresholdInputOption NotRequired { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateDefaultThresholdInputOption Optional { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateDefaultThresholdInputOption Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateDefaultThresholdInputOption other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateDefaultThresholdInputOption left, Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateDefaultThresholdInputOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateDefaultThresholdInputOption (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateDefaultThresholdInputOption? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateDefaultThresholdInputOption left, Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateDefaultThresholdInputOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AlertTemplateMetricMeasurement : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricMeasurement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricMeasurement>
    {
        internal AlertTemplateMetricMeasurement() { }
        public int? FrequencyInMinutes { get { throw null; } }
        public string MetricColumn { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricTriggerType? MetricTriggerType { get { throw null; } }
        public int? Threshold { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator? ThresholdOperator { get { throw null; } }
        public int? TimeWindowInMinutes { get { throw null; } }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricMeasurement JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricMeasurement PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricMeasurement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricMeasurement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricMeasurement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricMeasurement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricMeasurement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricMeasurement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricMeasurement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertTemplateMetricTriggerType : System.IEquatable<Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricTriggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertTemplateMetricTriggerType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricTriggerType Consecutive { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricTriggerType Total { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricTriggerType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricTriggerType left, Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricTriggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricTriggerType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricTriggerType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricTriggerType left, Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricTriggerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertTemplateParameterType : System.IEquatable<Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertTemplateParameterType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateParameterType CustomInput { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateParameterType LogAnalyticsQuery { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateParameterType ProviderProperty { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateParameterType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateParameterType left, Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateParameterType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateParameterType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateParameterType left, Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AlertTemplateQueryInputContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateQueryInputContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateQueryInputContent>
    {
        internal AlertTemplateQueryInputContent() { }
        public string DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string LaQuery { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateSelectionMode? SelectionMode { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateParameterType? Type { get { throw null; } }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateQueryInputContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateQueryInputContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateQueryInputContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateQueryInputContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateQueryInputContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateQueryInputContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateQueryInputContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateQueryInputContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateQueryInputContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertTemplateSelectionMode : System.IEquatable<Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateSelectionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertTemplateSelectionMode(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateSelectionMode Multiple { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateSelectionMode Single { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateSelectionMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateSelectionMode left, Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateSelectionMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateSelectionMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateSelectionMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateSelectionMode left, Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateSelectionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmWorkloadsSapMonitorModelFactory
    {
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricMeasurement AlertTemplateMetricMeasurement(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator? thresholdOperator = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator?), int? threshold = default(int?), Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricTriggerType? metricTriggerType = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricTriggerType?), string metricColumn = null, int? frequencyInMinutes = default(int?), int? timeWindowInMinutes = default(int?)) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateQueryInputContent AlertTemplateQueryInputContent(string name = null, Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateParameterType? type = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateParameterType?), string description = null, string defaultValue = null, string laQuery = null, Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateSelectionMode? selectionMode = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateSelectionMode?), string displayName = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.DB2ProviderInstanceProperties DB2ProviderInstanceProperties(string hostname = null, string dbName = null, string dbPort = null, string dbUsername = null, string dbPassword = null, System.Uri dbPasswordUri = null, string sapSid = null, Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference? sslPreference = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference?), System.Uri sslCertificateUri = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.HanaDBProviderInstanceProperties HanaDBProviderInstanceProperties(string hostname = null, string dbName = null, string sqlPort = null, string instanceNumber = null, string dbUsername = null, string dbPassword = null, System.Uri dbPasswordUri = null, System.Uri sslCertificateUri = null, string sslHostNameInCertificate = null, Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference? sslPreference = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference?), string sapSid = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.MsSqlServerProviderInstanceProperties MsSqlServerProviderInstanceProperties(string hostname = null, string dbPort = null, string dbUsername = null, string dbPassword = null, System.Uri dbPasswordUri = null, string sapSid = null, Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference? sslPreference = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference?), System.Uri sslCertificateUri = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.OracleProviderInstanceProperties OracleProviderInstanceProperties(string hostname = null, string dbPort = null, string dbName = null, string dbUsername = null, string dbPassword = null, System.Uri dbPasswordUri = null, string sapSid = null, Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference? sslPreference = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference?), System.Uri sslCertificateUri = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.PrometheusHAClusterProviderInstanceProperties PrometheusHAClusterProviderInstanceProperties(System.Uri prometheusUri = null, string hostname = null, string sid = null, string clusterName = null, Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference? sslPreference = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference?), System.Uri sslCertificateUri = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.PrometheusOSProviderInstanceProperties PrometheusOSProviderInstanceProperties(System.Uri prometheusUri = null, Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference? sslPreference = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference?), System.Uri sslCertificateUri = null, string sapSid = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.SapLandscapeMonitorData SapLandscapeMonitorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorProvisioningState?), Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorPropertiesGrouping grouping = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorMetricThresholds> topMetricsThresholds = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorMetricThresholds SapLandscapeMonitorMetricThresholds(string name = null, float? green = default(float?), float? yellow = default(float?), float? red = default(float?)) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorPropertiesGrouping SapLandscapeMonitorPropertiesGrouping(System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorSidMapping> landscape = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorSidMapping> sapApplication = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorSidMapping SapLandscapeMonitorSidMapping(string name = null, System.Collections.Generic.IEnumerable<string> topSid = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertData SapMonitorAlertData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertProperties properties = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertProperties SapMonitorAlertProperties(Azure.ResponseError errors = null, Azure.Core.ResourceIdentifier alertRuleResourceId = null, string templateName = null, string providerType = null, System.Collections.Generic.IEnumerable<string> providerNames = null, Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertRuleProperties alertRuleProperties = null, Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertQueryContent SapMonitorAlertQueryContent(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertRuleProperties SapMonitorAlertRuleProperties(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleStatus? status = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleStatus?), int? severity = default(int?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> actionGroups = null, int? threshold = default(int?), Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator? thresholdOperator = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator?), int? windowSize = default(int?), int? evaluationFrequency = default(int?), int? failingPeriodsToAlert = default(int?), Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator? failingPeriodsOperator = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator?), int? muteActionsDuration = default(int?), Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertAutoMitigate? autoMitigate = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertAutoMitigate?), string dimension = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertQueryContent> alertQueryParameters = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorAlertTemplateData SapMonitorAlertTemplateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertTemplateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertTemplateProperties SapMonitorAlertTemplateProperties(Azure.ResponseError errors = null, Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState?), string templateDisplayName = null, string providerType = null, string description = null, int? severity = default(int?), string query = null, Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator? thresholdOperator = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator?), int? defaultThreshold = default(int?), int? lowerBound = default(int?), int? upperBound = default(int?), Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateDefaultThresholdInputOption? defaultThresholdInputOption = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateDefaultThresholdInputOption?), string alertUnit = null, Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricMeasurement metricMeasurement = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateQueryInputContent> queryInputParameters = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanConfiguration SapMonitorAppServicePlanConfiguration(Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanTier? tier = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanTier?), int? capacity = default(int?)) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.SapMonitorData SapMonitorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState?), Azure.ResponseError errors = null, Azure.Core.AzureLocation? appLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.WorkloadsSapMonitor.Models.SapRoutingPreference? routingPreference = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.SapRoutingPreference?), string zoneRedundancyPreference = null, Azure.Core.ResourceIdentifier logAnalyticsWorkspaceArmId = null, Azure.Core.ResourceIdentifier monitorSubnetId = null, Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanConfiguration appServicePlanConfiguration = null, Azure.Core.ResourceIdentifier msiArmId = null, Azure.Core.ResourceIdentifier storageAccountArmId = null, string managedResourceGroupName = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorPatch SapMonitorPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.SapNetWeaverProviderInstanceProperties SapNetWeaverProviderInstanceProperties(string sapSid = null, string sapHostname = null, string sapInstanceNr = null, System.Collections.Generic.IEnumerable<string> sapHostFileEntries = null, string sapUsername = null, string sapPassword = null, System.Uri sapPasswordUri = null, string sapClientId = null, string sapPortNumber = null, System.Uri sslCertificateUri = null, Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference? sslPreference = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference?)) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.SapProviderInstanceData SapProviderInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState?), Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorHealth health = null, Azure.ResponseError errors = null, Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties providerSettings = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties SapProviderInstanceSpecificProperties(string providerType = null) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorHealth WorkloadsSapMonitorHealth(Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadProviderInstanceHealthState? healthState = default(Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadProviderInstanceHealthState?), string impactingReasons = null) { throw null; }
    }
    public partial class DB2ProviderInstanceProperties : Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.DB2ProviderInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.DB2ProviderInstanceProperties>
    {
        public DB2ProviderInstanceProperties() { }
        public string DBName { get { throw null; } set { } }
        public string DBPassword { get { throw null; } set { } }
        public System.Uri DBPasswordUri { get { throw null; } set { } }
        public string DBPort { get { throw null; } set { } }
        public string DBUsername { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public string SapSid { get { throw null; } set { } }
        public System.Uri SslCertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference? SslPreference { get { throw null; } set { } }
        protected override Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.DB2ProviderInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.DB2ProviderInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.DB2ProviderInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.DB2ProviderInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.DB2ProviderInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.DB2ProviderInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.DB2ProviderInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HanaDBProviderInstanceProperties : Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.HanaDBProviderInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.HanaDBProviderInstanceProperties>
    {
        public HanaDBProviderInstanceProperties() { }
        public string DBName { get { throw null; } set { } }
        public string DBPassword { get { throw null; } set { } }
        public System.Uri DBPasswordUri { get { throw null; } set { } }
        public string DBUsername { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public string InstanceNumber { get { throw null; } set { } }
        public string SapSid { get { throw null; } set { } }
        public string SqlPort { get { throw null; } set { } }
        public System.Uri SslCertificateUri { get { throw null; } set { } }
        public string SslHostNameInCertificate { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference? SslPreference { get { throw null; } set { } }
        protected override Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.HanaDBProviderInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.HanaDBProviderInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.HanaDBProviderInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.HanaDBProviderInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.HanaDBProviderInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.HanaDBProviderInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.HanaDBProviderInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MsSqlServerProviderInstanceProperties : Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.MsSqlServerProviderInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.MsSqlServerProviderInstanceProperties>
    {
        public MsSqlServerProviderInstanceProperties() { }
        public string DBPassword { get { throw null; } set { } }
        public System.Uri DBPasswordUri { get { throw null; } set { } }
        public string DBPort { get { throw null; } set { } }
        public string DBUsername { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public string SapSid { get { throw null; } set { } }
        public System.Uri SslCertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference? SslPreference { get { throw null; } set { } }
        protected override Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.MsSqlServerProviderInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.MsSqlServerProviderInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.MsSqlServerProviderInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.MsSqlServerProviderInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.MsSqlServerProviderInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.MsSqlServerProviderInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.MsSqlServerProviderInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleProviderInstanceProperties : Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.OracleProviderInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.OracleProviderInstanceProperties>
    {
        public OracleProviderInstanceProperties() { }
        public string DBName { get { throw null; } set { } }
        public string DBPassword { get { throw null; } set { } }
        public System.Uri DBPasswordUri { get { throw null; } set { } }
        public string DBPort { get { throw null; } set { } }
        public string DBUsername { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public string SapSid { get { throw null; } set { } }
        public System.Uri SslCertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference? SslPreference { get { throw null; } set { } }
        protected override Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.OracleProviderInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.OracleProviderInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.OracleProviderInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.OracleProviderInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.OracleProviderInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.OracleProviderInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.OracleProviderInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrometheusHAClusterProviderInstanceProperties : Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.PrometheusHAClusterProviderInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.PrometheusHAClusterProviderInstanceProperties>
    {
        public PrometheusHAClusterProviderInstanceProperties() { }
        public string ClusterName { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public System.Uri PrometheusUri { get { throw null; } set { } }
        public string Sid { get { throw null; } set { } }
        public System.Uri SslCertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference? SslPreference { get { throw null; } set { } }
        protected override Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.PrometheusHAClusterProviderInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.PrometheusHAClusterProviderInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.PrometheusHAClusterProviderInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.PrometheusHAClusterProviderInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.PrometheusHAClusterProviderInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.PrometheusHAClusterProviderInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.PrometheusHAClusterProviderInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrometheusOSProviderInstanceProperties : Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.PrometheusOSProviderInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.PrometheusOSProviderInstanceProperties>
    {
        public PrometheusOSProviderInstanceProperties() { }
        public System.Uri PrometheusUri { get { throw null; } set { } }
        public string SapSid { get { throw null; } set { } }
        public System.Uri SslCertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference? SslPreference { get { throw null; } set { } }
        protected override Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.PrometheusOSProviderInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.PrometheusOSProviderInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.PrometheusOSProviderInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.PrometheusOSProviderInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.PrometheusOSProviderInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.PrometheusOSProviderInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.PrometheusOSProviderInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapLandscapeMonitorMetricThresholds : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorMetricThresholds>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorMetricThresholds>
    {
        public SapLandscapeMonitorMetricThresholds() { }
        public float? Green { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public float? Red { get { throw null; } set { } }
        public float? Yellow { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorMetricThresholds JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorMetricThresholds PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorMetricThresholds System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorMetricThresholds>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorMetricThresholds>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorMetricThresholds System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorMetricThresholds>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorMetricThresholds>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorMetricThresholds>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapLandscapeMonitorPropertiesGrouping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorPropertiesGrouping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorPropertiesGrouping>
    {
        public SapLandscapeMonitorPropertiesGrouping() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorSidMapping> Landscape { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorSidMapping> SapApplication { get { throw null; } }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorPropertiesGrouping JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorPropertiesGrouping PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorPropertiesGrouping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorPropertiesGrouping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorPropertiesGrouping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorPropertiesGrouping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorPropertiesGrouping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorPropertiesGrouping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorPropertiesGrouping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapLandscapeMonitorProvisioningState : System.IEquatable<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapLandscapeMonitorProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorProvisioningState left, Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorProvisioningState left, Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapLandscapeMonitorSidMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorSidMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorSidMapping>
    {
        public SapLandscapeMonitorSidMapping() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TopSid { get { throw null; } }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorSidMapping JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorSidMapping PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorSidMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorSidMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorSidMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorSidMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorSidMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorSidMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapLandscapeMonitorSidMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapMonitorAlertProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertProperties>
    {
        public SapMonitorAlertProperties() { }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertRuleProperties AlertRuleProperties { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AlertRuleResourceId { get { throw null; } }
        public Azure.ResponseError Errors { get { throw null; } }
        public System.Collections.Generic.IList<string> ProviderNames { get { throw null; } }
        public string ProviderType { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState? ProvisioningState { get { throw null; } }
        public string TemplateName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapMonitorAlertQueryContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertQueryContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertQueryContent>
    {
        public SapMonitorAlertQueryContent() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertQueryContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertQueryContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertQueryContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertQueryContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertQueryContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertQueryContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertQueryContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertQueryContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertQueryContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapMonitorAlertRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertRuleProperties>
    {
        public SapMonitorAlertRuleProperties() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ActionGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertQueryContent> AlertQueryParameters { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertAutoMitigate? AutoMitigate { get { throw null; } set { } }
        public string Dimension { get { throw null; } set { } }
        public int? EvaluationFrequency { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator? FailingPeriodsOperator { get { throw null; } set { } }
        public int? FailingPeriodsToAlert { get { throw null; } set { } }
        public int? MuteActionsDuration { get { throw null; } set { } }
        public int? Severity { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleStatus? Status { get { throw null; } set { } }
        public int? Threshold { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator? ThresholdOperator { get { throw null; } set { } }
        public int? WindowSize { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertRuleProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertRuleProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapMonitorAlertTemplateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertTemplateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertTemplateProperties>
    {
        internal SapMonitorAlertTemplateProperties() { }
        public string AlertUnit { get { throw null; } }
        public int? DefaultThreshold { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateDefaultThresholdInputOption? DefaultThresholdInputOption { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResponseError Errors { get { throw null; } }
        public int? LowerBound { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateMetricMeasurement MetricMeasurement { get { throw null; } }
        public string ProviderType { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState? ProvisioningState { get { throw null; } }
        public string Query { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertTemplateQueryInputContent> QueryInputParameters { get { throw null; } }
        public int? Severity { get { throw null; } }
        public string TemplateDisplayName { get { throw null; } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.AlertRuleConditionalOperator? ThresholdOperator { get { throw null; } }
        public int? UpperBound { get { throw null; } }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertTemplateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertTemplateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertTemplateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertTemplateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertTemplateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertTemplateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertTemplateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertTemplateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAlertTemplateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapMonitorAppServicePlanConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanConfiguration>
    {
        public SapMonitorAppServicePlanConfiguration() { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanTier? Tier { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapMonitorAppServicePlanTier : System.IEquatable<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapMonitorAppServicePlanTier(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanTier ElasticPremium { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanTier PremiumV3 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanTier other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanTier left, Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanTier (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanTier? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanTier left, Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorAppServicePlanTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapMonitorPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorPatch>
    {
        public SapMonitorPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapMonitorPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapNetWeaverProviderInstanceProperties : Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapNetWeaverProviderInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapNetWeaverProviderInstanceProperties>
    {
        public SapNetWeaverProviderInstanceProperties() { }
        public string SapClientId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SapHostFileEntries { get { throw null; } }
        public string SapHostname { get { throw null; } set { } }
        public string SapInstanceNr { get { throw null; } set { } }
        public string SapPassword { get { throw null; } set { } }
        public System.Uri SapPasswordUri { get { throw null; } set { } }
        public string SapPortNumber { get { throw null; } set { } }
        public string SapSid { get { throw null; } set { } }
        public string SapUsername { get { throw null; } set { } }
        public System.Uri SslCertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference? SslPreference { get { throw null; } set { } }
        protected override Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.SapNetWeaverProviderInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapNetWeaverProviderInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapNetWeaverProviderInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.SapNetWeaverProviderInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapNetWeaverProviderInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapNetWeaverProviderInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapNetWeaverProviderInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class SapProviderInstanceSpecificProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties>
    {
        internal SapProviderInstanceSpecificProperties() { }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapProviderInstanceSpecificProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapRoutingPreference : System.IEquatable<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapRoutingPreference>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapRoutingPreference(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.SapRoutingPreference Default { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.SapRoutingPreference RouteAll { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapMonitor.Models.SapRoutingPreference other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapMonitor.Models.SapRoutingPreference left, Azure.ResourceManager.WorkloadsSapMonitor.Models.SapRoutingPreference right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.SapRoutingPreference (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.SapRoutingPreference? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapMonitor.Models.SapRoutingPreference left, Azure.ResourceManager.WorkloadsSapMonitor.Models.SapRoutingPreference right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapSslPreference : System.IEquatable<Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapSslPreference(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference Disabled { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference RootCertificate { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference ServerCertificate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference left, Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference left, Azure.ResourceManager.WorkloadsSapMonitor.Models.SapSslPreference right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadProviderInstanceHealthState : System.IEquatable<Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadProviderInstanceHealthState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadProviderInstanceHealthState(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadProviderInstanceHealthState Degraded { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadProviderInstanceHealthState Healthy { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadProviderInstanceHealthState Unavailable { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadProviderInstanceHealthState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadProviderInstanceHealthState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadProviderInstanceHealthState left, Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadProviderInstanceHealthState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadProviderInstanceHealthState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadProviderInstanceHealthState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadProviderInstanceHealthState left, Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadProviderInstanceHealthState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkloadsSapMonitorHealth : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorHealth>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorHealth>
    {
        internal WorkloadsSapMonitorHealth() { }
        public Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadProviderInstanceHealthState? HealthState { get { throw null; } }
        public string ImpactingReasons { get { throw null; } }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorHealth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorHealth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorHealth System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorHealth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorHealth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorHealth System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorHealth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorHealth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorHealth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadsSapMonitorProvisioningState : System.IEquatable<Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadsSapMonitorProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState Migrating { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState left, Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState left, Azure.ResourceManager.WorkloadsSapMonitor.Models.WorkloadsSapMonitorProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
