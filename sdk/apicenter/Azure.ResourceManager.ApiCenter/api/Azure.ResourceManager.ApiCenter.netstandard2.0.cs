namespace Azure.ResourceManager.ApiCenter
{
    public static partial class ApiCenterExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> GetApiCenterService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>> GetApiCenterServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiCenterServiceResource GetApiCenterServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiCenterServiceCollection GetApiCenterServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> GetApiCenterServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> GetApiCenterServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiDefinitionResource GetApiDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiResource GetApiResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiVersionResource GetApiVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiCenter.DeploymentResource GetDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiCenter.EnvironmentResource GetEnvironmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiCenter.MetadataSchemaResource GetMetadataSchemaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiCenter.WorkspaceResource GetWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState? ServiceProvisioningState { get { throw null; } }
        Azure.ResourceManager.ApiCenter.ApiCenterServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiCenterServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiCenterServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiCenterServiceResource : Azure.ResourceManager.ArmResource
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
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.MetadataSchemaResource> GetMetadataSchema(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.MetadataSchemaResource>> GetMetadataSchemaAsync(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.MetadataSchemaCollection GetMetadataSchemas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.WorkspaceResource> GetWorkspace(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.WorkspaceResource>> GetWorkspaceAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.WorkspaceCollection GetWorkspaces() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> Update(Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>> UpdateAsync(Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiResource>, System.Collections.IEnumerable
    {
        protected ApiCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string apiName, Azure.ResourceManager.ApiCenter.ApiData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string apiName, Azure.ResourceManager.ApiCenter.ApiData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiResource> Get(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiResource>> GetAsync(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiResource> GetIfExists(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiResource>> GetIfExistsAsync(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.ApiResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.ApiResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiData>
    {
        public ApiData() { }
        public Azure.ResourceManager.ApiCenter.Models.ApiProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.ApiCenter.ApiData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiDefinitionResource>, System.Collections.IEnumerable
    {
        protected ApiDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string definitionName, Azure.ResourceManager.ApiCenter.ApiDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string definitionName, Azure.ResourceManager.ApiCenter.ApiDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiDefinitionResource> Get(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiDefinitionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiDefinitionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiDefinitionResource>> GetAsync(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiDefinitionResource> GetIfExists(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiDefinitionResource>> GetIfExistsAsync(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.ApiDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.ApiDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiDefinitionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiDefinitionData>
    {
        public ApiDefinitionData() { }
        public Azure.ResourceManager.ApiCenter.Models.ApiDefinitionProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.ApiCenter.ApiDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiDefinitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiDefinitionResource() { }
        public virtual Azure.ResourceManager.ApiCenter.ApiDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string workspaceName, string apiName, string versionName, string definitionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResult> ExportSpecification(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResult>> ExportSpecificationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Head(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> HeadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ImportSpecification(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.Models.ApiSpecImportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ImportSpecificationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.Models.ApiSpecImportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiResource() { }
        public virtual Azure.ResourceManager.ApiCenter.ApiData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string workspaceName, string apiName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiVersionResource> GetApiVersion(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiVersionResource>> GetApiVersionAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiVersionCollection GetApiVersions() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.DeploymentResource> GetDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.DeploymentResource>> GetDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.DeploymentCollection GetDeployments() { throw null; }
        public virtual Azure.Response<bool> Head(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> HeadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiVersionResource>, System.Collections.IEnumerable
    {
        protected ApiVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string versionName, Azure.ResourceManager.ApiCenter.ApiVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string versionName, Azure.ResourceManager.ApiCenter.ApiVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiVersionResource> Get(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiVersionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiVersionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiVersionResource>> GetAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiVersionResource> GetIfExists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.ApiVersionResource>> GetIfExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.ApiVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.ApiVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.ApiVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.ApiVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiVersionData>
    {
        public ApiVersionData() { }
        public Azure.ResourceManager.ApiCenter.Models.ApiVersionProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.ApiCenter.ApiVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.ApiVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.ApiVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.ApiVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiVersionResource() { }
        public virtual Azure.ResourceManager.ApiCenter.ApiVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string workspaceName, string apiName, string versionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiDefinitionResource> GetApiDefinition(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiDefinitionResource>> GetApiDefinitionAsync(string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiDefinitionCollection GetApiDefinitions() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Head(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> HeadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.ApiVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.ApiVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.DeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.DeploymentResource>, System.Collections.IEnumerable
    {
        protected DeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.DeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.ApiCenter.DeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.DeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.ApiCenter.DeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.DeploymentResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.DeploymentResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.DeploymentResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.DeploymentResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.DeploymentResource> GetIfExists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.DeploymentResource>> GetIfExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.DeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.DeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.DeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.DeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeploymentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.DeploymentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.DeploymentData>
    {
        public DeploymentData() { }
        public Azure.ResourceManager.ApiCenter.Models.DeploymentProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.ApiCenter.DeploymentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.DeploymentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.DeploymentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.DeploymentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.DeploymentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.DeploymentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.DeploymentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeploymentResource() { }
        public virtual Azure.ResourceManager.ApiCenter.DeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string workspaceName, string apiName, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.DeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.DeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Head(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> HeadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.DeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.DeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.DeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.DeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnvironmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.EnvironmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.EnvironmentResource>, System.Collections.IEnumerable
    {
        protected EnvironmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.EnvironmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string environmentName, Azure.ResourceManager.ApiCenter.EnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.EnvironmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string environmentName, Azure.ResourceManager.ApiCenter.EnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.EnvironmentResource> Get(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.EnvironmentResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.EnvironmentResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.EnvironmentResource>> GetAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.EnvironmentResource> GetIfExists(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.EnvironmentResource>> GetIfExistsAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.EnvironmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.EnvironmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.EnvironmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.EnvironmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EnvironmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.EnvironmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.EnvironmentData>
    {
        public EnvironmentData() { }
        public Azure.ResourceManager.ApiCenter.Models.EnvironmentProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.ApiCenter.EnvironmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.EnvironmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.EnvironmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.EnvironmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.EnvironmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.EnvironmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.EnvironmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnvironmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EnvironmentResource() { }
        public virtual Azure.ResourceManager.ApiCenter.EnvironmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string workspaceName, string environmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.EnvironmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.EnvironmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Head(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> HeadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.EnvironmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.EnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.EnvironmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.EnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MetadataSchemaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.MetadataSchemaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.MetadataSchemaResource>, System.Collections.IEnumerable
    {
        protected MetadataSchemaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.MetadataSchemaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string metadataSchemaName, Azure.ResourceManager.ApiCenter.MetadataSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.MetadataSchemaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string metadataSchemaName, Azure.ResourceManager.ApiCenter.MetadataSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.MetadataSchemaResource> Get(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.MetadataSchemaResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.MetadataSchemaResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.MetadataSchemaResource>> GetAsync(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.MetadataSchemaResource> GetIfExists(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.MetadataSchemaResource>> GetIfExistsAsync(string metadataSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.MetadataSchemaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.MetadataSchemaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.MetadataSchemaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.MetadataSchemaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MetadataSchemaData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.MetadataSchemaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.MetadataSchemaData>
    {
        public MetadataSchemaData() { }
        public Azure.ResourceManager.ApiCenter.Models.MetadataSchemaProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.ApiCenter.MetadataSchemaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.MetadataSchemaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.MetadataSchemaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.MetadataSchemaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.MetadataSchemaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.MetadataSchemaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.MetadataSchemaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MetadataSchemaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MetadataSchemaResource() { }
        public virtual Azure.ResourceManager.ApiCenter.MetadataSchemaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string metadataSchemaName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.MetadataSchemaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.MetadataSchemaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Head(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> HeadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.MetadataSchemaResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.MetadataSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.MetadataSchemaResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.MetadataSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.WorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.WorkspaceResource>, System.Collections.IEnumerable
    {
        protected WorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.WorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.ApiCenter.WorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.WorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.ApiCenter.WorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.WorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.WorkspaceResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.WorkspaceResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.WorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApiCenter.WorkspaceResource> GetIfExists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApiCenter.WorkspaceResource>> GetIfExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiCenter.WorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiCenter.WorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiCenter.WorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.WorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkspaceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.WorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.WorkspaceData>
    {
        public WorkspaceData() { }
        public Azure.ResourceManager.ApiCenter.Models.WorkspaceProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.ApiCenter.WorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.WorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.WorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.WorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.WorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.WorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.WorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkspaceResource() { }
        public virtual Azure.ResourceManager.ApiCenter.WorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.WorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiResource> GetApi(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiResource>> GetApiAsync(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiCollection GetApis() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.WorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.EnvironmentResource> GetEnvironment(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.EnvironmentResource>> GetEnvironmentAsync(string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.EnvironmentCollection GetEnvironments() { throw null; }
        public virtual Azure.Response<bool> Head(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> HeadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.WorkspaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.WorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiCenter.WorkspaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiCenter.WorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ApiCenter.Mocking
{
    public partial class MockableApiCenterArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableApiCenterArmClient() { }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterServiceResource GetApiCenterServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiDefinitionResource GetApiDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiResource GetApiResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiVersionResource GetApiVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.DeploymentResource GetDeploymentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.EnvironmentResource GetEnvironmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.MetadataSchemaResource GetMetadataSchemaResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.WorkspaceResource GetWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableApiCenterResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableApiCenterResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> GetApiCenterService(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource>> GetApiCenterServiceAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiCenter.ApiCenterServiceCollection GetApiCenterServices() { throw null; }
    }
    public partial class MockableApiCenterSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableApiCenterSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> GetApiCenterServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiCenter.ApiCenterServiceResource> GetApiCenterServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ApiCenter.Models
{
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState left, Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState left, Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiCenterServicePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch>
    {
        public ApiCenterServicePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiCenterServicePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiDefinitionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiDefinitionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiDefinitionProperties>
    {
        public ApiDefinitionProperties(string title) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.ApiDefinitionPropertiesSpecification Specification { get { throw null; } }
        public string Title { get { throw null; } set { } }
        Azure.ResourceManager.ApiCenter.Models.ApiDefinitionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiDefinitionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiDefinitionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiDefinitionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiDefinitionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiDefinitionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiDefinitionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiDefinitionPropertiesSpecification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiDefinitionPropertiesSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiDefinitionPropertiesSpecification>
    {
        internal ApiDefinitionPropertiesSpecification() { }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.ResourceManager.ApiCenter.Models.ApiDefinitionPropertiesSpecification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiDefinitionPropertiesSpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiDefinitionPropertiesSpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiDefinitionPropertiesSpecification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiDefinitionPropertiesSpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiDefinitionPropertiesSpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiDefinitionPropertiesSpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiCenter.Models.ApiKind left, Azure.ResourceManager.ApiCenter.Models.ApiKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.ApiKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiCenter.Models.ApiKind left, Azure.ResourceManager.ApiCenter.Models.ApiKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiProperties>
    {
        public ApiProperties(string title, Azure.ResourceManager.ApiCenter.Models.ApiKind kind) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiCenter.Models.Contact> Contacts { get { throw null; } }
        public System.BinaryData CustomProperties { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiCenter.Models.ExternalDocumentation> ExternalDocumentation { get { throw null; } }
        public Azure.ResourceManager.ApiCenter.Models.ApiKind Kind { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.License License { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.LifecycleStage? LifecycleStage { get { throw null; } }
        public string Summary { get { throw null; } set { } }
        public System.Uri TermsOfServiceUri { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        Azure.ResourceManager.ApiCenter.Models.ApiProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiSpecExportResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResult>
    {
        internal ApiSpecExportResult() { }
        public Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResultFormat? Format { get { throw null; } }
        public string Value { get { throw null; } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResultFormat left, Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResultFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResultFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResultFormat left, Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResultFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiSpecImportContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecImportContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiSpecImportContent>
    {
        public ApiSpecImportContent() { }
        public Azure.ResourceManager.ApiCenter.Models.ApiSpecImportSourceFormat? Format { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.ApiSpecImportRequestSpecification Specification { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiCenter.Models.ApiSpecImportSourceFormat left, Azure.ResourceManager.ApiCenter.Models.ApiSpecImportSourceFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.ApiSpecImportSourceFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiCenter.Models.ApiSpecImportSourceFormat left, Azure.ResourceManager.ApiCenter.Models.ApiSpecImportSourceFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiVersionProperties>
    {
        public ApiVersionProperties(string title, Azure.ResourceManager.ApiCenter.Models.LifecycleStage lifecycleStage) { }
        public Azure.ResourceManager.ApiCenter.Models.LifecycleStage LifecycleStage { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        Azure.ResourceManager.ApiCenter.Models.ApiVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ApiVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ApiVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ApiVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmApiCenterModelFactory
    {
        public static Azure.ResourceManager.ApiCenter.ApiCenterServiceData ApiCenterServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState? serviceProvisioningState = default(Azure.ResourceManager.ApiCenter.Models.ApiCenterProvisioningState?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiData ApiData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ApiCenter.Models.ApiProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiDefinitionData ApiDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ApiCenter.Models.ApiDefinitionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiDefinitionProperties ApiDefinitionProperties(string title = null, string description = null, Azure.ResourceManager.ApiCenter.Models.ApiDefinitionPropertiesSpecification specification = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiDefinitionPropertiesSpecification ApiDefinitionPropertiesSpecification(string name = null, string version = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiProperties ApiProperties(string title = null, Azure.ResourceManager.ApiCenter.Models.ApiKind kind = default(Azure.ResourceManager.ApiCenter.Models.ApiKind), string description = null, string summary = null, Azure.ResourceManager.ApiCenter.Models.LifecycleStage? lifecycleStage = default(Azure.ResourceManager.ApiCenter.Models.LifecycleStage?), System.Uri termsOfServiceUri = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.Models.ExternalDocumentation> externalDocumentation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiCenter.Models.Contact> contacts = null, Azure.ResourceManager.ApiCenter.Models.License license = null, System.BinaryData customProperties = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResult ApiSpecExportResult(Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResultFormat? format = default(Azure.ResourceManager.ApiCenter.Models.ApiSpecExportResultFormat?), string value = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.ApiVersionData ApiVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ApiCenter.Models.ApiVersionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.DeploymentData DeploymentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ApiCenter.Models.DeploymentProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.EnvironmentData EnvironmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ApiCenter.Models.EnvironmentProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.MetadataSchemaData MetadataSchemaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ApiCenter.Models.MetadataSchemaProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult MetadataSchemaExportResult(Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportFormat? format = default(Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportFormat?), string value = null) { throw null; }
        public static Azure.ResourceManager.ApiCenter.WorkspaceData WorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ApiCenter.Models.WorkspaceProperties properties = null) { throw null; }
    }
    public partial class Contact : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.Contact>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.Contact>
    {
        public Contact() { }
        public string Email { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        Azure.ResourceManager.ApiCenter.Models.Contact System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.Contact>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.Contact>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.Contact System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.Contact>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.Contact>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.Contact>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.DeploymentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.DeploymentProperties>
    {
        public DeploymentProperties() { }
        public System.BinaryData CustomProperties { get { throw null; } set { } }
        public string DefinitionId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Uri> ServerRuntimeUri { get { throw null; } }
        public Azure.ResourceManager.ApiCenter.Models.DeploymentState? State { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        Azure.ResourceManager.ApiCenter.Models.DeploymentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.DeploymentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.DeploymentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.DeploymentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.DeploymentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.DeploymentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.DeploymentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentState : System.IEquatable<Azure.ResourceManager.ApiCenter.Models.DeploymentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentState(string value) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.DeploymentState Active { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.DeploymentState Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiCenter.Models.DeploymentState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiCenter.Models.DeploymentState left, Azure.ResourceManager.ApiCenter.Models.DeploymentState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.DeploymentState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiCenter.Models.DeploymentState left, Azure.ResourceManager.ApiCenter.Models.DeploymentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnvironmentKind : System.IEquatable<Azure.ResourceManager.ApiCenter.Models.EnvironmentKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnvironmentKind(string value) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentKind Development { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentKind Production { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentKind Staging { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentKind Testing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiCenter.Models.EnvironmentKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiCenter.Models.EnvironmentKind left, Azure.ResourceManager.ApiCenter.Models.EnvironmentKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.EnvironmentKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiCenter.Models.EnvironmentKind left, Azure.ResourceManager.ApiCenter.Models.EnvironmentKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnvironmentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentProperties>
    {
        public EnvironmentProperties(string title, Azure.ResourceManager.ApiCenter.Models.EnvironmentKind kind) { }
        public System.BinaryData CustomProperties { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.EnvironmentKind Kind { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.Onboarding Onboarding { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.EnvironmentServer Server { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        Azure.ResourceManager.ApiCenter.Models.EnvironmentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.EnvironmentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnvironmentServer : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentServer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentServer>
    {
        public EnvironmentServer() { }
        public System.Collections.Generic.IList<System.Uri> ManagementPortalUri { get { throw null; } }
        public Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType? ServerType { get { throw null; } set { } }
        Azure.ResourceManager.ApiCenter.Models.EnvironmentServer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentServer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentServer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.EnvironmentServer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentServer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentServer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.EnvironmentServer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnvironmentServerType : System.IEquatable<Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnvironmentServerType(string value) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType ApigeeAPIManagement { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType AWSAPIGateway { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType AzureAPIManagement { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType AzureComputeService { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType KongAPIGateway { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType Kubernetes { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType MuleSoftAPIManagement { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType left, Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType left, Azure.ResourceManager.ApiCenter.Models.EnvironmentServerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExternalDocumentation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ExternalDocumentation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ExternalDocumentation>
    {
        public ExternalDocumentation(System.Uri uri) { }
        public string Description { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        Azure.ResourceManager.ApiCenter.Models.ExternalDocumentation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ExternalDocumentation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.ExternalDocumentation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.ExternalDocumentation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ExternalDocumentation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ExternalDocumentation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.ExternalDocumentation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class License : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.License>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.License>
    {
        public License() { }
        public System.Uri Identifier { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        Azure.ResourceManager.ApiCenter.Models.License System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.License>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.License>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.License System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.License>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.License>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.License>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LifecycleStage : System.IEquatable<Azure.ResourceManager.ApiCenter.Models.LifecycleStage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LifecycleStage(string value) { throw null; }
        public static Azure.ResourceManager.ApiCenter.Models.LifecycleStage Deprecated { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.LifecycleStage Design { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.LifecycleStage Development { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.LifecycleStage Preview { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.LifecycleStage Production { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.LifecycleStage Retired { get { throw null; } }
        public static Azure.ResourceManager.ApiCenter.Models.LifecycleStage Testing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiCenter.Models.LifecycleStage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiCenter.Models.LifecycleStage left, Azure.ResourceManager.ApiCenter.Models.LifecycleStage right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.LifecycleStage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiCenter.Models.LifecycleStage left, Azure.ResourceManager.ApiCenter.Models.LifecycleStage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetadataAssignment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.MetadataAssignment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataAssignment>
    {
        public MetadataAssignment() { }
        public bool? Deprecated { get { throw null; } set { } }
        public Azure.ResourceManager.ApiCenter.Models.MetadataAssignmentEntity? Entity { get { throw null; } set { } }
        public bool? Required { get { throw null; } set { } }
        Azure.ResourceManager.ApiCenter.Models.MetadataAssignment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.MetadataAssignment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.MetadataAssignment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.MetadataAssignment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataAssignment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataAssignment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataAssignment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiCenter.Models.MetadataAssignmentEntity left, Azure.ResourceManager.ApiCenter.Models.MetadataAssignmentEntity right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.MetadataAssignmentEntity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiCenter.Models.MetadataAssignmentEntity left, Azure.ResourceManager.ApiCenter.Models.MetadataAssignmentEntity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetadataSchemaExportContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportContent>
    {
        public MetadataSchemaExportContent() { }
        public Azure.ResourceManager.ApiCenter.Models.MetadataAssignmentEntity? AssignedTo { get { throw null; } set { } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportFormat left, Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportFormat left, Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetadataSchemaExportResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult>
    {
        internal MetadataSchemaExportResult() { }
        public Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportFormat? Format { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaExportResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MetadataSchemaProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaProperties>
    {
        public MetadataSchemaProperties(string schema) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiCenter.Models.MetadataAssignment> AssignedTo { get { throw null; } }
        public string Schema { get { throw null; } set { } }
        Azure.ResourceManager.ApiCenter.Models.MetadataSchemaProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.MetadataSchemaProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.MetadataSchemaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Onboarding : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.Onboarding>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.Onboarding>
    {
        public Onboarding() { }
        public System.Collections.Generic.IList<System.Uri> DeveloperPortalUri { get { throw null; } }
        public string Instructions { get { throw null; } set { } }
        Azure.ResourceManager.ApiCenter.Models.Onboarding System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.Onboarding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.Onboarding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.Onboarding System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.Onboarding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.Onboarding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.Onboarding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.WorkspaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.WorkspaceProperties>
    {
        public WorkspaceProperties(string title) { }
        public string Description { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        Azure.ResourceManager.ApiCenter.Models.WorkspaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.WorkspaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApiCenter.Models.WorkspaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApiCenter.Models.WorkspaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.WorkspaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.WorkspaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApiCenter.Models.WorkspaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
