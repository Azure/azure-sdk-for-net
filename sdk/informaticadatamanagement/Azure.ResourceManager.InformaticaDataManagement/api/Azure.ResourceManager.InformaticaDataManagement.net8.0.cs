namespace Azure.ResourceManager.InformaticaDataManagement
{
    public partial class AzureResourceManagerInformaticaDataManagementContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerInformaticaDataManagementContext() { }
        public static Azure.ResourceManager.InformaticaDataManagement.AzureResourceManagerInformaticaDataManagementContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class InformaticaDataManagementExtensions
    {
        public static Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> GetInformaticaOrganization(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>> GetInformaticaOrganizationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource GetInformaticaOrganizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationCollection GetInformaticaOrganizations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> GetInformaticaOrganizations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> GetInformaticaOrganizationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource GetInformaticaServerlessRuntimeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class InformaticaOrganizationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>, System.Collections.IEnumerable
    {
        protected InformaticaOrganizationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> Get(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>> GetAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> GetIfExists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>> GetIfExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class InformaticaOrganizationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationData>
    {
        public InformaticaOrganizationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaOrganizationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InformaticaOrganizationResource() { }
        public virtual Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList> GetAllServerlessRuntimes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList>> GetAllServerlessRuntimesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource> GetInformaticaServerlessRuntime(string serverlessRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource>> GetInformaticaServerlessRuntimeAsync(string serverlessRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeCollection GetInformaticaServerlessRuntimes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse> GetServerlessMetadata(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse>> GetServerlessMetadataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> Update(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>> UpdateAsync(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InformaticaServerlessRuntimeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource>, System.Collections.IEnumerable
    {
        protected InformaticaServerlessRuntimeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverlessRuntimeName, Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverlessRuntimeName, Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverlessRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverlessRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource> Get(string serverlessRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource>> GetAsync(string serverlessRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource> GetIfExists(string serverlessRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource>> GetIfExistsAsync(string serverlessRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class InformaticaServerlessRuntimeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeData>
    {
        public InformaticaServerlessRuntimeData() { }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaServerlessRuntimeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InformaticaServerlessRuntimeResource() { }
        public virtual Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResult> CheckDependencies(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResult>> CheckDependenciesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName, string serverlessRuntimeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource> GetServerlessResourceById(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource>> GetServerlessResourceByIdAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StartFailedServerlessRuntime(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartFailedServerlessRuntimeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource> Update(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource>> UpdateAsync(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.InformaticaDataManagement.Mocking
{
    public partial class MockableInformaticaDataManagementArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableInformaticaDataManagementArmClient() { }
        public virtual Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource GetInformaticaOrganizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource GetInformaticaServerlessRuntimeResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableInformaticaDataManagementResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableInformaticaDataManagementResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> GetInformaticaOrganization(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>> GetInformaticaOrganizationAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationCollection GetInformaticaOrganizations() { throw null; }
    }
    public partial class MockableInformaticaDataManagementSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableInformaticaDataManagementSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> GetInformaticaOrganizations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> GetInformaticaOrganizationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.InformaticaDataManagement.Models
{
    public partial class AdvancedCustomProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties>
    {
        public AdvancedCustomProperties() { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmInformaticaDataManagementModelFactory
    {
        public static Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProperties CdiConfigProperties(string engineName = null, string engineVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationConfigs> applicationConfigs = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResult CheckDependenciesResult(int count = 0, string id = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency> references = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata ComputeUnitsMetadata(string name = null, System.Collections.Generic.IEnumerable<string> value = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationTypeMetadata InformaticaApplicationTypeMetadata(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationData InformaticaOrganizationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPatch InformaticaOrganizationPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPropertiesUpdate properties = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationProperties InformaticaOrganizationProperties(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProvisioningState? provisioningState = default(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProvisioningState?), Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProperties informaticaProperties = null, Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetails marketplaceDetails = null, Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetails userDetails = null, Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetails companyDetails = null, string linkOrganizationToken = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRegionsMetadata InformaticaRegionsMetadata(string id = null, string name = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeResourceFetchMetadata InformaticaRuntimeResourceFetchMetadata(string name = null, string createdTime = null, string updatedTime = null, string createdBy = null, string updatedBy = null, string id = null, Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeType runtimeType = default(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeType), string status = null, string statusLocalized = null, string statusMessage = null, Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessFetchConfigProperties serverlessConfigProperties = null, string description = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessFetchConfigProperties InformaticaServerlessFetchConfigProperties(string subnet = null, string applicationType = null, string resourceGroupName = null, string advancedCustomProperties = null, string supplementaryFileLocation = null, string platform = null, string tags = null, string vnet = null, string executionTimeout = null, string computeUnits = null, System.Guid? tenantId = default(System.Guid?), string subscriptionId = null, string region = null, Azure.Core.ResourceIdentifier serverlessArmResourceId = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeData InformaticaServerlessRuntimeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeProperties InformaticaServerlessRuntimeProperties(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProvisioningState? provisioningState = default(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProvisioningState?), string description = null, Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaPlatformType? platform = default(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaPlatformType?), Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationType? applicationType = default(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationType?), string computeUnits = null, string executionTimeout = null, string serverlessAccountLocation = null, Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfiguration networkInterfaceConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties> advancedCustomProperties = null, string supplementaryFileLocation = null, Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties serverlessRuntimeConfig = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag> serverlessRuntimeTags = null, string userContextToken = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList InformaticaServerlessRuntimeResourceList(System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeResourceFetchMetadata> informaticaRuntimeResources = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties ServerlessConfigProperties(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaPlatformType? platform = default(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaPlatformType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationTypeMetadata> applicationTypes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata> computeUnits = null, string executionTimeout = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRegionsMetadata> regions = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse ServerlessMetadataResponse(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeType? runtimeType = default(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeType?), Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties serverlessConfigProperties = null, Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties serverlessRuntimeConfigProperties = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties ServerlessRuntimeConfigProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProperties> cdiConfigProps = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProperties> cdieConfigProps = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigPropertiesUpdate ServerlessRuntimeConfigPropertiesUpdate(System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProperties> cdiConfigProps = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProperties> cdieConfigProps = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency ServerlessRuntimeDependency(string id = null, string appContextId = null, string path = null, string documentType = null, string description = null, string lastUpdatedTime = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimePropertiesUpdate ServerlessRuntimePropertiesUpdate(string description = null, Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaPlatformType? platform = default(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaPlatformType?), Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationType? applicationType = default(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationType?), string computeUnits = null, string executionTimeout = null, string serverlessAccountLocation = null, Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfigurationUpdate networkInterfaceConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties> advancedCustomProperties = null, string supplementaryFileLocation = null, Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigPropertiesUpdate serverlessRuntimeConfig = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag> serverlessRuntimeTags = null, string userContextToken = null) { throw null; }
    }
    public partial class CdiConfigProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProperties>
    {
        public CdiConfigProperties(string engineName, string engineVersion, System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationConfigs> applicationConfigs) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationConfigs> ApplicationConfigs { get { throw null; } }
        public string EngineName { get { throw null; } set { } }
        public string EngineVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckDependenciesResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResult>
    {
        internal CheckDependenciesResult() { }
        public int Count { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency> References { get { throw null; } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeUnitsMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata>
    {
        internal ComputeUnitsMetadata() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<string> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaApplicationConfigs : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationConfigs>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationConfigs>
    {
        public InformaticaApplicationConfigs(string applicationConfigsType, string name, string value, string platform, string customized, string defaultValue) { }
        public string ApplicationConfigsType { get { throw null; } set { } }
        public string Customized { get { throw null; } set { } }
        public string DefaultValue { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Platform { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationConfigs JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationConfigs PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationConfigs System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationConfigs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationConfigs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationConfigs System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationConfigs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationConfigs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationConfigs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InformaticaApplicationType : System.IEquatable<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InformaticaApplicationType(string value) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationType Cdi { get { throw null; } }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationType Cdie { get { throw null; } }
        public bool Equals(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationType left, Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationType left, Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InformaticaApplicationTypeMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationTypeMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationTypeMetadata>
    {
        internal InformaticaApplicationTypeMetadata() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationTypeMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationTypeMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationTypeMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationTypeMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationTypeMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationTypeMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationTypeMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationTypeMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationTypeMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaCompanyDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetails>
    {
        public InformaticaCompanyDetails() { }
        public string Business { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public int? NumberOfEmployees { get { throw null; } set { } }
        public string OfficeAddress { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaCompanyDetailsUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetailsUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetailsUpdate>
    {
        public InformaticaCompanyDetailsUpdate() { }
        public string Business { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public int? NumberOfEmployees { get { throw null; } set { } }
        public string OfficeAddress { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetailsUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetailsUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetailsUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetailsUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetailsUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetailsUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetailsUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetailsUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetailsUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaMarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetails>
    {
        public InformaticaMarketplaceDetails(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetails offerDetails) { }
        public string MarketplaceSubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetails OfferDetails { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaMarketplaceDetailsUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetailsUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetailsUpdate>
    {
        public InformaticaMarketplaceDetailsUpdate() { }
        public string MarketplaceSubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetailsUpdate OfferDetails { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetailsUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetailsUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetailsUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetailsUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetailsUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetailsUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetailsUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetailsUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetailsUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaNetworkInterfaceConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfiguration>
    {
        public InformaticaNetworkInterfaceConfiguration(Azure.Core.ResourceIdentifier vnetId, Azure.Core.ResourceIdentifier subnetId) { }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VnetId { get { throw null; } set { } }
        public string VnetResourceGuid { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaNetworkInterfaceConfigurationUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfigurationUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfigurationUpdate>
    {
        public InformaticaNetworkInterfaceConfigurationUpdate() { }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VnetId { get { throw null; } set { } }
        public string VnetResourceGuid { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfigurationUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfigurationUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfigurationUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfigurationUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfigurationUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfigurationUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfigurationUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfigurationUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfigurationUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaOfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetails>
    {
        public InformaticaOfferDetails(string publisherId, string offerId, string planId, string planName, string termId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaOfferDetailsUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetailsUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetailsUpdate>
    {
        public InformaticaOfferDetailsUpdate() { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetailsUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetailsUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetailsUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetailsUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetailsUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetailsUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetailsUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetailsUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOfferDetailsUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaOrganizationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPatch>
    {
        public InformaticaOrganizationPatch() { }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPropertiesUpdate Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaOrganizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationProperties>
    {
        public InformaticaOrganizationProperties() { }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetails CompanyDetails { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProperties InformaticaProperties { get { throw null; } set { } }
        public string LinkOrganizationToken { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetails MarketplaceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetails UserDetails { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaOrganizationPropertiesUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPropertiesUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPropertiesUpdate>
    {
        public InformaticaOrganizationPropertiesUpdate() { }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaCompanyDetailsUpdate CompanyDetails { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExistingResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPatch InformaticaOrganizationProperties { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaMarketplaceDetailsUpdate MarketplaceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetailsUpdate UserDetails { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPropertiesUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPropertiesUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPropertiesUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPropertiesUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPropertiesUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPropertiesUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPropertiesUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPropertiesUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationPropertiesUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InformaticaPlatformType : System.IEquatable<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaPlatformType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InformaticaPlatformType(string value) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaPlatformType Azure { get { throw null; } }
        public bool Equals(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaPlatformType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaPlatformType left, Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaPlatformType right) { throw null; }
        public static implicit operator Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaPlatformType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaPlatformType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaPlatformType left, Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaPlatformType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InformaticaProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProperties>
    {
        public InformaticaProperties() { }
        public string InformaticaRegion { get { throw null; } set { } }
        public string OrganizationId { get { throw null; } set { } }
        public string OrganizationName { get { throw null; } set { } }
        public System.Uri SingleSignOnUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InformaticaProvisioningState : System.IEquatable<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InformaticaProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProvisioningState left, Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProvisioningState left, Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InformaticaRegionsMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRegionsMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRegionsMetadata>
    {
        internal InformaticaRegionsMetadata() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRegionsMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRegionsMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRegionsMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRegionsMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRegionsMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRegionsMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRegionsMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRegionsMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRegionsMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaRuntimeResourceFetchMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeResourceFetchMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeResourceFetchMetadata>
    {
        internal InformaticaRuntimeResourceFetchMetadata() { }
        public string CreatedBy { get { throw null; } }
        public string CreatedTime { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeType RuntimeType { get { throw null; } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessFetchConfigProperties ServerlessConfigProperties { get { throw null; } }
        public string Status { get { throw null; } }
        public string StatusLocalized { get { throw null; } }
        public string StatusMessage { get { throw null; } }
        public string UpdatedBy { get { throw null; } }
        public string UpdatedTime { get { throw null; } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeResourceFetchMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeResourceFetchMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeResourceFetchMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeResourceFetchMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeResourceFetchMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeResourceFetchMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeResourceFetchMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeResourceFetchMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeResourceFetchMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InformaticaRuntimeType : System.IEquatable<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InformaticaRuntimeType(string value) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeType Serverless { get { throw null; } }
        public bool Equals(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeType left, Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeType left, Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InformaticaServerlessFetchConfigProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessFetchConfigProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessFetchConfigProperties>
    {
        internal InformaticaServerlessFetchConfigProperties() { }
        public string AdvancedCustomProperties { get { throw null; } }
        public string ApplicationType { get { throw null; } }
        public string ComputeUnits { get { throw null; } }
        public string ExecutionTimeout { get { throw null; } }
        public string Platform { get { throw null; } }
        public string Region { get { throw null; } }
        public string ResourceGroupName { get { throw null; } }
        public Azure.Core.ResourceIdentifier ServerlessArmResourceId { get { throw null; } }
        public string Subnet { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string SupplementaryFileLocation { get { throw null; } }
        public string Tags { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public string Vnet { get { throw null; } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessFetchConfigProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessFetchConfigProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessFetchConfigProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessFetchConfigProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessFetchConfigProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessFetchConfigProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessFetchConfigProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessFetchConfigProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessFetchConfigProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaServerlessRuntimePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimePatch>
    {
        public InformaticaServerlessRuntimePatch() { }
        public Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimePropertiesUpdate Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaServerlessRuntimeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeProperties>
    {
        public InformaticaServerlessRuntimeProperties(string serverlessAccountLocation) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties> AdvancedCustomProperties { get { throw null; } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationType? ApplicationType { get { throw null; } set { } }
        public string ComputeUnits { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string ExecutionTimeout { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfiguration NetworkInterfaceConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaPlatformType? Platform { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProvisioningState? ProvisioningState { get { throw null; } }
        public string ServerlessAccountLocation { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties ServerlessRuntimeConfig { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag> ServerlessRuntimeTags { get { throw null; } }
        public string SupplementaryFileLocation { get { throw null; } set { } }
        public string UserContextToken { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaServerlessRuntimeResourceList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList>
    {
        internal InformaticaServerlessRuntimeResourceList() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeResourceFetchMetadata> InformaticaRuntimeResources { get { throw null; } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaUserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetails>
    {
        public InformaticaUserDetails() { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaUserDetailsUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetailsUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetailsUpdate>
    {
        public InformaticaUserDetailsUpdate() { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetailsUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetailsUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetailsUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetailsUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetailsUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetailsUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetailsUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetailsUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaUserDetailsUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerlessConfigProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties>
    {
        internal ServerlessConfigProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationTypeMetadata> ApplicationTypes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata> ComputeUnits { get { throw null; } }
        public string ExecutionTimeout { get { throw null; } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaPlatformType? Platform { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRegionsMetadata> Regions { get { throw null; } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerlessMetadataResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse>
    {
        internal ServerlessMetadataResponse() { }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaRuntimeType? RuntimeType { get { throw null; } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties ServerlessConfigProperties { get { throw null; } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties ServerlessRuntimeConfigProperties { get { throw null; } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerlessRuntimeConfigProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties>
    {
        public ServerlessRuntimeConfigProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProperties> CdiConfigProps { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProperties> CdieConfigProps { get { throw null; } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerlessRuntimeConfigPropertiesUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigPropertiesUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigPropertiesUpdate>
    {
        public ServerlessRuntimeConfigPropertiesUpdate() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProperties> CdiConfigProps { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProperties> CdieConfigProps { get { throw null; } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigPropertiesUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigPropertiesUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigPropertiesUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigPropertiesUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigPropertiesUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigPropertiesUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigPropertiesUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigPropertiesUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigPropertiesUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerlessRuntimeDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency>
    {
        internal ServerlessRuntimeDependency() { }
        public string AppContextId { get { throw null; } }
        public string Description { get { throw null; } }
        public string DocumentType { get { throw null; } }
        public string Id { get { throw null; } }
        public string LastUpdatedTime { get { throw null; } }
        public string Path { get { throw null; } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerlessRuntimePropertiesUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimePropertiesUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimePropertiesUpdate>
    {
        public ServerlessRuntimePropertiesUpdate() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties> AdvancedCustomProperties { get { throw null; } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaApplicationType? ApplicationType { get { throw null; } set { } }
        public string ComputeUnits { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string ExecutionTimeout { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaNetworkInterfaceConfigurationUpdate NetworkInterfaceConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaPlatformType? Platform { get { throw null; } set { } }
        public string ServerlessAccountLocation { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigPropertiesUpdate ServerlessRuntimeConfig { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag> ServerlessRuntimeTags { get { throw null; } }
        public string SupplementaryFileLocation { get { throw null; } set { } }
        public string UserContextToken { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimePropertiesUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimePropertiesUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimePropertiesUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimePropertiesUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimePropertiesUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimePropertiesUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimePropertiesUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimePropertiesUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimePropertiesUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerlessRuntimeTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag>
    {
        public ServerlessRuntimeTag() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
