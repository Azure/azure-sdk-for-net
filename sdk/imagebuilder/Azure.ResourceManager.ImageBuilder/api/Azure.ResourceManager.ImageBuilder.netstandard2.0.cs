namespace Azure.ResourceManager.ImageBuilder
{
    public partial class AzureResourceManagerImageBuilderContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerImageBuilderContext() { }
        public static Azure.ResourceManager.ImageBuilder.AzureResourceManagerImageBuilderContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class ImageBuilderExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateResource> GetImageTemplate(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string imageTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateResource>> GetImageTemplateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string imageTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.ImageTemplateResource GetImageTemplateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputResource GetImageTemplateRunOutputResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.ImageTemplateCollection GetImageTemplates(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ImageBuilder.ImageTemplateResource> GetImageTemplates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ImageBuilder.ImageTemplateResource> GetImageTemplatesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerResource GetImageTemplateTriggerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ImageTemplateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ImageBuilder.ImageTemplateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImageBuilder.ImageTemplateResource>, System.Collections.IEnumerable
    {
        protected ImageTemplateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ImageBuilder.ImageTemplateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string imageTemplateName, Azure.ResourceManager.ImageBuilder.ImageTemplateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ImageBuilder.ImageTemplateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string imageTemplateName, Azure.ResourceManager.ImageBuilder.ImageTemplateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string imageTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string imageTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateResource> Get(string imageTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ImageBuilder.ImageTemplateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ImageBuilder.ImageTemplateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateResource>> GetAsync(string imageTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ImageBuilder.ImageTemplateResource> GetIfExists(string imageTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ImageBuilder.ImageTemplateResource>> GetIfExistsAsync(string imageTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ImageBuilder.ImageTemplateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ImageBuilder.ImageTemplateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ImageBuilder.ImageTemplateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImageBuilder.ImageTemplateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ImageTemplateData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.ImageTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.ImageTemplateData>
    {
        public ImageTemplateData(Azure.Core.AzureLocation location, Azure.ResourceManager.ImageBuilder.Models.ImageTemplateIdentity identity) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderDataDisk> AdditionalDataDisks { get { throw null; } }
        public Azure.ResourceManager.ImageBuilder.Models.ImageTemplateAutoRunState? AutoRunState { get { throw null; } set { } }
        public int? BuildTimeoutInMinutes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer> Customize { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor> Distribute { get { throw null; } }
        public Azure.ResourceManager.ImageBuilder.Models.ImageTemplateErrorHandling ErrorHandling { get { throw null; } set { } }
        public string ExactStagingResourceGroup { get { throw null; } }
        public Azure.ResourceManager.ImageBuilder.Models.ImageTemplateIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ImageBuilder.Models.ImageTemplateLastRunStatus LastRunStatus { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ManagedResourceTags { get { throw null; } }
        public Azure.ResourceManager.ImageBuilder.Models.ImageTemplateOptimizeConfig Optimize { get { throw null; } set { } }
        public Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningError ProvisioningError { get { throw null; } }
        public Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSource Source { get { throw null; } set { } }
        public string StagingResourceGroup { get { throw null; } set { } }
        public Azure.ResourceManager.ImageBuilder.Models.ImageTemplateValidationConfig Validate { get { throw null; } set { } }
        public Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVmProfile VmProfile { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.ImageTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.ImageTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.ImageTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.ImageTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.ImageTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.ImageTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.ImageTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.ImageTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.ImageTemplateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ImageTemplateResource() { }
        public virtual Azure.ResourceManager.ImageBuilder.ImageTemplateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Cancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string imageTemplateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputResource> GetImageTemplateRunOutput(string runOutputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputResource>> GetImageTemplateRunOutputAsync(string runOutputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputCollection GetImageTemplateRunOutputs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerResource> GetImageTemplateTrigger(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerResource>> GetImageTemplateTriggerAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerCollection GetImageTemplateTriggers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Run(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RunAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ImageBuilder.ImageTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.ImageTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.ImageTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.ImageTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.ImageTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.ImageTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.ImageTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ImageBuilder.ImageTemplateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ImageBuilder.ImageTemplateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ImageTemplateRunOutputCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputResource>, System.Collections.IEnumerable
    {
        protected ImageTemplateRunOutputCollection() { }
        public virtual Azure.Response<bool> Exists(string runOutputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string runOutputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputResource> Get(string runOutputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputResource>> GetAsync(string runOutputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputResource> GetIfExists(string runOutputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputResource>> GetIfExistsAsync(string runOutputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ImageTemplateRunOutputData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputData>
    {
        internal ImageTemplateRunOutputData() { }
        public string ArtifactId { get { throw null; } }
        public string ArtifactUri { get { throw null; } }
        public Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplateRunOutputResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ImageTemplateRunOutputResource() { }
        public virtual Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string imageTemplateName, string runOutputName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplateTriggerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerResource>, System.Collections.IEnumerable
    {
        protected ImageTemplateTriggerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string triggerName, Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string triggerName, Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerResource> Get(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerResource>> GetAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerResource> GetIfExists(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerResource>> GetIfExistsAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ImageTemplateTriggerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerData>
    {
        public ImageTemplateTriggerData() { }
        public Azure.ResourceManager.ImageBuilder.Models.TriggerProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplateTriggerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ImageTemplateTriggerResource() { }
        public virtual Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string imageTemplateName, string triggerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ImageBuilder.Mocking
{
    public partial class MockableImageBuilderArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableImageBuilderArmClient() { }
        public virtual Azure.ResourceManager.ImageBuilder.ImageTemplateResource GetImageTemplateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputResource GetImageTemplateRunOutputResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerResource GetImageTemplateTriggerResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableImageBuilderResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableImageBuilderResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateResource> GetImageTemplate(string imageTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImageBuilder.ImageTemplateResource>> GetImageTemplateAsync(string imageTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ImageBuilder.ImageTemplateCollection GetImageTemplates() { throw null; }
    }
    public partial class MockableImageBuilderSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableImageBuilderSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ImageBuilder.ImageTemplateResource> GetImageTemplates(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ImageBuilder.ImageTemplateResource> GetImageTemplatesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ImageBuilder.Models
{
    public static partial class ArmImageBuilderModelFactory
    {
        public static Azure.ResourceManager.ImageBuilder.Models.DistributeVersioner DistributeVersioner(string scheme = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.DistributeVersionerLatest DistributeVersionerLatest(int? major = default(int?)) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.DistributeVersionerSource DistributeVersionerSource() { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageBuilderDataDisk ImageBuilderDataDisk(int? sizeGB = default(int?)) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningError ImageBuilderProvisioningError(Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode? provisioningErrorCode = default(Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode?), string message = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageBuilderVirtualNetworkConfig ImageBuilderVirtualNetworkConfig(Azure.Core.ResourceIdentifier subnetId = null, Azure.Core.ResourceIdentifier containerInstanceSubnetId = null, string proxyVmSize = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer ImageTemplateCustomizer(string type = null, string name = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.ImageTemplateData ImageTemplateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSource source = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer> customize = null, Azure.ResourceManager.ImageBuilder.Models.ImageTemplateOptimizeConfig optimize = null, Azure.ResourceManager.ImageBuilder.Models.ImageTemplateValidationConfig validate = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor> distribute = null, Azure.ResourceManager.ImageBuilder.Models.ImageTemplateErrorHandling errorHandling = null, Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningState? provisioningState = default(Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningState?), Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningError provisioningError = null, Azure.ResourceManager.ImageBuilder.Models.ImageTemplateLastRunStatus lastRunStatus = null, int? buildTimeoutInMinutes = default(int?), Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVmProfile vmProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderDataDisk> additionalDataDisks = null, string stagingResourceGroup = null, string exactStagingResourceGroup = null, System.Collections.Generic.IDictionary<string, string> managedResourceTags = null, Azure.ResourceManager.ImageBuilder.Models.ImageTemplateAutoRunState? autoRunState = default(Azure.ResourceManager.ImageBuilder.Models.ImageTemplateAutoRunState?), Azure.ResourceManager.ImageBuilder.Models.ImageTemplateIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor ImageTemplateDistributor(string type = null, string runOutputName = null, System.Collections.Generic.IDictionary<string, string> artifactTags = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateErrorHandling ImageTemplateErrorHandling(Azure.ResourceManager.ImageBuilder.Models.ImageBuilderOnBuildError? onCustomizerError = default(Azure.ResourceManager.ImageBuilder.Models.ImageBuilderOnBuildError?), Azure.ResourceManager.ImageBuilder.Models.ImageBuilderOnBuildError? onValidationError = default(Azure.ResourceManager.ImageBuilder.Models.ImageBuilderOnBuildError?)) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateFileCustomizer ImageTemplateFileCustomizer(string name = null, string sourceUri = null, string sha256Checksum = null, string destination = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateFileValidator ImageTemplateFileValidator(string name = null, string sourceUri = null, string sha256Checksum = null, string destination = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateIdentity ImageTemplateIdentity(Azure.ResourceManager.ImageBuilder.Models.ImageBuilderIdentityType? type = default(Azure.ResourceManager.ImageBuilder.Models.ImageBuilderIdentityType?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateInVMValidator ImageTemplateInVMValidator(string type = null, string name = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateLastRunStatus ImageTemplateLastRunStatus(System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.ImageBuilder.Models.ImageTemplateRunState? runState = default(Azure.ResourceManager.ImageBuilder.Models.ImageTemplateRunState?), Azure.ResourceManager.ImageBuilder.Models.ImageTemplateRunSubState? runSubState = default(Azure.ResourceManager.ImageBuilder.Models.ImageTemplateRunSubState?), string message = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateManagedImageDistributor ImageTemplateManagedImageDistributor(string runOutputName = null, System.Collections.Generic.IDictionary<string, string> artifactTags = null, Azure.Core.ResourceIdentifier imageId = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation)) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateManagedImageSource ImageTemplateManagedImageSource(Azure.Core.ResourceIdentifier imageId = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateOptimizeConfig ImageTemplateOptimizeConfig(Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVMBootOptimizationState? vmBootState = default(Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVMBootOptimizationState?), Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWorkloadOptimization workload = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePatch ImageTemplatePatch(Azure.ResourceManager.ImageBuilder.Models.ImageTemplateIdentity identity = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor> distribute = null, Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVmProfile vmProfile = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePlatformImageSource ImageTemplatePlatformImageSource(string publisher = null, string offer = null, string sku = null, string version = null, string exactVersion = null, Azure.ResourceManager.ImageBuilder.Models.PlatformImagePurchasePlan planInfo = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePowerShellCustomizer ImageTemplatePowerShellCustomizer(string name = null, string scriptUri = null, string sha256Checksum = null, System.Collections.Generic.IEnumerable<string> inline = null, bool? isRunElevated = default(bool?), bool? isRunAsSystem = default(bool?), System.Collections.Generic.IEnumerable<int> validExitCodes = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePowerShellValidator ImageTemplatePowerShellValidator(string name = null, string scriptUri = null, string sha256Checksum = null, System.Collections.Generic.IEnumerable<string> inline = null, bool? isRunElevated = default(bool?), bool? isRunAsSystem = default(bool?), System.Collections.Generic.IEnumerable<int> validExitCodes = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateRestartCustomizer ImageTemplateRestartCustomizer(string name = null, string restartCommand = null, string restartCheckCommand = null, string restartTimeout = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.ImageTemplateRunOutputData ImageTemplateRunOutputData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string artifactId = null, string artifactUri = null, Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningState? provisioningState = default(Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSharedImageDistributor ImageTemplateSharedImageDistributor(string runOutputName = null, System.Collections.Generic.IDictionary<string, string> artifactTags = null, Azure.Core.ResourceIdentifier galleryImageId = null, System.Collections.Generic.IEnumerable<string> replicationRegions = null, bool? isExcludedFromLatest = default(bool?), Azure.ResourceManager.ImageBuilder.Models.SharedImageStorageAccountType? storageAccountType = default(Azure.ResourceManager.ImageBuilder.Models.SharedImageStorageAccountType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTargetRegion> targetRegions = null, Azure.ResourceManager.ImageBuilder.Models.DistributeVersioner versioning = null, Azure.ResourceManager.ImageBuilder.Models.ImageTemplateReplicationMode? replicationMode = default(Azure.ResourceManager.ImageBuilder.Models.ImageTemplateReplicationMode?)) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSharedImageVersionSource ImageTemplateSharedImageVersionSource(Azure.Core.ResourceIdentifier imageVersionId = null, string exactVersion = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateShellCustomizer ImageTemplateShellCustomizer(string name = null, string scriptUri = null, string sha256Checksum = null, System.Collections.Generic.IEnumerable<string> inline = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateShellValidator ImageTemplateShellValidator(string name = null, string scriptUri = null, string sha256Checksum = null, System.Collections.Generic.IEnumerable<string> inline = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSource ImageTemplateSource(string type = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTargetRegion ImageTemplateTargetRegion(string name = null, int? replicaCount = default(int?), Azure.ResourceManager.ImageBuilder.Models.SharedImageStorageAccountType? storageAccountType = default(Azure.ResourceManager.ImageBuilder.Models.SharedImageStorageAccountType?)) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.ImageTemplateTriggerData ImageTemplateTriggerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ImageBuilder.Models.TriggerProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTriggerStatus ImageTemplateTriggerStatus(string code = null, string message = null, System.DateTimeOffset? recordedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateValidationConfig ImageTemplateValidationConfig(bool? shouldContinueDistributeOnFailure = default(bool?), bool? isSourceValidationOnly = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateInVMValidator> inVMValidations = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVhdDistributor ImageTemplateVhdDistributor(string runOutputName = null, System.Collections.Generic.IDictionary<string, string> artifactTags = null, string uri = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVmProfile ImageTemplateVmProfile(string vmSize = null, int? osDiskSizeGB = default(int?), System.Collections.Generic.IEnumerable<string> userAssignedIdentities = null, Azure.ResourceManager.ImageBuilder.Models.ImageBuilderVirtualNetworkConfig vnetConfig = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWindowsUpdateCustomizer ImageTemplateWindowsUpdateCustomizer(string name = null, string searchCriteria = null, System.Collections.Generic.IEnumerable<string> filters = null, int? updateLimit = default(int?)) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWorkloadOptimization ImageTemplateWorkloadOptimization(Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWorkloadOptimizationState? state = default(Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWorkloadOptimizationState?), string scriptUri = null, string sha256Checksum = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.PlatformImagePurchasePlan PlatformImagePurchasePlan(string planName = null, string planProduct = null, string planPublisher = null) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.SourceImageTriggerProperties SourceImageTriggerProperties(Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTriggerStatus status = null, Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningState? provisioningState = default(Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.TriggerProperties TriggerProperties(string kind = null, Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTriggerStatus status = null, Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningState? provisioningState = default(Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningState?)) { throw null; }
    }
    public abstract partial class DistributeVersioner : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.DistributeVersioner>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.DistributeVersioner>
    {
        internal DistributeVersioner() { }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.DistributeVersioner JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.DistributeVersioner PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.DistributeVersioner System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.DistributeVersioner>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.DistributeVersioner>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.DistributeVersioner System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.DistributeVersioner>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.DistributeVersioner>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.DistributeVersioner>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DistributeVersionerLatest : Azure.ResourceManager.ImageBuilder.Models.DistributeVersioner, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.DistributeVersionerLatest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.DistributeVersionerLatest>
    {
        public DistributeVersionerLatest() { }
        public int? Major { get { throw null; } set { } }
        protected override Azure.ResourceManager.ImageBuilder.Models.DistributeVersioner JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ImageBuilder.Models.DistributeVersioner PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.DistributeVersionerLatest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.DistributeVersionerLatest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.DistributeVersionerLatest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.DistributeVersionerLatest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.DistributeVersionerLatest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.DistributeVersionerLatest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.DistributeVersionerLatest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DistributeVersionerSource : Azure.ResourceManager.ImageBuilder.Models.DistributeVersioner, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.DistributeVersionerSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.DistributeVersionerSource>
    {
        public DistributeVersionerSource() { }
        protected override Azure.ResourceManager.ImageBuilder.Models.DistributeVersioner JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ImageBuilder.Models.DistributeVersioner PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.DistributeVersionerSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.DistributeVersionerSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.DistributeVersionerSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.DistributeVersionerSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.DistributeVersionerSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.DistributeVersionerSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.DistributeVersionerSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageBuilderDataDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderDataDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderDataDisk>
    {
        public ImageBuilderDataDisk() { }
        public int? SizeGB { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageBuilderDataDisk JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageBuilderDataDisk PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageBuilderDataDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderDataDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderDataDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageBuilderDataDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderDataDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderDataDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderDataDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ImageBuilderIdentityType
    {
        UserAssigned = 0,
        None = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageBuilderOnBuildError : System.IEquatable<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderOnBuildError>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageBuilderOnBuildError(string value) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageBuilderOnBuildError Abort { get { throw null; } }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageBuilderOnBuildError Cleanup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ImageBuilder.Models.ImageBuilderOnBuildError other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ImageBuilder.Models.ImageBuilderOnBuildError left, Azure.ResourceManager.ImageBuilder.Models.ImageBuilderOnBuildError right) { throw null; }
        public static implicit operator Azure.ResourceManager.ImageBuilder.Models.ImageBuilderOnBuildError (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ImageBuilder.Models.ImageBuilderOnBuildError? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ImageBuilder.Models.ImageBuilderOnBuildError left, Azure.ResourceManager.ImageBuilder.Models.ImageBuilderOnBuildError right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImageBuilderProvisioningError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningError>
    {
        internal ImageBuilderProvisioningError() { }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode? ProvisioningErrorCode { get { throw null; } }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageBuilderProvisioningErrorCode : System.IEquatable<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageBuilderProvisioningErrorCode(string value) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode BadCustomizerType { get { throw null; } }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode BadDistributeType { get { throw null; } }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode BadManagedImageSource { get { throw null; } }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode BadPIRSource { get { throw null; } }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode BadSharedImageDistribute { get { throw null; } }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode BadSharedImageVersionSource { get { throw null; } }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode BadSourceType { get { throw null; } }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode BadStagingResourceGroup { get { throw null; } }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode BadValidatorType { get { throw null; } }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode NoCustomizerScript { get { throw null; } }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode NoValidatorScript { get { throw null; } }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode Other { get { throw null; } }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode ServerError { get { throw null; } }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode UnsupportedCustomizerType { get { throw null; } }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode UnsupportedValidatorType { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode left, Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode left, Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ImageBuilderProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Succeeded = 2,
        Failed = 3,
        Deleting = 4,
        Canceled = 5,
    }
    public partial class ImageBuilderVirtualNetworkConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderVirtualNetworkConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderVirtualNetworkConfig>
    {
        public ImageBuilderVirtualNetworkConfig() { }
        public Azure.Core.ResourceIdentifier ContainerInstanceSubnetId { get { throw null; } set { } }
        public string ProxyVmSize { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageBuilderVirtualNetworkConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageBuilderVirtualNetworkConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageBuilderVirtualNetworkConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderVirtualNetworkConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderVirtualNetworkConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageBuilderVirtualNetworkConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderVirtualNetworkConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderVirtualNetworkConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageBuilderVirtualNetworkConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ImageTemplateAutoRunState
    {
        AutoRunEnabled = 0,
        AutoRunDisabled = 1,
    }
    public abstract partial class ImageTemplateCustomizer : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer>
    {
        internal ImageTemplateCustomizer() { }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ImageTemplateDistributor : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor>
    {
        internal ImageTemplateDistributor() { }
        public System.Collections.Generic.IDictionary<string, string> ArtifactTags { get { throw null; } }
        public string RunOutputName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplateErrorHandling : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateErrorHandling>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateErrorHandling>
    {
        public ImageTemplateErrorHandling() { }
        public Azure.ResourceManager.ImageBuilder.Models.ImageBuilderOnBuildError? OnCustomizerError { get { throw null; } set { } }
        public Azure.ResourceManager.ImageBuilder.Models.ImageBuilderOnBuildError? OnValidationError { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateErrorHandling JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateErrorHandling PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateErrorHandling System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateErrorHandling>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateErrorHandling>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateErrorHandling System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateErrorHandling>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateErrorHandling>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateErrorHandling>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplateFileCustomizer : Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateFileCustomizer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateFileCustomizer>
    {
        public ImageTemplateFileCustomizer() { }
        public string Destination { get { throw null; } set { } }
        public string Sha256Checksum { get { throw null; } set { } }
        public string SourceUri { get { throw null; } set { } }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateFileCustomizer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateFileCustomizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateFileCustomizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateFileCustomizer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateFileCustomizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateFileCustomizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateFileCustomizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplateFileValidator : Azure.ResourceManager.ImageBuilder.Models.ImageTemplateInVMValidator, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateFileValidator>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateFileValidator>
    {
        public ImageTemplateFileValidator() { }
        public string Destination { get { throw null; } set { } }
        public string Sha256Checksum { get { throw null; } set { } }
        public string SourceUri { get { throw null; } set { } }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateInVMValidator JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateInVMValidator PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateFileValidator System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateFileValidator>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateFileValidator>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateFileValidator System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateFileValidator>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateFileValidator>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateFileValidator>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplateIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateIdentity>
    {
        public ImageTemplateIdentity() { }
        public Azure.ResourceManager.ImageBuilder.Models.ImageBuilderIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ImageTemplateInVMValidator : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateInVMValidator>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateInVMValidator>
    {
        internal ImageTemplateInVMValidator() { }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateInVMValidator JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateInVMValidator PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateInVMValidator System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateInVMValidator>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateInVMValidator>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateInVMValidator System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateInVMValidator>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateInVMValidator>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateInVMValidator>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplateLastRunStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateLastRunStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateLastRunStatus>
    {
        internal ImageTemplateLastRunStatus() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.ImageBuilder.Models.ImageTemplateRunState? RunState { get { throw null; } }
        public Azure.ResourceManager.ImageBuilder.Models.ImageTemplateRunSubState? RunSubState { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateLastRunStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateLastRunStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateLastRunStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateLastRunStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateLastRunStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateLastRunStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateLastRunStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateLastRunStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateLastRunStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplateManagedImageDistributor : Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateManagedImageDistributor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateManagedImageDistributor>
    {
        public ImageTemplateManagedImageDistributor(string runOutputName, Azure.Core.ResourceIdentifier imageId, Azure.Core.AzureLocation location) { }
        public Azure.Core.ResourceIdentifier ImageId { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateManagedImageDistributor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateManagedImageDistributor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateManagedImageDistributor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateManagedImageDistributor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateManagedImageDistributor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateManagedImageDistributor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateManagedImageDistributor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplateManagedImageSource : Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateManagedImageSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateManagedImageSource>
    {
        public ImageTemplateManagedImageSource(Azure.Core.ResourceIdentifier imageId) { }
        public Azure.Core.ResourceIdentifier ImageId { get { throw null; } set { } }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateManagedImageSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateManagedImageSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateManagedImageSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateManagedImageSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateManagedImageSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateManagedImageSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateManagedImageSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplateOptimizeConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateOptimizeConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateOptimizeConfig>
    {
        public ImageTemplateOptimizeConfig() { }
        public Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVMBootOptimizationState? VmBootState { get { throw null; } set { } }
        public Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWorkloadOptimization Workload { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateOptimizeConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateOptimizeConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateOptimizeConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateOptimizeConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateOptimizeConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateOptimizeConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateOptimizeConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateOptimizeConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateOptimizeConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplatePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePatch>
    {
        public ImageTemplatePatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor> Distribute { get { throw null; } }
        public Azure.ResourceManager.ImageBuilder.Models.ImageTemplateIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVmProfile VmProfile { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplatePlatformImageSource : Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePlatformImageSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePlatformImageSource>
    {
        public ImageTemplatePlatformImageSource() { }
        public string ExactVersion { get { throw null; } }
        public string Offer { get { throw null; } set { } }
        public Azure.ResourceManager.ImageBuilder.Models.PlatformImagePurchasePlan PlanInfo { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePlatformImageSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePlatformImageSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePlatformImageSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePlatformImageSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePlatformImageSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePlatformImageSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePlatformImageSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplatePowerShellCustomizer : Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePowerShellCustomizer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePowerShellCustomizer>
    {
        public ImageTemplatePowerShellCustomizer() { }
        public System.Collections.Generic.IList<string> Inline { get { throw null; } }
        public bool? IsRunAsSystem { get { throw null; } set { } }
        public bool? IsRunElevated { get { throw null; } set { } }
        public string ScriptUri { get { throw null; } set { } }
        public string Sha256Checksum { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> ValidExitCodes { get { throw null; } }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePowerShellCustomizer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePowerShellCustomizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePowerShellCustomizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePowerShellCustomizer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePowerShellCustomizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePowerShellCustomizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePowerShellCustomizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplatePowerShellValidator : Azure.ResourceManager.ImageBuilder.Models.ImageTemplateInVMValidator, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePowerShellValidator>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePowerShellValidator>
    {
        public ImageTemplatePowerShellValidator() { }
        public System.Collections.Generic.IList<string> Inline { get { throw null; } }
        public bool? IsRunAsSystem { get { throw null; } set { } }
        public bool? IsRunElevated { get { throw null; } set { } }
        public string ScriptUri { get { throw null; } set { } }
        public string Sha256Checksum { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> ValidExitCodes { get { throw null; } }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateInVMValidator JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateInVMValidator PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePowerShellValidator System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePowerShellValidator>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePowerShellValidator>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePowerShellValidator System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePowerShellValidator>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePowerShellValidator>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplatePowerShellValidator>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageTemplateReplicationMode : System.IEquatable<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateReplicationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageTemplateReplicationMode(string value) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateReplicationMode Full { get { throw null; } }
        public static Azure.ResourceManager.ImageBuilder.Models.ImageTemplateReplicationMode Shallow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ImageBuilder.Models.ImageTemplateReplicationMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ImageBuilder.Models.ImageTemplateReplicationMode left, Azure.ResourceManager.ImageBuilder.Models.ImageTemplateReplicationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ImageBuilder.Models.ImageTemplateReplicationMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ImageBuilder.Models.ImageTemplateReplicationMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ImageBuilder.Models.ImageTemplateReplicationMode left, Azure.ResourceManager.ImageBuilder.Models.ImageTemplateReplicationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImageTemplateRestartCustomizer : Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateRestartCustomizer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateRestartCustomizer>
    {
        public ImageTemplateRestartCustomizer() { }
        public string RestartCheckCommand { get { throw null; } set { } }
        public string RestartCommand { get { throw null; } set { } }
        public string RestartTimeout { get { throw null; } set { } }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateRestartCustomizer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateRestartCustomizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateRestartCustomizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateRestartCustomizer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateRestartCustomizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateRestartCustomizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateRestartCustomizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ImageTemplateRunState
    {
        Running = 0,
        Canceling = 1,
        Succeeded = 2,
        PartiallySucceeded = 3,
        Failed = 4,
        Canceled = 5,
    }
    public enum ImageTemplateRunSubState
    {
        Queued = 0,
        Building = 1,
        Customizing = 2,
        Optimizing = 3,
        Validating = 4,
        Distributing = 5,
    }
    public partial class ImageTemplateSharedImageDistributor : Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSharedImageDistributor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSharedImageDistributor>
    {
        public ImageTemplateSharedImageDistributor(string runOutputName, Azure.Core.ResourceIdentifier galleryImageId) { }
        public Azure.Core.ResourceIdentifier GalleryImageId { get { throw null; } set { } }
        public bool? IsExcludedFromLatest { get { throw null; } set { } }
        public Azure.ResourceManager.ImageBuilder.Models.ImageTemplateReplicationMode? ReplicationMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ReplicationRegions { get { throw null; } }
        public Azure.ResourceManager.ImageBuilder.Models.SharedImageStorageAccountType? StorageAccountType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTargetRegion> TargetRegions { get { throw null; } }
        public Azure.ResourceManager.ImageBuilder.Models.DistributeVersioner Versioning { get { throw null; } set { } }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSharedImageDistributor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSharedImageDistributor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSharedImageDistributor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSharedImageDistributor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSharedImageDistributor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSharedImageDistributor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSharedImageDistributor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplateSharedImageVersionSource : Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSharedImageVersionSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSharedImageVersionSource>
    {
        public ImageTemplateSharedImageVersionSource(Azure.Core.ResourceIdentifier imageVersionId) { }
        public string ExactVersion { get { throw null; } }
        public Azure.Core.ResourceIdentifier ImageVersionId { get { throw null; } set { } }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSharedImageVersionSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSharedImageVersionSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSharedImageVersionSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSharedImageVersionSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSharedImageVersionSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSharedImageVersionSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSharedImageVersionSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplateShellCustomizer : Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateShellCustomizer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateShellCustomizer>
    {
        public ImageTemplateShellCustomizer() { }
        public System.Collections.Generic.IList<string> Inline { get { throw null; } }
        public string ScriptUri { get { throw null; } set { } }
        public string Sha256Checksum { get { throw null; } set { } }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateShellCustomizer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateShellCustomizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateShellCustomizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateShellCustomizer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateShellCustomizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateShellCustomizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateShellCustomizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplateShellValidator : Azure.ResourceManager.ImageBuilder.Models.ImageTemplateInVMValidator, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateShellValidator>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateShellValidator>
    {
        public ImageTemplateShellValidator() { }
        public System.Collections.Generic.IList<string> Inline { get { throw null; } }
        public string ScriptUri { get { throw null; } set { } }
        public string Sha256Checksum { get { throw null; } set { } }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateInVMValidator JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateInVMValidator PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateShellValidator System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateShellValidator>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateShellValidator>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateShellValidator System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateShellValidator>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateShellValidator>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateShellValidator>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ImageTemplateSource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSource>
    {
        internal ImageTemplateSource() { }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplateTargetRegion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTargetRegion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTargetRegion>
    {
        public ImageTemplateTargetRegion(string name) { }
        public string Name { get { throw null; } set { } }
        public int? ReplicaCount { get { throw null; } set { } }
        public Azure.ResourceManager.ImageBuilder.Models.SharedImageStorageAccountType? StorageAccountType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTargetRegion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTargetRegion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTargetRegion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTargetRegion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTargetRegion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTargetRegion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTargetRegion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTargetRegion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTargetRegion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplateTriggerStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTriggerStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTriggerStatus>
    {
        internal ImageTemplateTriggerStatus() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? RecordedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTriggerStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTriggerStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTriggerStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTriggerStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTriggerStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTriggerStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTriggerStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTriggerStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTriggerStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplateValidationConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateValidationConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateValidationConfig>
    {
        public ImageTemplateValidationConfig() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateInVMValidator> InVMValidations { get { throw null; } }
        public bool? IsSourceValidationOnly { get { throw null; } set { } }
        public bool? ShouldContinueDistributeOnFailure { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateValidationConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateValidationConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateValidationConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateValidationConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateValidationConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateValidationConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateValidationConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateValidationConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateValidationConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplateVhdDistributor : Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVhdDistributor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVhdDistributor>
    {
        public ImageTemplateVhdDistributor(string runOutputName) { }
        public string Uri { get { throw null; } set { } }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateDistributor PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVhdDistributor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVhdDistributor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVhdDistributor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVhdDistributor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVhdDistributor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVhdDistributor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVhdDistributor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ImageTemplateVMBootOptimizationState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class ImageTemplateVmProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVmProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVmProfile>
    {
        public ImageTemplateVmProfile() { }
        public int? OsDiskSizeGB { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> UserAssignedIdentities { get { throw null; } }
        public string VmSize { get { throw null; } set { } }
        public Azure.ResourceManager.ImageBuilder.Models.ImageBuilderVirtualNetworkConfig VnetConfig { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVmProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVmProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVmProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVmProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVmProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVmProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVmProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVmProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateVmProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplateWindowsUpdateCustomizer : Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWindowsUpdateCustomizer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWindowsUpdateCustomizer>
    {
        public ImageTemplateWindowsUpdateCustomizer() { }
        public System.Collections.Generic.IList<string> Filters { get { throw null; } }
        public string SearchCriteria { get { throw null; } set { } }
        public int? UpdateLimit { get { throw null; } set { } }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ImageBuilder.Models.ImageTemplateCustomizer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWindowsUpdateCustomizer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWindowsUpdateCustomizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWindowsUpdateCustomizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWindowsUpdateCustomizer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWindowsUpdateCustomizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWindowsUpdateCustomizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWindowsUpdateCustomizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageTemplateWorkloadOptimization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWorkloadOptimization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWorkloadOptimization>
    {
        public ImageTemplateWorkloadOptimization() { }
        public string ScriptUri { get { throw null; } set { } }
        public string Sha256Checksum { get { throw null; } set { } }
        public Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWorkloadOptimizationState? State { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWorkloadOptimization JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWorkloadOptimization PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWorkloadOptimization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWorkloadOptimization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWorkloadOptimization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWorkloadOptimization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWorkloadOptimization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWorkloadOptimization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.ImageTemplateWorkloadOptimization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ImageTemplateWorkloadOptimizationState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class PlatformImagePurchasePlan : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.PlatformImagePurchasePlan>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.PlatformImagePurchasePlan>
    {
        public PlatformImagePurchasePlan(string planName, string planProduct, string planPublisher) { }
        public string PlanName { get { throw null; } set { } }
        public string PlanProduct { get { throw null; } set { } }
        public string PlanPublisher { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.PlatformImagePurchasePlan JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.PlatformImagePurchasePlan PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.PlatformImagePurchasePlan System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.PlatformImagePurchasePlan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.PlatformImagePurchasePlan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.PlatformImagePurchasePlan System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.PlatformImagePurchasePlan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.PlatformImagePurchasePlan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.PlatformImagePurchasePlan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SharedImageStorageAccountType : System.IEquatable<Azure.ResourceManager.ImageBuilder.Models.SharedImageStorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SharedImageStorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.ImageBuilder.Models.SharedImageStorageAccountType PremiumLRS { get { throw null; } }
        public static Azure.ResourceManager.ImageBuilder.Models.SharedImageStorageAccountType StandardLRS { get { throw null; } }
        public static Azure.ResourceManager.ImageBuilder.Models.SharedImageStorageAccountType StandardZRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ImageBuilder.Models.SharedImageStorageAccountType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ImageBuilder.Models.SharedImageStorageAccountType left, Azure.ResourceManager.ImageBuilder.Models.SharedImageStorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ImageBuilder.Models.SharedImageStorageAccountType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ImageBuilder.Models.SharedImageStorageAccountType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ImageBuilder.Models.SharedImageStorageAccountType left, Azure.ResourceManager.ImageBuilder.Models.SharedImageStorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SourceImageTriggerProperties : Azure.ResourceManager.ImageBuilder.Models.TriggerProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.SourceImageTriggerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.SourceImageTriggerProperties>
    {
        public SourceImageTriggerProperties() { }
        protected override Azure.ResourceManager.ImageBuilder.Models.TriggerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ImageBuilder.Models.TriggerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.SourceImageTriggerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.SourceImageTriggerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.SourceImageTriggerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.SourceImageTriggerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.SourceImageTriggerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.SourceImageTriggerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.SourceImageTriggerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TriggerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.TriggerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.TriggerProperties>
    {
        internal TriggerProperties() { }
        public Azure.ResourceManager.ImageBuilder.Models.ImageBuilderProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ImageBuilder.Models.ImageTemplateTriggerStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.TriggerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ImageBuilder.Models.TriggerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ImageBuilder.Models.TriggerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.TriggerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImageBuilder.Models.TriggerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImageBuilder.Models.TriggerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.TriggerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.TriggerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImageBuilder.Models.TriggerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
