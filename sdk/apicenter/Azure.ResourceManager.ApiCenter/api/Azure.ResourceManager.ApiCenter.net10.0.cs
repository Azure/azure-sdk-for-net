namespace Azure.ResourceManager.ApiCenter
{
    public partial class ApiCenterApiCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterApiResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterApiResource>, System.Collections.IEnumerable
    {
        protected ApiCenterApiCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterApiResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string apiName, Azure.ResourceManager.ApiCenter.ApiCenterApiData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterApiResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string apiName, Azure.ResourceManager.ApiCenter.ApiCenterApiData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterApiResource> Get(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiCenterApiResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiCenterApiResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterApiResource>> GetAsync(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiCenterApiResource> GetIfExists(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiCenterApiResource>> GetIfExistsAsync(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.ApiCenterApiResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterApiResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.ApiCenterApiResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterApiResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiCenterApiData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterApiData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterApiData>
    {
        public ApiCenterApiData() { }
        public Azure.ResourceManager.ApiCenter.Models.ApiCenterApiProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiCenterApiData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterApiData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterApiData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiCenterApiData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterApiData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterApiData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterApiData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiCenterApiDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionResource>, System.Collections.IEnumerable
    {
        protected ApiCenterApiDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string definitionName, Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string definitionName, Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionResource> Get(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionResource>> GetAsync(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionResource> GetIfExists(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionResource>> GetIfExistsAsync(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiCenterApiDefinitionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionData>
    {
        public ApiCenterApiDefinitionData() { }
        public Azure.ResourceManager.ApiCenter.Models.ApiCenterApiDefinitionProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiCenterApiDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiCenterApiDefinitionResource() { }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string workspaceName, string apiName, string versionName, string definitionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResult> ExportSpecification(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResult>> ExportSpecificationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Head(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> HeadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ImportSpecification(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.Models.ApiSpecImportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ImportSpecificationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.Models.ApiSpecImportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiCenterApiResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterApiData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterApiData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiCenterApiResource() { }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterApiData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string workspaceName, string apiName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterApiResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionResource> GetApiCenterApiVersion(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionResource>> GetApiCenterApiVersionAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterApiVersionCollection GetApiCenterApiVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentResource> GetApiCenterDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentResource>> GetApiCenterDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterDeploymentCollection GetApiCenterDeployments() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterApiResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Head(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response HeadApiVersion(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> HeadApiVersionAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> HeadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response HeadDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> HeadDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiCenterApiData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterApiData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterApiData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiCenterApiData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterApiData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterApiData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterApiData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterApiResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiCenterApiData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterApiResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiCenterApiData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiCenterApiVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionResource>, System.Collections.IEnumerable
    {
        protected ApiCenterApiVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string versionName, Azure.ResourceManager.ApiCenter.ApiCenterApiVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string versionName, Azure.ResourceManager.ApiCenter.ApiCenterApiVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionResource> Get(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionResource>> GetAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionResource> GetIfExists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionResource>> GetIfExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiCenterApiVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionData>
    {
        public ApiCenterApiVersionData() { }
        public Azure.ResourceManager.ApiCenter.Models.ApiCenterApiVersionProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiCenterApiVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiCenterApiVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiCenterApiVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiCenterApiVersionResource() { }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterApiVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string workspaceName, string apiName, string versionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionResource> GetApiCenterApiDefinition(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionResource>> GetApiCenterApiDefinitionAsync(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionCollection GetApiCenterApiDefinitions() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Head(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Head(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> HeadAsync(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> HeadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiCenterApiVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiCenterApiVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiCenterApiVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterApiVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiCenterApiVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiCenterDeletedServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceResource>, System.Collections.IEnumerable
    {
        protected ApiCenterDeletedServiceCollection() { }
        public virtual Azure.Response<bool> Exists(string deletedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deletedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceResource> Get(string deletedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceResource>> GetAsync(string deletedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceResource> GetIfExists(string deletedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceResource>> GetIfExistsAsync(string deletedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiCenterDeletedServiceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceData>
    {
        internal ApiCenterDeletedServiceData() { }
        public Azure.ResourceManager.ApiCenter.Models.ApiCenterDeletedServiceProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiCenterDeletedServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiCenterDeletedServiceResource() { }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deletedServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiCenterDeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentResource>, System.Collections.IEnumerable
    {
        protected ApiCenterDeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.ApiCenter.ApiCenterDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.ApiCenter.ApiCenterDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentResource> GetIfExists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentResource>> GetIfExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiCenterDeploymentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentData>
    {
        public ApiCenterDeploymentData() { }
        public Azure.ResourceManager.ApiCenter.Models.ApiCenterDeploymentProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiCenterDeploymentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiCenterDeploymentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiCenterDeploymentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiCenterDeploymentResource() { }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterDeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string workspaceName, string apiName, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Head(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> HeadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiCenterDeploymentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiCenterDeploymentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiCenterDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterDeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiCenterDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiCenterEnvironmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentResource>, System.Collections.IEnumerable
    {
        protected ApiCenterEnvironmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string environmentName, Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string environmentName, Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentResource> Get(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentResource>> GetAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentResource> GetIfExists(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentResource>> GetIfExistsAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiCenterEnvironmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentData>
    {
        public ApiCenterEnvironmentData() { }
        public Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiCenterEnvironmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiCenterEnvironmentResource() { }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string workspaceName, string environmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Head(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> HeadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ApiCenterExtensions
    {
        public static Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionResource GetApiCenterApiDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiCenterApiResource GetApiCenterApiResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiCenterApiVersionResource GetApiCenterApiVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceResource> GetApiCenterDeletedService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deletedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceResource>> GetApiCenterDeletedServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deletedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceResource GetApiCenterDeletedServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceCollection GetApiCenterDeletedServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceResource> GetApiCenterDeletedServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceResource> GetApiCenterDeletedServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiCenterDeploymentResource GetApiCenterDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentResource GetApiCenterEnvironmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaResource GetApiCenterMetadataSchemaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> GetApiCenterService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>> GetApiCenterServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiCenterServiceResource GetApiCenterServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiCenterServiceCollection GetApiCenterServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> GetApiCenterServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> GetApiCenterServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceResource GetApiCenterWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiSourceResource GetApiSourceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ApiCenterMetadataSchemaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaResource>, System.Collections.IEnumerable
    {
        protected ApiCenterMetadataSchemaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string metadataSchemaName, Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string metadataSchemaName, Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaResource> Get(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaResource>> GetAsync(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaResource> GetIfExists(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaResource>> GetIfExistsAsync(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiCenterMetadataSchemaData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaData>
    {
        public ApiCenterMetadataSchemaData() { }
        public Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataSchemaProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiCenterMetadataSchemaResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiCenterMetadataSchemaResource() { }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string metadataSchemaName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Head(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> HeadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiCenterServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>, System.Collections.IEnumerable
    {
        protected ApiCenterServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.ApiCenter.ApiCenterServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.ApiCenter.ApiCenterServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> Get(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>> GetAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> GetIfExists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>> GetIfExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiCenterServiceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>
    {
        public ApiCenterServiceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState? ApiCenterServiceProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.ApiCenterServiceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiCenterServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiCenterServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiCenterServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiCenterServiceResource() { }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult> ExportMetadataSchema(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult>> ExportMetadataSchemaAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaResource> GetApiCenterMetadataSchema(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaResource>> GetApiCenterMetadataSchemaAsync(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaCollection GetApiCenterMetadataSchemas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceResource> GetApiCenterWorkspace(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceResource>> GetApiCenterWorkspaceAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceCollection GetApiCenterWorkspaces() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response HeadMetadataSchema(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> HeadMetadataSchemaAsync(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response HeadWorkspace(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> HeadWorkspaceAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiCenterServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiCenterServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> Update(Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>> UpdateAsync(Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiCenterWorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceResource>, System.Collections.IEnumerable
    {
        protected ApiCenterWorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceResource> GetIfExists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceResource>> GetIfExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiCenterWorkspaceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceData>
    {
        public ApiCenterWorkspaceData() { }
        public Azure.ResourceManager.ApiCenter.Models.ApiCenterWorkspaceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiCenterWorkspaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiCenterWorkspaceResource() { }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterApiResource> GetApiCenterApi(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterApiResource>> GetApiCenterApiAsync(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterApiCollection GetApiCenterApis() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentResource> GetApiCenterEnvironment(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentResource>> GetApiCenterEnvironmentAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentCollection GetApiCenterEnvironments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiSourceResource> GetApiSource(string apiSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiSourceResource>> GetApiSourceAsync(string apiSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiSourceCollection GetApiSources() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Head(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response HeadApi(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> HeadApiAsync(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response HeadApiSource(string apiSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> HeadApiSourceAsync(string apiSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> HeadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response HeadEnvironment(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> HeadEnvironmentAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiSourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiSourceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiSourceResource>, System.Collections.IEnumerable
    {
        protected ApiSourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiSourceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string apiSourceName, Azure.ResourceManager.ApiCenter.ApiSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiSourceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string apiSourceName, Azure.ResourceManager.ApiCenter.ApiSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string apiSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string apiSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiSourceResource> Get(string apiSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiSourceResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiSourceResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiSourceResource>> GetAsync(string apiSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiSourceResource> GetIfExists(string apiSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiSourceResource>> GetIfExistsAsync(string apiSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.ApiSourceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiSourceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.ApiSourceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiSourceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiSourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiSourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiSourceData>
    {
        public ApiSourceData() { }
        public Azure.ResourceManager.ApiCenter.Models.ApiSourceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiSourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiSourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiSourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiSourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiSourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiSourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiSourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiSourceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiSourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiSourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiSourceResource() { }
        public virtual Azure.ResourceManager.ApiCenter.ApiSourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string workspaceName, string apiSourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiSourceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiSourceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ApiCenter.ApiSourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiSourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiSourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiSourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiSourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiSourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiSourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiSourceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiSourceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerApiCenterContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerApiCenterContext() { }
        public static Azure.ResourceManager.ApiCenter.AzureResourceManagerApiCenterContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
}
namespace Azure.ResourceManager.ApiCenter.Mocking
{
    public partial class MockableApiCenterArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableApiCenterArmClient() { }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionResource GetApiCenterApiDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterApiResource GetApiCenterApiResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterApiVersionResource GetApiCenterApiVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceResource GetApiCenterDeletedServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterDeploymentResource GetApiCenterDeploymentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentResource GetApiCenterEnvironmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaResource GetApiCenterMetadataSchemaResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterServiceResource GetApiCenterServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceResource GetApiCenterWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiSourceResource GetApiSourceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableApiCenterResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableApiCenterResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceResource> GetApiCenterDeletedService(string deletedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceResource>> GetApiCenterDeletedServiceAsync(string deletedServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceCollection GetApiCenterDeletedServices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> GetApiCenterService(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>> GetApiCenterServiceAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterServiceCollection GetApiCenterServices() { throw null; }
    }
    public partial class MockableApiCenterSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableApiCenterSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceResource> GetApiCenterDeletedServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceResource> GetApiCenterDeletedServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> GetApiCenterServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> GetApiCenterServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ApiCenter.Models
{
    public partial class ApiCenterApiDefinitionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiDefinitionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiDefinitionProperties>
    {
        public ApiCenterApiDefinitionProperties(string title) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.ApiSpecificationDetails Specification { get { throw null; } }
        public string Title { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterApiDefinitionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterApiDefinitionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterApiDefinitionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiDefinitionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiDefinitionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterApiDefinitionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiDefinitionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiDefinitionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiDefinitionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiCenterApiManagementSource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiManagementSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiManagementSource>
    {
        public ApiCenterApiManagementSource(Azure.Core.ResourceIdentifier resourceId) { }
        public Azure.Core.ResourceIdentifier MsiResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterApiManagementSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterApiManagementSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterApiManagementSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiManagementSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiManagementSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterApiManagementSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiManagementSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiManagementSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiManagementSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiCenterApiProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiProperties>
    {
        public ApiCenterApiProperties(string title, Azure.ResourceManager.ApiCenter.Models.ApiKind kind) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiCenter.Models.ApiContactInformation> Contacts { get { throw null; } }
        public System.BinaryData CustomProperties { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiCenter.Models.ApiExternalDocumentation> ExternalDocumentation { get { throw null; } }
        public Azure.ResourceManager.ApiCenter.Models.ApiKind Kind { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.ApiLicenseInformation License { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.ApiLifecycleStage? LifecycleStage { get { throw null; } }
        public string Summary { get { throw null; } set { } }
        public System.Uri TermsOfServiceUri { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterApiProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterApiProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterApiProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterApiProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiCenterApiSourceLinkState : System.IEquatable<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiSourceLinkState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiCenterApiSourceLinkState(string value) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterApiSourceLinkState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterApiSourceLinkState Error { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterApiSourceLinkState Initializing { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterApiSourceLinkState Syncing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiCenter.Models.ApiCenterApiSourceLinkState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiCenter.Models.ApiCenterApiSourceLinkState left, Azure.ResourceManager.ApiCenter.Models.ApiCenterApiSourceLinkState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.ApiCenterApiSourceLinkState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.ApiCenterApiSourceLinkState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiCenter.Models.ApiCenterApiSourceLinkState left, Azure.ResourceManager.ApiCenter.Models.ApiCenterApiSourceLinkState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiCenterApiVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiVersionProperties>
    {
        public ApiCenterApiVersionProperties(string title, Azure.ResourceManager.ApiCenter.Models.ApiLifecycleStage lifecycleStage) { }
        public Azure.ResourceManager.ApiCenter.Models.ApiLifecycleStage LifecycleStage { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterApiVersionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterApiVersionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterApiVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterApiVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterApiVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiCenterDeletedServiceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterDeletedServiceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterDeletedServiceProperties>
    {
        internal ApiCenterDeletedServiceProperties() { }
        public System.DateTimeOffset? ScheduledPurgeOn { get { throw null; } }
        public System.DateTimeOffset? SoftDeletionOn { get { throw null; } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterDeletedServiceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterDeletedServiceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterDeletedServiceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterDeletedServiceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterDeletedServiceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterDeletedServiceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterDeletedServiceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterDeletedServiceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterDeletedServiceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiCenterDeploymentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterDeploymentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterDeploymentProperties>
    {
        public ApiCenterDeploymentProperties() { }
        public System.BinaryData CustomProperties { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DefinitionId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Uri> ServerRuntimeUri { get { throw null; } }
        public Azure.ResourceManager.ApiCenter.Models.ApiCenterDeploymentState? State { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterDeploymentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterDeploymentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterDeploymentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterDeploymentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterDeploymentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterDeploymentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterDeploymentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterDeploymentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterDeploymentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiCenterDeploymentState : System.IEquatable<Azure.ResourceManager.ApiCenter.Models.ApiCenterDeploymentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiCenterDeploymentState(string value) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterDeploymentState Active { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterDeploymentState Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiCenter.Models.ApiCenterDeploymentState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiCenter.Models.ApiCenterDeploymentState left, Azure.ResourceManager.ApiCenter.Models.ApiCenterDeploymentState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.ApiCenterDeploymentState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.ApiCenterDeploymentState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiCenter.Models.ApiCenterDeploymentState left, Azure.ResourceManager.ApiCenter.Models.ApiCenterDeploymentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiCenterEnvironmentKind : System.IEquatable<Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiCenterEnvironmentKind(string value) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentKind Development { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentKind Production { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentKind Staging { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentKind Testing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentKind left, Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentKind left, Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiCenterEnvironmentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentProperties>
    {
        public ApiCenterEnvironmentProperties(string title, Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentKind kind) { }
        public System.BinaryData CustomProperties { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentKind Kind { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.EnvironmentOnboardingInformation Onboarding { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentServer Server { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiCenterEnvironmentServer : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentServer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentServer>
    {
        public ApiCenterEnvironmentServer() { }
        public Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType? EnvironmentServerType { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Uri> ManagementPortalUri { get { throw null; } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentServer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentServer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentServer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentServer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentServer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentServer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentServer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentServer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentServer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiCenterImportSpecificationModel : System.IEquatable<Azure.ResourceManager.ApiCenter.Models.ApiCenterImportSpecificationModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiCenterImportSpecificationModel(string value) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterImportSpecificationModel Always { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterImportSpecificationModel Never { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterImportSpecificationModel OnDemand { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiCenter.Models.ApiCenterImportSpecificationModel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiCenter.Models.ApiCenterImportSpecificationModel left, Azure.ResourceManager.ApiCenter.Models.ApiCenterImportSpecificationModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.ApiCenterImportSpecificationModel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.ApiCenterImportSpecificationModel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiCenter.Models.ApiCenterImportSpecificationModel left, Azure.ResourceManager.ApiCenter.Models.ApiCenterImportSpecificationModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiCenterLinkState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterLinkState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterLinkState>
    {
        internal ApiCenterLinkState() { }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.ApiCenter.Models.ApiCenterApiSourceLinkState? State { get { throw null; } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterLinkState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterLinkState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterLinkState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterLinkState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterLinkState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterLinkState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterLinkState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterLinkState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterLinkState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiCenterMetadataAssignment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataAssignment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataAssignment>
    {
        public ApiCenterMetadataAssignment() { }
        public bool? Deprecated { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.MetadataAssignmentEntity? Entity { get { throw null; } set { } }
        public bool? Required { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataAssignment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataAssignment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataAssignment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataAssignment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataAssignment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataAssignment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataAssignment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataAssignment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataAssignment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiCenterMetadataSchemaProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataSchemaProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataSchemaProperties>
    {
        public ApiCenterMetadataSchemaProperties(string schema) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataAssignment> AssignedTo { get { throw null; } }
        public string Schema { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataSchemaProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataSchemaProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataSchemaProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataSchemaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataSchemaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataSchemaProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataSchemaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataSchemaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataSchemaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiCenterProvisioningState : System.IEquatable<Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiCenterProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState left, Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState left, Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiCenterServicePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch>
    {
        public ApiCenterServicePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsRestore { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiCenterServiceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServiceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServiceProperties>
    {
        public ApiCenterServiceProperties() { }
        public bool? IsRestore { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterServiceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterServiceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterServiceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServiceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServiceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterServiceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServiceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServiceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServiceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiCenterWorkspaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterWorkspaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterWorkspaceProperties>
    {
        public ApiCenterWorkspaceProperties(string title) { }
        public string Description { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterWorkspaceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiCenterWorkspaceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterWorkspaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterWorkspaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterWorkspaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterWorkspaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterWorkspaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterWorkspaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterWorkspaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiContactInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiContactInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiContactInformation>
    {
        public ApiContactInformation() { }
        public string Email { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiContactInformation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiContactInformation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.ApiContactInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiContactInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiContactInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiContactInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiContactInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiContactInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiContactInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiExternalDocumentation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiExternalDocumentation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiExternalDocumentation>
    {
        public ApiExternalDocumentation(System.Uri uri) { }
        public string Description { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiExternalDocumentation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiExternalDocumentation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.ApiExternalDocumentation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiExternalDocumentation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiExternalDocumentation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiExternalDocumentation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiExternalDocumentation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiExternalDocumentation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiExternalDocumentation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiKind : System.IEquatable<Azure.ResourceManager.ApiCenter.Models.ApiKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiKind(string value) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiKind Graphql { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiKind Grpc { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiKind Rest { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiKind Soap { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiKind Webhook { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiKind Websocket { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiCenter.Models.ApiKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiCenter.Models.ApiKind left, Azure.ResourceManager.ApiCenter.Models.ApiKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.ApiKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.ApiKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiCenter.Models.ApiKind left, Azure.ResourceManager.ApiCenter.Models.ApiKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiLicenseInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiLicenseInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiLicenseInformation>
    {
        public ApiLicenseInformation() { }
        public System.Uri Identifier { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiLicenseInformation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiLicenseInformation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.ApiLicenseInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiLicenseInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiLicenseInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiLicenseInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiLicenseInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiLicenseInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiLicenseInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiLifecycleStage : System.IEquatable<Azure.ResourceManager.ApiCenter.Models.ApiLifecycleStage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiLifecycleStage(string value) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiLifecycleStage Deprecated { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiLifecycleStage Design { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiLifecycleStage Development { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiLifecycleStage Preview { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiLifecycleStage Production { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiLifecycleStage Retired { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiLifecycleStage Testing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiCenter.Models.ApiLifecycleStage other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiCenter.Models.ApiLifecycleStage left, Azure.ResourceManager.ApiCenter.Models.ApiLifecycleStage right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.ApiLifecycleStage (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.ApiLifecycleStage? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiCenter.Models.ApiLifecycleStage left, Azure.ResourceManager.ApiCenter.Models.ApiLifecycleStage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiSourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiSourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSourceProperties>
    {
        public ApiSourceProperties() { }
        public Azure.ResourceManager.ApiCenter.Models.ApiCenterApiManagementSource AzureApiManagementSource { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.ApiCenterImportSpecificationModel? ImportSpecification { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.ApiCenterLinkState LinkState { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetEnvironmentId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.ApiLifecycleStage? TargetLifecycleStage { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiSourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiSourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.ApiSourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiSourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiSourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiSourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiSpecExportResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResult>
    {
        internal ApiSpecExportResult() { }
        public Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResultFormat? Format { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiSpecExportResultFormat : System.IEquatable<Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResultFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiSpecExportResultFormat(string value) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResultFormat Inline { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResultFormat Link { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResultFormat other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResultFormat left, Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResultFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResultFormat (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResultFormat? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResultFormat left, Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResultFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiSpecificationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecificationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecificationDetails>
    {
        internal ApiSpecificationDetails() { }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiSpecificationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiSpecificationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.ApiSpecificationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecificationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecificationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiSpecificationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecificationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecificationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecificationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiSpecImportContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecImportContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecImportContent>
    {
        public ApiSpecImportContent() { }
        public Azure.ResourceManager.ApiCenter.Models.ApiSpecImportSourceFormat? Format { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.ApiSpecImportRequestSpecification Specification { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiSpecImportContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiSpecImportContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.ApiSpecImportContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecImportContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecImportContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiSpecImportContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecImportContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecImportContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecImportContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiSpecImportRequestSpecification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecImportRequestSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecImportRequestSpecification>
    {
        public ApiSpecImportRequestSpecification() { }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiSpecImportRequestSpecification JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.ApiSpecImportRequestSpecification PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.ApiSpecImportRequestSpecification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecImportRequestSpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecImportRequestSpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiSpecImportRequestSpecification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecImportRequestSpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecImportRequestSpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecImportRequestSpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiSpecImportSourceFormat : System.IEquatable<Azure.ResourceManager.ApiCenter.Models.ApiSpecImportSourceFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiSpecImportSourceFormat(string value) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiSpecImportSourceFormat Inline { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.ApiSpecImportSourceFormat Link { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiCenter.Models.ApiSpecImportSourceFormat other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiCenter.Models.ApiSpecImportSourceFormat left, Azure.ResourceManager.ApiCenter.Models.ApiSpecImportSourceFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.ApiSpecImportSourceFormat (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.ApiSpecImportSourceFormat? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiCenter.Models.ApiSpecImportSourceFormat left, Azure.ResourceManager.ApiCenter.Models.ApiSpecImportSourceFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmApiCenterModelFactory
    {
        public static Azure.ResourceManager.ApiCenter.ApiCenterApiData ApiCenterApiData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ApiCenter.Models.ApiCenterApiProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiCenterApiDefinitionData ApiCenterApiDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ApiCenter.Models.ApiCenterApiDefinitionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterApiDefinitionProperties ApiCenterApiDefinitionProperties(string title = null, string description = null, Azure.ResourceManager.ApiCenter.Models.ApiSpecificationDetails specification = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterApiProperties ApiCenterApiProperties(string title = null, Azure.ResourceManager.ApiCenter.Models.ApiKind kind = default(Azure.ResourceManager.ApiCenter.Models.ApiKind), string description = null, string summary = null, Azure.ResourceManager.ApiCenter.Models.ApiLifecycleStage? lifecycleStage = default(Azure.ResourceManager.ApiCenter.Models.ApiLifecycleStage?), System.Uri termsOfServiceUri = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.Models.ApiExternalDocumentation> externalDocumentation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.Models.ApiContactInformation> contacts = null, Azure.ResourceManager.ApiCenter.Models.ApiLicenseInformation license = null, System.BinaryData customProperties = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiCenterApiVersionData ApiCenterApiVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ApiCenter.Models.ApiCenterApiVersionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiCenterDeletedServiceData ApiCenterDeletedServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ApiCenter.Models.ApiCenterDeletedServiceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterDeletedServiceProperties ApiCenterDeletedServiceProperties(System.DateTimeOffset? scheduledPurgeOn = default(System.DateTimeOffset?), System.DateTimeOffset? softDeletionOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiCenterDeploymentData ApiCenterDeploymentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ApiCenter.Models.ApiCenterDeploymentProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiCenterEnvironmentData ApiCenterEnvironmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterEnvironmentServer ApiCenterEnvironmentServer(Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType? environmentServerType = default(Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType?), System.Collections.Generic.IEnumerable<System.Uri> managementPortalUri = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterLinkState ApiCenterLinkState(Azure.ResourceManager.ApiCenter.Models.ApiCenterApiSourceLinkState? state = default(Azure.ResourceManager.ApiCenter.Models.ApiCenterApiSourceLinkState?), string message = null, System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiCenterMetadataSchemaData ApiCenterMetadataSchemaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataSchemaProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataSchemaProperties ApiCenterMetadataSchemaProperties(string schema = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.Models.ApiCenterMetadataAssignment> assignedTo = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiCenterServiceData ApiCenterServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ApiCenter.Models.ApiCenterServiceProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiCenterServiceData ApiCenterServiceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState? apiCenterServiceProvisioningState, Azure.ResourceManager.Models.ManagedServiceIdentity identity) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch ApiCenterServicePatch(Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IDictionary<string, string> tags = null, bool? isRestore = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiCenterServiceProperties ApiCenterServiceProperties(Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState? provisioningState = default(Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState?), bool? isRestore = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiCenterWorkspaceData ApiCenterWorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ApiCenter.Models.ApiCenterWorkspaceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiSourceData ApiSourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ApiCenter.Models.ApiSourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiSourceProperties ApiSourceProperties(Azure.ResourceManager.ApiCenter.Models.ApiCenterImportSpecificationModel? importSpecification = default(Azure.ResourceManager.ApiCenter.Models.ApiCenterImportSpecificationModel?), Azure.ResourceManager.ApiCenter.Models.ApiCenterApiManagementSource azureApiManagementSource = null, Azure.Core.ResourceIdentifier targetEnvironmentId = null, Azure.ResourceManager.ApiCenter.Models.ApiLifecycleStage? targetLifecycleStage = default(Azure.ResourceManager.ApiCenter.Models.ApiLifecycleStage?), Azure.ResourceManager.ApiCenter.Models.ApiCenterLinkState linkState = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResult ApiSpecExportResult(Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResultFormat? format = default(Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResultFormat?), string value = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiSpecificationDetails ApiSpecificationDetails(string name = null, string version = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentOnboardingInformation EnvironmentOnboardingInformation(string instructions = null, System.Collections.Generic.IEnumerable<System.Uri> developerPortalUri = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult MetadataSchemaExportResult(Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportFormat? format = default(Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportFormat?), string value = null) { throw null; }
    }
    public partial class EnvironmentOnboardingInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentOnboardingInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentOnboardingInformation>
    {
        public EnvironmentOnboardingInformation() { }
        public System.Collections.Generic.IList<System.Uri> DeveloperPortalUri { get { throw null; } }
        public string Instructions { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.EnvironmentOnboardingInformation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.EnvironmentOnboardingInformation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.EnvironmentOnboardingInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentOnboardingInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentOnboardingInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.EnvironmentOnboardingInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentOnboardingInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentOnboardingInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentOnboardingInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnvironmentServerType : System.IEquatable<Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnvironmentServerType(string value) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType ApigeeApiManagement { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType AwsApiGateway { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType AzureApiManagement { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType AzureComputeService { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType KongApiGateway { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType Kubernetes { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType MuleSoftApiManagement { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType left, Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType left, Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetadataAssignmentEntity : System.IEquatable<Azure.ResourceManager.ApiCenter.Models.MetadataAssignmentEntity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetadataAssignmentEntity(string value) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.MetadataAssignmentEntity Api { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.MetadataAssignmentEntity Deployment { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.MetadataAssignmentEntity Environment { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiCenter.Models.MetadataAssignmentEntity other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiCenter.Models.MetadataAssignmentEntity left, Azure.ResourceManager.ApiCenter.Models.MetadataAssignmentEntity right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.MetadataAssignmentEntity (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.MetadataAssignmentEntity? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiCenter.Models.MetadataAssignmentEntity left, Azure.ResourceManager.ApiCenter.Models.MetadataAssignmentEntity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetadataSchemaExportContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportContent>
    {
        public MetadataSchemaExportContent() { }
        public Azure.ResourceManager.ApiCenter.Models.MetadataAssignmentEntity? AssignedTo { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetadataSchemaExportFormat : System.IEquatable<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetadataSchemaExportFormat(string value) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportFormat Inline { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportFormat Link { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportFormat other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportFormat left, Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportFormat (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportFormat? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportFormat left, Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetadataSchemaExportResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult>
    {
        internal MetadataSchemaExportResult() { }
        public Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportFormat? Format { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
